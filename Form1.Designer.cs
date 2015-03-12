namespace ImageGroupUtil
{
    partial class Form1
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
            this.dataGridViewSource = new System.Windows.Forms.DataGridView();
            this.ColumnSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxDstPath = new System.Windows.Forms.TextBox();
            this.buttonExplorer = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.dataGridViewConflit = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConflit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSource
            // 
            this.dataGridViewSource.AllowUserToAddRows = false;
            this.dataGridViewSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSrc,
            this.ColumnButton});
            this.dataGridViewSource.Location = new System.Drawing.Point(6, 46);
            this.dataGridViewSource.Name = "dataGridViewSource";
            this.dataGridViewSource.RowHeadersVisible = false;
            this.dataGridViewSource.RowTemplate.Height = 23;
            this.dataGridViewSource.Size = new System.Drawing.Size(458, 162);
            this.dataGridViewSource.TabIndex = 0;
            this.dataGridViewSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSource_CellContentClick);
            // 
            // ColumnSrc
            // 
            this.ColumnSrc.HeaderText = "源路径";
            this.ColumnSrc.Name = "ColumnSrc";
            this.ColumnSrc.Width = 300;
            // 
            // ColumnButton
            // 
            this.ColumnButton.HeaderText = "浏览";
            this.ColumnButton.Name = "ColumnButton";
            this.ColumnButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnButton.Text = "浏览";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标路径:";
            // 
            // textBoxDstPath
            // 
            this.textBoxDstPath.Location = new System.Drawing.Point(69, 6);
            this.textBoxDstPath.Name = "textBoxDstPath";
            this.textBoxDstPath.Size = new System.Drawing.Size(314, 21);
            this.textBoxDstPath.TabIndex = 2;
            // 
            // buttonExplorer
            // 
            this.buttonExplorer.Location = new System.Drawing.Point(389, 6);
            this.buttonExplorer.Name = "buttonExplorer";
            this.buttonExplorer.Size = new System.Drawing.Size(75, 23);
            this.buttonExplorer.TabIndex = 3;
            this.buttonExplorer.Text = "浏览";
            this.buttonExplorer.UseVisualStyleBackColor = true;
            this.buttonExplorer.Click += new System.EventHandler(this.buttonExplorer_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(5, 261);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "处理";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // dataGridViewConflit
            // 
            this.dataGridViewConflit.AllowUserToAddRows = false;
            this.dataGridViewConflit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConflit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3});
            this.dataGridViewConflit.Location = new System.Drawing.Point(5, 290);
            this.dataGridViewConflit.Name = "dataGridViewConflit";
            this.dataGridViewConflit.RowHeadersVisible = false;
            this.dataGridViewConflit.RowTemplate.Height = 23;
            this.dataGridViewConflit.Size = new System.Drawing.Size(458, 191);
            this.dataGridViewConflit.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "源路径";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "冲突文件";
            this.Column3.Name = "Column3";
            this.Column3.Width = 210;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(308, 214);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "增加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(389, 214);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 493);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.buttonExplorer);
            this.Controls.Add(this.textBoxDstPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewConflit);
            this.Controls.Add(this.dataGridViewSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "jpg util";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConflit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxDstPath;
        private System.Windows.Forms.Button buttonExplorer;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.DataGridView dataGridViewConflit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSrc;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButton;
    }
}

