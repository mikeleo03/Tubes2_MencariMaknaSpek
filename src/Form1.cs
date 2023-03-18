using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using TreasureHunt.Container;

namespace TreasureHunt {
    public partial class TreasureFinder : Form {
        //public var fileContent = string.Empty;
        //public var filePath = string.Empty;
        public string algorithm;
        public bool browsed = false;
        private MatrixNode maze = new MatrixNode();

        public TreasureFinder() {
            InitializeComponent();
            // grid_hartakarun.RowPostPaint += new DataGridViewRowPostPaintEventHandler(grid_hartakarun_RowPostPaint);
            grid_hartakarun.CellFormatting += grid_hartakarun_CellFormatting;
        }

        private void label1_Click(object sender, EventArgs e) // Title Label
        {

        }

        private void label2_Click(object sender, EventArgs e) // Input Label
        {

        }

        private void label3_Click(object sender, EventArgs e) // Output Label
        {

        }

        private void label4_Click(object sender, EventArgs e) // Filename Label
        {

        }

        private void button1_Click(object sender, EventArgs e) // Browse button
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                // Title = "Browse Text File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All Files(*.*)|*.*", // filter txt
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                Filename_iotbox.Text = openFileDialog1.FileName; // blm ada text box jadi g dulu
                DataGrid.file = Filename_iotbox.Text;
                this.maze.fillMatrix(Filename_iotbox.Text);
                grid_hartakarun.DataSource = DataGrid.DataTableFromTextFile(this.maze.convertToStringArray());
                grid_hartakarun.CellFormatting += grid_hartakarun_CellFormatting;
                Filename_iotbox.Text = openFileDialog1.SafeFileName;
                int tinggi = grid_hartakarun.Height / grid_hartakarun.Rows.Count;
                foreach (DataGridViewRow row in grid_hartakarun.Rows) {
                    row.Height = tinggi;
                }
            }

        }

        private void grid_hartakarun_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // Pewarnaan grid terbaca 
        {
            foreach (DataGridViewRow row in grid_hartakarun.Rows) {
                for (int i = 0; i < grid_hartakarun.ColumnCount; i++) {
                    if (row.Cells[i].Value != null) {
                        if (Convert.ToString(row.Cells[i].Value) == "X") {
                            row.Cells[i].Style.BackColor = Color.Black;
                            row.Cells[i].Style.ForeColor = Color.Black;
                        } else if (Convert.ToString(row.Cells[i].Value) == "K") {
                            //row.Cells[i].Style.BackColor = Color.Yellow;
                            row.Cells[i].Style.BackColor = Color.White;
                           // row.Cells[i].Value = "Start";
                        } else if (Convert.ToString(row.Cells[i].Value) == "R") {
                            row.Cells[i].Style.ForeColor = Color.White;
                            row.Cells[i].Style.BackColor = Color.White;
                        } else if (Convert.ToString(row.Cells[i].Value) == "T") {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.ForeColor = Color.Black;
                            //row.Cells[i].Value = "Treassure";
                        }
                    }
                }
            }
        }
        
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TreasureFinder_Load(object sender, EventArgs e)
        {

        }

        private void Filename_iotbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void BFS_option_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = "BFS";
        }

        private void DFS_option_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = "DFS";
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (browsed)
            {
                if (algorithm == "BFS")
                {

                    Pick_algorithm_warning.Text = "";
                    // algoritma BFS
                }
                else if (algorithm == "DFS")
                {
                    Pick_algorithm_warning.Text = "";
                    // algoritma DFS
                }
                else
                {
                    algorithm = "";
                    Pick_algorithm_warning.Text = "Pick the algorithm first!";
                }
            }
        }
    }
}
    }
}
