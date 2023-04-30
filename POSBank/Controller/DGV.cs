using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace POSBank.Controller
{
   public class DGV:DataGridView
    {
        public bool GONextCell { get; set; }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GONextCell && keyData == Keys.Enter)
            {
                base.ProcessTabKey(Keys.Tab);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (GONextCell && e.KeyCode == Keys.Enter)
            {
                base.ProcessTabKey(Keys.Tab);
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }
        private Color _Alternating = Color.Yellow;

        public Color AlteraningColor
        {
            get
            {
                return _Alternating;
            }
            set
            {
                _Alternating = value;
                DataGridViewCellStyle objCellStyle = new DataGridViewCellStyle();
                objCellStyle.BackColor = this._Alternating;
                this.AlternatingRowsDefaultCellStyle = objCellStyle;
            }
        }
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            e.CellStyle.BackColor = Color.Pink;
        }
        private void InitializeComponent()
        {
            //this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // stiViewerControl1
            // 
            //this.stiViewerControl1.AllowDrop = true;
            //this.stiViewerControl1.IgnoreApplyStyle = false;
            //this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            //this.stiViewerControl1.Name = "stiViewerControl1";
            //this.stiViewerControl1.Report = null;
            //this.stiViewerControl1.ShowZoom = true;
            //this.stiViewerControl1.Size = new System.Drawing.Size(721, 443);
            //this.stiViewerControl1.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        public int Selected_Row = -1, Selected_Column = -1;




        protected override void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            try
            {

            int num;
            base.OnColumnHeaderMouseDoubleClick(e);
            _Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(System.Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            _Workbook workbook = application.Workbooks.Add(System.Type.Missing);
            _Worksheet activeSheet = null;
            application.Visible = true;
            activeSheet = (Worksheet)workbook.Sheets["Sheet1"];
            activeSheet = (Worksheet)workbook.ActiveSheet;
            activeSheet.Name = "Sheet1";
            for (num = 1; num < (base.Columns.Count + 1); num++)
            {
                activeSheet.Cells[1, num] = base.Columns[num - 1].HeaderText;
            }
            for (num = 0; num < (base.Rows.Count - 1); num++)
            {
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    activeSheet.Cells[num + 2, i + 1] = base.Rows[num].Cells[i].Value.ToString();
                }
            }

            }
            catch
            {


            }
        }
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            {
                try
                {
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        // this.Rows[i].Cells[0].Value = (i + 1).ToString();
                        this.ClearSelection();
                        //int R = this.CurrentCell.RowIndex; R++;
                        //this.CurrentCell = this[0, R];
                        this.RowHeadersWidth = 30;


                    }
                }
                catch
                {
                }

            }
        }

        //protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        //{
        //    base.OnDataBindingComplete(e);
        //    for (int i = 0; i < base.Rows.Count; i++)
        //    {
        //        base.Rows[i].HeaderCell.Value = (i + 1).ToString();
        //        base.ClearSelection();
        //        int num2 = base.Rows.Count - 1;
        //        base.RowHeadersWidth = 0x29;
        //        base.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control;
        //    }
        //}
    }
}
