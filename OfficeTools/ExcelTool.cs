using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.XSSF.UserModel;



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
            
            try
            {
                using (FileStream inputFile = new FileStream(inputFileName, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook inputWb = new NPOI.XSSF.UserModel.XSSFWorkbook(inputFile);
                    foreach(XSSFSheet inputSheet in inputWb)
                    {
                        string sheetName = inputSheet.SheetName;
                        NPOI.HSSF.UserModel.HSSFWorkbook outputWb = new NPOI.HSSF.UserModel.HSSFWorkbook();
                        NPOI.SS.UserModel.ISheet outputSheet = outputWb.CreateSheet();
                        object[,] data = new object[57, 33];
                        int index=0;
                        foreach(XSSFRow row in inputSheet)
                        {
                            for(int i=0;i<57;i++)
                            {
                                data[i, index] = row.GetCell(i + 1);
                            }
                            index++;
                        }
                        foreach()
                        for (int inputCellIndex = 2, outputRowIndex = 1; inputCellIndex <= 58; inputCellIndex++)
                        {
                            string year = data[inputCellIndex, 1] as string;
                            for (int inputRowIndex = 2; inputRowIndex <= 33; inputRowIndex++, outputRowIndex++)
                            {
                                string value = data[inputCellIndex, inputRowIndex] as string;
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
