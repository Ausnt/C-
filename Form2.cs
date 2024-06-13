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
namespace BaiThi
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
            ColorDialog cld = new ColorDialog();
            FontDialog fd = new FontDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            dl.Filter = "Text files (*.txt)|*.txt";
            DialogResult rs = dl.ShowDialog();
            if (rs == DialogResult.OK)
            {
                StreamReader f = new StreamReader(dl.FileName);
                richTextBox1.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void nmSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dl = new SaveFileDialog();
            dl.Filter = "Open files |*.txt";
            DialogResult  rs = dl.ShowDialog();
            if (rs == DialogResult.OK)
            {
                StreamWriter f = new StreamWriter(dl.FileName);
                f.Write(richTextBox1.Text);
                f.Close();
            }
        }

        private void mnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void contextMenuStrip4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Áp dụng màu được chọn vào văn bản đang được chọn (nếu có)
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
                else
                {
                    // Nếu không có văn bản nào được chọn, thì áp dụng màu cho văn bản tiếp theo được thêm vào
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void richTextBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Hiển thị menu context
                ContextMenu contextMenu = new ContextMenu();

                // Tạo menu cho màu
                MenuItem colorMenuItem = new MenuItem("Chọn màu");
                colorMenuItem.Click += contextMenuStrip4_Click;
                contextMenu.MenuItems.Add(colorMenuItem);

                // Tạo menu cho định dạng văn bản (ví dụ: in đậm, in nghiêng)
                MenuItem formatMenuItem = new MenuItem("Định dạng văn bản");
                // Thêm các tùy chọn định dạng văn bản vào đây
                contextMenu.MenuItems.Add(formatMenuItem);

                // Hiển thị menu tại vị trí chuột
                contextMenu.Show(richTextBox1, e.Location);
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                

                // Hiển thị menu tại vị trí chuột
                contextMenuStrip1.Show(richTextBox1, e.Location);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void setColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog cld = new ColorDialog();
            DialogResult color = cld.ShowDialog();
            // See if user pressed ok.
            if (color == DialogResult.OK)
            {
                // Set Color to the selected text
                this.richTextBox1.SelectionColor = cld.Color;
            }
        }

        private void setFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult font = fd.ShowDialog();
            if (font == DialogResult.OK)
            {
                // Set selection font to the fontDialog1.Font
                this.richTextBox1.SelectionFont = fd.Font;
            }
        }
    }
}
