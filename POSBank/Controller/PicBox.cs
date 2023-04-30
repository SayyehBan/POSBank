using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace POSBank.Controller
{
    public class PicBox : PictureBox
    {
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            try
            {
                base.Image = null;
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "تمام تصاویر|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|BMP فایل: (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|JPEG فایل: (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF فایل: (*.GIF)|*.GIF|TIFF فایل: (*.TIF;*.TIFF)|*.TIF;*.TIFF|PNG فایل: (*.PNG)|*.PNG|تمام فایل ها|*.*",
                    Title = "انتخاب تصویر"
                };
                dialog.ShowDialog();
                float width = Image.FromFile(dialog.FileName).PhysicalDimension.Width;
                float height = Image.FromFile(dialog.FileName).PhysicalDimension.Height;
                this.picimage = Image.FromFile(dialog.FileName);
                base.Image = this.picimage;
                base.SizeMode = PictureBoxSizeMode.StretchImage;
                base.BorderStyle = BorderStyle.Fixed3D;
            }
            catch
            {
            }
        }

        public Image picimage { get; set; }
    }
}
