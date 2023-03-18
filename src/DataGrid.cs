using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TreasureHunt {
    class DataGrid {
        public static string file;
        
        // public static DataTable DataTableFromTextFile(string location, char delimiter = ' ')
        // {
        //     DataTable result;
        //     string[] LineArray = File.ReadAllLines(location);
        //     result = FromDataTable(LineArray, delimiter);
        //     return result;

        // }
        public static DataTable DataTableFromTextFile(string[] LineArray, char delimiter = ' ') {
            DataTable result;
            result = FromDataTable(LineArray, delimiter);
            return result;

        }

        private static DataTable FromDataTable(string[] LineArray, char delimiter) {
            DataTable dt = new DataTable();

            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            return dt;

        }

        private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable dt) {
            string[] columns = columnCollection[0].Split(delimiter); // collect data per column dipisah spasi
            for(int i = 0; i < columns.Length; i++) // setiap kolom diiterasi
            {
                DataColumn dc = new DataColumn("", typeof(string)); // ini yang "" itu judul tiap kolom 
                dt.Columns.Add(dc);
            }
        }

        private static void AddRowToTable(string[] valueCollection, char delimiter, ref DataTable dt) {
            for (int i = 0; i < valueCollection.Length; i++) {
                string[] values = valueCollection[i].Split(delimiter);
                DataRow dr = dt.NewRow();
                for (int j = 0; j < values.Length; j++) {
                    dr[j] = values[j];
                }

                dt.Rows.Add(dr);
            }
        }
    }
}
