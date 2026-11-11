# CẨM NANG BẢO VỆ ĐỒ ÁN & BỘ CÂU HỎI PHẢN BIỆN (Q&A)
## HỆ THỐNG QUẢN LÝ XỬ PHẠT VI PHẠM NỒNG ĐỘ CỒN
**Môn học:** Phân tích và Thiết kế Yêu cầu (PTTKYC)  
**Công nghệ:** C# .NET 10, Windows Forms, ADO.NET, Microsoft SQL Server

---

## PHẦN 1: BỘ CÂU HỎI KIẾN TRÚC & CÔNG NGHỆ

### Câu 1: Tại sao nhóm lựa chọn kiến trúc phân tầng (Domain - DAL - BLL - WinForms) mà không viết truy vấn trực tiếp trên Form?
* **Trả lời:**
  * **Nguyên tắc phân tách trách nhiệm (Separation of Concerns):** Giúp mã nguồn có tính tổ chức cao, dễ bảo trì và kiểm thử.
  * **Độc lập và an toàn:** Tầng giao diện (`WinForms`) chỉ tương tác với tầng nghiệp vụ (`BLL`), tuyệt đối **không tham chiếu trực tiếp tầng DAL**. Nếu sau này cần thay đổi giao diện từ WinForms sang Web (ASP.NET Core) hoặc Mobile, toàn bộ tầng `BLL` và `DAL` vẫn giữ nguyên mà không cần viết lại.
  * **Domain độc lập:** Chứa các Entity, DTO, Enum, Exception dùng chung cho cả 3 tầng mà không phụ thuộc vào bất kỳ thư viện hay công nghệ cụ thể nào.

### Câu 2: Tại sao dự án sử dụng ADO.NET thuần kết hợp Stored Procedure/Trigger mà không dùng Entity Framework Core (ORM)?
* **Trả lời:**
  * **Kiểm soát tối đa hiệu năng và câu truy vấn:** ADO.NET thuần cho phép tối ưu hóa chính xác từng câu lệnh SQL, tận dụng tối đa sức mạnh của chỉ mục (Indexes) và Stored Procedure được biên dịch sẵn trên SQL Server.
  * **Bảo vệ toàn vẹn nghiệp vụ ở tầng lõi CSDL:** Các quy tắc trọng yếu (như tính tiền phạt tự động, giao dịch nhiều bảng đồng thời) được thực thi nguyên tử bằng Transaction và Trigger tại SQL Server, không phụ thuộc vào tầng ứng dụng bên ngoài.
  * **Phù hợp đặc thù môn học:** Thể hiện rõ năng lực thiết kế cơ sở dữ liệu quan hệ, viết trigger, procedure và kiểm soát kết nối trực tiếp, thay vì phó mặc cho ORM sinh câu lệnh tự động.

### Câu 3: Làm thế nào ứng dụng quản lý vòng đời (Lifecycle) khi chuyển đổi giữa Đăng nhập, Làm việc chính và Đăng xuất?
* **Trả lời:**
  * Dự án sử dụng lớp `AppLifecycleContext` kế thừa từ `ApplicationContext` của Windows Forms.
  * Khi người dùng đăng nhập thành công, Form Đăng nhập sẽ được giải phóng tài nguyên (`Dispose`) và Form Chính mở lên.
  * Khi người dùng bấm Đăng xuất, hệ thống hủy phiên làm việc (`AppSession.SignOut()`), đóng Form Chính và mở lại Form Đăng nhập mà **không làm tắt tiến trình nền (Message Loop)** của ứng dụng, tránh rò rỉ bộ nhớ hoặc lỗi ứng dụng bị treo ngầm.

---

## PHẦN 2: BỘ CÂU HỎI CƠ SỞ DỮ LIỆU & QUY TẮC NGHIỆP VỤ

### Câu 4: Cơ sở dữ liệu của dự án đã đạt chuẩn mấy? Hãy chứng minh?
* **Trả lời:**
  * CSDL đã đạt **Chuẩn hóa bậc 3 (3NF)**:
    1. **1NF:** Mọi thuộc tính đều là giá trị nguyên tố (atomic), không có mảng hay thuộc tính lặp trong cột. Mỗi bảng đều có Khóa chính (PK) rõ ràng.
    2. **2NF:** Đạt 1NF và mọi thuộc tính không khóa đều phụ thuộc hàm toàn phần vào khóa chính, không có sự phụ thuộc từng phần (partial dependency).
    3. **3NF:** Đạt 2NF và không có thuộc tính không khóa nào phụ thuộc bắc cầu (transitive dependency) vào khóa chính. Ví dụ: Thông tin cán bộ, tài khoản, người vi phạm, loại phương tiện, mức nồng độ cồn đều được tách thành các bảng danh mục riêng biệt và liên kết qua Khóa ngoại (FK).

### Câu 5: Tại sao số tiền phạt không để người dùng tự nhập hoặc tính ở tầng BLL mà lại dùng Trigger `TRIGGER_TINH_PHAT`?
* **Trả lời:**
  * **Chống gian lận và sai sót nghiệp vụ:** Số tiền phạt theo quy định pháp luật được gắn chặt với cặp `(Loại phương tiện, Mức nồng độ cồn)`. Nếu để người dùng nhập ở giao diện, người xử phạt có thể tự ý can thiệp giảm tiền phạt.
  * **Bảo vệ toàn vẹn dữ liệu từ gốc:** Bằng việc sử dụng Trigger `TRIGGER_TINH_PHAT`, bất kể dữ liệu quyết định được tạo qua phần mềm hay ai đó cố tình chèn qua SQL script, SQL Server vẫn tự động tra cứu bảng `LOAI_VI_PHAM` để gán đúng số tiền phạt thực tế.

### Câu 6: Hệ thống xử lý bài toán tranh chấp dữ liệu đồng thời (Concurrency) thế nào khi có 2 cán bộ cùng thao tác?
* **Trả lời:**
  * **Ví dụ:** Vụ việc đang mở, Cán bộ A bấm cập nhật thông tin trong khi Cán bộ B đã nhanh tay lập Quyết định xử phạt cho vụ việc đó.
  * **Cách xử lý:** Trong câu lệnh `UPDATE dbo.VI_PHAM` tại `ViPhamRepository`, hệ thống bổ sung điều kiện kiểm tra nguyên tử:
    ```sql
    WHERE Ma_VuViec = @MaVuViec 
      AND NOT EXISTS (SELECT 1 FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_VuViec = @MaVuViec)
    ```
    Nếu vụ việc đã phát sinh quyết định xử phạt trong tích tắc trước đó, số dòng cập nhật sẽ là `0`, tầng BLL phát hiện ngay và ném ra thông báo: *"Vụ việc đã phát sinh quyết định xử phạt trong lúc cập nhật. Vui lòng tải lại dữ liệu."* mà không làm sai lệch trạng thái.

### Câu 7: Khi thanh toán nộp phạt, làm sao bảo đảm trạng thái của Quyết định và Vụ việc được cập nhật đồng bộ?
* **Trả lời:**
  * Sử dụng Stored Procedure `sp_GhiNhanThanhToan` kết hợp giao dịch tường minh `BEGIN TRANSACTION ... COMMIT TRANSACTION` cùng với `SET XACT_ABORT ON`.
  * Trong một Transaction, hệ thống thực hiện đồng thời:
    1. Chèn bản ghi vào bảng `THANH_TOAN` (Biên lai).
    2. Cập nhật `QUYET_DINH_XU_PHAT` sang trạng thái `TT02` (Đã nộp) và gán ngày nộp.
    3. Cập nhật `VI_PHAM` sang `TT02`.
  * Nếu bất kỳ bước nào gặp sự cố, toàn bộ giao dịch sẽ tự động Rollback, bảo đảm không bao giờ xảy ra tình trạng "đã trừ tiền/lập biên lai mà vụ việc vẫn báo chưa nộp".

---

## PHẦN 3: BỘ CÂU HỎI BẢO MẬT & PHÂN QUYỀN

### Câu 8: Mật khẩu người dùng được lưu trữ và bảo vệ như thế nào?
* **Trả lời:**
  * Hệ thống tuyệt đối không lưu mật khẩu dạng bản rõ (plaintext) hay băm đơn giản (MD5/SHA1 vì dễ bị tấn công bằng bảng cầu vồng - Rainbow table).
  * Ứng dụng sử dụng thuật toán **PBKDF2-SHA256**:
    * **Salt ngẫu nhiên:** 16 bytes bằng `RandomNumberGenerator.GetBytes`.
    * **Số vòng lặp (Iterations):** 100.000 vòng để làm chậm tốc độ brute-force của tin tặc.
    * **So sánh an toàn:** Sử dụng hàm `CryptographicOperations.FixedTimeEquals` để so sánh chuỗi hash trong thời gian cố định, chống lại kỹ thuật tấn công đo thời gian (Timing Attack).

### Câu 9: Cơ chế phân quyền được tổ chức như thế nào? Có bị qua mặt (bypass) nếu người dùng can thiệp giao diện không?
* **Trả lời:**
  * Hệ thống áp dụng **Phân quyền 2 lớp (Two-tier Authorization)**:
    1. **Lớp giao diện (Presentation):** Căn cứ theo `AppSession.User.VaiTroId`, ẩn các menu chức năng hoặc vô hiệu hóa (`Enabled = false`, `Visible = false`) các nút Thêm, Sửa, Lập quyết định đối với vai trò không được phép.
    2. **Lớp nghiệp vụ (BLL):** Mọi Service method đều gọi phương thức kiểm tra bản quyền `Permissions.Ensure...`. Dù kẻ gian có dùng công cụ can thiệp bộ nhớ để kích hoạt lại nút bấm trên UI thì lời gọi xuống BLL vẫn sẽ bị chặn và ném ngoại lệ `BusinessException("Bạn không có quyền thực hiện chức năng này.")`.
  * **Cơ chế khóa tài khoản giữa phiên (`EnsureTaiKhoanHoatDongAsync`):** Mỗi khi người dùng thực hiện bất kỳ thao tác CSDL nào, hệ thống đều kiểm tra lại trạng thái tài khoản. Nếu Quản trị viên vừa khóa tài khoản đó, thao tác sẽ bị chặn ngay lập tức mà không cần đợi người đó đăng xuất.

### Câu 10: Ứng dụng chống tấn công SQL Injection bằng cách nào?
* **Trả lời:**
  * 100% câu lệnh truy vấn trong `DAL` đều sử dụng **Truy vấn có tham số (Parameterized Queries)** qua `SqlCommand.Parameters.AddWithValue`. Tuyệt đối không cộng chuỗi SQL với dữ liệu người dùng nhập.
  * Với các chức năng tìm kiếm sử dụng mệnh đề `LIKE`, lớp `SqlLike.Contains` chủ động chuyển đổi (escape) các ký tự đặc biệt của SQL Server như `%`, `_`, `[`, `\` trước khi truyền vào tham số.

---

## PHẦN 4: BỘ CÂU HỎI KIỂM THỬ & ĐỘ TIN CẬY

### Câu 11: Dự án đã thực hiện kiểm thử như thế nào?
* **Trả lời:**
  * **Kiểm thử tự động (Unit Test):** Dự án có riêng project `AlcoholViolationManagement.Tests` sử dụng framework **xUnit**, kiểm thử tự động toàn bộ các quy tắc xác thực (CCCD, SĐT, Nồng độ cồn, Ngày sinh, Biển số) và thuật toán mã hóa mật khẩu.
  * **Kiểm thử tích hợp trên CSDL:** Script `SeedData.sql` chuẩn bị sẵn các bộ dữ liệu đa dạng (hồ sơ hợp lệ, hồ sơ có lịch sử vi phạm, vụ việc chưa có quyết định, vụ việc đã thanh toán, tài khoản demo cho cả 4 vai trò và tài khoản bị khóa).

### Câu 12: Khi xảy ra lỗi kết nối CSDL hoặc lỗi vi phạm dữ liệu, ứng dụng phản hồi ra sao?
* **Trả lời:**
  * Ứng dụng có lớp dịch lỗi `SqlErrorTranslator` để chặn bắt `SqlException`:
    * Mã lỗi `2601`, `2627` (Unique): Dịch thành *"Dữ liệu bị trùng với một bản ghi đã có."*
    * Mã lỗi `547` (Foreign Key / Check): Dịch thành *"Dữ liệu đang được tham chiếu bởi hồ sơ khác nên không thể thay đổi."*
    * Mã lỗi `-2` (Timeout): Dịch thành *"Máy chủ cơ sở dữ liệu phản hồi quá lâu. Vui lòng thử lại."*
  * Nhờ vậy, người dùng không bao giờ phải nhìn thấy các thông báo lỗi kỹ thuật tiếng Anh khó hiểu, đồng thời chi tiết lỗi gốc (Stack Trace) vẫn được ghi lại vào tệp nhật ký `%LOCALAPPDATA%\AlcoholViolationManagement\logs\` phục vụ bảo trì.

---

> **LỜI KHUYÊN KHI TRẢ LỜI TRƯỚC HỘI ĐỒNG:**
> 1. Luôn tự tin nhấn mạnh vào tính **phòng thủ đa tầng** (Giao diện $\rightarrow$ Nghiệp vụ $\rightarrow$ CSDL).
> 2. Nhấn mạnh việc **không dùng số liệu mẫu hiển thị giả lập trên UI**: Mọi số liệu báo cáo, biểu đồ, danh sách đều đọc trực tiếp từ SQL Server.
> 3. Trả lời ngắn gọn, đúng trọng tâm câu hỏi của thầy cô, sau đó chủ động liên hệ tới đoạn mã nguồn hoặc Stored Procedure cụ thể trong đồ án để chứng minh.
