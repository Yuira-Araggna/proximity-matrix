namespace Proximity_Matrix
{
    partial class FormUtama
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
			this.buttonLoad = new System.Windows.Forms.Button();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.buttonShow = new System.Windows.Forms.Button();
			this.dataGridViewCSV = new System.Windows.Forms.DataGridView();
			this.buttonProximity = new System.Windows.Forms.Button();
			this.buttonSimpanHasil = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCSV)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(397, 4);
			this.buttonLoad.Margin = new System.Windows.Forms.Padding(2);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(88, 38);
			this.buttonLoad.TabIndex = 0;
			this.buttonLoad.Text = "Load File";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxOutput.Location = new System.Drawing.Point(9, 5);
			this.textBoxOutput.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.Size = new System.Drawing.Size(311, 38);
			this.textBoxOutput.TabIndex = 1;
			// 
			// buttonShow
			// 
			this.buttonShow.Location = new System.Drawing.Point(500, 4);
			this.buttonShow.Margin = new System.Windows.Forms.Padding(2);
			this.buttonShow.Name = "buttonShow";
			this.buttonShow.Size = new System.Drawing.Size(86, 38);
			this.buttonShow.TabIndex = 2;
			this.buttonShow.Text = "Show File";
			this.buttonShow.UseVisualStyleBackColor = true;
			this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
			// 
			// dataGridViewCSV
			// 
			this.dataGridViewCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCSV.Location = new System.Drawing.Point(9, 47);
			this.dataGridViewCSV.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewCSV.Name = "dataGridViewCSV";
			this.dataGridViewCSV.RowHeadersWidth = 51;
			this.dataGridViewCSV.RowTemplate.Height = 24;
			this.dataGridViewCSV.Size = new System.Drawing.Size(577, 423);
			this.dataGridViewCSV.TabIndex = 3;
			// 
			// buttonProximity
			// 
			this.buttonProximity.Location = new System.Drawing.Point(7, 474);
			this.buttonProximity.Margin = new System.Windows.Forms.Padding(2);
			this.buttonProximity.Name = "buttonProximity";
			this.buttonProximity.Size = new System.Drawing.Size(132, 46);
			this.buttonProximity.TabIndex = 4;
			this.buttonProximity.Text = "Hitung Proximity";
			this.buttonProximity.UseVisualStyleBackColor = true;
			this.buttonProximity.Click += new System.EventHandler(this.buttonProximity_Click);
			// 
			// buttonSimpanHasil
			// 
			this.buttonSimpanHasil.Location = new System.Drawing.Point(143, 474);
			this.buttonSimpanHasil.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSimpanHasil.Name = "buttonSimpanHasil";
			this.buttonSimpanHasil.Size = new System.Drawing.Size(132, 46);
			this.buttonSimpanHasil.TabIndex = 6;
			this.buttonSimpanHasil.Text = "Simpan Hasil Proximity ";
			this.buttonSimpanHasil.UseVisualStyleBackColor = true;
			this.buttonSimpanHasil.Click += new System.EventHandler(this.buttonSimpanHasil_Click);
			// 
			// FormUtama
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 531);
			this.Controls.Add(this.buttonSimpanHasil);
			this.Controls.Add(this.buttonProximity);
			this.Controls.Add(this.dataGridViewCSV);
			this.Controls.Add(this.buttonShow);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.buttonLoad);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormUtama";
			this.Text = "Form Utama";
			this.Load += new System.EventHandler(this.FormUtama_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCSV)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.DataGridView dataGridViewCSV;
        private System.Windows.Forms.Button buttonProximity;
        private System.Windows.Forms.Button buttonSimpanHasil;
    }
}

