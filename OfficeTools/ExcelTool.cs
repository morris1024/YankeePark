using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2016/4/23-星期六 15:16:57
 * ID: 268f163e-2bfd-495d-b597-c18cc3125ee1
 ***************************************************/
namespace Morris.YankeePark.OfficeTools
{
    public class ExcelTool
    {
        public void foo(string inputFileName,string outputFilePrefix)
        {
            Application app = new Application();
            if(app==null)
            {
                return;
            }
            Workbook inputWb=null;
            try
            {
                app.Visible = false;
                app.UserControl = false;
                inputWb = app.Application.Workbooks.Open(inputFileName);
                var inputSheetsEunumer  = inputWb.Worksheets.GetEnumerator();
                while(inputSheetsEunumer.MoveNext())
                {
                    Worksheet inputSheet = inputSheetsEunumer.Current as Worksheet;
                    string sheetName = inputSheet.Name as string;
                    Workbook outputWb = app.Application.Workbooks.Add();
                    Worksheet outputSheet = outputWb.Worksheets.get_Item(1);
                    for (int inputCellIndex = 2,outputRowIndex = 1; inputCellIndex <= 58; inputCellIndex++)
                    {
                        Range tmpRange = inputSheet.Cells[1, inputCellIndex] as Range;
                        string year = tmpRange.Text as string;
                        for (int inputRowIndex = 2 ; inputRowIndex <= 33; inputRowIndex++, outputRowIndex++)
                        {
                            tmpRange = inputSheet.Cells[inputRowIndex, inputCellIndex] as Range;
                            string value = tmpRange.Value2 as string;
                            string tmp = year + "\t" + value;
                            outputSheet.Cells[outputRowIndex, 1] = year;
                            outputSheet.Cells[outputRowIndex, 2] = value.Split('+')[0].Trim();
                            //System.Console.WriteLine(year + "\t" + value.Split('+')[0].Trim());
                        }
                    }
                    //save .xlsx
                    outputWb.SaveAs(outputFilePrefix + sheetName + ".xlsx", XlFileFormat.xlWorkbookDefault);
                    //save .xls
                    //outputWb.SaveAs(outputFilePrefix + sheetName + ".xls", XlFileFormat.xlWorkbookNormal);
                    outputWb.Close();
                }
            }
            finally
            {
                if(inputWb!=null)
                {
                    inputWb.Close(false);
                }
                app.Application.Workbooks.Close();
                app.Quit();
            }
        }
    }
}
