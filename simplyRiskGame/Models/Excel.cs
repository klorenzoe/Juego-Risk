using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace simplyRiskGame.Models
{
    public class Excel
    {
        _Excel.Application file;
        _Excel.Workbook workBook;
        _Excel.Worksheet workSheet;


        public void Open(string path, int sheetNum)
        {
            file = new _Excel.Application();
            workBook = file.Workbooks.Open(path);
            workSheet = workBook.Worksheets[sheetNum];
        }

        public void Write(int rowNumber, string columnLetter, string value)
        {
            workSheet.Cells[rowNumber, columnLetter] = value;
            
        }

        public void Save() {
            workBook.Save();
        }


       

        public int getRowNumber() {
            int i = 1;
            while (true) {
                i++;
                if (workSheet.Cells[i, "A"].Value == null)
                    return i;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(int handle, out int processId);

        public void Close()
        {
            //As soon as i figure out how to properly end the fucking excel process,  i will :J
            workBook.Close();
            file.Quit();
            int proId;
            GetWindowThreadProcessId(file.Hwnd, out proId);
            Process[] allProcesses = Process.GetProcessesByName("excel");
            foreach (Process excelProcess in allProcesses)
            {
                if (excelProcess.Id == proId)
                {
                    excelProcess.Kill();
                }
            }
            allProcesses = null;
        }
    }
}
