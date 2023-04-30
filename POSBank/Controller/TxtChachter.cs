using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSBank.Controller
{
   public class TxtChachter:TextBox
    {

        Color background;
        Color BackgroundFocuse;

        public TxtChachter()
        {
            base.KeyPress += new KeyPressEventHandler(this.ExtdTextBox_KeyPress);
            this.background = base.BackColor;
            base.Enter += new EventHandler(this.ExtendTextBox_Enter);
            //base.KeyDown += new KeyEventHandler(this.TextBox_KeyDown);
            base.LostFocus += new EventHandler(this.ExtdTextBox_LostFocus);
            this.BackgroundFocuse = Color.FromArgb(0xcc, 0xff, 0xbd);
        }

        private void ExtdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (true == Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void ExtdTextBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = this.background;
            //base.Width -= 6;
            //base.Left += 3;
        }
        //void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SendKeys.Send("{TAB}");
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //    }
        //}
        private void ExtendTextBox_Enter(object sender, EventArgs e)
        {

            this.background = base.BackColor;
            this.BackColor = this.BackgroundFocuse;
            //base.Width += 6;
            //base.Left -= 3;
            //base.Select(0, this.Text.Length);
        }
    }
}
