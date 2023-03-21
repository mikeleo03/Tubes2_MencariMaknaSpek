namespace TreasureHunt
{
    partial class TreasureFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title_Label = new System.Windows.Forms.Label();
            this.Input_Label = new System.Windows.Forms.Label();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Filename_label = new System.Windows.Forms.Label();
            this.Filename_iotbox = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.grid_hartakarun = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Algoritma_Label = new System.Windows.Forms.Label();
            this.BFS_option = new System.Windows.Forms.RadioButton();
            this.DFS_option = new System.Windows.Forms.RadioButton();
            this.Pick_algorithm_warning = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Label();
            this.TPS_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.No_TSP_RadioButon = new System.Windows.Forms.RadioButton();
            this.Yes_TSP_RadioButton = new System.Windows.Forms.RadioButton();
            this.Visualize_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Line2 = new System.Windows.Forms.Label();
            this.Route_Label = new System.Windows.Forms.Label();
            this.Steps_Label = new System.Windows.Forms.Label();
            this.Nodes_Label = new System.Windows.Forms.Label();
            this.ExT_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hartakarun)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.ForeColor = System.Drawing.Color.Black;
            this.Title_Label.Location = new System.Drawing.Point(123, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(1406, 43);
            this.Title_Label.TabIndex = 0;
            this.Title_Label.Text = "Treasure Hunt Solver";
            this.Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Input_Label
            // 
            this.Input_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Input_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Label.Location = new System.Drawing.Point(38, 110);
            this.Input_Label.Name = "Input_Label";
            this.Input_Label.Size = new System.Drawing.Size(611, 43);
            this.Input_Label.TabIndex = 1;
            this.Input_Label.Text = "Input";
            this.Input_Label.Click += new System.EventHandler(this.label2_Click);
            // 
            // Output_Label
            // 
            this.Output_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Output_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output_Label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Output_Label.Location = new System.Drawing.Point(692, 110);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(698, 43);
            this.Output_Label.TabIndex = 2;
            this.Output_Label.Text = "Output";
            this.Output_Label.Click += new System.EventHandler(this.label3_Click);
            // 
            // Filename_label
            // 
            this.Filename_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Filename_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filename_label.Location = new System.Drawing.Point(40, 219);
            this.Filename_label.Name = "Filename_label";
            this.Filename_label.Size = new System.Drawing.Size(224, 43);
            this.Filename_label.TabIndex = 3;
            this.Filename_label.Text = "Filename";
            this.Filename_label.Click += new System.EventHandler(this.label4_Click);
            // 
            // Filename_iotbox
            // 
            this.Filename_iotbox.Location = new System.Drawing.Point(89, 265);
            this.Filename_iotbox.Name = "Filename_iotbox";
            this.Filename_iotbox.Size = new System.Drawing.Size(140, 22);
            this.Filename_iotbox.TabIndex = 4;
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(89, 305);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 5;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // grid_hartakarun
            // 
            this.grid_hartakarun.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.grid_hartakarun.AllowUserToAddRows = false;
            this.grid_hartakarun.AllowUserToDeleteRows = false;
            this.grid_hartakarun.AllowUserToResizeColumns = false;
            this.grid_hartakarun.AllowUserToResizeRows = false;
            this.grid_hartakarun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grid_hartakarun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_hartakarun.BackgroundColor = System.Drawing.Color.LightBlue;
            this.grid_hartakarun.ColumnHeadersHeight = 29;
            this.grid_hartakarun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_hartakarun.ColumnHeadersVisible = false;
            this.grid_hartakarun.Enabled = false;
            this.grid_hartakarun.Location = new System.Drawing.Point(700, 219);
            this.grid_hartakarun.MultiSelect = false;
            this.grid_hartakarun.Name = "grid_hartakarun";
            this.grid_hartakarun.ReadOnly = true;
            this.grid_hartakarun.RowHeadersVisible = false;
            this.grid_hartakarun.RowHeadersWidth = 51;
            this.grid_hartakarun.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_hartakarun.RowTemplate.Height = 24;
            this.grid_hartakarun.Size = new System.Drawing.Size(580, 453);
            this.grid_hartakarun.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Algoritma_Label
            // 
            this.Algoritma_Label.AutoSize = true;
            this.Algoritma_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Algoritma_Label.Location = new System.Drawing.Point(89, 382);
            this.Algoritma_Label.Name = "Algoritma_Label";
            this.Algoritma_Label.Size = new System.Drawing.Size(159, 34);
            this.Algoritma_Label.TabIndex = 7;
            this.Algoritma_Label.Text = "Algoritma";
            // 
            // BFS_option
            // 
            this.BFS_option.AutoSize = true;
            this.BFS_option.Location = new System.Drawing.Point(95, 436);
            this.BFS_option.Name = "BFS_option";
            this.BFS_option.Size = new System.Drawing.Size(54, 20);
            this.BFS_option.TabIndex = 8;
            this.BFS_option.TabStop = true;
            this.BFS_option.Text = "BFS";
            this.BFS_option.UseVisualStyleBackColor = true;
            this.BFS_option.CheckedChanged += new System.EventHandler(this.BFS_option_CheckedChanged);
            // 
            // DFS_option
            // 
            this.DFS_option.AutoSize = true;
            this.DFS_option.Location = new System.Drawing.Point(95, 462);
            this.DFS_option.Name = "DFS_option";
            this.DFS_option.Size = new System.Drawing.Size(55, 20);
            this.DFS_option.TabIndex = 9;
            this.DFS_option.TabStop = true;
            this.DFS_option.Text = "DFS";
            this.DFS_option.UseVisualStyleBackColor = true;
            this.DFS_option.CheckedChanged += new System.EventHandler(this.DFS_option_CheckedChanged);
            // 
            // Pick_algorithm_warning
            // 
            this.Pick_algorithm_warning.AutoSize = true;
            this.Pick_algorithm_warning.ForeColor = System.Drawing.Color.Red;
            this.Pick_algorithm_warning.Location = new System.Drawing.Point(92, 495);
            this.Pick_algorithm_warning.Name = "Pick_algorithm_warning";
            this.Pick_algorithm_warning.Size = new System.Drawing.Size(49, 16);
            this.Pick_algorithm_warning.TabIndex = 10;
            this.Pick_algorithm_warning.Text = "              ";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(954, 693);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 11;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click_1);
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.Black;
            this.Line.Location = new System.Drawing.Point(17, 78);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(1600, 2);
            this.Line.TabIndex = 7;
            this.Line.Text = " \r\n";
            // 
            // TPS_Label
            // 
            this.TPS_Label.AutoSize = true;
            this.TPS_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPS_Label.Location = new System.Drawing.Point(89, 546);
            this.TPS_Label.Name = "TPS_Label";
            this.TPS_Label.Size = new System.Drawing.Size(74, 34);
            this.TPS_Label.TabIndex = 12;
            this.TPS_Label.Text = "TSP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(92, 656);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "              ";
            // 
            // No_TSP_RadioButon
            // 
            this.No_TSP_RadioButon.AutoSize = true;
            this.No_TSP_RadioButon.Location = new System.Drawing.Point(95, 623);
            this.No_TSP_RadioButon.Name = "No_TSP_RadioButon";
            this.No_TSP_RadioButon.Size = new System.Drawing.Size(46, 20);
            this.No_TSP_RadioButon.TabIndex = 14;
            this.No_TSP_RadioButon.TabStop = true;
            this.No_TSP_RadioButon.Text = "No";
            this.No_TSP_RadioButon.UseVisualStyleBackColor = true;
            // 
            // Yes_TSP_RadioButton
            // 
            this.Yes_TSP_RadioButton.AutoSize = true;
            this.Yes_TSP_RadioButton.Location = new System.Drawing.Point(95, 597);
            this.Yes_TSP_RadioButton.Name = "Yes_TSP_RadioButton";
            this.Yes_TSP_RadioButton.Size = new System.Drawing.Size(52, 20);
            this.Yes_TSP_RadioButton.TabIndex = 13;
            this.Yes_TSP_RadioButton.TabStop = true;
            this.Yes_TSP_RadioButton.Text = "Yes";
            this.Yes_TSP_RadioButton.UseVisualStyleBackColor = true;
            // 
            // Visualize_Button
            // 
            this.Visualize_Button.Location = new System.Drawing.Point(95, 693);
            this.Visualize_Button.Name = "Visualize_Button";
            this.Visualize_Button.Size = new System.Drawing.Size(264, 23);
            this.Visualize_Button.TabIndex = 16;
            this.Visualize_Button.Text = "Visualize";
            this.Visualize_Button.UseVisualStyleBackColor = true;
            this.Visualize_Button.Click += new System.EventHandler(this.Visualize_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(89, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "          ";
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(464, 136);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(2, 700);
            this.Line2.TabIndex = 18;
            this.Line2.Text = " ";
            // 
            // Route_Label
            // 
            this.Route_Label.AutoSize = true;
            this.Route_Label.Location = new System.Drawing.Point(668, 738);
            this.Route_Label.Name = "Route_Label";
            this.Route_Label.Size = new System.Drawing.Size(107, 16);
            this.Route_Label.TabIndex = 19;
            this.Route_Label.Text = "Routes                 : ";
            // 
            // Steps_Label
            // 
            this.Steps_Label.AutoSize = true;
            this.Steps_Label.Location = new System.Drawing.Point(668, 765);
            this.Steps_Label.Name = "Steps_Label";
            this.Steps_Label.Size = new System.Drawing.Size(105, 16);
            this.Steps_Label.TabIndex = 20;
            this.Steps_Label.Text = "Steps                   : ";
            // 
            // Nodes_Label
            // 
            this.Nodes_Label.AutoSize = true;
            this.Nodes_Label.Location = new System.Drawing.Point(668, 790);
            this.Nodes_Label.Name = "Nodes_Label";
            this.Nodes_Label.Size = new System.Drawing.Size(108, 16);
            this.Nodes_Label.TabIndex = 21;
            this.Nodes_Label.Text = "Nodes                  : ";
            // 
            // ExT_Label
            // 
            this.ExT_Label.AutoSize = true;
            this.ExT_Label.Location = new System.Drawing.Point(668, 818);
            this.ExT_Label.Name = "ExT_Label";
            this.ExT_Label.Size = new System.Drawing.Size(114, 16);
            this.ExT_Label.TabIndex = 22;
            this.ExT_Label.Text = "Execution Time    :";
            // 
            // TreasureFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1641, 1033);
            this.Controls.Add(this.ExT_Label);
            this.Controls.Add(this.Nodes_Label);
            this.Controls.Add(this.Steps_Label);
            this.Controls.Add(this.Route_Label);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Visualize_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.No_TSP_RadioButon);
            this.Controls.Add(this.Yes_TSP_RadioButton);
            this.Controls.Add(this.TPS_Label);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Pick_algorithm_warning);
            this.Controls.Add(this.DFS_option);
            this.Controls.Add(this.BFS_option);
            this.Controls.Add(this.Algoritma_Label);
            this.Controls.Add(this.grid_hartakarun);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.Filename_iotbox);
            this.Controls.Add(this.Filename_label);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.Input_Label);
            this.Controls.Add(this.Title_Label);
            this.MaximizeBox = false;
            this.Name = "TreasureFinder";
            this.Text = "TreasureFinder";
            ((System.ComponentModel.ISupportInitialize)(this.grid_hartakarun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label Input_Label;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.Label Filename_label;
        private System.Windows.Forms.TextBox Filename_iotbox;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.DataGridView grid_hartakarun;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Algoritma_Label;
        private System.Windows.Forms.RadioButton BFS_option;
        private System.Windows.Forms.RadioButton DFS_option;
        private System.Windows.Forms.Label Pick_algorithm_warning;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label Line;
        private System.Windows.Forms.Label TPS_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton No_TSP_RadioButon;
        private System.Windows.Forms.RadioButton Yes_TSP_RadioButton;
        private System.Windows.Forms.Button Visualize_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Line2;
        private System.Windows.Forms.Label Route_Label;
        private System.Windows.Forms.Label Steps_Label;
        private System.Windows.Forms.Label Nodes_Label;
        private System.Windows.Forms.Label ExT_Label;
    }
}

