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
    public class TxtMoney : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
            //NumberFormatInfo fi = CultureInfo.CurrentCulture.NumberFormat;

            //string c = e.KeyChar.ToString();
            //if (char.IsDigit(c, 0))
            //    return;

            //if ((SelectionStart == 0) && (c.Equals(fi.NegativeSign)))
            //    return;

            //// copy/paste
            //if ((((int)e.KeyChar == 22) || ((int)e.KeyChar == 3))
            //    && ((ModifierKeys & Keys.Control) == Keys.Control))
            //    return;

            //if (e.KeyChar == '\b')
            //    return;

            //e.Handled = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                base.OnTextChanged(e);

                NumberFormatInfo provider = new NumberFormatInfo
                {
                    NumberDecimalDigits = 0
                };
                this.Text = decimal.Parse(this.Text, NumberStyles.AllowThousands).ToString("N", provider);
                base.Select(this.Text.Length, 0);
            }
            catch
            {
            }
        }

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
