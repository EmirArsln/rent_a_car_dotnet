using ClosedXML.Excel;
using Entities.DTOs;
using System.Collections.Generic;
using System.IO;

namespace Business.Helpers
{
    public static class ExcelHelper
    {
        public static byte[] GenerateRentalExcel(List<RentalDetailDto> rentals)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kiralama Raporu");

                worksheet.Cell(1, 1).Value = "Kiralama ID";
                worksheet.Cell(1, 2).Value = "Kullanıcı Adı";
                worksheet.Cell(1, 3).Value = "Marka";
                worksheet.Cell(1, 4).Value = "Renk";
                worksheet.Cell(1, 5).Value = "Model Yılı";
                worksheet.Cell(1, 6).Value = "Açıklama";
                worksheet.Cell(1, 7).Value = "Günlük Fiyat (₺)";
                worksheet.Cell(1, 8).Value = "Kiralama Tarihi";
                worksheet.Cell(1, 9).Value = "Teslim Tarihi";
                worksheet.Cell(1, 10).Value = "Koltuk Sayısı";
                worksheet.Cell(1, 11).Value = "Vites Türü";
                worksheet.Cell(1, 12).Value = "Maksimum Hız (km/s)";
                worksheet.Cell(1, 13).Value = "Yakıt Türü";

                for (int i = 0; i < rentals.Count; i++)
                {
                    var r = rentals[i];
                    worksheet.Cell(i + 2, 1).Value = r.RentalId;
                    worksheet.Cell(i + 2, 2).Value = $"{r.FirstName} {r.LastName}";
                    worksheet.Cell(i + 2, 3).Value = r.BrandName;
                    worksheet.Cell(i + 2, 4).Value = r.ColorName;
                    worksheet.Cell(i + 2, 5).Value = r.ModelYear;
                    worksheet.Cell(i + 2, 6).Value = r.Description;
                    worksheet.Cell(i + 2, 7).Value = $"{r.DailyPrice} ₺";
                    worksheet.Cell(i + 2, 8).Value = r.RentDate.ToString("dd.MM.yyyy");
                    worksheet.Cell(i + 2, 9).Value = r.ReturnDate?.ToString("dd.MM.yyyy") ?? "-";
                    worksheet.Cell(i + 2, 10).Value = r.Seats;
                    worksheet.Cell(i + 2, 11).Value = r.Gear;
                    worksheet.Cell(i + 2, 12).Value = $"{r.Speed} km/s";
                    worksheet.Cell(i + 2, 13).Value = r.FuelType;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
