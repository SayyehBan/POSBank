using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSBank.Controller
{
   public class Txtmasked: MaskedTextBox
    {
        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            this.RightToLeft = RightToLeft.No;
            base.Mask = "####/##/##";
            //PersianCalendar calendar = new PersianCalendar();
            //this.Text = calendar.GetYear(DateTime.Now).ToString() + "/" + calendar.GetMonth(DateTime.Now).ToString("0#") + "/" + calendar.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            //this.Text = "";
            base.Mask = base.Mask = "####/##/##";
        }

        //protected override void OnGotFocus(EventArgs e)
        //{
        //    base.OnGotFocus(e);
        //    //new ToolTip().SetToolTip(this, "برای پاک کردن دوبار کلیک کنید");
        //}

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SendKeys.Send("{Tab}");
        //    }
        //    this.BackColor = Color.White;
        //}

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    base.OnTextChanged(e);
        //    if (base.MaskCompleted)
        //    {
        //        this.BackColor = Color.Yellow;
        //    }
        //    else
        //    {
        //        this.BackColor = Color.YellowGreen;
        //    }
        //}
        protected override void OnEnter(EventArgs e)
        {
            BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            BackColor = Color.White;
            base.OnLeave(e);
        }
    }
}
