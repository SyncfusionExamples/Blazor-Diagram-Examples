using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using System.IO;
using System.Data;
using Syncfusion.Blazor.Diagram;
using System.Drawing;
using static DiagramToExcel.Index;

namespace DiagramToExcel.Data
{
    public class CreateExcel
    {
        public MemoryStream CreateDocument(DiagramObjectCollection<Node> nodes)
        {
            //Create an instance of ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Range["A1"].CellStyle.Font.Bold = true;
                worksheet.Range["B1"].CellStyle.Font.Bold = true;
                worksheet.Range["C1"].CellStyle.Font.Bold = true;

                #region Import from Data Table
                //Initialize the DataTable
                DataTable table = SampleDataTable(nodes);
                //Import DataTable to the worksheet
                worksheet.ImportDataTable(table, true, 1, 1);
                #endregion

                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
        }
        private static DataTable SampleDataTable(DiagramObjectCollection<Node> nodes)
        {
            //Create a DataTable with four columns
            DataTable table = new DataTable();
            table.Columns.Add("Element ID", typeof(string));
            table.Columns.Add("FillColor", typeof(string));
            table.Columns.Add("Content", typeof(string));

            foreach(Node node in nodes)
            {
                table.Rows.Add(node.ID, node.Style.Fill, (node.Data as HierarchicalDetails).Manager);
            }
           

            return table;
        }
    }
}
