# Kiến trúc và khung mã nguồn

Tài liệu mô tả cách tổ chức solution, luồng khởi động, luồng xử lý một nghiệp vụ, các mẫu code chuẩn và quy ước cần tuân thủ khi mở rộng hệ thống **Quản lý xử phạt vi phạm nồng độ cồn**.

- [1. Kiến trúc phân tầng](#1-kiến-trúc-phân-tầng)
- [2. Cấu trúc thư mục](#2-cấu-trúc-thư-mục)
- [3. Luồng khởi động và phiên đăng nhập](#3-luồng-khởi-động-và-phiên-đăng-nhập)
- [4. Luồng xử lý một nghiệp vụ](#4-luồng-xử-lý-một-nghiệp-vụ)
- [5. Trách nhiệm từng tầng](#5-trách-nhiệm-từng-tầng)
- [6. Mẫu mã nguồn chuẩn](#6-mẫu-mã-nguồn-chuẩn)
- [7. Phân quyền](#7-phân-quyền)
- [8. Xử lý lỗi và ghi nhật ký](#8-xử-lý-lỗi-và-ghi-nhật-ký)
- [9. Cấu hình](#9-cấu-hình)
- [10. Quy ước giao diện và DPI](#10-quy-ước-giao-diện-và-dpi)
- [11. Thêm một chức năng mới](#11-thêm-một-chức-năng-mới)
- [12. Kiểm tra trước khi bàn giao](#12-kiểm-tra-trước-khi-bàn-giao)

---

## 1. Kiến trúc phân tầng

```
┌──────────────────────────────────────────────┐
│ WinForms (Presentation)                      │
│ Forms • Controls • Helpers • Program         │
└──────────────────────┬───────────────────────┘
                       │ gọi service, không viết SQL
┌──────────────────────▼───────────────────────┐
│ BLL (Business Logic)                          │
│ Services • Validators • Security • Interfaces │
└──────────────────────┬───────────────────────┘
                       │ gọi repository qua interface
┌──────────────────────▼───────────────────────┐
│ DAL (Data Access)                             │
│ Database • Repositories • Interfaces • Mapping│
└──────────────────────┬───────────────────────┘
                       │ ADO.NET, tham số hóa
┌──────────────────────▼───────────────────────┐
│ SQL Server — QuanLyXuPhatNongDoCon            │
│ Tables • Views • Functions • Triggers • SP    │
└──────────────────────────────────────────────┘

Domain (Entities • DTOs • Enums • Exceptions)
được tham chiếu bởi cả ba tầng.
```

Quy tắc phụ thuộc:

- `Domain` không tham chiếu project nào.
- `DAL` chỉ tham chiếu `Domain`.
- `BLL` tham chiếu `DAL` và `Domain`.
- `WinForms` tham chiếu `BLL` và `Domain`, **không** tham chiếu trực tiếp `DAL`.
- Không có chiều phụ thuộc ngược (DAL/BLL không biết gì về WinForms).

---

## 2. Cấu trúc thư mục

```text
D:\PTTKYC\Project
├─ AlcoholViolationManagement.slnx
├─ database\                       # 9 script SQL, chạy theo thứ tự trong DatabaseGuide
├─ docs\
│  ├─ README.md                    # tổng quan, cài đặt, tài khoản demo
│  ├─ DatabaseGuide.md             # thiết kế CSDL, trigger, sao lưu
│  └─ Skeleton.md                  # tài liệu này
└─ src\
   ├─ AlcoholViolationManagement.Domain\
   │  ├─ Entities\                 # 11 entity ánh xạ 1-1 bảng
   │  ├─ DTOs\                     # CurrentUser, PagedResult, các DTO danh sách/chi tiết/thống kê
   │  ├─ Enums\                    # VaiTroId, TrangThaiThanhToanCode, PhuongThucThanhToan, NhomThongKe
   │  └─ Exceptions\               # BusinessException
   ├─ AlcoholViolationManagement.DAL\
   │  ├─ Db\                       # Database, SqlParameterExtensions, ReaderExtensions, SqlLike
   │  ├─ Interfaces\               # 8 interface repository
   │  ├─ Mapping\                  # EntityMappers
   │  └─ Repositories\             # 8 repository ADO.NET
   ├─ AlcoholViolationManagement.BLL\
   │  ├─ Interfaces\               # IPasswordHasher
   │  ├─ Security\                 # Permissions, UserContext, Pbkdf2PasswordHasher, SqlErrorTranslator
   │  ├─ Services\                 # 10 service + ServiceBase + ServiceContainer
   │  └─ Validators\               # 7 validator + CommonRules
   └─ AlcoholViolationManagement.WinForms\
      ├─ Controls\                 # NavButton, StatCard, PaginationControl, StatusOverlay, Charts...
      ├─ Forms\                    # 28 màn hình/hộp thoại, mỗi form có .Designer.cs
      ├─ Helpers\                  # AppSettings, AppSession, AppLifecycleContext, UiHelper, Theme, Formatting, PrintService, AppLogger
      ├─ appsettings.json
      └─ Program.cs
```

Số lượng form và file `.Designer.cs` tương ứng 1-1, cho phép mở kéo thả trong Visual Studio Designer.

---

## 3. Luồng khởi động và phiên đăng nhập

### 3.1 Khởi động

`Program.Main` ([`Program.cs`](../src/AlcoholViolationManagement.WinForms/Program.cs)):

1. `ApplicationConfiguration.Initialize()` — thiết lập WinForms, font mặc định Segoe UI 9.75pt, DPI.
2. Gắn `Application.ThreadException` để ghi log lỗi ngoài dự kiến.
3. `AppSettings.Load()` đọc `appsettings.json` và biến môi trường `ALCOHOL_DB_CONNECTION`.
4. `ServiceContainer.Create(connectionString)` khởi tạo `Database`, repository, service, `UserContext`.
5. `AppSession.Initialize(services)` công khai container cho các form.
6. `Application.Run(new AppLifecycleContext(services))`.

`AppLifecycleContext` quản lý vòng đời **Login → Main → Logout → Login**:

- Đăng nhập thành công: `LoginForm` phát `LoginSucceeded`, form chính được tạo, form đăng nhập bị ẩn và giải phóng.
- Đăng xuất: `MainForm` phát `LogoutRequested`, `ServiceContainer.SignOut()` xóa người dùng hiện tại, quay lại `LoginForm`.
- Đóng form chính hoặc đóng đăng nhập (khi chưa vào hệ thống) sẽ kết thúc ứng dụng.

### 3.2 Đăng nhập

`AuthService.LoginAsync`:

1. Tìm tài khoản theo tên đăng nhập qua `vw_TaiKhoanDangNhap`.
2. Nếu không tồn tại → thông báo chung “Tên đăng nhập hoặc mật khẩu không đúng”.
3. Nếu `TrangThai = 0` → “Tài khoản đã bị khóa...”.
4. Xác thực PBKDF2-SHA256 (100.000 vòng lặp, salt ngẫu nhiên, so sánh constant-time).
5. Cập nhật `LanDangNhapCuoi`.
6. Trả `CurrentUser` (mã, họ tên, vai trò, cấp bậc, đơn vị) và gán vào `UserContext`.

`LoginForm` chỉ hiển thị lỗi; không truy vấn SQL trực tiếp.

### 3.3 Điều hướng

`MainForm` khai báo danh sách màn hình (`Screens`) kèm:

- `Key`, tiêu đề, mô tả, glyph, nhóm;
- danh sách vai trò được phép.

`BuildNavigation()` chỉ tạo nút cho màn hình mà `AppSession.User.IsInRole(...)` trả `true`. `NavigateTo(key)` kiểm tra lại quyền trước khi tạo form, gắn form vào `panelContent` dưới dạng docked, và giải phóng màn hình trước đó.

Ma trận hiển thị menu:

| Màn hình | Quản trị | CSGT | Lãnh đạo | Tài chính |
|---|:---:|:---:|:---:|:---:|
| Tổng quan | ✓ | ✓ | ✓ | ✓ |
| Người vi phạm | ✓ | ✓ | ✓ | ✓ |
| Vụ việc vi phạm | ✓ | ✓ | ✓ | ✓ |
| Quyết định xử phạt | ✓ | ✓ | ✓ | ✓ |
| Thanh toán | ✓ | — | ✓ (xem) | ✓ |
| Tra cứu | ✓ | ✓ | ✓ | ✓ |
| Báo cáo thống kê | ✓ | — | ✓ | ✓ |
| Cán bộ | ✓ | — | — | — |
| Tài khoản | ✓ | — | — | — |
| Danh mục | ✓ | — | — | — |

Ẩn menu **không đủ**; mọi service nghiệp vụ còn kiểm tra quyền ở BLL (xem mục 7).

---

## 4. Luồng xử lý một nghiệp vụ

Ví dụ “Thêm người vi phạm”:

```
ViolatorEditForm
  → AppSession.Services.NguoiViPham.SaveAsync(entity)
    → UserContext.RequireUser()
    → Permissions.EnsureManageNguoiViPham(user)
    → NguoiViPhamValidator.Validate(entity)
    → INguoiViPhamRepository.ExistsCccdAsync / ExistsPhoneAsync / ExistsGplxAsync
    → INguoiViPhamRepository.InsertAsync(entity)
      → Database.QuerySingleAsync(...)  (câu lệnh tham số hóa, OUTPUT INSERTED)
    ← trả entity có MaNguoiViPham do CSDL sinh
  ← UiHelper.RunAsync hiển thị thành công hoặc lỗi BusinessException
```

Điểm quan trọng:

- **Không có SQL trong form**. Form chỉ gọi service và hiển thị kết quả.
- **Không giả lập thành công**: mã bản ghi chỉ được hiển thị sau khi CSDL trả về qua `OUTPUT INSERTED`.
- **Kiểm tra quyền ở service**, không chỉ ở nút bấm.
- **Kiểm tra nghiệp vụ ở validator** trước khi chạm CSDL; ràng buộc cuối cùng vẫn do CSDL bảo đảm.
- **Lỗi SQL được dịch** thành thông báo tiếng Việt qua `SqlErrorTranslator`.

Các thao tác nhiều bảng đi qua stored procedure có transaction:

- Tạo quyết định: `sp_TaoQuyetDinh` (trigger tính tiền + đồng bộ trạng thái).
- Đổi trạng thái: `sp_CapNhatTrangThaiQuyetDinh`.
- Ghi nhận thanh toán: `sp_GhiNhanThanhToan` (chèn biên lai + cập nhật quyết định + cập nhật vụ việc trong một transaction).

DAL gọi procedure qua `Database.ExecuteProcedureForIdAsync`, nhận mã qua tham số `OUTPUT`.

---

## 5. Trách nhiệm từng tầng

### 5.1 Domain

| Nhóm | Nội dung |
|---|---|
| `Entities` | `NguoiViPham`, `ViPham`, `QuyetDinhXuPhat`, `ThanhToan`, `CanBo`, `TaiKhoan`, `LoaiViPham`, `LoaiPhuongTien`, `MucNongDoCon`, `VaiTro`, `TrangThaiThanhToan` — thuộc tính khớp cột CSDL |
| `DTOs` | `CurrentUser`, `PagedResult<T>`, `NguoiViPhamChiTiet`, `ViPhamListItem`, `QuyetDinhListItem`, `ThanhToanListItem`, `DashboardData`, `ThongKeTongHop`, `ThongKeNhomRow`, `ThongKeResult`, `TraCuuResult` |
| `Enums` | `VaiTroId` (1–4), `TrangThaiThanhToanCode` (TT01–TT03), `PhuongThucThanhToan`, `NhomThongKe` |
| `Exceptions` | `BusinessException` — lỗi nghiệp vụ hiển thị được cho người dùng |

Không đặt logic truy cập dữ liệu trong entity.

### 5.2 DAL

- `Database`: mở kết nối, query danh sách/đơn, query phân trang (đếm + dữ liệu trên cùng kết nối), execute scalar/non-query, gọi procedure có tham số `OUTPUT`.
- `SqlParameterExtensions`: thêm tham số có kiểu rõ ràng, xử lý `NULL`, `DBNull`.
- `ReaderExtensions`: đọc cột an toàn theo tên, xử lý giá trị NULL.
- `SqlLike`: escape `%`, `_`, `[` và bọc `%...%` cho tìm kiếm.
- Repository: dựng câu SQL **cố định**, tham số hóa toàn bộ giá trị người dùng; trả entity/DTO qua `EntityMappers`.
- Không trả `DataTable`/`SqlDataReader` ra ngoài tầng DAL.

### 5.3 BLL

- Service: điều phối nghiệp vụ, kiểm tra quyền, gọi validator, gọi repository, dịch lỗi SQL.
- Validator: kiểm tra dữ liệu đầu vào theo quy tắc báo cáo (định dạng CCCD/SĐT, độ dài, miền giá trị, quan hệ logic).
- `Permissions`: nguồn duy nhất định nghĩa quyền; cả UI (ẩn nút) và BLL (chặn thao tác) dùng chung.
- `UserContext`: giữ người dùng đang đăng nhập; `RequireUser()` ném lỗi nếu phiên hết.
- `ServiceContainer`: composition root — tạo repository, service, hasher; không dùng DI container bên ngoài.
- `Pbkdf2PasswordHasher`: băm/kiểm tra mật khẩu; không lưu mật khẩu thô.

### 5.4 WinForms

- Form chỉ chứa code giao diện: bind dữ liệu, bắt sự kiện, gọi service, hiển thị trạng thái.
- Mỗi form có file `.Designer.cs` riêng; ưu tiên kéo thả trong Visual Studio.
- Control tự vẽ (`RoundedButton`, `NavButton`, `StatCard`, `StatusOverlay`, `Charts`) đóng gói phần trình bày, không chứa nghiệp vụ.
- `Helpers` cung cấp theme, định dạng tiền/ngày, in ấn, session, logger, settings.
- Không hard-code chuỗi kết nối, mật khẩu hay thông tin cá nhân.

---

## 6. Mẫu mã nguồn chuẩn

### 6.1 Repository với truy vấn tham số hóa và phân trang

```csharp
public async Task<PagedResult<NguoiViPham>> SearchAsync(string? keyword, int page, int pageSize)
{
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 200);
    var pattern = SqlLike.Contains(keyword);

    var countSql = $"SELECT COUNT(*) FROM dbo.NGUOI_VI_PHAM WHERE {SearchFilter};";
    var dataSql = $"""
        SELECT {SelectColumns}
        FROM dbo.NGUOI_VI_PHAM
        WHERE {SearchFilter}
        ORDER BY HoTen, Ma_NguoiViPham
        OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
        """;

    void AddParameters(SqlParameterCollection parameters)
    {
        parameters.AddValue("@kw", pattern);
        parameters.AddValue("@offset", (page - 1) * pageSize);
        parameters.AddValue("@pageSize", pageSize);
    }

    var (items, total) = await _database.QueryPagedAsync(
        countSql, dataSql, EntityMappers.MapNguoiViPham, AddParameters);

    return new PagedResult<NguoiViPham>
    {
        Items = items, TotalCount = total, Page = page, PageSize = pageSize
    };
}
```

Nguyên tắc:

- Chỉ nối chuỗi cho **mảnh SQL tĩnh** (tên cột, mệnh đề lọc nội bộ); mọi giá trị đi qua `SqlParameter`.
- `SearchFilter` dùng chung cho câu đếm và câu dữ liệu để số trang luôn khớp.
- `SqlLike.Contains` escape ký tự đại diện, tránh tìm sai.

### 6.2 Service kiểm tra quyền và dịch lỗi

```csharp
public async Task<NguoiViPham> SaveAsync(NguoiViPham input)
{
    var user = _userContext.RequireUser();
    Permissions.EnsureManageNguoiViPham(user);

    ArgumentNullException.ThrowIfNull(input);
    NguoiViPhamValidator.Validate(input);

    var isNew = string.IsNullOrWhiteSpace(input.MaNguoiViPham);
    var excludeMa = isNew ? null : input.MaNguoiViPham;

    if (await DbAsync(
            () => _nguoiViPhamRepository.ExistsCccdAsync(input.CanCuocCongDan, excludeMa),
            "Không thể kiểm tra dữ liệu trùng."))
        throw new BusinessException("Số CCCD đã tồn tại trong hệ thống.");

    // ... kiểm tra SĐT, GPLX

    if (isNew)
    {
        input.MaNguoiViPham = await DbAsync(
            () => _nguoiViPhamRepository.InsertAsync(input),
            "Không thể thêm người vi phạm. Vui lòng kiểm tra dữ liệu.");
        return input;
    }

    // ... kiểm tra tồn tại rồi cập nhật
}
```

- `RequireUser()` trước, `Permissions` sau, `Validate` sau cùng mới tới CSDL.
- `DbAsync` bắt `SqlException` và chuyển thành `BusinessException` có thông báo thân thiện.
- Trả entity đã có mã do CSDL sinh, không tự sinh mã trong C#.

### 6.3 Gọi procedure trả mã `OUTPUT`

```csharp
public Task<string?> CreateAsync(string maVuViec, DateTime ngayRa, string maTrangThai) =>
    _database.ExecuteProcedureForIdAsync(
        "dbo.sp_TaoQuyetDinh",
        "@MaQuyetDinh",
        parameters =>
        {
            parameters.AddValue("@MaVuViec", maVuViec);
            parameters.AddValue("@NgayRaQuyetDinh", ngayRa);
            parameters.AddValue("@MaTrangThai", maTrangThai);
        });
```

### 6.4 Giao diện gọi service bất đồng bộ

```csharp
private async void btnLuu_Click(object? sender, EventArgs e)
{
    if (!ValidateInputs()) return;

    var ok = await UiHelper.RunAsync(
        this,
        async () =>
        {
            var saved = await AppSession.Services.NguoiViPham.SaveAsync(BuildEntity());
            _savedId = saved.MaNguoiViPham;
        },
        overlay,
        "Đã lưu thông tin người vi phạm.");

    if (ok)
    {
        DialogResult = DialogResult.OK;
        Close();
    }
}
```

- `async void` chỉ dùng cho event handler.
- `UiHelper.RunAsync` bật overlay, bắt `BusinessException` (cảnh báo), lỗi khác (ghi log + thông báo), và luôn tắt overlay trong `finally`.
- Hiển thị thành công **sau khi** service trả về, không hiển thị trước.

### 6.5 Nạp dữ liệu màn hình

```csharp
private async Task LoadDataAsync()
{
    var keyword = txtKeyword.Text.Trim();
    var result = await UiHelper.TryLoadAsync(
        this,
        () => AppSession.Services.NguoiViPham.SearchAsync(keyword, _page, PageSize),
        overlay);

    if (result is null) return;

    _total = result.TotalCount;
    grid.DataSource = result.Items.ToList();
    pagination.SetPage(_page, _total, PageSize);
    lblEmpty.Visible = _total == 0;
}
```

Ba trạng thái luôn được xử lý: có dữ liệu, rỗng (empty state), lỗi (thông báo + log).

### 6.6 Validator

```csharp
public static void Validate(NguoiViPham input)
{
    CommonRules.RequireText(input.HoTen, "Họ tên", 100);
    CommonRules.RequirePhone(input.SoDienThoai);
    CommonRules.RequireCitizenId(input.CanCuocCongDan);
    CommonRules.RequireText(input.DiaChi, "Địa chỉ", 255);
    if (input.GioiTinh is not ("Nam" or "Nữ"))
        throw new BusinessException("Giới tính chỉ nhận giá trị Nam hoặc Nữ.");
}
```

Validator ném `BusinessException` với thông báo tiếng Việt, không ném `ArgumentException` cho lỗi người dùng.

---

## 7. Phân quyền

`Permissions` ([`Permissions.cs`](../src/AlcoholViolationManagement.BLL/Security/Permissions.cs)) định nghĩa:

| Hàm | Vai trò được phép | Dùng cho |
|---|---|---|
| `CanManageNguoiViPham` | Quản trị, CSGT | Thêm/sửa người vi phạm |
| `CanManageViPham` | Quản trị, CSGT | Thêm/sửa vụ việc |
| `CanManageQuyetDinh` | Quản trị, CSGT, Lãnh đạo | Tạo/đổi trạng thái quyết định |
| `CanManageThanhToan` | Quản trị, Tài chính | Ghi nhận thanh toán |
| `CanViewThanhToan` | Quản trị, Tài chính, Lãnh đạo | Xem danh sách/biên lai |
| `CanViewReports` | Quản trị, Lãnh đạo, Tài chính | Xem dashboard/báo cáo |
| `CanAdminister` | Quản trị | Cán bộ, tài khoản |
| `CanEditCatalog` | Quản trị | Danh mục dùng chung |

Mỗi quyền có cặp `Can...` (trả bool cho UI) và `Ensure...` (ném `BusinessException` ở BLL). Quy ước:

- **UI**: ẩn/khóa nút bằng `AppSession.Can...` để tránh thao tác thừa.
- **BLL**: luôn gọi `Ensure...` trước khi đọc/ghi để chặn cả khi gọi service từ nơi khác.
- Menu được lọc theo vai trò; nhưng quyền thực thi không phụ thuộc menu.
- Ví dụ: CSGT không thấy menu Thanh toán/Báo cáo; nếu gọi thẳng `ThongKeService.GetThongKeAsync`, service ném “Bạn không có quyền thực hiện chức năng này.”

Đổi quyền: sửa đúng một nơi trong `Permissions.cs`; không rải điều kiện vai trò khắp form.

---

## 8. Xử lý lỗi và ghi nhật ký

### 8.1 Ba mức lỗi

| Loại | Nơi phát sinh | Cách hiển thị |
|---|---|---|
| Lỗi nghiệp vụ (`BusinessException`) | Validator, service, `SqlErrorTranslator` | Hộp thoại cảnh báo với thông điệp tiếng Việt |
| Lỗi kỹ thuật (kết nối, timeout, null...) | DAL/UI | Ghi log + thông báo chung kèm đường dẫn log |
| Lỗi không bắt được trên UI thread | `Program.ThreadException` | Ghi log + thông báo lỗi ứng dụng |

### 8.2 `SqlErrorTranslator`

| Mã SQL | Thông điệp |
|---|---|
| ≥ 50000 | Giữ nguyên thông điệp từ `THROW` của procedure (đã là tiếng Việt) |
| 2601/2627 | Dữ liệu bị trùng |
| 547 | Dữ liệu đang được tham chiếu |
| -2 | Máy chủ phản hồi quá lâu |
| 4060/18456 | Không thể kết nối CSDL |

Các mã khác dùng thông điệp fallback của từng thao tác.

### 8.3 Nhật ký

`AppLogger` ghi file:

```text
%LOCALAPPDATA%\AlcoholViolationManagement\logs\app-yyyyMMdd.log
```

- Chỉ ghi lỗi và một số sự kiện quan trọng; không ghi mật khẩu, chuỗi kết nối hay dữ liệu nhạy cảm.
- Ghi log lỗi không được làm gián đoạn nghiệp vụ (`try/catch` nội bộ).
- Khi hỗ trợ người dùng, lấy file log theo ngày để tra nguyên nhân.

### 8.4 Quy ước thông báo

- Không hiển thị stack trace cho người dùng cuối.
- Thông báo nêu **việc cần làm** (“Kiểm tra kết nối CSDL và thử lại”), không chỉ nêu lỗi.
- Thao tác xóa/khóa quan trọng dùng `UiHelper.Confirm` với nút mặc định là **No**.

---

## 9. Cấu hình

`appsettings.json` nằm cạnh file chạy (được copy khi build):

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost\\SQLEXPRESS01;Database=QuanLyXuPhatNongDoCon;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;"
  },
  "Application": { "TenUngDung": "...", "PhienBan": "1.0.0", "MayChu": "localhost\\SQLEXPRESS01", "CoSoDuLieu": "..." },
  "ToChuc": { "DonViCapTren": "...", "TenDonVi": "...", "DiaChi": "...", "DienThoai": "..." }
}
```

Thứ tự ưu tiên chuỗi kết nối:

1. Biến môi trường `ALCOHOL_DB_CONNECTION` (nếu có, được trim).
2. `ConnectionStrings:Default` trong `appsettings.json`.

`AppSettings.Load()` báo lỗi rõ ràng nếu thiếu file hoặc chuỗi kết nối rỗng. Thông tin `ToChuc` là placeholder, dùng cho tiêu đề/in ấn; có thể sửa mà không cần build lại mã nghiệp vụ.

Không đặt mật khẩu SQL trong `appsettings.json`; mặc định dùng Windows Authentication.

---

## 10. Quy ước giao diện và DPI

- Kích thước thiết kế chuẩn **1440×900**, font **Segoe UI**, màu:
  - Navy `#0C2340` (sidebar, tiêu đề)
  - Accent `#2F80ED` (nút chính, liên kết)
  - Gold `#F2B344` (điểm nhấn)
  - Background `#F4F6F9` (vùng nội dung)
- Mỗi màn hình là `Form` có `.Designer.cs`; mở trong VS để kéo thả.
- Form con được dock `Fill` vào `panelContent`, không mở cửa sổ rời.
- DataGridView: tiêu đề rõ ràng, hàng xen kẽ, chọn cả dòng, không cho thêm/xóa trực tiếp, cột có `MinimumWidth` hợp lý.
- Luôn có trạng thái: đang tải (overlay), rỗng (label hướng dẫn), lỗi (hộp thoại), thành công (thông báo sau khi lưu).
- Nút chính nằm cuối form theo thứ tự **Hủy → Lưu**; nút nguy hiểm (xóa/khóa) tách khỏi nhóm chính.

### DPI

Ứng dụng chạy system-DPI-aware. Bài học thực tế:

- **Không đặt `Location`/`Size` trong code sau `InitializeComponent()`** cho control đã có trong Designer. Giá trị code không được AutoScale theo DPI, trong khi giá trị Designer thì có → chồng lấn ở 125%/150%.
- Mọi vị trí/kích thước tĩnh đặt trong `.Designer.cs`; runtime chỉ thay đổi nội dung (`Text`), trạng thái (`Visible`, `Enabled`) hoặc neo (`Anchor`, `Dock`).
- Nếu buộc phải đặt động, dùng `SuspendLayout`/`ResumeLayout` và tính theo `DeviceDpi` hoặc `AutoScaleDimensions`.
- Kiểm thử ở 100% và 125% trước khi bàn giao; đặc biệt các nút footer và nhãn gợi ý dài.

---

## 11. Thêm một chức năng mới

Ví dụ thêm “Biên bản vi phạm giao thông khác” (chỉ mô tả quy trình, không có trong bản này):

1. **CSDL**: thêm bảng/script mới trong `database/` theo đúng thứ tự; không đổi tên bảng cũ. Cập nhật `DatabaseGuide.md`.
2. **Domain**: tạo entity + DTO cần thiết; thêm enum nếu có trạng thái mới.
3. **DAL**: định nghĩa interface repository; implement bằng `Database`, tham số hóa, map qua `EntityMappers`. Đăng ký trong `ServiceContainer`.
4. **BLL**: tạo validator, service kế thừa `ServiceBase`, gọi `RequireUser` + `Permissions.Ensure...`, bọc `DbAsync`. Thêm quyền mới vào `Permissions.cs`.
5. **WinForms**:
   - Tạo `XxxListForm` + `.Designer.cs`, `XxxEditForm` + `.Designer.cs`.
   - Dùng `UiHelper.TryLoadAsync`/`RunAsync`, `PaginationControl`, `StatusOverlay`.
   - Thêm màn hình vào `Screens` trong `MainForm.cs` kèm vai trò.
6. **Kiểm thử**: build 0 warning/0 error; thử các vai trò; thử dữ liệu trùng/không hợp lệ; kiểm tra log; kiểm tra DPI 125%.
7. **Tài liệu**: cập nhật `README.md` (chức năng, quyền, ảnh hưởng cài đặt) và `Skeleton.md` nếu thay đổi kiến trúc.

Quy ước đặt tên:

- Entity/DTO: `PascalCase` tiếng Việt không dấu (`NguoiViPham`, `QuyetDinhListItem`).
- Cột/thuộc tính CSDL: `PascalCase` ánh xạ từ `snake` hoặc tên gốc qua alias.
- Service: `XxxService`; repository: `XxxRepository`; interface: `IXxxRepository`.
- Form: `XxxListForm`, `XxxEditForm`, `XxxDetailForm`; control: `XxxControl`.
- Sự kiện: `btnLuu_Click`, `txtKeyword_TextChanged`; biến private: `_camelCase`.

---

## 12. Kiểm tra trước khi bàn giao

Checklist tối thiểu:

- [ ] `dotnet build` thành công, **0 warning / 0 error**.
- [ ] Chạy đủ 9 script CSDL theo thứ tự; seed báo đúng 30/60/48/21.
- [ ] Đăng nhập được cả 5 tài khoản hoạt động; `csgt03` bị chặn với thông báo khóa.
- [ ] Menu thay đổi đúng theo vai trò; không mở được màn hình ngoài quyền bằng điều hướng.
- [ ] CRUD người vi phạm/vụ việc/cán bộ/tài khoản/danh mục lưu thật vào CSDL.
- [ ] Tạo quyết định: tiền phạt tự đúng theo danh mục; không tạo trùng vụ việc.
- [ ] Ghi nhận thanh toán: đúng số tiền, biên lai hiển thị, trạng thái đồng bộ; không thu lần hai.
- [ ] Tra cứu theo mã quyết định/họ tên/biển số trả đúng dữ liệu.
- [ ] Dashboard/báo cáo khớp truy vấn SQL; xuất CSV mở đúng tiếng Việt.
- [ ] Không có SQL trong event handler giao diện; không có mật khẩu thật trong mã/seed.
- [ ] Giao diện không chồng lấn ở 100% và 125% DPI; bảng không cắt cột quan trọng.
- [ ] Log ghi đúng thư mục `%LOCALAPPDATA%\AlcoholViolationManagement\logs`.
- [ ] Tài liệu `README.md`, `DatabaseGuide.md`, `Skeleton.md` khớp với mã hiện tại.

---

Tài liệu liên quan: [README.md](README.md) · [DatabaseGuide.md](DatabaseGuide.md)
