using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreasureHunt.Container;
using TreasureHunt.Algorithm;
using System.Diagnostics;

namespace TreasureHunt  {
    // Pemrosesan Tampilan GUI pada desktop application
    public partial class TreasureFinder : Form {
        private string fileName;                    // Nama file
        private int delay = 1000;                   // Nilai default untuk time delay
        private string algorithm;                   // Jenis algoritma yang dipilih
        private bool browsed = false;               // Mengecek apakah sudah di-browsed
        private bool BFS_solved = false;            // Apakah BFS sudah selesai
        private bool DFS_solved = false;            // Apakah DFS sudah selesai
        private bool TSP = false;                   // Apakah menerapkan metode TSP
        private MatrixNode maze;                    // Matriks peta
        private DFSSolver dfs_sol;                  // Pemanggilan objek DFSSolver
        private BFSSolver bfs_sol;                  // Pemanggilan objek BFSSolver
        private Stopwatch et = new Stopwatch();     // Stopwatch
        private int[,] visited;                     // Matriks jumlah pengunjungan

        // Konstruktor objek TreasureFinder
        public TreasureFinder() {
            InitializeComponent();
        }

        // Label judul
        private void label1_Click(object sender, EventArgs e) {}

        // Label masukan
        private void label2_Click(object sender, EventArgs e) {}

        // Label keluaran
        private void label3_Click(object sender, EventArgs e) {}

        // Label nama file
        private void label4_Click(object sender, EventArgs e) {}

        // Tombol pencarian
        private void button1_Click(object sender, EventArgs e) {
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
                Filename_iotbox.Text = openFileDialog1.FileName;
                fileName = Filename_iotbox.Text;
                DataGrid.file = Filename_iotbox.Text;
                maze = new MatrixNode();
                try {
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
                    if (grid_hartakarun.SelectedCells.Count > 0) {
                        // Menghapus seleksi
                        grid_hartakarun.ClearSelection();
                    }

                } catch {
                    Browse_file_warning.Text = "Invalid file";
                }
            }
        }

        // Pewarnaan grid yang terbaca
        private void grid_hartakarun_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
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
                            row.Cells[i].Value = "Treasure";
                        }
                    }
                }
            }
        }

        // Implementasi dari algoritma BFS
        private async void BFS_Algo() {
            foreach (Route x in bfs_sol.getSequence()) {
                visited = new int[this.maze.getRow(), this.maze.getCol()];
                for (int i = 0; i < this.maze.getRow(); i++) {
                    for (int j = 0; j < this.maze.getCol(); j++) {
                        visited[i, j] = 0;
                    }
                }

                foreach (Coordinate y in x.getRoutes()) {
                    int col = visited[y.getX(), y.getY()];
                    grid_hartakarun.Rows[y.getX()].Cells[y.getY()].Style.BackColor = Color.FromArgb(255 - (15 * col), 255 - (15 * col), 0);
                    visited[y.getX(), y.getY()]++;
                }

                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.BackColor = Color.Blue;
                grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.ForeColor = Color.Blue;
                await Task.Delay(delay);

                if (grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Value == "Start" || grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Value == "Treasure") {
                    grid_hartakarun.Rows[x.getRoutesTopX()].Cells[x.getRoutesTopY()].Style.ForeColor = Color.Black;
                }

                // Reset semua rute
                foreach (Coordinate z in x.getRoutes()) {
                    grid_hartakarun.Rows[z.getX()].Cells[z.getY()].Style.BackColor = Color.White;
                }
            }

            Route o;
            if (TSP) {
                o = bfs_sol.getFinalRouteTSP();
            } else {
                o = bfs_sol.getFinalRoute();
            }

            visited = new int[this.maze.getRow(), this.maze.getCol()];
            for (int i = 0; i < this.maze.getRow(); i++) {
                for (int j = 0; j < this.maze.getCol(); j++) {
                    visited[i, j] = 0;
                }
            }

            foreach (Coordinate fin in o.getRoutes()) {
                int fon = visited[fin.getX(), fin.getY()];
                grid_hartakarun.Rows[fin.getX()].Cells[fin.getY()].Style.BackColor = Color.FromArgb(255 - 15*fon, 255 - 15*fon, 0);
                visited[fin.getX(), fin.getY()]++;
            }
        }

        // Implementasi dari algoritma DFS
        private async void DFS_Algo() {
            visited = new int[this.maze.getRow(), this.maze.getCol()];
            for (int i = 0; i < this.maze.getRow(); i++) {
                for (int j = 0; j < this.maze.getCol(); j++) {
                    visited[i,j] = 0;
                }
            }

            foreach (Coordinate x in dfs_sol.getRoute()) {
                grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.Blue;
                grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Blue;
                
                await Task.Delay(delay);
                
                if (grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Value == "Start" || grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Value == "Treasure") {
                    grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.ForeColor = Color.Black;
                }

                int a = visited[x.getX(), x.getY()];
                grid_hartakarun.Rows[x.getX()].Cells[x.getY()].Style.BackColor = Color.FromArgb(255-(15*a), 255-(15*a), 0);
                visited[x.getX(), x.getY()]++;
            }
        }

        // Tombol search click 1
        private void Search_Click_1(object sender, EventArgs e) {
            if (browsed) {
                ClearTable();
                this.maze.fillMatrix(fileName);
                Browse_file_warning.Text = "";
                Route_result.Text = "";
                if (algorithm == "BFS") {
                    Route_result.Text = "";
                    Pick_algorithm_warning.Text = "";
                    bfs_sol = new BFSSolver(this.maze);
                    et.Start();

                    if (TSP) {
                        bfs_sol.solveAndTSP();
                        et.Stop();

                        foreach (String x in bfs_sol.getFinalRouteTSP().getSequenceOfDirection()) {
                            Route_result.Text += x + "-";
                        }

                        Route_result.Text = Route_result.Text.Substring(0, Route_result.Text.Length - 1);
                        Steps_taken.Text = bfs_sol.numsOfStepsTSP().ToString();
                    } else {
                        bfs_sol.solve();
                        et.Stop();

                        foreach (String x in bfs_sol.getFinalRoute().getSequenceOfDirection()) {
                            Route_result.Text += x + "-";
                        }

                        Route_result.Text = Route_result.Text.Substring(0, Route_result.Text.Length - 1);
                        Steps_taken.Text = bfs_sol.numsOfSteps().ToString();
                    }

                    Nodes_taken.Text = bfs_sol.numsOfNode().ToString();
                    et_value.Text = et.ElapsedMilliseconds + " ms";
                    et.Reset();
                    BFS_solved = true;
                    DFS_solved = false;
                } else if (algorithm == "DFS") {
                    Pick_algorithm_warning.Text = "";
                    dfs_sol = new DFSSolver();
                    dfs_sol.fillMaze(fileName);
                    et.Start();

                    if (TSP) {
                        dfs_sol.solveAndTSP();
                        et.Stop();
                    } else {
                        dfs_sol.solve();
                        et.Stop();
                    }

                    foreach (String x in dfs_sol.getSequenceOfDirection()) {
                        Route_result.Text += x + "-";
                    }

                    Route_result.Text = Route_result.Text.Substring(0, Route_result.Text.Length - 1);
                    Steps_taken.Text = (dfs_sol.getRoute().Length-1).ToString();
                    Nodes_taken.Text = (dfs_sol.getRoute().Length - 1).ToString();
                    et_value.Text = et.ElapsedMilliseconds +" ms";
                    et.Reset();
                    DFS_solved = true;
                    BFS_solved = false;
                } else {
                    algorithm = "";
                    Pick_algorithm_warning.Text = "Pick the algorithm first!";
                }
            } else {
                Browse_file_warning.Text = "Choose a txt file first!";
            }
        }

        // Tombol transisi algoritma BFS
        private void BFS_option_CheckedChanged(object sender, EventArgs e) {
            algorithm = "BFS";
        }

        // Tombol transisi algoritma DFS
        private void DFS_option_CheckedChanged(object sender, EventArgs e) {
            algorithm = "DFS";
        }

        // Menghapus elemen warna pada tabel
        public void ClearTable() {
            foreach (DataGridViewRow row in grid_hartakarun.Rows) {
                for (int i = 0; i < grid_hartakarun.ColumnCount; i++) { 
                    if (row.Cells[i].Style.BackColor != Color.Black) {
                        row.Cells[i].Style.BackColor = Color.White;
                    }
                }
            }
        }

        // Tombol visualisasi tombol
        private void Visualize_Button_Click(object sender, EventArgs e) {
            if (BFS_solved) {
                ClearTable();
                Visualize_Warning.Text = "";
                BFS_Algo();
                BFS_solved = false;
            } else if (DFS_solved) {
                ClearTable();
                Visualize_Warning.Text = "";
                DFS_Algo();
                DFS_solved = false;
            } else {
                Visualize_Warning.Text = "Solve the chosen file first!";
            }
        }

        // Scrollbar delay time
        private void Delay_Scrollbar_Scroll(object sender, EventArgs e) {
            delay_value.Text = Delay_Scrollbar.Value.ToString();
            delay = Delay_Scrollbar.Value;
        }

        // Tombol checkbox TSP
        private void TSP_checkBox_CheckedChanged(object sender, EventArgs e) {
            if (TSP_checkBox.Checked) {
                TSP = true;
            } else {
                TSP = false;
            }
        }
    }
}