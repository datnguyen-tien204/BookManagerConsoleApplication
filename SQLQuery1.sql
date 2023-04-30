CREATE PROCEDURE QLSach
	@Masach nvarchar(200),
	@TenSach nvarchar(200),
	@Soluong int,
    @TacGia nvarchar(200),
    @Nhaxuatban nvarchar(200),
    @Chungloai nvarchar(200),
	@Giaban float
AS
   INSERT INTO QLSach(Masach,Tensach,Soluong,Tacgia,Chungloai,Nhaxuatban,Giaban)
   VALUES(@Masach,@TenSach,@Soluong,@TacGia,@Chungloai,@Nhaxuatban,@Giaban) 