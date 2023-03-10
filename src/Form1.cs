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

namespace TreasureHunt
{
    public partial class TreasureFinder : Form
    {
        //public var fileContent = string.Empty;
        //public var filePath = string.Empty;
        public TreasureFinder()
        {
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {

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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*// Nyimpen pathnya
                filePath = openFileDialog1.FileName;

                // Baca isi file 
                var fileStream = openFileDialog1.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }*/


                // Ini yang dicoba

                //textBox1.text = openFileDialog1.fileName; // blm ada text box jadi g dulu
                // DataGrid.file = textBox1.text;
                grid_hartakarun.DataSource = DataGrid.DataTableFromTextFile(openFileDialog1.FileName);
            }

        }

        private void grid_hartakarun_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // Pewarnaan grid terbaca 
        {
            foreach (DataGridViewRow row in grid_hartakarun.Rows)
            {
                for (int i = 0; i < grid_hartakarun.ColumnCount; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (Convert.ToString(row.Cells[i].Value) == "X")
                        {
                            row.Cells[i].Style.BackColor = Color.Black;
                            row.Cells[i].Style.ForeColor = Color.Black;
                        }
                        else if (Convert.ToString(row.Cells[i].Value) == "K")
                        {
                            //row.Cells[i].Style.BackColor = Color.Yellow;
                            row.Cells[i].Style.BackColor = Color.White;
                        }
                        else if (Convert.ToString(row.Cells[i].Value) == "R")
                        {
                            row.Cells[i].Style.ForeColor = Color.White;
                            row.Cells[i].Style.BackColor = Color.White;
                        }
                        else if (Convert.ToString(row.Cells[i].Value) == "T")
                        {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }
    }
    }
