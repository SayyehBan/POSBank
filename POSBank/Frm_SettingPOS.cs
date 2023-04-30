using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace POSBank
{
    public partial class Frm_SettingPOS : Form
    {
        public Frm_SettingPOS()
        {
            InitializeComponent();
        }
        void FocuseMoveControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Txt_DeviceNumberEdit1.Text = Properties.Settings.Default.DeviceNumberEdit1;
            Btn_SearchDevices_Click(sender, e);
            Btn_SelectDevice_Click(sender, e);
            MS_I1.Set_Baud(Properties.Settings.Default.SP_Port1Edit, Properties.Settings.Default.SP_Port2Edit,
                Properties.Settings.Default.SP_Port3Edit);
            Txt_SCMD_DataEdit.Text = Properties.Settings.Default.SCMD_DataEdit;
            Txt_NumberOfDevicesEdit.Text = Properties.Settings.Default.NumberOfDevicesEdit;
            Txt_SelectDeviceEdit.Text = Properties.Settings.Default.SelectDeviceEdit;
            Cmb_Port1Edit.Text = Convert.ToDouble(Properties.Settings.Default.SP_Port1Edit).ToString();
            Cmb_Port2Edit.Text = Convert.ToDouble(Properties.Settings.Default.SP_Port2Edit).ToString();
            Cmb_Port3Edit.Text = Convert.ToDouble(Properties.Settings.Default.SP_Port3Edit).ToString();
            Txt_VolumeEdit.Text = Properties.Settings.Default.VolumeEdit;
            Cmb_POS.Text = Properties.Settings.Default.CompanyPOS;
            Cmb_CompPort.Text = Properties.Settings.Default.Port;
            Txt_ir_kish_SerialNO.Text = Properties.Settings.Default.ir_kish_SerialNO;
            Txt_ir_kish_TerminalID.Text = Properties.Settings.Default.ir_kish_TerminalID;
            Txt_ir_kish_ReceiptionID.Text = Properties.Settings.Default.ir_kish_ReceiptionID;
        }

        private void Txt_SCMD_DataEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SCMD_DataEdit = Txt_SCMD_DataEdit.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_NumberOfDevicesEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NumberOfDevicesEdit = Txt_NumberOfDevicesEdit.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_DeviceNumberEdit1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DeviceNumberEdit1 = Txt_DeviceNumberEdit1.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_SelectDeviceEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SelectDeviceEdit = Txt_SelectDeviceEdit.Text;
            Properties.Settings.Default.Save();
        }


        private void Txt_VolumeEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VolumeEdit = Txt_VolumeEdit.Text;
            Properties.Settings.Default.Save();
        }

        private void Btn_SendCMD_Click(object sender, EventArgs e)
        {
            Txt_SCMD_DataEdit.Text = MS_I1.POS_Dev_INFO();
        }

        private void Btn_SearchDevices_Click(object sender, EventArgs e)
        {
            MS_I1.POS_Search_Devices();
            Txt_NumberOfDevicesEdit.Text = MS_I1.POS_Select_Device(Convert.ToInt16(Txt_DeviceNumberEdit1.Text));
        }

        private void Btn_SelectDevice_Click(object sender, EventArgs e)
        {
            Txt_SelectDeviceEdit.Text = MS_I1.POS_Select_Device(Convert.ToInt16(Txt_DeviceNumberEdit1.Text));
        }

        private void MS_I1_OnClick(object sender, EventArgs e)
        {
            Properties.Settings.Default.MS_I1 = MS_I1.Text;
            Properties.Settings.Default.Save();
        }

        private void Cmb_POS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanyPOS = Cmb_POS.Text;
            Properties.Settings.Default.Save();
            switch (Cmb_POS.SelectedIndex)
            {

            }
        }

        private void Cmb_POS_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanyPOS = Cmb_POS.Text;
            Properties.Settings.Default.Save();
        }

        private void Cmb_CompPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = Cmb_CompPort.Text;
            Properties.Settings.Default.Save();
        }

        private void Cmb_CompPort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = Cmb_CompPort.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_ir_kish_SerialNO_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ir_kish_SerialNO = Txt_ir_kish_SerialNO.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_ir_kish_TerminalID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ir_kish_TerminalID = Txt_ir_kish_TerminalID.Text;
            Properties.Settings.Default.Save();
        }

        private void Txt_ir_kish_ReceiptionID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ir_kish_ReceiptionID = Txt_ir_kish_ReceiptionID.Text;
            Properties.Settings.Default.Save();
        }


        private void Btn_CompBuy_Click(object sender, EventArgs e)
        {
            short flgWhichRadio = Convert.ToInt16(Cmb_POS.SelectedIndex+1);
            Lbl_Msg.Text = "لطفا صبر کنيد تا پاسخ از دستگاه دريافت شود";
            Btn_CompBuy.Enabled = false;
            if (MS_I1.POS_Send(flgWhichRadio.ToString(), Txt_CompBuyEdit.Text, Txt_CompFactorEdit.Text,
                Txt_CompMSGEdit.Text, Convert.ToInt16(Cmb_CompPort.SelectedIndex+1)))
            {
                Btn_Result_Click(sender, e);
            }

            else
            {
                MessageBox.Show("خطا در برقراري ارتباط با دستگاه پوز");
            }

            Btn_CompBuy.Enabled = true;
        }

        private short flgWhichRadio = 0;
        private void Btn_Result_Click(object sender, EventArgs e)
        {
            short flgWhichRadio = Convert.ToInt16(Cmb_POS.SelectedIndex+1);
            string Response_Code, Card_Number, Action_Code, RRN, Trace_NO, Terminal_ID, S_N;
            string Res;
            Res = Response_Code = Card_Number = Action_Code = RRN = Trace_NO = Terminal_ID = S_N = "";
            Res = MS_I1.POS_Response(flgWhichRadio, ref Response_Code, ref Card_Number, ref Action_Code, ref RRN, ref Trace_NO, ref Terminal_ID, ref S_N);

            Txt_CompResponseLabeledEdit.Text = Response_Code;
            Txt_CompCardNumberLabeledEdit.Text = Card_Number;
            Txt_CompActionCodeLabeledEdit.Text = Action_Code;
            Txt_CompRRNLabeledEdit.Text = RRN;
            Txt_CompTraceLabeledEdit.Text = Trace_NO;
            Txt_TerminalIDLabeledEdit.Text = Terminal_ID;
            Txt_CompSNLabeledEdit.Text = S_N;
            LblMsg.Text = Res;
        }

        private void Btn_Comp_Click(object sender, EventArgs e)
        {
            short flgWhichRadio = Convert.ToInt16(Cmb_POS.SelectedIndex +1);
            MS_I1.Cancel_Wait(flgWhichRadio);
        }

        private void Txt_CompCardNumberLabeledEdit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
