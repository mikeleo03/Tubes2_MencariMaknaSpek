﻿namespace TreasureHunt
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
            ((System.ComponentModel.ISupportInitialize)(this.grid_hartakarun)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.ForeColor = System.Drawing.Color.Black;
            this.Title_Label.Location = new System.Drawing.Point(12, 9);
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
            this.Input_Label.Location = new System.Drawing.Point(81, 110);
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
            this.Output_Label.Location = new System.Drawing.Point(708, 110);
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
            this.Filename_label.Location = new System.Drawing.Point(83, 219);
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
            this.browse_button.Text = "Search";
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
            this.grid_hartakarun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.grid_hartakarun.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grid_hartakarun.BackgroundColor = System.Drawing.Color.LightBlue;
            this.grid_hartakarun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_hartakarun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_hartakarun.ColumnHeadersVisible = false;
            this.grid_hartakarun.Enabled = false;
            this.grid_hartakarun.Location = new System.Drawing.Point(725, 219);
            this.grid_hartakarun.MultiSelect = false;
            this.grid_hartakarun.Name = "grid_hartakarun";
            this.grid_hartakarun.ReadOnly = true;
            this.grid_hartakarun.RowHeadersVisible = false;
            this.grid_hartakarun.RowHeadersWidth = 51;
            this.grid_hartakarun.RowTemplate.Height = 24;
            this.grid_hartakarun.Size = new System.Drawing.Size(559, 539);
            this.grid_hartakarun.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TreasureFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1418, 1033);
            this.Controls.Add(this.grid_hartakarun);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.Filename_iotbox);
            this.Controls.Add(this.Filename_label);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.Input_Label);
            this.Controls.Add(this.Title_Label);
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
    }
}

