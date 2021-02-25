using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace 截图工具
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class MainWindow : Window 
    { 

        public MainWindow()
        {
            InitializeComponent();
        }


        // 新增
        private void Button_Click(object sender, MouseEventArgs e)
        {
            this.Hide();
            
            // 通过监听鼠标事件获取坐标点
            //System.Drawing.Point start = e.Location;
            Boolean drawing = true;
            
            while (drawing) {
                if (e.Button == MouseButtons.Left)
                {
                    System.Windows.Forms.MessageBox.Show("左键");
                }
                else if (e.Button == MouseButtons.Right)
                {
                    System.Windows.Forms.MessageBox.Show("右键");
                    drawing = false;
                }
            }

            // 通过坐标位置保存截取的图片
            using (Bitmap bitmap = new Bitmap(1000,300))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                    g.CopyFromScreen(new System.Drawing.Point(e.X,e.Y), System.Drawing.Point.Empty,new System.Drawing.Size(1000,300));

                }
                bitmap.Save(@"C:\Users\Administrator\Desktop\Capture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        // 鼠标事件:按下
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            ControlPaint.DrawReversibleFrame(new Rectangle(100, 100, 300, 300), Color.Transparent, FrameStyle.Thick);
        }


    }


}