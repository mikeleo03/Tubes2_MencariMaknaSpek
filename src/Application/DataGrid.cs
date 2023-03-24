using System.Data;

namespace TreasureHunt {
    // Kelas datagrid
    class DataGrid {
        // Nama file
        public static string file;
        
        public static DataTable DataTableFromTextFile(string[] LineArray, char delimiter = ' ') {
            return FromDataTable(LineArray, delimiter);
        }

        private static DataTable FromDataTable(string[] LineArray, char delimiter) {
            DataTable dt = new DataTable();

            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            return dt;
        }

        private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable dt) {
            // collect data per column dipisah spasi
            string[] columns = columnCollection[0].Split(delimiter);
            // setiap kolom diiterasi
            for(int i = 0; i < columns.Length; i++) {
                DataColumn dc = new DataColumn("", typeof(string));
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
