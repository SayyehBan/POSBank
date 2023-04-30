using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSBank.Controller
{
    public class cmbbox:ComboBox
    {
        //public cmbbox()
        //{
        //    base.KeyDown += new KeyEventHandler(this.comboboxBox_KeyDown);
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

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.BackColor = Color.FromArgb(0xcc, 0xff, 0xbd);
        }



        private Color FBC = Color.Yellow;
        private Color FFC = Color.Blue;
        private Font FF = Control.DefaultFont;

        private bool ETT = true;
        private bool FTS = true;

        public bool FocusTextSelect
        {
            get
            {
                return this.FTS;
            }
            set
            {
                this.FTS = value;
            }
        }

        public Color FocusBackColor
        {
            get
            {
                return this.FBC;
            }
            set
            {
                this.FBC = value;
            }
        }

        public Color FocusForeColor
        {
            get
            {
                return this.FFC;
            }
            set
            {
                this.FFC = value;
            }
        }

        public Font FocusFont
        {
            get
            {
                return this.FF;
            }
            set
            {
                this.FF = value;
            }
        }

        public bool EnterToTab
        {
            get
            {
                return this.ETT;
            }
            set
            {
                this.ETT = value;
            }
        }
        //protected override void OnEnter(EventArgs e)
        //{
        //    this.BackColor = this.FocusBackColor;
        //    this.ForeColor = this.FocusForeColor;
        //    this.Font = this.FocusFont;

        //    if (this.FocusTextSelect)
        //    {
        //        this.SelectionStart = 0;
        //        this.SelectionLength = this.Text.Length;


        //    }
        //    base.OnEnter(e);

        //}
        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (Convert.ToInt32((object)e.KeyCode) == 13 && this.EnterToTab)
        //    {
        //        SendKeys.Send("{Tab}");
        //    }

        //}
        //protected override void OnValidated(EventArgs e)
        //{
        //    base.OnValidated(e);
        //    this.BackColor = Color.White;
        //    this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        //    this.ForeColor = Color.Black;
        //}
        //protected override void OnTextChanged(EventArgs e)
        //{
        //    base.OnTextChanged(e);

        //}

    }
}
