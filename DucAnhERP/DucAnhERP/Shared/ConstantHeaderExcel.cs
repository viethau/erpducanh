using OfficeOpenXml.Style;

namespace DucAnhERP.Shared
{
    public class ConstantHeaderExcel
    {
        //Phân loại
        public static List<ComplexHeader> PHANLOAIHOGA_HEADERS = new List<ComplexHeader>
            {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin hố ga sau phân loại", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 42,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin chiếm chỗ hố ga", StartRow = 16, EndRow = 16, StartCol = 43, EndCol = 74,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                new ComplexHeader { Title = "Thông tin cấu tạo hố ga", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 8,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin phủ bì hố ga (m)", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 10,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kích thước hình học bê tông lót móng hố ga (m)", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 13,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kích thước hình học bê tông móng hố ga (m)", StartRow = 17, EndRow = 17, StartCol = 14, EndCol = 16,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KTHH đế hố ga", StartRow = 17, EndRow = 17, StartCol = 17, EndCol = 19,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kích thước hình học tường hố ga (m)", StartRow = 17, EndRow = 17, StartCol = 20, EndCol = 23,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KTHH dầm giữa hố ga", StartRow = 17, EndRow = 17, StartCol = 24, EndCol = 28,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Chát hố ga mặt trong", StartRow = 17, EndRow = 17, StartCol = 29, EndCol = 31,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Chát hố ga mặt ngoài, cạnh 01 +02 (m)", StartRow = 17, EndRow = 17, StartCol = 32, EndCol = 34,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kích thước hình học tường mũ mố thớt dưới (m)", StartRow = 17, EndRow = 17, StartCol = 35, EndCol = 38,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kích thước hình học tường mũ mố thớt trên (m)", StartRow = 17, EndRow = 17, StartCol = 39, EndCol = 42,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 43, EndCol = 46,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 47, EndCol = 50,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 51, EndCol = 54,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 55, EndCol = 58,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 59, EndCol = 62,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 63, EndCol = 66,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 67, EndCol = 70,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức đấu nối", StartRow = 17, EndRow = 17, StartCol = 71, EndCol = 74,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                new ComplexHeader { Title = "Phân loại hố ga", DataProperty="ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 18, EndRow = 18, StartCol = 1, EndCol = 1,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức hố ga", DataProperty="ThongTinChungHoGa_HinhThucHoGa_Name", StartRow = 18, EndRow = 18, StartCol = 2, EndCol = 2,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kết cấu mũ mố", DataProperty="ThongTinChungHoGa_KetCauMuMo_Name", StartRow = 18, EndRow = 18, StartCol = 3, EndCol = 3,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kết cấu tường", DataProperty="ThongTinChungHoGa_KetCauTuong_Name", StartRow = 18, EndRow = 18, StartCol = 4, EndCol = 4,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức móng hố ga", DataProperty="ThongTinChungHoGa_HinhThucMongHoGa_Name", StartRow = 18, EndRow = 18, StartCol = 5, EndCol = 5,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kết cấu móng", DataProperty="ThongTinChungHoGa_KetCauMong_Name", StartRow = 18, EndRow = 18, StartCol = 6, EndCol = 6,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Chát mặt trong", DataProperty="ThongTinChungHoGa_ChatMatTrong_Name", StartRow = 18, EndRow = 18, StartCol = 7, EndCol = 7,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Chát mặt ngoài", DataProperty="ThongTinChungHoGa_ChatMatNgoai_Name", StartRow = 18, EndRow = 18, StartCol = 8, EndCol = 8,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C.Dài (m)", DataProperty="PhuBiHoGa_CDai", StartRow = 18, EndRow = 18, StartCol = 9, EndCol = 9,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C.rộng (m)", DataProperty="PhuBiHoGa_CRong", StartRow = 18, EndRow = 18, StartCol = 10, EndCol = 10,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="BeTongLotMong_D", StartRow = 18, EndRow = 18, StartCol = 11, EndCol = 11,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="BeTongLotMong_R", StartRow = 18, EndRow = 18, StartCol = 12, EndCol = 12,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="BeTongLotMong_C", StartRow = 18, EndRow = 18, StartCol = 13, EndCol = 13,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="BeTongMongHoGa_D", StartRow = 18, EndRow = 18, StartCol = 14, EndCol = 14,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="BeTongMongHoGa_R", StartRow = 18, EndRow = 18, StartCol = 15, EndCol = 15,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="BeTongMongHoGa_C", StartRow = 18, EndRow = 18, StartCol = 16, EndCol = 16,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="DeHoGa_D", StartRow = 18, EndRow = 18, StartCol = 17, EndCol = 17,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="DeHoGa_R", StartRow = 18, EndRow = 18, StartCol = 18, EndCol = 18,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="DeHoGa_C", StartRow = 18, EndRow = 18, StartCol = 19, EndCol = 19,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="TuongHoGa_D", StartRow = 18, EndRow = 18, StartCol = 20, EndCol = 20,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="TuongHoGa_R", StartRow = 18, EndRow = 18, StartCol = 21, EndCol = 21,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="TuongHoGa_C", StartRow = 18, EndRow = 18, StartCol = 22, EndCol = 22,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CD tường (m) ", DataProperty="TuongHoGa_CdTuong", StartRow = 18, EndRow = 18, StartCol = 23, EndCol = 23,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="DamGiuaHoGa_D", StartRow = 18, EndRow = 18, StartCol = 24, EndCol = 24,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="DamGiuaHoGa_C", StartRow = 18, EndRow = 18, StartCol = 25, EndCol = 25,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="DamGiuaHoGa_C", StartRow = 18, EndRow = 18, StartCol = 26, EndCol = 26,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CD dầm (m) ", DataProperty="DamGiuaHoGa_CdDam", StartRow = 18, EndRow = 18, StartCol = 27, EndCol = 27,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C.Cao dầm giữa tường so với đáy hố ga (m) ", DataProperty="DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa", StartRow = 18, EndRow = 18, StartCol = 28, EndCol = 28,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="ChatMatTrong_D", StartRow = 18, EndRow = 18, StartCol = 29, EndCol = 29,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="ChatMatTrong_R", StartRow = 18, EndRow = 18, StartCol = 30, EndCol = 30,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="ChatMatTrong_C", StartRow = 18, EndRow = 18, StartCol = 31, EndCol = 31,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="ChatMatNgoaiCanh_D", StartRow = 18, EndRow = 18, StartCol = 32, EndCol = 32,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="ChatMatNgoaiCanh_R", StartRow = 18, EndRow = 18, StartCol =33, EndCol = 33,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="ChatMatNgoaiCanh_C", StartRow = 18, EndRow = 18, StartCol = 34, EndCol = 34,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="MuMoThotDuoi_D", StartRow = 18, EndRow = 18, StartCol = 35, EndCol = 35,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="MuMoThotDuoi_R", StartRow = 18, EndRow = 18, StartCol = 36, EndCol = 36,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="MuMoThotDuoi_C", StartRow = 18, EndRow = 18, StartCol = 37, EndCol = 37,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CD tường (m) ", DataProperty="MuMoThotDuoi_CdTuong", StartRow = 18, EndRow = 18, StartCol = 38, EndCol = 38,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D (m) ", DataProperty="MuMoThotTren_D", StartRow = 18, EndRow = 18, StartCol = 39, EndCol = 39,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "R (m) ", DataProperty="MuMoThotTren_R", StartRow = 18, EndRow = 18, StartCol = 40, EndCol = 40,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C (m) ", DataProperty="MuMoThotTren_C", StartRow = 18, EndRow = 18, StartCol = 41, EndCol = 41,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CD tường (m) ", DataProperty="MuMoThotTren_CdTuong", StartRow = 18, EndRow = 18, StartCol = 42, EndCol = 42,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi1_Loai", StartRow = 18, EndRow = 18, StartCol = 43, EndCol = 43,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi1_CanhDai", StartRow = 18, EndRow = 18, StartCol = 44, EndCol = 44,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi1_CanhRong", StartRow = 18, EndRow = 18, StartCol = 45, EndCol = 45,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi1_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 46, EndCol = 46,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi2_Loai", StartRow = 18, EndRow = 18, StartCol = 47, EndCol = 47,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi2_CanhDai", StartRow = 18, EndRow = 18, StartCol = 48, EndCol = 48,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi2_CanhRong", StartRow = 18, EndRow = 18, StartCol = 49, EndCol = 49,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi2_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 50, EndCol = 50,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi3_Loai", StartRow = 18, EndRow = 18, StartCol = 51, EndCol = 51,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi3_CanhDai", StartRow = 18, EndRow = 18, StartCol = 52, EndCol = 52,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi3_CanhRong", StartRow = 18, EndRow = 18, StartCol = 53, EndCol = 53,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi3_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 54, EndCol = 54,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi4_Loai", StartRow = 18, EndRow = 18, StartCol = 55, EndCol = 55,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi4_CanhDai", StartRow = 18, EndRow = 18, StartCol = 56, EndCol = 56,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi4_CanhRong", StartRow = 18, EndRow = 18, StartCol = 57, EndCol = 57,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi4_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 58, EndCol = 58,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi5_Loai", StartRow = 18, EndRow = 18, StartCol = 59, EndCol = 59,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi5_CanhDai", StartRow = 18, EndRow = 18, StartCol = 60, EndCol = 60,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi5_CanhRong", StartRow = 18, EndRow = 18, StartCol = 61, EndCol = 61,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi5_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 62, EndCol = 62,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi6_Loai", StartRow = 18, EndRow = 18, StartCol = 63, EndCol = 63,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi6_CanhDai", StartRow = 18, EndRow = 18, StartCol = 64, EndCol = 64,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi6_CanhRong", StartRow = 18, EndRow = 18, StartCol = 65, EndCol = 65,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi6_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 66, EndCol = 66,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi7_Loai", StartRow = 18, EndRow = 18, StartCol = 67, EndCol = 67,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi7_CanhDai", StartRow = 18, EndRow = 18, StartCol = 68, EndCol = 68,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi7_CanhRong", StartRow = 18, EndRow = 18, StartCol = 69, EndCol = 69,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi7_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 70, EndCol = 70,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Loại ", DataProperty="HinhThucDauNoi8_Loai", StartRow = 18, EndRow = 18, StartCol = 71, EndCol = 71,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh dài", DataProperty="HinhThucDauNoi8_CanhDai", StartRow = 18, EndRow = 18, StartCol = 72, EndCol = 72,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh rộng", DataProperty="HinhThucDauNoi8_CanhRong", StartRow = 18, EndRow = 18, StartCol = 73, EndCol = 73,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cạnh chéo ", DataProperty="HinhThucDauNoi8_CanhCheo", StartRow = 18, EndRow = 18, StartCol = 74, EndCol = 74,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                };
        public static List<ComplexHeader> PHANLOAITDHG_HEADERS = new List<ComplexHeader>
            {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI TẤM ĐAN HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Loại tròn", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại vuông hoặc chữ nhật", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
               
                new ComplexHeader { Title = "Phân loại tấm đan", DataProperty = "ThongTinTamDanHoGa2_PhanLoaiDayHoGa", StartRow = 16, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức đậy hố ga", DataProperty = "ThongTinTamDanHoGa2_HinhThucDayHoGa_Name", StartRow = 16, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính (m)", DataProperty = "ThongTinTamDanHoGa2_DuongKinh", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dầy (m)", DataProperty = "ThongTinTamDanHoGa2_ChieuDay", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                };
        public static List<ComplexHeader> PHANLOAICONG_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI CỐNG", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin chung", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đế", StartRow = 16, EndRow = 16, StartCol = 10, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Thân", StartRow = 16, EndRow = 16, StartCol = 12, EndCol = 15, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Mũ mố", StartRow = 16, EndRow = 16, StartCol = 16, EndCol = 19, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát", StartRow = 16, EndRow = 16, StartCol = 20, EndCol = 21, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "Phân loại cống", DataProperty = "ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai", StartRow = 16, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_HinhThucTruyenDan_Name", StartRow = 16, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 16, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dài C.Kiện (C.Tròn, C.Hộp)", DataProperty = "TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien", StartRow = 16, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dầy phủ bì cống tròn (m)", DataProperty = "ThongTinCauTaoCongTron_CDayPhuBi", StartRow = 16, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo tường", DataProperty = "TTKTHHCongHopRanh_CauTaoTuong_Name", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo mũ mố", DataProperty = "TTKTHHCongHopRanh_CauTaoMuMo_Name", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát mặt trong", DataProperty = "TTKTHHCongHopRanh_ChatMatTrong_Name", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát mặt ngoài", DataProperty = "TTKTHHCongHopRanh_ChatMatNgoai_Name", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao đế (m)", DataProperty = "TTKTHHCongHopRanh_CCaoDe", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng đế (m)", DataProperty = "TTKTHHCongHopRanh_CRongDe", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dầy tường 01 bên (m)", DataProperty = "TTKTHHCongHopRanh_CDayTuong01Ben", StartRow = 16, EndRow = 16, StartCol = 12, EndCol = 12, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "Số lượng tường (m)", DataProperty = "TTKTHHCongHopRanh_SoLuongTuong", StartRow = 17, EndRow = 17, StartCol = 13, EndCol = 13, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng lòng sử dụng (m)", DataProperty = "TTKTHHCongHopRanh_CRongLongSuDung", StartRow = 17, EndRow = 17, StartCol = 14, EndCol = 14, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao tường gộp", DataProperty = "TTKTHHCongHopRanh_CCaoTuongGop", StartRow = 17, EndRow = 17, StartCol = 15, EndCol = 15, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao mũ mố thớt dưới (m)", DataProperty = "TTKTHHCongHopRanh_CCaoMuMoThotDuoi", StartRow = 17, EndRow = 17, StartCol = 16, EndCol = 16, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng mũ mố dưới", DataProperty = "TTKTHHCongHopRanh_CRongMuMoDuoi", StartRow = 17, EndRow = 17, StartCol = 17, EndCol = 17, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao mũ mố thớt trên (m)", DataProperty = "TTKTHHCongHopRanh_CCaoMuMoThotTren", StartRow = 17, EndRow = 17, StartCol = 18, EndCol = 18, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng mũ mố trên", DataProperty = "TTKTHHCongHopRanh_CRongMuMoTren", StartRow = 17, EndRow = 17, StartCol = 19, EndCol = 19, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao chát mặt trong (m)", DataProperty = "TTKTHHCongHopRanh_CCaoChatMatTrong", StartRow = 17, EndRow = 17, StartCol = 20, EndCol = 20, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao chát mặt ngoài (m)", DataProperty = "TTKTHHCongHopRanh_CCaoChatMatNgoai", StartRow = 17, EndRow = 17, StartCol = 21, EndCol = 21, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dầy phủ bì ống nhựa (m)", DataProperty = "ThongTinKichThuocHinhHocOngNhua_CDayPhuBi", StartRow = 16, EndRow = 17, StartCol = 22, EndCol = 22, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                };
        public static List<ComplexHeader> PHANLOAIMONG_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI MÓNG", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                
                new ComplexHeader { Title = "PL móng", DataProperty = "ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_HinhThucTruyenDan_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại móng", DataProperty = "ThongTinMongDuongTruyenDan_LoaiMong_Name", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức móng", DataProperty = "ThongTinMongDuongTruyenDan_HinhThucMong_Name", StartRow = 16, EndRow = 16, StartCol = 5, EndCol =5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao lót móng (m)", DataProperty = "ThongTinCauTaoCongTron_CCaoLotMong", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng lót móng", DataProperty = "ThongTinCauTaoCongTron_CRongLotMong", StartRow = 16, EndRow = 16, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao móng (m)", DataProperty = "ThongTinCauTaoCongTron_CCaoMong", StartRow = 16, EndRow = 16, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng móng (m)", DataProperty = "ThongTinCauTaoCongTron_CRongMong", StartRow = 16, EndRow = 16, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                };
        public static List<ComplexHeader> PHANLOAIDECONG_HEADERS = new List<ComplexHeader>
            {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI ĐẾ CỐNG", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                
                new ComplexHeader { Title = "Phân loại đế cống", DataProperty = "ThongTinDeCong_TenLoaiDeCong", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo đế cống", DataProperty = "ThongTinDeCong_CauTaoDeCong_Name", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "D", DataProperty = "ThongTinDeCong_D", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R", DataProperty = "ThongTinDeCong_R", StartRow = 16, EndRow = 16, StartCol = 5, EndCol =5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C", DataProperty = "ThongTinDeCong_C", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
               
                };
        public static List<ComplexHeader> PHANLOAITHANHCHONG_HEADERS = new List<ComplexHeader>
        {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI THANH CHỐNG", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Phân loại thanh chống", DataProperty = "TTKTHHCongHopRanh_LoaiThanhChong", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo thanh chống rãnh", DataProperty = "TTKTHHCongHopRanh_CauTaoThanhChong_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao thanh chống (m)", DataProperty = "TTKTHHCongHopRanh_CCaoThanhChong", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng thanh chống (m)", DataProperty = "TTKTHHCongHopRanh_CRongThanhChong", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dài (m)", DataProperty = "TTKTHHCongHopRanh_CDai", StartRow = 16, EndRow = 16, StartCol = 5, EndCol =5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
        };
        public static List<ComplexHeader> PHANLOAITDTD_HEADERS = new List<ComplexHeader>
        {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG PHÂN LOẠI TẤM ĐAN TRUYỀN DẪN", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "PL tấm đan tiêu chuẩn", DataProperty = "TTTDCongHoRanh_TenLoaiTamDanTieuChuan", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Từ lý trình", DataProperty = "ThongTinLyTrinhTruyenDan_TuLyTrinh", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đến lý trình", DataProperty = "ThongTinLyTrinhTruyenDan_DenLyTrinh", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_HinhThucTruyenDan_Name", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại truyền dẫn", DataProperty = "ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 16, EndRow = 16, StartCol = 5, EndCol =5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo tấm đan truyền dẫn", DataProperty = "TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name", StartRow = 16, EndRow = 16, StartCol = 6, EndCol =6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dài", DataProperty = "TTTDCongHoRanh_CDai", StartRow = 16, EndRow = 16, StartCol = 7, EndCol =7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Rộng", DataProperty = "TTTDCongHoRanh_CRong", StartRow = 16, EndRow = 16, StartCol = 8, EndCol =8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao ", DataProperty = "TTTDCongHoRanh_CCao", StartRow = 16, EndRow = 16, StartCol = 9, EndCol =9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

        };
        //Báo cáo
        public static List<ComplexHeader> TTHGA_HEADERS = new List<ComplexHeader>
        {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THÔNG TIN TỔNG HỢP HỐ GA NƯỚC MƯA DỌC PHÍA TRÁI", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 23, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center, IsUppercase = true,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Bảng này in (in theo từng tuyến) làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin lý trình", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 3,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin cấu tạo hố ga", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 5,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin tấm đan hố ga", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 7,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin truyền dẫn", StartRow = 16, EndRow = 16, StartCol = 8, EndCol = 9,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin cao độ hố ga", StartRow = 16, EndRow = 16, StartCol = 10, EndCol = 21,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tọa độ", StartRow = 16, EndRow = 16, StartCol = 22, EndCol = 23,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                new ComplexHeader { Title = "STT",DataProperty="STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tuyến đường", DataProperty="ThongTinLyTrinh_TuyenDuong", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Lý trình tại tim hố ga", DataProperty="ThongTinLyTrinh_LyTrinhTaiTimHoGa", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty="PhanLoaiHoGas_TenHoGaSauPhanLoai", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên hố ga theo bản vẽ", DataProperty="ThongTinChungHoGa_TenHoGaTheoBanVe", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên loại tấm đan", DataProperty="PhanLoaiTDHoGa_PhanLoaiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Số lượng tấm đan (C.Kiện)", DataProperty="ThongTinTamDanHoGa2_SoLuongNapDay", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Hình thức truyền dẫn", DataProperty="ThongTinDuongTruyenDan_HinhThucTruyenDan_Name", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên loại truyền dẫn sau phân loại", DataProperty="ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 17, EndRow = 17, StartCol = 9, EndCol =9,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Cao độ hiện trạng trước khi đào (m)", DataProperty="ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đáy đào", DataProperty="ThongTinCaoDoHoGa_DayDao", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C.Sâu đào", DataProperty="ThongTinCaoDoHoGa_CSauDao", StartRow = 17, EndRow = 17, StartCol = 12, EndCol = 12,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh lót móng", DataProperty="ThongTinCaoDoHoGa_DinhLotMong", StartRow = 17, EndRow = 17, StartCol = 13, EndCol = 13,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh móng", DataProperty="ThongTinCaoDoHoGa_CdDinhMong", StartRow = 17, EndRow = 17, StartCol = 14, EndCol = 14,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CĐ đáy hố ga (m)", DataProperty="ThongTinCaoDoHoGa_CdDayHoGa", StartRow = 17, EndRow = 17, StartCol = 15, EndCol = 15,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "C.Cao tường (m)", DataProperty="ThongTinCaoDoHoGa_CCaoTuong", StartRow = 17, EndRow = 17, StartCol = 16, EndCol = 16,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh tường dưới dầm giữa tường (m)", DataProperty="ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong", StartRow = 17, EndRow = 17, StartCol = 17, EndCol = 17,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh dầm giữa tường (m)", DataProperty="ThongTinCaoDoHoGa_DinhDamGiuaTuong", StartRow = 17, EndRow = 17, StartCol = 18, EndCol = 18,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh tường (m)", DataProperty="ThongTinCaoDoHoGa_DinhTuong", StartRow = 17, EndRow = 17, StartCol = 19, EndCol = 19,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đỉnh mũ mố thớt dưới (m)", DataProperty="ThongTinCaoDoHoGa_DinhMuMoThotDuoi", StartRow = 17, EndRow = 17, StartCol = 20, EndCol = 20,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CĐ đỉnh hố ga (m)", DataProperty="ThongTinCaoDoHoGa_CdDinhHoGa", StartRow = 17, EndRow = 17, StartCol = 21, EndCol = 21,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "X", DataProperty="ToaDoX", StartRow = 17, EndRow = 17, StartCol = 22, EndCol = 22,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Y", DataProperty="ToaDoY", StartRow = 17, EndRow = 17, StartCol = 23, EndCol = 23,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
        };
        public static List<ComplexHeader> TTHKLBPD_HEADERS = new List<ComplexHeader>
        {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THÔNG TIN TỔNG HỢP ĐÀO BIỆN PHÁP HỐ GA NƯỚC MƯA DỌC PHÍA TRÁI", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 23, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center, IsUppercase = true,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Bảng này in (in theo từng tuyến) làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 23, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin lý trình", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 5,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin loại vật liệu đào", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 8,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin mái đào", StartRow = 16, EndRow = 16, StartCol = 9, EndCol = 12,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Thông tin diện tích", StartRow = 16, EndRow = 16, StartCol = 13, EndCol = 16,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kl đào", StartRow = 16, EndRow = 16, StartCol = 17, EndCol = 19,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KL chiếm chỗ", StartRow = 16, EndRow = 16, StartCol = 20, EndCol = 22,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KL đắp trả", StartRow = 16, EndRow = 16, StartCol = 23, EndCol = 25,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                new ComplexHeader { Title = "STT",DataProperty="STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tuyến đường", DataProperty="ThongTinLyTrinh_TuyenDuong", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Lý trình tại tim hố ga", DataProperty="ThongTinLyTrinh_LyTrinhTaiTimHoGa", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty="PhanLoaiHoGas_TenHoGaSauPhanLoai", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên hố ga theo bản vẽ", DataProperty="ThongTinChungHoGa_TenHoGaTheoBanVe", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                
                new ComplexHeader { Title = "Loại vật liệu đào", DataProperty="ThongTinVatLieuDaoHoGa_LoaiVatLieuDao_Name", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đào đá (m)", DataProperty="ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Đào đất (m)", DataProperty="ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tên loại truyền dẫn sau phân loại", DataProperty="ThongTinDuongTruyenDan_LoaiTruyenDan_Name", StartRow = 17, EndRow = 17, StartCol = 9, EndCol =9,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CR đáy đào nhỏ (m)", DataProperty="ThongTinMaiDao_ChieuRongDayDaoNho", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tỷ lệ mở mái (m)", DataProperty="ThongTinMaiDao_TyLeMoMai", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Số cạnh mái trái", DataProperty="ThongTinMaiDao_SoCanhMaiTrai", StartRow = 17, EndRow = 17, StartCol = 12, EndCol = 12,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Số cạnh mái phải", DataProperty="ThongTinMaiDao_SoCanhMaiPhai", StartRow = 17, EndRow = 17, StartCol = 13, EndCol = 13,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CR hố móng đáy đào lớn đất (m)", DataProperty="TTKLD_CRongDaoDayLonDat", StartRow = 17, EndRow = 17, StartCol = 14, EndCol = 14,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "CR hố móng đáy đào lớn đá (m)", DataProperty="TTKLD_CRongDaoDayLonDa", StartRow = 17, EndRow = 17, StartCol = 15, EndCol = 15,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Diện tích đất (m2)", DataProperty="TTKLD_DienTichDaoDat", StartRow = 17, EndRow = 17, StartCol = 16, EndCol = 16,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "D.Tích đá (m2)", DataProperty="TTKLD_DienTichDaoDa", StartRow = 17, EndRow = 17, StartCol = 17, EndCol = 17,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Khối lượng đào đất (m3)", DataProperty="TTKLD_KlDaoDat", StartRow = 17, EndRow = 17, StartCol = 18, EndCol = 18,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tổng đào (m3)", DataProperty="TTKLD_TongKlDao", StartRow = 17, EndRow = 17, StartCol = 19, EndCol = 19,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KL chiếm chỗ đất (m3)", DataProperty="TTKLD_KlChiemChoDat", StartRow = 17, EndRow = 17, StartCol = 20, EndCol = 20,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "KL chiếm chỗ đá (m3)", DataProperty="TTKLD_KlChiemChoDa", StartRow = 17, EndRow = 17, StartCol = 21, EndCol = 21,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},

                new ComplexHeader { Title = "Tổng C.chỗ (m3)", DataProperty="TTKLD_TongChiemCho", StartRow = 17, EndRow = 17, StartCol = 22, EndCol = 22,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kl đắp trả đất (m3)", DataProperty="TTKLD_KlDapTraDat", StartRow = 17, EndRow = 17, StartCol = 23, EndCol = 23,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Kl đắp trả đá (m3)", DataProperty="TTKLD_KlDapTraDa", StartRow = 17, EndRow = 17, StartCol = 24, EndCol = 24,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                new ComplexHeader { Title = "Tổng đắp trả (m3)", DataProperty="TTKLD_TongDapTra", StartRow = 17, EndRow = 17, StartCol = 25, EndCol = 25,IsBold=true ,HasBorder = true ,WrapText=true , Alignment = ExcelHorizontalAlignment.Center},
                
        };
        public static List<ComplexHeader> CTCHG_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THÔNG TIN CẤU TẠO CHUNG HỐ GA SAU PHÂN LOẠI", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin tên hố ga", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Thông tin phủ bì hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 10, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức hố ga", DataProperty = "ThongTinChungHoGa_HinhThucHoGa_Name", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu mũ mố", DataProperty = "ThongTinChungHoGa_KetCauMuMo_Name", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu tường", DataProperty = "ThongTinChungHoGa_KetCauTuong_Name", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức móng hố ga", DataProperty = "ThongTinChungHoGa_HinhThucMongHoGa_Name", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu móng", DataProperty = "ThongTinChungHoGa_KetCauMong_Name", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát mặt trong", DataProperty = "ThongTinChungHoGa_ChatMatTrong_Name", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát mặt ngoài", DataProperty = "ThongTinChungHoGa_ChatMatNgoai_Name", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Dài (m)", DataProperty = "PhuBiHoGa_CDai", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.rộng (m)", DataProperty = "PhuBiHoGa_CRong", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                };
        public static List<ComplexHeader> KHHGTD_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG KẾT HỢP HỐ GA VÀ TẤM ĐAN", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin chung", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại tròn", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại vuông hoặc chữ nhật", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại hố ga", DataProperty = "PhanLoaiHoGas_TenHoGaSauPhanLoai", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại nắp đậy hố ga", DataProperty = "PhanLoaiTDHoGa_PhanLoaiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính (m)", DataProperty = "ThongTinTamDanHoGa2_DuongKinh", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dầy (m)", DataProperty = "ThongTinTamDanHoGa2_ChieuDay", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số lượng nắp đậy (C.Kiện)", DataProperty = "ThongTinTamDanHoGa2_SoLuongNapDay", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                };
        public static List<ComplexHeader> KTHHTDHG_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG KÍCH THƯỚC HÌNH HỌC TẤM ĐAN HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin chung", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại tròn", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại vuông hoặc chữ nhật", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại nắp đậy hố ga", DataProperty = "ThongTinTamDanHoGa2_PhanLoaiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính (m)", DataProperty = "ThongTinTamDanHoGa2_DuongKinh", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dầy (m)", DataProperty = "ThongTinTamDanHoGa2_ChieuDay", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
  
                };
        public static List<ComplexHeader> TONGSLHG_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG KÍCH THƯỚC HÌNH HỌC TẤM ĐAN HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Trái tuyến", DataProperty = "countTrai", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Phải tuyến", DataProperty = "countPhai", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng", DataProperty = "Tong", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                

            };
        public static List<ComplexHeader> TONGSLHGTT_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ SỐ LƯỢNG HỐ GA THEO TUYẾN", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Tuyến đường", DataProperty = "ThongTinLyTrinh_TuyenDuong", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Trái tuyến", DataProperty = "countTrai", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Phải tuyến", DataProperty = "countPhai", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng", DataProperty = "Tong", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
            };
        public static List<ComplexHeader> TONGSLTDHG_HEADERS = new List<ComplexHeader>
         {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ SỐ LƯỢNG TẤM ĐAN HỐ GA THEO TUYẾN", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin chung", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại tròn", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại vuông hoặc chữ nhật", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số lượng", StartRow = 16, EndRow = 16, StartCol = 8, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên tấm đan sau phân loại", DataProperty = "ThongTinTamDanHoGa2_PhanLoaiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính (m)", DataProperty = "ThongTinTamDanHoGa2_DuongKinh", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dầy (m)", DataProperty = "ThongTinTamDanHoGa2_ChieuDay", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Trái", DataProperty = "countTrai", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Phải", DataProperty = "countPhai", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng", DataProperty = "Tong", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
         };
        public static List<ComplexHeader> TONGSLTDHGTT_HEADERS = new List<ComplexHeader>
         {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ SỐ LƯỢNG TẤM ĐAN HỐ GA THEO TUYẾN", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin chung", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại tròn", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại vuông hoặc chữ nhật", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số lượng", StartRow = 16, EndRow = 16, StartCol = 9, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tuyến đường", DataProperty = "ThongTinLyTrinh_TuyenDuong", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên tấm đan sau phân loại", DataProperty = "ThongTinTamDanHoGa2_PhanLoaiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính (m)", DataProperty = "ThongTinTamDanHoGa2_DuongKinh", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dầy (m)", DataProperty = "ThongTinTamDanHoGa2_ChieuDay", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Trái", DataProperty = "countTrai", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Phải", DataProperty = "countPhai", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng", DataProperty = "Tong", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
         };
        public static List<ComplexHeader> HGASDTHEP_HEADERS = new List<ComplexHeader>
            {
                 // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ HỐ GA CÓ SỬ DỤNG THÉP", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Tên hố ga", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu mũ mố", DataProperty = "ThongTinChungHoGa_KetCauMuMo_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu tường", DataProperty = "ThongTinChungHoGa_KetCauTuong_Name", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kết cấu móng", DataProperty = "ThongTinChungHoGa_KetCauMong_Name", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
        };
        public static List<ComplexHeader> TDHGSDT_HEADERS = new List<ComplexHeader>
         {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ TẤM ĐAN HỐ GA CÓ SỬ DỤNG THÉP", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                // Header thông tin chi tiết
                new ComplexHeader { Title = "Loại tấm đan", DataProperty = "ThongTinTamDanHoGa2_PhanLoaiDayHoGa", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Cấu tạo tấm đan", DataProperty = "ThongTinTamDanHoGa2_HinhThucDayHoGa_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "D (m)", DataProperty = "ThongTinTamDanHoGa2_D", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ThongTinTamDanHoGa2_R", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ThongTinTamDanHoGa2_C", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
         };
        public static List<ComplexHeader> KTHHHG_HEADERS = new List<ComplexHeader>
         {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG KÍCH THƯỚC HÌNH HOC CƠ BẢN HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Qui ước kích thước hình học: Chiều dài là chiều song song với đường; Chiều rộng là chiều vuông góc với đường; Chiều cao là chiều từ đáy đến đỉnh; Chiều rộng là chiều rộng của cấu kiện.", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Những bảng sử dụng số liệu tại bảng này bị thay đổi nếu số liệu tại bảng này bị thay đổi.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, tính khối lượng, thi công, nghiệm thu, hoàn công ", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "Thông tin tên hố ga", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kích thước hình học bê tông lót móng hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kích thước hình học bê tông móng hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 7, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "KTHH đế hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 10, EndCol = 12, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kích thước hình học tường hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 13, EndCol = 16, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "KTHH dầm giữa hố ga (m)", StartRow = 16, EndRow = 16, StartCol = 17, EndCol = 21, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát hố ga mặt trong (m) ", StartRow = 16, EndRow = 16, StartCol = 22, EndCol = 24, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chát hố ga mặt ngoài, cạnh 01 +02 (m)", StartRow = 16, EndRow = 16, StartCol = 25 , EndCol = 27, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kích thước hình học tường mũ mố thớt dưới (m)", StartRow = 16, EndRow = 16, StartCol = 28, EndCol = 31, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Kích thước hình học tường mũ mố thớt trên (m)", StartRow = 16, EndRow = 16, StartCol = 32, EndCol = 35, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 17, EndRow = 17, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên hố ga sau phân loại", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai", StartRow = 17, EndRow = 17, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Hình thức hố ga", DataProperty = "ThongTinChungHoGa_HinhThucHoGa_Name", StartRow = 17, EndRow = 17, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
               
                new ComplexHeader { Title = "D (m)", DataProperty = "BeTongLotMong_D", StartRow = 17, EndRow = 17, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "BeTongLotMong_R", StartRow = 17, EndRow = 17, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "BeTongLotMong_C", StartRow = 17, EndRow = 17, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "BeTongMongHoGa_D", StartRow = 17, EndRow = 17, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "BeTongMongHoGa_R", StartRow = 17, EndRow = 17, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "BeTongMongHoGa_C", StartRow = 17, EndRow = 17, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "DeHoGa_D", StartRow = 17, EndRow = 17, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "DeHoGa_R", StartRow = 17, EndRow = 17, StartCol = 11, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "DeHoGa_C", StartRow = 17, EndRow = 17, StartCol = 12, EndCol = 12, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "TuongHoGa_D", StartRow = 17, EndRow = 17, StartCol = 13, EndCol = 13, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "TuongHoGa_R", StartRow = 17, EndRow = 17, StartCol = 14, EndCol = 14, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "TuongHoGa_C", StartRow = 17, EndRow = 17, StartCol = 15, EndCol = 15, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "CD tường", DataProperty = "TuongHoGa_CdTuong", StartRow = 17, EndRow = 17, StartCol = 16, EndCol = 16, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "DamGiuaHoGa_D", StartRow = 17, EndRow = 17, StartCol = 17, EndCol = 17, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "DamGiuaHoGa_R", StartRow = 17, EndRow = 17, StartCol = 18, EndCol = 18, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "DamGiuaHoGa_C", StartRow = 17, EndRow = 17, StartCol = 19, EndCol = 19, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "CD tường", DataProperty = "DamGiuaHoGa_CdDam", StartRow = 17, EndRow = 17, StartCol = 20, EndCol = 20, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C.Cao dầm giữa tường so với đáy HG", DataProperty = "DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa", StartRow = 17, EndRow = 17, StartCol = 21, EndCol = 21, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "ChatMatTrong_D", StartRow = 17, EndRow = 17, StartCol = 22, EndCol = 22, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ChatMatTrong_R", StartRow = 17, EndRow = 17, StartCol = 23, EndCol = 23, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ChatMatTrong_C", StartRow = 17, EndRow = 17, StartCol = 24, EndCol = 24, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "ChatMatNgoaiCanh_D", StartRow = 17, EndRow = 17, StartCol = 25, EndCol = 25, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "ChatMatNgoaiCanh_R", StartRow = 17, EndRow = 17, StartCol = 26, EndCol = 26, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "ChatMatNgoaiCanh_C", StartRow = 17, EndRow = 17, StartCol = 27, EndCol = 27, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                 new ComplexHeader { Title = "D (m)", DataProperty = "MuMoThotDuoi_D", StartRow = 17, EndRow = 17, StartCol = 28, EndCol = 28, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "MuMoThotDuoi_R", StartRow = 17, EndRow = 17, StartCol = 29, EndCol = 29, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "MuMoThotDuoi_C", StartRow = 17, EndRow = 17, StartCol = 30, EndCol = 30, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "CD tường", DataProperty = "MuMoThotDuoi_CdTuong", StartRow = 17, EndRow = 17, StartCol = 31, EndCol = 31, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

                new ComplexHeader { Title = "D (m)", DataProperty = "MuMoThotTren_D", StartRow = 17, EndRow = 17, StartCol = 32, EndCol = 32, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "R (m)", DataProperty = "MuMoThotTren_R", StartRow = 17, EndRow = 17, StartCol = 33, EndCol = 33, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "C (m)", DataProperty = "MuMoThotTren_C", StartRow = 17, EndRow = 17, StartCol = 34, EndCol = 34, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "CD tường", DataProperty = "MuMoThotTren_CdTuong", StartRow = 17, EndRow = 17, StartCol = 35, EndCol = 35, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },

         };
        //Thống kê thép hố ga
        public static List<ComplexHeader> TKTHG_HEADERS = new List<ComplexHeader>
         {
                // Dòng tiêu đề chung
                new ComplexHeader { Title = "CÔNG TY CỔ PHẦN XÂY DỰNG ĐỨC ANH", StartRow = 1, StartCol = 1, EndRow = 1, EndCol = 5,Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "TÊN DỰ ÁN", StartRow = 2, StartCol = 1, EndRow = 2, EndCol = 5 ,Alignment = ExcelHorizontalAlignment.Center ,IsBold=true},
                new ComplexHeader { Title = "BẢNG THỐNG KÊ THÉP HỐ GA THEO LOẠI HỐ GA", StartRow = 3, StartCol = 1, EndRow = 3, EndCol = 15, TextColor = System.Drawing.Color.Black, Alignment = ExcelHorizontalAlignment.Center,IsBold=true },
                new ComplexHeader { Title = "Số liệu màu đen nhạt là số liệu nhập bằng tay; Số liệu màu đen đậm là kết quả mang từ một bảng khác sang; Số liệu màu đỏ là kết quả của 01 phép tính.", StartRow = 4, StartCol = 1, EndRow = 4, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Nhưng bảng sử dụng số liệu của bảng này bị thay đổi số liệu nếu số liệu tại bảng này bị thay đổi", StartRow = 5, StartCol = 1, EndRow = 5, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "Bảng này in làm tài liệu lưu trữ, thi công, nghiệm thu, hoàn công.", StartRow = 6, StartCol = 1, EndRow = 6, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},
                new ComplexHeader { Title = "", StartRow = 7, StartCol = 1, EndRow = 7, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red },
                new ComplexHeader { Title = "", StartRow = 8, StartCol = 1, EndRow = 8, EndCol = 15, Alignment = ExcelHorizontalAlignment.Center ,TextColor = System.Drawing.Color.Red},

                // Header thông tin chi tiết
                new ComplexHeader { Title = "STT", DataProperty = "STT", StartRow = 16, EndRow = 16, StartCol = 1, EndCol = 1, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại cấu kiện", DataProperty = "ThongTinChungHoGa_TenHoGaSauPhanLoai_Name", StartRow = 16, EndRow = 16, StartCol = 2, EndCol = 2, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tên công tác", DataProperty = "TenCongTac", StartRow = 16, EndRow = 16, StartCol = 3, EndCol = 3, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Vị trí lấy khối lượng", DataProperty = "VTLayKhoiLuong", StartRow = 16, EndRow = 16, StartCol = 4, EndCol = 4, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Loại thép", DataProperty = "LoaiThep_Name", StartRow = 16, EndRow = 16, StartCol = 5, EndCol = 5, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số hiệu", DataProperty = "SoHieu", StartRow = 16, EndRow = 16, StartCol = 6, EndCol = 6, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Đường kính chiều dầy (mm,mm2)", DataProperty = "DKCD", StartRow = 16, EndRow = 16, StartCol = 7, EndCol = 7, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số thanh/01 cấu kiện", DataProperty = "SoThanh", StartRow = 16, EndRow = 16, StartCol = 8, EndCol = 8, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Số cấu kiện", DataProperty = "SoCK", StartRow = 16, EndRow = 16, StartCol = 9, EndCol = 9, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng số thanh", DataProperty = "TongSoThanh", StartRow = 16, EndRow = 16, StartCol = 10, EndCol = 10, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Chiều dài 01 thanh (mm)/diện tích (mm2)", DataProperty = "ChieuDai1Thanh", StartRow = 16, EndRow = 16, StartCol = 11, EndCol = 11, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng chiều dài (m,m2)", DataProperty = "TongChieuDai", StartRow = 16, EndRow = 16, StartCol = 12, EndCol = 12, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Trọng lượng thép/(kg/m,m3)", DataProperty = "TrongLuong", StartRow = 16, EndRow = 16, StartCol = 13, EndCol = 13, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                new ComplexHeader { Title = "Tổng trọng lượng (kg)", DataProperty = "TongTrongLuong", StartRow = 16, EndRow = 16, StartCol = 14, EndCol = 14, IsBold = true, HasBorder = true, WrapText = true, Alignment = ExcelHorizontalAlignment.Center },
                
         };

    }
}
