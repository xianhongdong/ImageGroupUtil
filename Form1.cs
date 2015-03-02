/******************************************************
* author :  xianhongdong
* description: 
* history:  created by xianhongdong 3/2/2015 2:53:47 PM 
******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageGroupUtil
{
    public partial class Form1 : Form
    {
        string dstDir = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            dataGridViewSource.Rows.Add("", "浏览");
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if(dataGridViewSource.CurrentCell != null)
            {
                dataGridViewSource.Rows.RemoveAt(dataGridViewSource.CurrentCell.RowIndex);                
            }
            else if(dataGridViewSource.CurrentRow != null)
            {
                dataGridViewSource.Rows.Remove(dataGridViewSource.CurrentRow);
            }
        }

        private void buttonExplorer_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxDstPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var clickColumn = dataGridViewSource.Columns[e.ColumnIndex];
            if(clickColumn is DataGridViewButtonColumn)
            {
                if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dataGridViewSource.Rows[e.RowIndex].Cells[0].Value = folderBrowserDialog1.SelectedPath;
                }
            }
            
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            dstDir = textBoxDstPath.Text.Trim();
            var srcDirs = new HashSet<string>();
            if (!Directory.Exists(dstDir))
            {
                var info = string.Format("目录:{0},不存在", dstDir);
                return;
            }
            foreach(DataGridViewRow row in dataGridViewSource.Rows)
            {
                var src = row.Cells[0].Value as string;
                src = src.Trim();
                if(!Directory.Exists(src))
                {
                    var info = string.Format("目录:{0},不存在",src);
                    MessageBox.Show(info);
                    return;
                }
                srcDirs.Add(src);
            }
            var result = new List<RelocateFailFile>();
            var flag = true;
            foreach(var path in srcDirs)
            {
                var dirInfo = new DirectoryInfo(path);
                if(!ImageDateTimeGroupUtil.RelocateDiretoryFile(dirInfo,dstDir,result))
                {
                    flag = false;
                }
            }
            if(!flag)
            {
                dataGridViewConflit.Rows.Clear();
                foreach(var item in result)
                {
                    dataGridViewConflit.Rows.Add(item.SourceFile,item.ConflitFile);
                }
            }
            else
            {
                MessageBox.Show("处理成功");
            }
        }
    }
}
