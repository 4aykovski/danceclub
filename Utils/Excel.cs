using ClosedXML.Excel;


namespace Utils
{
    public static class Excel
    {
        public static void ListToExcel(List<Object> list)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("sheetName");
            var ws = workbook.Worksheet("sheetName");

            int column = 1;
            foreach (var item in list[0].GetType().GetProperties())
            {
                ws.Cell(1, column).Value = item.Name.ToString();
                column++;
            }

            int row = 2;
            column = 1;
            foreach (object item in list)
            {
                foreach (var field in item.GetType().GetProperties())
                {
                    ws.Cell(row, column).Value = field.GetValue(item, null)?.ToString();
                    column++;
                }
                row++;
            }

            workbook.SaveAs($"./excels/{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff")}.xlsx");
        }
    }
}
