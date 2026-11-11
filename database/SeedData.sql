/*
    SeedData.sql
    Dữ liệu mẫu phục vụ kiểm thử – không dùng thông tin cá nhân thật.
    Mật khẩu demo:
        admin      / Admin@123
        csgt01     / Csgt@123
        csgt02     / Csgt@123
        lanhdao    / Lanhdao@123
        taichinh   / Taichinh@123
        csgt03     / Csgt@123   (tài khoản bị khóa để kiểm thử)
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
GO

IF EXISTS (SELECT 1 FROM dbo.NGUOI_VI_PHAM)
    THROW 50041, N'Dữ liệu đã tồn tại. Hãy chạy lại CreateDatabase.sql trước khi seed.', 1;
GO

/* ================= VAI TRÒ / TRẠNG THÁI ================= */
INSERT INTO dbo.VAI_TRO (Ma_VaiTro, TenVaiTro, MoTa) VALUES
    (1, N'Quản trị hệ thống', N'Quản trị toàn bộ hệ thống, cán bộ và tài khoản'),
    (2, N'Cán bộ CSGT',       N'Lập biên bản, quản lý người vi phạm và quyết định'),
    (3, N'Lãnh đạo',          N'Theo dõi, tra cứu, quyết định và báo cáo'),
    (4, N'Cán bộ tài chính',  N'Ghi nhận thanh toán và lập biên lai');

INSERT INTO dbo.TRANG_THAI_THANH_TOAN (Ma_TrangThaiThanhToan, TenTrangThai) VALUES
    ('TT01', N'Chưa nộp'),
    ('TT02', N'Đã nộp'),
    ('TT03', N'Quá hạn');
GO

/* ================= DANH MỤC ================= */
INSERT INTO dbo.LOAI_PHUONG_TIEN (Ma_LoaiPhuongTien, TenPhuongTien, MoTa) VALUES
    ('LPT0000001', N'Xe mô tô (xe máy)', N'Xe mô tô, xe gắn máy hai bánh'),
    ('LPT0000002', N'Ô tô con',          N'Ô tô chở người đến 9 chỗ'),
    ('LPT0000003', N'Xe tải',            N'Xe tải, xe chuyên dùng'),
    ('LPT0000004', N'Xe khách',          N'Xe ô tô chở khách trên 9 chỗ');

INSERT INTO dbo.MUC_NONG_DO_CON (Ma_MucNongDoCon, KhoangGiaTri, MoTa, NguongTren) VALUES
    ('MND0000001', N'0.00 – 0.25 mg/L', N'Mức 1: từ 0.00 đến 0.25 mg/L (biên trên thuộc mức 1)', 0.25),
    ('MND0000002', N'0.25 – 0.40 mg/L', N'Mức 2: trên 0.25 và đến 0.40 mg/L', 0.40),
    ('MND0000003', N'Trên 0.40 mg/L',   N'Mức 3: trên 0.40 mg/L', NULL);

INSERT INTO dbo.LOAI_VI_PHAM
    (Ma_LoaiViPham, TenLoaiViPham, MoTa, Ma_LoaiPhuongTien, Ma_MucNongDoCon, MucPhat)
VALUES
    ('LVP0000001', N'Vi phạm nồng độ cồn mức 1 – Xe mô tô',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000001', 'MND0000001',  2000000),
    ('LVP0000002', N'Vi phạm nồng độ cồn mức 2 – Xe mô tô',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000001', 'MND0000002',  4000000),
    ('LVP0000003', N'Vi phạm nồng độ cồn mức 3 – Xe mô tô',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000001', 'MND0000003',  6000000),
    ('LVP0000004', N'Vi phạm nồng độ cồn mức 1 – Ô tô con',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000002', 'MND0000001',  6000000),
    ('LVP0000005', N'Vi phạm nồng độ cồn mức 2 – Ô tô con',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000002', 'MND0000002', 16000000),
    ('LVP0000006', N'Vi phạm nồng độ cồn mức 3 – Ô tô con',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000002', 'MND0000003', 30000000),
    ('LVP0000007', N'Vi phạm nồng độ cồn mức 1 – Xe tải',    N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000003', 'MND0000001',  8000000),
    ('LVP0000008', N'Vi phạm nồng độ cồn mức 2 – Xe tải',    N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000003', 'MND0000002', 18000000),
    ('LVP0000009', N'Vi phạm nồng độ cồn mức 3 – Xe tải',    N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000003', 'MND0000003', 35000000),
    ('LVP0000010', N'Vi phạm nồng độ cồn mức 1 – Xe khách',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000004', 'MND0000001',  8000000),
    ('LVP0000011', N'Vi phạm nồng độ cồn mức 2 – Xe khách',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000004', 'MND0000002', 18000000),
    ('LVP0000012', N'Vi phạm nồng độ cồn mức 3 – Xe khách',  N'Dữ liệu mẫu phục vụ kiểm thử, không phải mức phạt pháp lý hiện hành.', 'LPT0000004', 'MND0000003', 35000000);
GO

/* ================= CÁN BỘ & TÀI KHOẢN ================= */
INSERT INTO dbo.CAN_BO
    (Ma_CanBo, HoTen, SoDienThoai, CanCuocCongDan, DiaChi, CapBac, DonViCongTac, VaiTro)
VALUES
    ('CB00000001', N'Nguyễn Văn An',    '0911000001', '079198001001', N'Số 1 Phan Đăng Lưu, Phường 6, Bình Thạnh, TP.HCM',   N'Đại úy',   N'Đội CSGT – Trật tự, Công an quận Bình Thạnh', 1),
    ('CB00000002', N'Trần Minh Bình',   '0911000002', '079198002002', N'45 Đinh Tiên Hoàng, Phường 3, Bình Thạnh, TP.HCM',    N'Thượng úy', N'Đội CSGT – Trật tự, Công an quận Bình Thạnh', 2),
    ('CB00000003', N'Lê Hoàng Cường',   '0911000003', '079198503003', N'88 Nguyễn Xí, Phường 26, Bình Thạnh, TP.HCM',         N'Đại úy',   N'Đội CSGT – Trật tự, Công an quận Bình Thạnh', 2),
    ('CB00000004', N'Phạm Quốc Dũng',   '0911000004', '079197504004', N'120 Phan Văn Trị, Phường 11, Bình Thạnh, TP.HCM',     N'Trung tá', N'Đội CSGT – Trật tự, Công an quận Bình Thạnh', 3),
    ('CB00000005', N'Võ Thị Hạnh',      '0911000005', '079197905005', N'22 Lê Quang Định, Phường 14, Bình Thạnh, TP.HCM',     N'Đại úy',   N'Đội Tài chính – Hậu cần, Công an quận Bình Thạnh', 4),
    ('CB00000006', N'Đặng Thanh Hùng',  '0911000006', '079199506006', N'76 Nơ Trang Long, Phường 13, Bình Thạnh, TP.HCM',    N'Thiếu úy', N'Đội CSGT – Trật tự, Công an quận Bình Thạnh', 2);
GO

INSERT INTO dbo.TAI_KHOAN
    (Ma_TaiKhoan, TenDangNhap, MatKhau, Email, Ma_CanBo, TrangThai, NgayTao, LanDangNhapCuoi)
VALUES
    ('TK00000001', N'admin',    N'100000.5HA9+ghMiObZAmk0jWSMZQ==.6RqNodH/P0zAVhHJUQkfAnwNtoJV4f6GS9bVgtCav/I=', N'admin@demo.local',    'CB00000001', 1, DATEADD(DAY, -90, SYSDATETIME()), DATEADD(DAY, -1, SYSDATETIME())),
    ('TK00000002', N'csgt01',   N'100000.4V0pLEXSsGg7h0vTalp14w==.iuF51mllTcGkNQ54anvE8QnR5p04ldi7D3G0AvRd9bc=', N'csgt01@demo.local',   'CB00000002', 1, DATEADD(DAY, -80, SYSDATETIME()), DATEADD(DAY, -2, SYSDATETIME())),
    ('TK00000003', N'csgt02',   N'100000.+RiCzVJngvjv2EXy1fNdaA==.QHYz0bQnQGUMZrDWi6E0DyPjiJM0TQ5VtjUdj3su1YI=', N'csgt02@demo.local',   'CB00000003', 1, DATEADD(DAY, -75, SYSDATETIME()), DATEADD(DAY, -3, SYSDATETIME())),
    ('TK00000004', N'lanhdao',  N'100000.fYwdxrRdA9rn0AaryHTGCQ==.bZBtYpFExuaPTI00W2XZcajz20KwwSv/s/RTVF2azIg=', N'lanhdao@demo.local',  'CB00000004', 1, DATEADD(DAY, -70, SYSDATETIME()), DATEADD(DAY, -4, SYSDATETIME())),
    ('TK00000005', N'taichinh', N'100000.Sdd5rUetB2gO9OTvLyuDlg==.rbKKlrlT6BqlVmKC/d+9VfiIajGkUplCZt5/wLsWzbA=', N'taichinh@demo.local', 'CB00000005', 1, DATEADD(DAY, -60, SYSDATETIME()), DATEADD(DAY, -5, SYSDATETIME())),
    ('TK00000006', N'csgt03',   N'100000.3NeKnjcJVW9A10cbyBZ6tw==.SsF2T0TEG9kpIEEwCGF79U2WcH4361LSw58dQpZ4w6M=', N'csgt03@demo.local',   'CB00000006', 0, DATEADD(DAY, -45, SYSDATETIME()), NULL);
GO

/* ================= NGƯỜI VI PHẠM ================= */
INSERT INTO dbo.NGUOI_VI_PHAM
    (Ma_NguoiViPham, HoTen, SoDienThoai, CanCuocCongDan, NgaySinh, DiaChi, GioiTinh, SoGPLX)
VALUES
    ('NVP0000001', N'Nguyễn Minh Khang', '0901000001', '079200001001', '1995-03-14', N'12 Nguyễn Xí, Phường 26, Bình Thạnh, TP.HCM',        N'Nam', N'B2-000001'),
    ('NVP0000002', N'Trần Thị Lan',      '0901000002', '079200001002', '1992-07-22', N'45 Đinh Tiên Hoàng, Phường 3, Bình Thạnh, TP.HCM',   N'Nữ',  N'B2-000002'),
    ('NVP0000003', N'Lê Quốc Bảo',       '0901000003', '079200001003', '1988-11-05', N'88 Phan Văn Trị, Phường 11, Bình Thạnh, TP.HCM',     N'Nam', N'B2-000003'),
    ('NVP0000004', N'Phạm Hoàng Nam',    '0901000004', '079200001004', '1997-01-19', N'120 Lê Quang Định, Phường 14, Bình Thạnh, TP.HCM',   N'Nam', N'B2-000004'),
    ('NVP0000005', N'Võ Thị Mai',        '0901000005', '079200001005', '1990-05-30', N'22 Nơ Trang Long, Phường 13, Bình Thạnh, TP.HCM',    N'Nữ',  N'B2-000005'),
    ('NVP0000006', N'Đặng Hữu Phước',    '0901000006', '079200001006', '1985-09-12', N'76 Nguyễn Hữu Cảnh, Phường 22, Bình Thạnh, TP.HCM', N'Nam', NULL),
    ('NVP0000007', N'Bùi Anh Tuấn',       '0901000007', '079200001007', '1999-12-02', N'31 Bạch Đằng, Phường 24, Bình Thạnh, TP.HCM',        N'Nam', N'B2-000007'),
    ('NVP0000008', N'Ngô Thị Hồng',      '0901000008', '079200001008', '1994-04-17', N'15/3 Xô Viết Nghệ Tĩnh, Phường 25, Bình Thạnh, TP.HCM', N'Nữ', N'B2-000008'),
    ('NVP0000009', N'Dương Văn Sơn',     '0901000009', '079200001009', '1982-08-08', N'210 Điện Biên Phủ, Phường 15, Bình Thạnh, TP.HCM',  N'Nam', N'B2-000009'),
    ('NVP0000010', N'Đỗ Thị Thu',        '0901000010', '079200001010', '2001-02-25', N'9 Ung Văn Khiêm, Phường 25, Bình Thạnh, TP.HCM',     N'Nữ',  NULL),
    ('NVP0000011', N'Hồ Nhật Trường',    '0901000011', '079200001011', '1993-06-11', N'55 Đường D2, Phường 25, Bình Thạnh, TP.HCM',         N'Nam', N'B2-000011'),
    ('NVP0000012', N'Lý Thị Ngọc',       '0901000012', '079200001012', '1987-10-29', N'68 Nguyễn Gia Trí, Phường 25, Bình Thạnh, TP.HCM',  N'Nữ',  N'B2-000012'),
    ('NVP0000013', N'Phan Văn Đạt',      '0901000013', '079200001013', '1996-03-07', N'101 Chu Văn An, Phường 26, Bình Thạnh, TP.HCM',      N'Nam', N'B2-000013'),
    ('NVP0000014', N'Vũ Thị Hà',         '0901000014', '079200001014', '1991-09-18', N'23 Nguyễn Thượng Hiền, Phường 5, Bình Thạnh, TP.HCM', N'Nữ', N'B2-000014'),
    ('NVP0000015', N'Trịnh Công Lý',     '0901000015', '079200001015', '1979-12-24', N'170 Trần Quý Cáp, Phường 11, Bình Thạnh, TP.HCM',    N'Nam', N'B2-000015'),
    ('NVP0000016', N'Nguyễn Thị Kim',    '0901000016', '079200001016', '2000-08-13', N'7 Lê Trực, Phường 7, Bình Thạnh, TP.HCM',             N'Nữ',  NULL),
    ('NVP0000017', N'Lê Văn Hùng',       '0901000017', '079200001017', '1984-01-09', N'34 Nguyễn Văn Đậu, Phường 6, Bình Thạnh, TP.HCM',   N'Nam', N'B2-000017'),
    ('NVP0000018', N'Trần Quốc Việt',    '0901000018', '079200001018', '1998-05-21', N'92 Phan Đăng Lưu, Phường 6, Bình Thạnh, TP.HCM',    N'Nam', N'B2-000018'),
    ('NVP0000019', N'Phạm Thị Yến',      '0901000019', '079200001019', '1993-11-30', N'18C Phan Chu Trinh, Phường 24, Bình Thạnh, TP.HCM', N'Nữ',  N'B2-000019'),
    ('NVP0000020', N'Bùi Thanh Tùng',    '0901000020', '079200001020', '1990-07-04', N'63 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, TP.HCM',  N'Nam', N'B2-000020'),
    ('NVP0000021', N'Đặng Thị Hương',    '0901000021', '079200001021', '1986-02-16', N'5 Nguyễn Bỉnh Khiêm, Phường 1, Bình Thạnh, TP.HCM',  N'Nữ',  N'B2-000021'),
    ('NVP0000022', N'Võ Minh Triết',     '0901000022', '079200001022', '1995-10-08', N'118 Võ Oanh, Phường 25, Bình Thạnh, TP.HCM',          N'Nam', N'B2-000022'),
    ('NVP0000023', N'Ngô Văn Lộc',       '0901000023', '079200001023', '1983-04-27', N'41 Đường D3, Phường 25, Bình Thạnh, TP.HCM',         N'Nam', NULL),
    ('NVP0000024', N'Dương Thị Ánh',     '0901000024', '079200001024', '1997-06-15', N'72 Bùi Hữu Nghĩa, Phường 5, Bình Thạnh, TP.HCM',    N'Nữ',  N'B2-000024'),
    ('NVP0000025', N'Hồ Quang Huy',      '0901000025', '079200001025', '1978-09-03', N'133 Nguyễn Xí, Phường 26, Bình Thạnh, TP.HCM',      N'Nam', N'B2-000025'),
    ('NVP0000026', N'Đỗ Minh Quân',      '0901000026', '079200001026', '2002-01-31', N'26 Tăng Bạt Hổ, Phường 11, Bình Thạnh, TP.HCM',      N'Nam', N'B2-000026'),
    ('NVP0000027', N'Lý Văn Phát',       '0901000027', '079200001027', '1989-12-19', N'84 Lê Văn Duyệt, Phường 1, Bình Thạnh, TP.HCM',      N'Nam', N'B2-000027'),
    ('NVP0000028', N'Phan Thị Diễm',     '0901000028', '079200001028', '1994-08-06', N'19 Trần Bình Trọng, Phường 5, Bình Thạnh, TP.HCM',   N'Nữ',  N'B2-000028'),
    ('NVP0000029', N'Vũ Hoàng Long',     '0901000029', '079200001029', '1981-05-14', N'150 Bình Lợi, Phường 13, Bình Thạnh, TP.HCM',        N'Nam', NULL),
    ('NVP0000030', N'Trịnh Thị Trang',   '0901000030', '079200001030', '1999-03-28', N'37 Phạm Viết Chánh, Phường 19, Bình Thạnh, TP.HCM',  N'Nữ',  N'B2-000030');
GO

/* ================= VỤ VI PHẠM / QUYẾT ĐỊNH / THANH TOÁN ================= */
DECLARE @i INT = 1;
DECLARE @soQuyetDinh INT = 0;
DECLARE @soThanhToan INT = 0;
DECLARE @maVv CHAR(10), @maQd CHAR(10), @maNvp CHAR(10), @maLpt CHAR(10),
        @maMnd CHAR(10), @maLvp CHAR(10), @maCb CHAR(10), @maTt CHAR(10);
DECLARE @nvpIdx INT, @lptIdx INT, @mndIdx INT;
DECLARE @nongDo FLOAT, @thoiGian DATETIME2(0), @soNgayTruoc INT;
DECLARE @diaDiem NVARCHAR(255), @bienSo NVARCHAR(15), @moTaPt NVARCHAR(255);
DECLARE @coQuyetDinh BIT, @daNop BIT, @quaHan BIT;
DECLARE @ngayRa DATE, @ngayNop DATETIME2(0), @mucPhat DECIMAL(18,2);

WHILE @i <= 60
BEGIN
    SET @maVv = 'VV' + RIGHT('00000000' + CONVERT(VARCHAR(8), @i), 8);

    SET @nvpIdx = ((@i - 1) % 30) + 1;
    SET @maNvp = 'NVP' + RIGHT('0000000' + CONVERT(VARCHAR(7), @nvpIdx), 7);

    SET @lptIdx = ((@i - 1) % 4) + 1;
    SET @maLpt = 'LPT' + RIGHT('0000000' + CONVERT(VARCHAR(7), @lptIdx), 7);

    SET @mndIdx = ((@i - 1) % 3) + 1;
    SET @maMnd = 'MND' + RIGHT('0000000' + CONVERT(VARCHAR(7), @mndIdx), 7);

    SET @maLvp = 'LVP' + RIGHT('0000000' + CONVERT(VARCHAR(7), ((@lptIdx - 1) * 3 + @mndIdx)), 7);

    SET @maCb = CASE (@i % 3)
                    WHEN 0 THEN 'CB00000002'
                    WHEN 1 THEN 'CB00000003'
                    ELSE 'CB00000006'
                END;

    SET @nongDo = CASE @mndIdx
                      WHEN 1 THEN 0.08 + ((@i % 4) * 0.05)
                      WHEN 2 THEN 0.28 + ((@i % 3) * 0.05)
                      ELSE 0.45 + ((@i % 5) * 0.08)
                  END;

    SET @soNgayTruoc = 15 + ((@i * 7) % 160);
    SET @thoiGian = DATEADD(HOUR, 6 + (@i % 14),
                    DATEADD(DAY, -@soNgayTruoc, CAST(CAST(SYSDATETIME() AS DATE) AS DATETIME2(0))));

    SET @diaDiem = CASE (@i % 6)
                       WHEN 0 THEN N'Nút giao Điện Biên Phủ – Nguyễn Xí, Bình Thạnh'
                       WHEN 1 THEN N'Đường Phan Văn Trị, Phường 11, Bình Thạnh'
                       WHEN 2 THEN N'Đường Lê Quang Định, Phường 14, Bình Thạnh'
                       WHEN 3 THEN N'Cầu Thị Nghè, Bình Thạnh'
                       WHEN 4 THEN N'Đường Nơ Trang Long, Phường 13, Bình Thạnh'
                       ELSE N'Ngã tư Hàng Xanh, Bình Thạnh'
                   END;

    SET @bienSo = CASE @lptIdx
                      WHEN 1 THEN '59-X' + RIGHT('00' + CONVERT(VARCHAR(2), @i % 100), 2) + '-' + RIGHT('000' + CONVERT(VARCHAR(3), (@i * 7) % 1000), 3)
                      WHEN 2 THEN '51G-' + RIGHT('00000' + CONVERT(VARCHAR(5), (@i * 137) % 100000), 5)
                      WHEN 3 THEN '51C-' + RIGHT('00000' + CONVERT(VARCHAR(5), (@i * 211) % 100000), 5)
                      ELSE '51B-' + RIGHT('00000' + CONVERT(VARCHAR(5), (@i * 173) % 100000), 5)
                  END;

    SET @moTaPt = CASE @lptIdx
                      WHEN 1 THEN N'Xe mô tô Wave màu đen'
                      WHEN 2 THEN N'Ô tô con 4 chỗ màu trắng'
                      WHEN 3 THEN N'Xe tải nhỏ 1,5 tấn'
                      ELSE N'Xe khách 29 chỗ màu xanh'
                  END;

    SET @coQuyetDinh = CASE WHEN @i % 5 = 0 THEN 0 ELSE 1 END;
    SET @daNop = CASE WHEN @coQuyetDinh = 1 AND (@i % 7) IN (0, 2, 5) THEN 1 ELSE 0 END;
    SET @quaHan = CASE WHEN @coQuyetDinh = 1 AND @daNop = 0 AND @soNgayTruoc > 90 THEN 1 ELSE 0 END;

    SET @maTt = CASE
                    WHEN @daNop = 1 THEN 'TT02'
                    WHEN @quaHan = 1 THEN 'TT03'
                    ELSE 'TT01'
                END;

    INSERT INTO dbo.VI_PHAM
        (Ma_VuViec, ThoiGianViPham, DiaDiem, NongDoCon, BienSoXe, MoTaPhuongTien,
         Ma_LoaiViPham, Ma_LoaiPhuongTien, Ma_MucNongDoCon, Ma_CanBo, Ma_NguoiViPham, Ma_TrangThaiThanhToan)
    VALUES
        (@maVv, @thoiGian, @diaDiem, @nongDo, @bienSo, @moTaPt,
         @maLvp, @maLpt, @maMnd, @maCb, @maNvp, @maTt);

    IF @coQuyetDinh = 1
    BEGIN
        SET @soQuyetDinh += 1;
        SET @maQd = 'QD' + RIGHT('00000000' + CONVERT(VARCHAR(8), @soQuyetDinh), 8);
        SET @ngayRa = DATEADD(DAY, 2, CAST(@thoiGian AS DATE));
        SET @ngayNop = DATEADD(HOUR, 9, DATEADD(DAY, 3, CAST(@ngayRa AS DATETIME2(0))));
        SET @mucPhat = (SELECT MucPhat FROM dbo.LOAI_VI_PHAM WHERE Ma_LoaiViPham = @maLvp);

        INSERT INTO dbo.QUYET_DINH_XU_PHAT
            (Ma_QuyetDinh, Ma_VuViec, SoTienPhat, NgayRaQuyetDinh, NgayNopPhat, Ma_TrangThaiThanhToan)
        VALUES
            (@maQd, @maVv, 0, @ngayRa,
             CASE WHEN @daNop = 1 THEN CAST(@ngayNop AS DATE) ELSE NULL END,
             @maTt);

        IF @daNop = 1
        BEGIN
            SET @soThanhToan += 1;

            INSERT INTO dbo.THANH_TOAN
                (Ma_ThanhToan, Ma_QuyetDinh, NgayNop, SoTien, PhuongThuc, Ma_CanBo, GhiChu)
            VALUES
                ('BL' + RIGHT('00000000' + CONVERT(VARCHAR(8), @soThanhToan), 8),
                 @maQd, @ngayNop, @mucPhat,
                 CASE WHEN @soThanhToan % 2 = 0 THEN N'Chuyển khoản' ELSE N'Tiền mặt' END,
                 CASE WHEN @soThanhToan % 3 = 0 THEN 'CB00000001' ELSE 'CB00000005' END,
                 N'Thu tiền phạt theo quyết định ' + @maQd);
        END
    END

    SET @i += 1;
END
GO

/* ================= ĐỒNG BỘ SEQUENCE ================= */
ALTER SEQUENCE dbo.SEQ_NGUOI_VI_PHAM RESTART WITH 31;
ALTER SEQUENCE dbo.SEQ_CAN_BO        RESTART WITH 7;
ALTER SEQUENCE dbo.SEQ_TAI_KHOAN     RESTART WITH 7;
ALTER SEQUENCE dbo.SEQ_LOAI_PT       RESTART WITH 5;
ALTER SEQUENCE dbo.SEQ_MUC_NONG_DO   RESTART WITH 4;
ALTER SEQUENCE dbo.SEQ_LOAI_VI_PHAM  RESTART WITH 13;
ALTER SEQUENCE dbo.SEQ_VI_PHAM       RESTART WITH 61;
ALTER SEQUENCE dbo.SEQ_QUYET_DINH    RESTART WITH 49;
ALTER SEQUENCE dbo.SEQ_THANH_TOAN    RESTART WITH 22;
GO

/* ================= KIỂM TRA NHẤT QUÁN ================= */
IF EXISTS (
    SELECT 1
    FROM dbo.QUYET_DINH_XU_PHAT q
    JOIN dbo.VI_PHAM v ON v.Ma_VuViec = q.Ma_VuViec
    JOIN dbo.LOAI_VI_PHAM lv ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
    WHERE q.SoTienPhat <> lv.MucPhat
)
    THROW 50042, N'Seed lỗi: tiền phạt không khớp danh mục loại vi phạm.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.QUYET_DINH_XU_PHAT q
    JOIN dbo.VI_PHAM v ON v.Ma_VuViec = q.Ma_VuViec
    WHERE q.Ma_TrangThaiThanhToan <> v.Ma_TrangThaiThanhToan
)
    THROW 50043, N'Seed lỗi: trạng thái quyết định và vụ việc không đồng bộ.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.THANH_TOAN p
    JOIN dbo.QUYET_DINH_XU_PHAT q ON q.Ma_QuyetDinh = p.Ma_QuyetDinh
    WHERE p.SoTien <> q.SoTienPhat OR q.Ma_TrangThaiThanhToan <> 'TT02'
)
    THROW 50044, N'Seed lỗi: biên lai thanh toán không khớp quyết định.', 1;
GO

SELECT N'VAI_TRO' AS Bang, COUNT(*) AS SoLuong FROM dbo.VAI_TRO
UNION ALL SELECT N'CAN_BO', COUNT(*) FROM dbo.CAN_BO
UNION ALL SELECT N'TAI_KHOAN', COUNT(*) FROM dbo.TAI_KHOAN
UNION ALL SELECT N'NGUOI_VI_PHAM', COUNT(*) FROM dbo.NGUOI_VI_PHAM
UNION ALL SELECT N'VI_PHAM', COUNT(*) FROM dbo.VI_PHAM
UNION ALL SELECT N'QUYET_DINH_XU_PHAT', COUNT(*) FROM dbo.QUYET_DINH_XU_PHAT
UNION ALL SELECT N'THANH_TOAN', COUNT(*) FROM dbo.THANH_TOAN;
GO

PRINT N'Đã nạp dữ liệu mẫu.';
GO
