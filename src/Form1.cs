using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using TreasureHunt.Container;
using TreasureHunt.Algorithm;
using System.Threading;
using System.Diagnostics;

namespace TreasureHunt 
{
    public partial class TreasureFinder : Form 
    {
        //public var fileContent = string.Empty;
        //public var filePath = string.Empty;
        private string fileName;
        private int delay = 1000; // default
        private string algorithm;
        private bool browsed = false;
        private bool BFS_solved = false;
        private bool DFS_solved = false;
        private bool TSP = false;
        private MatrixNode maze;
        private DFSSolver dfs_sol;
        private BFSSolver bfs_sol;
        private Stopwatch et = new Stopwatch();
        private int[,] visited;

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
                maze = new MatrixNode();
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
            visited = new int[this.maze.getRow(), this.maze.getCol()];
            for (int i = 0; i < this.maze.getRow(); i++)
            {
                for (int j = 0; j < this.maze.getCol(); j++)
                {
                    visited[i, j] = 0;
                }
            }
            foreach (Route x in bfs_sol.getSequence())
            {
                foreach (Coordinate y in x.getRoutes())
                {
                    if (visited[y.getX(), y.getY()] == 0)
                    {
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.FromArgb(255, 255, 0);
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.FromArgb(255, 255, 0);
                    }
                    else
                    {
                        int col = visited[y.getX(), y.getY()];
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.FromArgb(255 - 5 * col, 255 - 5 * col, 0);
                        grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.ForeColor = Color.FromArgb(255 - 5 * col, 255 - 5 * col, 0);
                    }
                    visited[y.getX(), y.getY()]++;

                }
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.BackColor = Color.Blue;
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.ForeColor = Color.Blue;
                await Task.Delay(delay);
                // reset every route on the way
                foreach (Coordinate z in x.getRoutes())
                {
                    grid_hartakarun.Rows[z.getX()].Cells[z.getY()].Style.BackColor = Color.White;
                    grid_hartakarun.Rows[z.getX()].Cells[z.getY()].Style.ForeColor = Color.White;
                }
            }
            Route o = bfs_sol.getFinalRoute();
            foreach (Coordinate fin in o.getRoutes())
            {
                int fon = visited[fin.getX(), fin.getY()];
                grid_hartakarun.Rows[fin.getX()].Cells[fin.getY()].Style.BackColor = Color.FromArgb(255 - 5*fon, 255 - 5*fon, 0);
                grid_hartakarun.Rows[fin.getX()].Cells[fin.getY()].Style.ForeColor = Color.FromArgb(255 - 5*fon, 255 - 5*fon, 0);
            }
        }

        private async void DFS_Algo()
        {
            //maze = new MatrixNode();
            visited = new int[this.maze.getRow(), this.maze.getCol()];
            for (int i = 0; i < this.maze.getRow(); i++)
            {
                for (int j = 0; j < this.maze.getCol(); j++)
                {
                    visited[i,j] = 0;
                }
            }
            foreach (Coordinate x in dfs_sol.getRoute())
            {
                if (visited[x.getX(), x.getY()] == 0)
                {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(delay);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.FromArgb(255, 255, 0);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.FromArgb(255, 255, 0);
                    visited[x.getX(), x.getY()]++;
                }
                else
                {
                    int a = visited[x.getX(), x.getY()];
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                    await Task.Delay(delay);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.FromArgb(255-20*a, 255-20*a, 0);
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.FromArgb(255-20*a, 255-20*a, 0);
                    visited[x.getX(), x.getY()]++;
                }

                /*
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
                }*/
            }
        }
        

        private void Search_Click_1(object sender, EventArgs e)
        {
            if (browsed)
            {
                ClearTable();
                this.maze.fillMatrix(fileName);
                Browse_file_warning.Text = "";
                if (algorithm == "BFS")
                {
                    Pick_algorithm_warning.Text = "";
                    bfs_sol = new BFSSolver(this.maze);
                    et.Start();
                    if (TSP)
                    {
                        bfs_sol.solveAndTSP();
                    }
                    else
                    {
                        bfs_sol.solve();
                    }
                    et.Stop();
                    et_value.Text = et.ElapsedMilliseconds + " ms";
                    et.Reset();
                    BFS_solved = true;
                    DFS_solved = false;
                    // algoritma BFS
                }
                else if (algorithm == "DFS")
                {
                    Pick_algorithm_warning.Text = "";
                    dfs_sol = new DFSSolver();
                    dfs_sol.fillMaze(fileName);
                    et.Start();
                    if (TSP)
                    {
                        dfs_sol.solveAndTSP();
                    }
                    else
                    {
                        dfs_sol.solve();
                    }
                    et.Stop();
                    et_value.Text = et.ElapsedMilliseconds +" ms";
                    et.Reset();
                    
                    DFS_solved = true;
                    BFS_solved = false;
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
                Browse_file_warning.Text = "Choose a txt file first!";
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

        public void ClearTable()
        {
            foreach (DataGridViewRow row in grid_hartakarun.Rows)
            {
                for (int i = 0; i < grid_hartakarun.ColumnCount; i++)
                { 
                    if (row.Cells[i].Style.BackColor != Color.Black)
                    {
                        row.Cells[i].Style.BackColor = Color.White;
                        if (row.Cells[i].Value != "")
                        {
                            row.Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }
        private void Visualize_Button_Click(object sender, EventArgs e)
        {
            // ini nanti dipisah
            if (BFS_solved)
            {
                ClearTable();
                Visualize_Warning.Text = "";
                BFS_Algo();
                BFS_solved = false;
            }
            else if (DFS_solved)
            {
                ClearTable();
                Visualize_Warning.Text = "";
                DFS_Algo();
                DFS_solved = false;
            }
            else
            {
                Visualize_Warning.Text = "Solve the chosen file first!";
            }

        }

        private void Delay_Scrollbar_Scroll(object sender, EventArgs e)
        {
            delay_value.Text = Delay_Scrollbar.Value.ToString();
            delay = Delay_Scrollbar.Value;
        }

        private void TSP_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TSP_checkBox.Checked)
            {
                TSP = true;
            }
            else
            {
                TSP = false;
            }
        }
    }
}
