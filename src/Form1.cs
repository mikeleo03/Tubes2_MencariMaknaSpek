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
using TreasureHunt.Algorithm;
using System.Threading;

namespace TreasureHunt 
{
    public partial class TreasureFinder : Form 
    {
        //public var fileContent = string.Empty;
        //public var filePath = string.Empty;
        private string fileName;
        private string algorithm;
        private bool browsed = false;
        private bool BFS_solved = false;
        private bool DFS_solved = false;
        private MatrixNode maze = new MatrixNode();
        private DFSSolver dfs_sol;
        private BFSSolver bfs_sol;

        public TreasureFinder() {
            InitializeComponent();
            // grid_hartakarun.RowPostPaint += new DataGridViewRowPostPaintEventHandler(grid_hartakarun_RowPostPaint);
            // grid_hartakarun.CellFormatting += grid_hartakarun_CellFormatting;
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
                fileName = Filename_iotbox.Text;
                DataGrid.file = Filename_iotbox.Text;
                this.maze.fillMatrix(Filename_iotbox.Text);
                grid_hartakarun.DataSource = DataGrid.DataTableFromTextFile(this.maze.convertToStringArray());
                grid_hartakarun.CellFormatting += grid_hartakarun_CellFormatting;
                Filename_iotbox.Text = openFileDialog1.SafeFileName;
                int tinggi = grid_hartakarun.Height / grid_hartakarun.Rows.Count;
                foreach (DataGridViewRow row in grid_hartakarun.Rows) {
                    row.Height = tinggi;
                }
                browsed = true;
                if (grid_hartakarun.SelectedCells.Count > 0)
                {
                    // Clear the selection
                    grid_hartakarun.ClearSelection();
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
                            row.Cells[i].Value = "";
                        } else if (Convert.ToString(row.Cells[i].Value) == "K") {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.ForeColor = Color.Black;
                            row.Cells[i].Value = "Start";
                        } else if (Convert.ToString(row.Cells[i].Value) == "R") {
                            row.Cells[i].Style.ForeColor = Color.White;
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Value = "";
                        } else if (Convert.ToString(row.Cells[i].Value) == "T") {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.ForeColor = Color.Black;
                            row.Cells[i].Value = "Treassure";
                        }
                    }
                }
            }
        }
        private async void BFS_Algo()
        {
            BFSSolver TestBFS = new BFSSolver(this.maze);
            TestBFS.solve();
            foreach (Route x in bfs_sol.getSequence())
            {
                foreach (Coordinate y in x.getRoutes())
                {
                    //grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.Blue;
                    //grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.Blue;
                    // await Task.Delay(1000);
                    // without IF conditions yet.
                    if (grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor == Color.White)
                    {
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.GreenYellow;
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.GreenYellow;
                    }
                    else if (grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor == Color.White)
                    {
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.GreenYellow;
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.GreenYellow;
                    }

                }
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.BackColor = Color.Blue;
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.ForeColor = Color.Blue;
                await Task.Delay(1000);
                // reset every route on the way
                foreach (Coordinate z in x.getRoutes())
                {
                    grid_hartakarun.Rows[z.getX()].Cells[z.getY()].Style.BackColor = Color.White;
                    grid_hartakarun.Rows[z.getX()].Cells[z.getY()].Style.ForeColor = Color.White;
                }
            }
            // Ini variasi reset all
            /*foreach (Route x in TestBFS.getSequence())
            {
                foreach (Coordinate y in x.getRoutes())
                {
                    //grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.Blue;
                    //grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.Blue;
                    // await Task.Delay(1000);
                    // without IF conditions yet.
                    grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.White;
                    grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.White;

                }
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.BackColor = Color.Blue;
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.ForeColor = Color.Blue;
                await Task.Delay(1000);
            }*/
            Route o = bfs_sol.getFinalRoute();
            foreach (Coordinate fin in o.getRoutes())
            {
                grid_hartakarun.Rows[fin.getX()].Cells[fin.getY()].Style.BackColor = Color.GreenYellow;
                grid_hartakarun.Rows[fin.getX()].Cells[fin.getY()].Style.ForeColor = Color.GreenYellow;
            }
        }

        private async void DFS_Algo()
        {
            foreach (Coordinate x in dfs_sol.getRoute())
            {
                if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.White)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.GreenYellow;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.GreenYellow;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.GreenYellow)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.LawnGreen;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.LawnGreen;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.LawnGreen)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Lime;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Lime;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.Lime)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.LimeGreen;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.LimeGreen;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.LimeGreen)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.ForestGreen;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.ForestGreen;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.ForestGreen)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Green;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Green;
                }
                else if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor == Color.Green)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(1000);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.DarkGreen;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.DarkGreen;
                }
            }
            await Task.Delay(250);
        }
     

        private void Search_Click_1(object sender, EventArgs e)
        {
            if (browsed)
            {
                if (algorithm == "BFS")
                {

                    Pick_algorithm_warning.Text = "";
                    bfs_sol = new BFSSolver(this.maze);
                    bfs_sol.solve();
                    BFS_solved = true;
                    // algoritma BFS
                }
                else if (algorithm == "DFS")
                {
                    Pick_algorithm_warning.Text = "";
                    dfs_sol = new DFSSolver();
                    dfs_sol.fillMaze(fileName);
                    dfs_sol.solve();
                    DFS_solved = true;
                    // algoritma DFS
                }
                else
                {
                    algorithm = "";
                    Pick_algorithm_warning.Text = "Pick the algorithm first!";
                }
            }
            else
            {

            }
        }

        private void BFS_option_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = "BFS";
        }

        private void DFS_option_CheckedChanged(object sender, EventArgs e)
        {
            algorithm = "DFS";
        }

        private void Visualize_Button_Click(object sender, EventArgs e)
        {
            // ini nanti dipisah
            if (BFS_solved)
            {
                Visualize_Warning.Text = "";
                BFS_Algo();
            }
            else if (DFS_solved)
            {
                Visualize_Warning.Text = "";
                DFS_Algo();
            }
            else
            {
                Visualize_Warning.Text = "Solve the chosen file!";
            }
        }
    }
}
