# Hệ thống quản lý xử phạt vi phạm nồng độ cồn

Ứng dụng desktop quản lý nghiệp vụ xử phạt vi phạm nồng độ cồn, được xây dựng bằng
**C# / .NET 10 / WinForms**, truy cập **Microsoft SQL Server** qua **ADO.NET**.
Toàn bộ số liệu trên giao diện được đọc từ CSDL; không có dữ liệu mẫu hiển thị giả
lập trong tầng giao diện.

> Tài liệu liên quan:
> - [DatabaseGuide.md](DatabaseGuide.md) — thiết kế CSDL, kịch bản cài đặt, sao lưu và kiểm tra.
> - [Skeleton.md](Skeleton.md) — kiến trúc, luồng xử lý và hướng dẫn mở rộng.
> - [DefenseQnA.md](DefenseQnA.md) — cẩm nang bảo vệ đồ án & bộ câu hỏi phản biện môn PTTKYC.
> - Kho mã nguồn: [https://github.com/minhchi1009/QuanLyXuPhatViPhamNDC](https://github.com/minhchi1009/QuanLyXuPhatViPhamNDC)

---

## 1. Thông tin chung

| Hạng mục | Giá trị |
|---|---|
| Tên ứng dụng | Hệ thống quản lý xử phạt vi phạm nồng độ cồn |
| Phiên bản | 1.0.0 |
| Nền tảng | Windows 10/11 (x64) |
| Công nghệ | .NET 10, WinForms, ADO.NET, SQL Server |
| Kiến trúc | Domain → DAL → BLL → WinForms (phân tầng) |
| CSDL | `QuanLyXuPhatNongDoCon` (SQL Server, collation `Vietnamese_CI_AS`) |
| Ngôn ngữ giao diện | Tiếng Việt |
| Độ phân giải khuyến nghị | 1440 × 900 trở lên |

Đơn vị khảo sát/cơ sở trong báo cáo chưa thống nhất, vì vậy thông tin tổ chức được
để dạng mẫu trong `appsettings.json` và có thể thay đổi sau mà không ảnh hưởng mã nguồn.

---

## 2. Công nghệ và thư viện

- **.NET 10** (`net10.0-windows` cho WinForms, `net10.0` cho các lớp nghiệp vụ).
- **Windows Forms** với các control tự vẽ (bo góc, biểu đồ, thẻ số liệu, phân trang).
- **Microsoft.Data.SqlClient 6.1.3** — truy cập SQL Server bằng ADO.NET.
- **System.Security.Cryptography.Pkcs 10.0.13** — ghim phiên bản để loại cảnh báo
  bảo mật gián tiếp của `Microsoft.Data.SqlClient`.
- Không dùng ORM, không dùng thư viện UI bên thứ ba.

Các gói được khai báo trong:
- `src/AlcoholViolationManagement.DAL/AlcoholViolationManagement.DAL.csproj`
- `src/AlcoholViolationManagement.WinForms/AlcoholViolationManagement.WinForms.csproj`

---

## 3. Chức năng theo yêu cầu 5.1 – 5.8

### 5.1 Đăng nhập và phân quyền
- Đăng nhập bằng tài khoản nội bộ; mật khẩu lưu dạng **PBKDF2-SHA256** (muối ngẫu nhiên,
  100.000 vòng lặp), không lưu mật khẩu rõ.
- Tài khoản bị khóa không thể đăng nhập; ghi nhận thời điểm đăng nhập cuối.
- Điều hướng theo vai trò; các nút thao tác trái quyền bị ẩn.
- Đổi mật khẩu, đăng xuất, đổi mật khẩu cho tài khoản khác (quản trị viên).

### 5.2 Quản lý người vi phạm
- Danh sách, tìm kiếm theo họ tên/CCCD/số điện thoại, phân trang 20 dòng/trang.
- Thêm, cập nhật hồ sơ; kiểm tra trùng CCCD, số điện thoại, số GPLX.
- Xem hồ sơ chi tiết và **toàn bộ lịch sử vụ việc** của người vi phạm.
- Không xóa cứng hồ sơ/lịch sử vi phạm.

### 5.3 Quản lý vụ việc vi phạm
- Danh sách và tìm kiếm theo mã vụ việc, người vi phạm, biển số.
- Lọc theo khoảng thời gian và trạng thái thanh toán.
- Lập vụ việc với người vi phạm, phương tiện, biển số, nồng độ cồn, địa điểm.
- **Tự xác định mức nồng độ và mức phạt** theo loại phương tiện + nồng độ;
  người dùng không tự nhập số tiền phạt.
- Vụ việc đã có quyết định chỉ được xem, không sửa.

### 5.4 Quản lý danh mục
- Loại phương tiện; mức nồng độ cồn (ngưỡng trên, mô tả); loại vi phạm và mức phạt.
- Chỉ quản trị viên được thêm/sửa danh mục.
- Ràng buộc mỗi cặp (loại phương tiện, mức nồng độ) có đúng một loại vi phạm.

### 5.5 Lập và quản lý quyết định xử phạt
- Chọn vụ việc chưa có quyết định để lập quyết định.
- Ngày ra quyết định không trước ngày vi phạm, không ở tương lai.
- Mỗi vụ việc chỉ có một quyết định (ràng buộc unique ở CSDL).
- Số tiền phạt do **trigger CSDL** lấy từ loại vi phạm; BLL không tự tính lại.
- Xem, in quyết định; cập nhật trạng thái thanh toán theo quy tắc.
- Không thể chuyển sang “Đã nộp” nếu chưa có biên lai; đã có biên lai thì không
  chuyển ngược trạng thái.

### 5.6 Ghi nhận thanh toán và biên lai
- Chọn quyết định chưa thanh toán; số tiền nộp phải **bằng đúng** số tiền phạt.
- Phương thức: Tiền mặt / Chuyển khoản; thời gian nộp không ở tương lai và không
  trước ngày ra quyết định.
- Một quyết định chỉ có một biên lai.
- Ghi nhận thanh toán, cập nhật đồng thời trạng thái quyết định và vụ việc trong
  một transaction; in biên lai.

### 5.7 Báo cáo và thống kê
- Dashboard: tổng vụ việc, tổng quyết định, tổng tiền phạt, tiền đã thu; biểu đồ
  vụ việc theo tháng, cơ cấu trạng thái và danh sách vụ việc gần đây.
- Báo cáo theo: **tháng, địa điểm, mức nồng độ, cán bộ xử phạt, trạng thái thanh toán**.
- Khoảng thời gian tùy chọn, tối đa 10 năm, không vượt quá hôm nay.
- Xuất CSV (UTF-8, mở được bằng Excel) và in báo cáo.
- Số liệu lấy trực tiếp từ stored procedure tổng hợp trên CSDL.

### 5.8 Tra cứu
- Tra cứu nhanh theo mã quyết định, họ tên, CCCD, số điện thoại hoặc biển số.
- Hiển thị quyết định, vụ việc và biên lai liên quan trong cùng một màn hình.

---

## 4. Vai trò và quyền

| Chức năng | Quản trị hệ thống | Cán bộ CSGT | Lãnh đạo | Cán bộ tài chính |
|---|:---:|:---:|:---:|:---:|
| Tổng quan | ✓ | ✓ | ✓ | ✓ |
| Xem người vi phạm / vụ việc / quyết định | ✓ | ✓ | ✓ | ✓ |
| Thêm, sửa người vi phạm / vụ việc | ✓ | ✓ | – | – |
| Lập, cập nhật trạng thái quyết định | ✓ | ✓ | ✓ | – |
| Xem thanh toán, biên lai | ✓ | – | ✓ | ✓ |
| Ghi nhận thanh toán | ✓ | – | – | ✓ |
| Tra cứu | ✓ | ✓ | ✓ | ✓ |
| Báo cáo thống kê | ✓ | – | ✓ | ✓ |
| Quản lý cán bộ, tài khoản, danh mục | ✓ | – | – | – |

Quyền được kiểm tra ở **hai lớp**:
- Giao diện: ẩn nút/màn hình không phù hợp (`AppSession`, `MainForm`).
- Nghiệp vụ: `Permissions.Ensure...` trong BLL, ném `BusinessException` nếu gọi trái quyền.

---

## 5. Giao diện

- Phong cách doanh nghiệp hiện đại, nền sáng, sidebar tối màu, font Segoe UI.
- Kích thước tham chiếu 1440 × 900; form chính mở toàn màn hình, nội dung co giãn.
- Sidebar nhóm chức năng: **Tổng quan / Nghiệp vụ / Phân tích / Quản trị**.
- Bảng dữ liệu có tiêu đề rõ ràng, dòng xen kẽ, phân trang, trạng thái rỗng/đang tải.
- Form nhập liệu chia nhóm, có nhãn bắt buộc, kiểm tra lỗi tại chỗ.
- Thông báo thành công/lỗi thân thiện; lỗi kỹ thuật được ghi log.
- Các control dùng lại: `RoundedPanel`, `RoundedButton`, `StatCard`, `NavButton`,
  `PaginationControl`, `AvatarControl`, `StatusOverlay`, biểu đồ trong `Charts.cs`.

Giao diện được dựng trong các tệp `*.Designer.cs` theo cách kéo thả của WinForms Designer;
mã xử lý sự kiện nằm trong `*.cs` tương ứng.

---

## 6. Cấu trúc thư mục

```text
Project/
├─ AlcoholViolationManagement.slnx
├─ database/
│  ├─ CreateDatabase.sql
│  ├─ Tables.sql
│  ├─ ConstraintsAndIndexes.sql
│  ├─ Functions.sql
│  ├─ Views.sql
│  ├─ Triggers.sql
│  ├─ StoredProcedures.sql
│  ├─ Producers.sql
│  └─ SeedData.sql
├─ docs/
│  ├─ README.md
│  ├─ DatabaseGuide.md
│  └─ Skeleton.md
└─ src/
   ├─ AlcoholViolationManagement.Domain/
   │  ├─ Entities/        Thực thể nghiệp vụ
   │  ├─ Enums/           Vai trò, trạng thái, nhóm thống kê
   │  ├─ DTOs/            Dữ liệu hiển thị/tổng hợp
   │  └─ Exceptions/
   ├─ AlcoholViolationManagement.DAL/
   │  ├─ Db/              Kết nối, đọc dữ liệu, tham số hóa
   │  ├─ Interfaces/
   │  ├─ Repositories/    Truy vấn ADO.NET
   │  └─ Mapping/
   ├─ AlcoholViolationManagement.BLL/
   │  ├─ Services/        Nghiệp vụ
   │  ├─ Validators/      Kiểm tra dữ liệu
   │  ├─ Security/        Phân quyền, băm mật khẩu, dịch lỗi SQL
   │  └─ Interfaces/
   └─ AlcoholViolationManagement.WinForms/
      ├─ Forms/           Màn hình và hộp thoại
      ├─ Controls/        Control dùng lại
      ├─ Helpers/         Cấu hình, phiên, định dạng, in, log
      ├─ appsettings.json
      └─ Program.cs
```

---

## 7. Cài đặt và chạy

### 7.1 Yêu cầu
- Windows 10/11.
- .NET 10 SDK.
- SQL Server Express/Developer (mặc định `localhost\SQLEXPRESS01`) hoặc instance tương đương.
- Visual Studio có hỗ trợ .NET 10 (nếu IDE chưa hỗ trợ `.slnx`, mở trực tiếp
  `src/AlcoholViolationManagement.WinForms/AlcoholViolationManagement.WinForms.csproj`).

### 7.2 Tạo CSDL

Mở terminal tại thư mục gốc dự án và chạy **đúng thứ tự**:

```bat
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\CreateDatabase.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\Tables.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\ConstraintsAndIndexes.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\Functions.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\Views.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\Triggers.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\StoredProcedures.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\Producers.sql
sqlcmd -S "localhost\SQLEXPRESS01" -E -b -f 65001 -i database\SeedData.sql
```

> `-f 65001` rất quan trọng để tiếng Việt trong script không bị lỗi mã hóa.
> `CreateDatabase.sql` sẽ **xóa và tạo lại** database — chỉ dùng cho môi trường học tập/kiểm thử.

Chi tiết từng script, sơ đồ quan hệ và cách khôi phục dữ liệu: xem [DatabaseGuide.md](DatabaseGuide.md).

### 7.3 Cấu hình kết nối

Tệp `src/AlcoholViolationManagement.WinForms/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost\\SQLEXPRESS01;Database=QuanLyXuPhatNongDoCon;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;"
  }
}
```

- Mặc định dùng **Windows Authentication**, không có mật khẩu trong mã nguồn.
- Nếu instance SQL Server của bạn có tên khác, thay `localhost\\SQLEXPRESS01` bằng tên tương ứng (ví dụ `Server=.\\SQLEXPRESS;`).
- Có thể ghi đè chuỗi kết nối bằng biến môi trường `ALCOHOL_DB_CONNECTION`
  (hữu ích khi dùng SQL Authentication hoặc máy chủ khác).
- Khi sửa cấu hình, sửa tệp trong thư mục `src/.../WinForms/` rồi build lại để tệp được
  sao chép sang thư mục chạy.
- Thông tin tổ chức (`ToChuc`) đang là mẫu, thay bằng thông tin thực khi có quyết định
  thống nhất đơn vị khảo sát.

### 7.4 Build, Test và Chạy ứng dụng

```bat
# 1. Build toàn bộ solution (0 error, 0 warning)
dotnet build AlcoholViolationManagement.slnx

# 2. Chạy toàn bộ kiểm thử tự động (xUnit)
dotnet test AlcoholViolationManagement.slnx

# 3. Chạy ứng dụng quản lý nghiệp vụ chính
dotnet run --project src\AlcoholViolationManagement.WinForms

# 4. Chạy cổng tra cứu vi phạm dành cho người dân
dotnet run --project src\AlcoholViolationManagement.PublicLookup
```

Hoặc mở solution/project trong Visual Studio, chọn cấu hình `Debug`, chạy
`AlcoholViolationManagement.WinForms`.

---

## 8. Tài khoản mẫu

Dữ liệu seed chỉ phục vụ kiểm thử, **không dùng thông tin cá nhân thật**.

| Tên đăng nhập | Mật khẩu | Vai trò | Ghi chú |
|---|---|---|---|
| `admin` | `Admin@123` | Quản trị hệ thống | Toàn quyền |
| `csgt01` | `Csgt@123` | Cán bộ CSGT | Nghiệp vụ hồ sơ, vụ việc, quyết định |
| `csgt02` | `Csgt@123` | Cán bộ CSGT | Nghiệp vụ hồ sơ, vụ việc, quyết định |
| `lanhdao` | `Lanhdao@123` | Lãnh đạo | Xem thanh toán, quyết định, báo cáo |
| `taichinh` | `Taichinh@123` | Cán bộ tài chính | Ghi nhận thanh toán, báo cáo |
| `csgt03` | `Csgt@123` | Cán bộ CSGT | **Tài khoản bị khóa** để kiểm thử |

> Đổi toàn bộ mật khẩu demo trước khi dùng ngoài môi trường học tập.

Dữ liệu mẫu hiện có: 30 người vi phạm, 60 vụ việc, 48 quyết định, 21 biên lai,
6 cán bộ, 6 tài khoản, 4 loại phương tiện, 3 mức nồng độ và 12 loại vi phạm.

---

## 9. Quy tắc nghiệp vụ chính

### Người vi phạm
- Họ tên, địa chỉ bắt buộc; CCCD đúng 12 chữ số; số điện thoại 10–11 chữ số bắt đầu bằng 0.
- CCCD và số điện thoại không trùng; số GPLX (nếu có) không trùng.
- Ngày sinh không ở tương lai và không trước 01/01/1900.

### Vụ việc
- Phải chọn người vi phạm và loại phương tiện.
- Thời gian vi phạm không ở tương lai; nồng độ cồn từ 0 đến 2,0 mg/L.
- Biển số tối thiểu 4 ký tự, được chuẩn hóa chữ hoa.
- Mức nồng độ và loại vi phạm được xác định tự động:
  - Mức 1: `0,00 – 0,25 mg/L` (giá trị 0,25 thuộc mức 1).
  - Mức 2: `> 0,25 – 0,40 mg/L`.
  - Mức 3: `> 0,40 mg/L`.
- Mức phạt lấy theo loại vi phạm tương ứng với loại phương tiện và mức nồng độ.

### Quyết định
- Mỗi vụ việc chỉ có một quyết định.
- Ngày ra quyết định không trước ngày vi phạm, không ở tương lai.
- Quyết định mới không được ở trạng thái “Đã nộp”.
- Số tiền phạt do trigger `TRIGGER_TINH_PHAT` cập nhật từ `LOAI_VI_PHAM.MucPhat`.
- Có biên lai thì không được chuyển trạng thái về “Chưa nộp”/“Quá hạn”.

### Thanh toán
- Mỗi quyết định chỉ có một biên lai.
- Số tiền nộp bằng đúng số tiền phạt.
- Thời gian nộp không trước ngày quyết định và không ở tương lai.
- Ghi nhận thanh toán cập nhật đồng bộ trạng thái quyết định và vụ việc.
- Trạng thái thanh toán dùng chung cho vụ việc và quyết định.

### Báo cáo
- `Từ ngày` không lớn hơn `Đến ngày`; không chọn ngày tương lai.
- Khoảng thống kê tối đa 10 năm (3.650 ngày).
- Báo cáo theo tháng hiển thị đủ các tháng trong khoảng, kể cả tháng chưa phát sinh vụ việc.

### Tài khoản
- Tên đăng nhập 3–50 ký tự, chỉ gồm chữ, số và `. _ -`.
- Email hợp lệ và không trùng.
- Mật khẩu 8–64 ký tự, có ít nhất một chữ cái và một chữ số.
- Mỗi cán bộ có tối đa một tài khoản.
- Không thể tự khóa tài khoản đang đăng nhập.

---

## 10. Kiểm thử đã thực hiện

Đã kiểm tra trên SQL Server Express và màn hình 1920 × 1080 (DPI 125%):

- Build toàn solution: **0 warning, 0 error**.
- Đăng nhập thành công với cả bốn vai trò; tài khoản khóa hiển thị đúng thông báo.
- Phân quyền sidebar và nút thao tác đúng theo vai trò.
- Danh sách, tìm kiếm, lọc, phân trang người vi phạm/vụ việc/quyết định/thanh toán.
- Xem hồ sơ người vi phạm kèm lịch sử vụ việc thật.
- Lập thử quyết định trong transaction và rollback:
  - Trigger tính đúng `SoTienPhat` theo `LOAI_VI_PHAM`.
  - Số quyết định sau rollback vẫn là 48.
- Ghi nhận thanh toán, biên lai và đồng bộ trạng thái được kiểm tra ở tầng CSDL.
- Báo cáo theo tháng trả đúng 10 nhóm tháng (01–10/2026), không phát sinh tháng rỗng ngoài khoảng.
- Xuất CSV thật ra tệp, nội dung khớp số liệu trên màn hình.
- Các hộp thoại thêm/sửa được mở và hủy an toàn, không tạo dữ liệu rác khi chưa lưu.

---

## 11. Ghi chú triển khai

- Không có SQL trong sự kiện điều khiển giao diện; mọi truy vấn nằm ở DAL.
- Truy vấn dùng tham số; thao tác nhiều bảng dùng transaction/stored procedure.
- Lỗi SQL được dịch sang thông báo tiếng Việt tại `SqlErrorTranslator`.
- Log ứng dụng: `%LOCALAPPDATA%\AlcoholViolationManagement\logs\app-yyyyMMdd.log`.
- Hộp thoại hệ thống (chọn tệp, in, xác nhận của Windows) có thể hiển thị nút
  bằng ngôn ngữ của Windows; nội dung nghiệp vụ của ứng dụng là tiếng Việt.
- Ứng dụng không xóa cứng hồ sơ vi phạm; lịch sử được giữ lại để tra cứu.
- Dữ liệu mẫu dùng tên/CCCD/số điện thoại giả lập, không phải thông tin cá nhân thật.

---

## 12. Tài liệu tham chiếu

- **GitHub Repository:** [https://github.com/minhchi1009/QuanLyXuPhatViPhamNDC](https://github.com/minhchi1009/QuanLyXuPhatViPhamNDC)
- Báo cáo phân tích và thiết kế: `D:\PTTKYC\BAITAPLON-PTTKYC2.pdf`.
- [DatabaseGuide.md](DatabaseGuide.md) — Thiết kế cơ sở dữ liệu và kịch bản SQL.
- [Skeleton.md](Skeleton.md) — Khung kiến trúc và mở rộng chức năng.
- [DefenseQnA.md](DefenseQnA.md) — Bộ câu hỏi và trả lời phản biện bảo vệ đồ án.
