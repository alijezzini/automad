using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Automad
{
    class Excel
    {
        String path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(String path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                var val = ws.Cells[i, j].Value2;
                String num = val.ToString();
                return num;

            }
            else
            {
                return "";
            }
        }
        public List<string> numlist()
        {
            List<string> domains = new List<string>();
            for (int rw = 1; rw <= ws.UsedRange.Rows.Count; rw++)
            {
                if (ws.Cells[rw, 1].Value != null)
                    domains.Add(ws.Cells[rw, 1].Value.ToString());
            }
            excel.Visible = false;
            wb.Close(0);
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
            excel = null;
            return domains;
        }
    }
}
