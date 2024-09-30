using Microsoft.Office.Interop.Excel;
using NsExcel = Microsoft.Office.Interop.Excel.Application;

namespace Utils
{
    public static class Excel
    {
        public static void ListToExcel(List<Object> list)
        {
            //start excel
            var excapp = new NsExcel();

            //create a blank workbook
            var workbook = excapp.Workbooks.Add();

            //Not done yet. You have to work on a specific sheet - note the cast
            //You may not have any sheets at all. Then you have to add one with NsExcel.Worksheet.Add()
            var sheet = (Worksheet)workbook.Sheets[1]; //indexing starts from 1

            //now the list
            string cellName;
            int counter = 1;
            foreach (var item in list)
            {
                cellName = "A" + counter.ToString();
                var range = sheet.get_Range(cellName, cellName);
                range.Value2 = item.ToString();
                ++counter;
            }

            excapp.Visible = true;
        }
    }
}
