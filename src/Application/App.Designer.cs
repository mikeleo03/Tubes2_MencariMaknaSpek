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
            this.components = new System.ComponentModel.Container();
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
            this.Visualize_Button = new System.Windows.Forms.Button();
            this.Browse_file_warning = new System.Windows.Forms.Label();
            this.Line2 = new System.Windows.Forms.Label();
            this.Route_Label = new System.Windows.Forms.Label();
            this.Steps_Label = new System.Windows.Forms.Label();
            this.Nodes_Label = new System.Windows.Forms.Label();
            this.ExT_Label = new System.Windows.Forms.Label();
            this.Visualize_Warning = new System.Windows.Forms.Label();
            this.Delay_Scrollbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.delay_value = new System.Windows.Forms.Label();
            this.milisekon_label = new System.Windows.Forms.Label();
            this.Execution_time = new System.Windows.Forms.Timer(this.components);
            this.et_value = new System.Windows.Forms.Label();
            this.TSP_checkBox = new System.Windows.Forms.CheckBox();
            this.Route_result = new System.Windows.Forms.Label();
            this.Steps_taken = new System.Windows.Forms.Label();
            this.Nodes_taken = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hartakarun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delay_Scrollbar)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title_Label.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.ForeColor = System.Drawing.Color.Black;
            this.Title_Label.Location = new System.Drawing.Point(-16, 9);
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
            this.Input_Label.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Label.Location = new System.Drawing.Point(31, 110);
            this.Input_Label.Name = "Input_Label";
            this.Input_Label.Size = new System.Drawing.Size(254, 43);
            this.Input_Label.TabIndex = 1;
            this.Input_Label.Text = "Input";
            this.Input_Label.Click += new System.EventHandler(this.label2_Click);
            // 
            // Output_Label
            // 
            this.Output_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Output_Label.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output_Label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Output_Label.Location = new System.Drawing.Point(381, 94);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(698, 43);
            this.Output_Label.TabIndex = 2;
            this.Output_Label.Text = "Output";
            this.Output_Label.Click += new System.EventHandler(this.label3_Click);
            // 
            // Filename_label
            // 
            this.Filename_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Filename_label.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filename_label.Location = new System.Drawing.Point(30, 219);
            this.Filename_label.Name = "Filename_label";
            this.Filename_label.Size = new System.Drawing.Size(224, 43);
            this.Filename_label.TabIndex = 3;
            this.Filename_label.Text = "Filename";
            this.Filename_label.Click += new System.EventHandler(this.label4_Click);
            // 
            // Filename_iotbox
            // 
            this.Filename_iotbox.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filename_iotbox.Location = new System.Drawing.Point(33, 265);
            this.Filename_iotbox.Name = "Filename_iotbox";
            this.Filename_iotbox.Size = new System.Drawing.Size(140, 23);
            this.Filename_iotbox.TabIndex = 4;
            // 
            // browse_button
            // 
            this.browse_button.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse_button.Location = new System.Drawing.Point(33, 309);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 36);
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
            this.grid_hartakarun.Location = new System.Drawing.Point(411, 190);
            this.grid_hartakarun.MultiSelect = false;
            this.grid_hartakarun.Name = "grid_hartakarun";
            this.grid_hartakarun.ReadOnly = true;
            this.grid_hartakarun.RowHeadersVisible = false;
            this.grid_hartakarun.RowHeadersWidth = 51;
            this.grid_hartakarun.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_hartakarun.RowTemplate.Height = 24;
            this.grid_hartakarun.Size = new System.Drawing.Size(580, 375);
            this.grid_hartakarun.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Algoritma_Label
            // 
            this.Algoritma_Label.AutoSize = true;
            this.Algoritma_Label.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Algoritma_Label.Location = new System.Drawing.Point(33, 386);
            this.Algoritma_Label.Name = "Algoritma_Label";
            this.Algoritma_Label.Size = new System.Drawing.Size(128, 36);
            this.Algoritma_Label.TabIndex = 7;
            this.Algoritma_Label.Text = "Algoritma";
            // 
            // BFS_option
            // 
            this.BFS_option.AutoSize = true;
            this.BFS_option.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFS_option.Location = new System.Drawing.Point(39, 440);
            this.BFS_option.Name = "BFS_option";
            this.BFS_option.Size = new System.Drawing.Size(53, 22);
            this.BFS_option.TabIndex = 8;
            this.BFS_option.TabStop = true;
            this.BFS_option.Text = "BFS";
            this.BFS_option.UseVisualStyleBackColor = true;
            this.BFS_option.CheckedChanged += new System.EventHandler(this.BFS_option_CheckedChanged);
            // 
            // DFS_option
            // 
            this.DFS_option.AutoSize = true;
            this.DFS_option.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFS_option.Location = new System.Drawing.Point(39, 466);
            this.DFS_option.Name = "DFS_option";
            this.DFS_option.Size = new System.Drawing.Size(55, 22);
            this.DFS_option.TabIndex = 9;
            this.DFS_option.TabStop = true;
            this.DFS_option.Text = "DFS";
            this.DFS_option.UseVisualStyleBackColor = true;
            this.DFS_option.CheckedChanged += new System.EventHandler(this.DFS_option_CheckedChanged);
            // 
            // Pick_algorithm_warning
            // 
            this.Pick_algorithm_warning.AutoSize = true;
            this.Pick_algorithm_warning.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pick_algorithm_warning.ForeColor = System.Drawing.Color.Red;
            this.Pick_algorithm_warning.Location = new System.Drawing.Point(36, 499);
            this.Pick_algorithm_warning.Name = "Pick_algorithm_warning";
            this.Pick_algorithm_warning.Size = new System.Drawing.Size(36, 17);
            this.Pick_algorithm_warning.TabIndex = 10;
            this.Pick_algorithm_warning.Text = "              ";
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(668, 572);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 36);
            this.Search.TabIndex = 11;
            this.Search.Text = "Solve";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click_1);
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.Black;
            this.Line.Location = new System.Drawing.Point(17, 70);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(1500, 2);
            this.Line.TabIndex = 7;
            this.Line.Text = " \r\n";
            // 
            // Visualize_Button
            // 
            this.Visualize_Button.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Visualize_Button.Location = new System.Drawing.Point(39, 597);
            this.Visualize_Button.Name = "Visualize_Button";
            this.Visualize_Button.Size = new System.Drawing.Size(196, 40);
            this.Visualize_Button.TabIndex = 16;
            this.Visualize_Button.Text = "Visualize";
            this.Visualize_Button.UseVisualStyleBackColor = true;
            this.Visualize_Button.Click += new System.EventHandler(this.Visualize_Button_Click);
            // 
            // Browse_file_warning
            // 
            this.Browse_file_warning.AutoSize = true;
            this.Browse_file_warning.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse_file_warning.ForeColor = System.Drawing.Color.Red;
            this.Browse_file_warning.Location = new System.Drawing.Point(33, 348);
            this.Browse_file_warning.Name = "Browse_file_warning";
            this.Browse_file_warning.Size = new System.Drawing.Size(28, 17);
            this.Browse_file_warning.TabIndex = 17;
            this.Browse_file_warning.Text = "          ";
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(331, 110);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(2, 652);
            this.Line2.TabIndex = 18;
            this.Line2.Text = " ";
            // 
            // Route_Label
            // 
            this.Route_Label.AutoSize = true;
            this.Route_Label.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Route_Label.Location = new System.Drawing.Point(365, 620);
            this.Route_Label.Name = "Route_Label";
            this.Route_Label.Size = new System.Drawing.Size(85, 17);
            this.Route_Label.TabIndex = 19;
            this.Route_Label.Text = "Routes                 : ";
            // 
            // Steps_Label
            // 
            this.Steps_Label.AutoSize = true;
            this.Steps_Label.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Steps_Label.Location = new System.Drawing.Point(1016, 309);
            this.Steps_Label.Name = "Steps_Label";
            this.Steps_Label.Size = new System.Drawing.Size(82, 17);
            this.Steps_Label.TabIndex = 20;
            this.Steps_Label.Text = "Steps                   : ";
            // 
            // Nodes_Label
            // 
            this.Nodes_Label.AutoSize = true;
            this.Nodes_Label.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nodes_Label.Location = new System.Drawing.Point(1013, 406);
            this.Nodes_Label.Name = "Nodes_Label";
            this.Nodes_Label.Size = new System.Drawing.Size(83, 17);
            this.Nodes_Label.TabIndex = 21;
            this.Nodes_Label.Text = "Nodes                  : ";
            // 
            // ExT_Label
            // 
            this.ExT_Label.AutoSize = true;
            this.ExT_Label.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExT_Label.Location = new System.Drawing.Point(1016, 499);
            this.ExT_Label.Name = "ExT_Label";
            this.ExT_Label.Size = new System.Drawing.Size(100, 17);
            this.ExT_Label.TabIndex = 22;
            this.ExT_Label.Text = "Execution Time    :";
            // 
            // Visualize_Warning
            // 
            this.Visualize_Warning.AutoSize = true;
            this.Visualize_Warning.ForeColor = System.Drawing.Color.Red;
            this.Visualize_Warning.Location = new System.Drawing.Point(78, 738);
            this.Visualize_Warning.Name = "Visualize_Warning";
            this.Visualize_Warning.Size = new System.Drawing.Size(112, 16);
            this.Visualize_Warning.TabIndex = 23;
            this.Visualize_Warning.Text = "                                   ";
            // 
            // Delay_Scrollbar
            // 
            this.Delay_Scrollbar.Location = new System.Drawing.Point(1039, 187);
            this.Delay_Scrollbar.Maximum = 2000;
            this.Delay_Scrollbar.Minimum = 100;
            this.Delay_Scrollbar.Name = "Delay_Scrollbar";
            this.Delay_Scrollbar.Size = new System.Drawing.Size(210, 56);
            this.Delay_Scrollbar.TabIndex = 24;
            this.Delay_Scrollbar.Value = 100;
            this.Delay_Scrollbar.Scroll += new System.EventHandler(this.Delay_Scrollbar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1044, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 36);
            this.label2.TabIndex = 25;
            this.label2.Text = "Delay Interval";
            // 
            // delay_value
            // 
            this.delay_value.AutoSize = true;
            this.delay_value.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delay_value.Location = new System.Drawing.Point(1098, 235);
            this.delay_value.Name = "delay_value";
            this.delay_value.Size = new System.Drawing.Size(30, 17);
            this.delay_value.TabIndex = 26;
            this.delay_value.Text = "           ";
            // 
            // milisekon_label
            // 
            this.milisekon_label.AutoSize = true;
            this.milisekon_label.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.milisekon_label.Location = new System.Drawing.Point(1148, 235);
            this.milisekon_label.Name = "milisekon_label";
            this.milisekon_label.Size = new System.Drawing.Size(24, 17);
            this.milisekon_label.TabIndex = 27;
            this.milisekon_label.Text = "ms";
            // 
            // Execution_time
            // 
            this.Execution_time.Interval = 50;
            // 
            // et_value
            // 
            this.et_value.AutoSize = true;
            this.et_value.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.et_value.Location = new System.Drawing.Point(1142, 499);
            this.et_value.Name = "et_value";
            this.et_value.Size = new System.Drawing.Size(44, 17);
            this.et_value.TabIndex = 28;
            this.et_value.Text = "                  ";
            // 
            // TSP_checkBox
            // 
            this.TSP_checkBox.AutoSize = true;
            this.TSP_checkBox.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSP_checkBox.Location = new System.Drawing.Point(39, 545);
            this.TSP_checkBox.Name = "TSP_checkBox";
            this.TSP_checkBox.Size = new System.Drawing.Size(55, 22);
            this.TSP_checkBox.TabIndex = 29;
            this.TSP_checkBox.Text = "TSP";
            this.TSP_checkBox.UseVisualStyleBackColor = true;
            this.TSP_checkBox.CheckedChanged += new System.EventHandler(this.TSP_checkBox_CheckedChanged);
            // 
            // Route_result
            // 
            this.Route_result.AutoSize = true;
            this.Route_result.Location = new System.Drawing.Point(466, 621);
            this.Route_result.Name = "Route_result";
            this.Route_result.Size = new System.Drawing.Size(64, 16);
            this.Route_result.TabIndex = 30;
            this.Route_result.Text = "                   ";
            // 
            // Steps_taken
            // 
            this.Steps_taken.AutoSize = true;
            this.Steps_taken.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Steps_taken.Location = new System.Drawing.Point(1142, 309);
            this.Steps_taken.Name = "Steps_taken";
            this.Steps_taken.Size = new System.Drawing.Size(34, 17);
            this.Steps_taken.TabIndex = 31;
            this.Steps_taken.Text = "             ";
            // 
            // Nodes_taken
            // 
            this.Nodes_taken.AutoSize = true;
            this.Nodes_taken.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nodes_taken.Location = new System.Drawing.Point(1142, 406);
            this.Nodes_taken.Name = "Nodes_taken";
            this.Nodes_taken.Size = new System.Drawing.Size(38, 17);
            this.Nodes_taken.TabIndex = 32;
            this.Nodes_taken.Text = "               ";
            // 
            // TreasureFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1362, 674);
            this.Controls.Add(this.Nodes_taken);
            this.Controls.Add(this.Steps_taken);
            this.Controls.Add(this.Route_result);
            this.Controls.Add(this.TSP_checkBox);
            this.Controls.Add(this.et_value);
            this.Controls.Add(this.milisekon_label);
            this.Controls.Add(this.delay_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Delay_Scrollbar);
            this.Controls.Add(this.Visualize_Warning);
            this.Controls.Add(this.ExT_Label);
            this.Controls.Add(this.Nodes_Label);
            this.Controls.Add(this.Steps_Label);
            this.Controls.Add(this.Route_Label);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.Browse_file_warning);
            this.Controls.Add(this.Visualize_Button);
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
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreasureFinder";
            ((System.ComponentModel.ISupportInitialize)(this.grid_hartakarun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delay_Scrollbar)).EndInit();
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
        private System.Windows.Forms.Button Visualize_Button;
        private System.Windows.Forms.Label Browse_file_warning;
        private System.Windows.Forms.Label Line2;
        private System.Windows.Forms.Label Route_Label;
        private System.Windows.Forms.Label Steps_Label;
        private System.Windows.Forms.Label Nodes_Label;
        private System.Windows.Forms.Label ExT_Label;
        private System.Windows.Forms.Label Visualize_Warning;
        private System.Windows.Forms.TrackBar Delay_Scrollbar;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label delay_value;
        private System.Windows.Forms.Label milisekon_label;
        private System.Windows.Forms.Timer Execution_time;
        private System.Windows.Forms.Label et_value;
        private System.Windows.Forms.CheckBox TSP_checkBox;
        private System.Windows.Forms.Label Route_result;
        private System.Windows.Forms.Label Steps_taken;
        private System.Windows.Forms.Label Nodes_taken;
    }
}