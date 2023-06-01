using EUV.Commons;
using EUV.Messages;
using EUV.Sockets;
using EUV.Utility;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Views
{
    public partial class LEDSettings : MaterialForm
    {
        Theme theme;    // 테마
        List<Parameter> parameters;
        List<string> id;
        int r, g, b;

        public LEDSettings(List<string> id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void LEDSettings_Load(object sender, EventArgs e)
        {
            theme = new Theme(this,Container);
            theme.ThemeMode = ((MainForm)(Owner)).theme.ThemeMode;

            // LED
            if (int.TryParse(txtRed.Text, out r)
                && int.TryParse(txtGreen.Text, out g)
                && int.TryParse(txtBlue.Text, out b))
            {
                if (g <= 140)
                    lblColor.ForeColor = Color.White;

                else
                    lblColor.ForeColor = Color.Black;

                lblColor.BackColor = Color.FromArgb(r, g, b);
            }

            // 가이드 모드인지
            this.parameters = ((MainForm)(Owner)).parameters;
            foreach (ListViewItem row in ((MainForm)(Owner)).listView.Items)
            {
                var param = parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                if (param != null && param.Mode == "GUIDED")
                {
                    cboShipID.Size = new Size(348, 29);
                    grpLedSetting.Enabled = false;
                    chkAllBoat.Enabled = false;
                }
            }

            // 선택 선박 
            cboShipID.Items.Clear();
            //id.Sort(new StrCmpLogicalComparer());
            cboShipID.Items.AddRange(id.ToArray());

            if (cboShipID.Items.Count > 0)
                cboShipID.SelectedIndex = 0;
        }

        #region < from - rgb >
        #region < from - trb >
        private void trbRed_ValueChanged(object sender, EventArgs e)
        {
            txtRed.Text = trbRed.Value.ToString();
        }

        private void trbGreen_ValueChanged(object sender, EventArgs e)
        {
            txtGreen.Text = trbGreen.Value.ToString();
        }

        private void trbBlue_ValueChanged(object sender, EventArgs e)
        {
            txtBlue.Text = trbBlue.Value.ToString();
        }
        #endregion < to - trb >

        #region < from - txt >
        private void txtRed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtRed.Text, out int value))
            {
                if (value > 255)
                {
                    txtRed.Text = "";
                    return;
                }

                trbRed.Value = r = value;
                lblColor.BackColor = Color.FromArgb(value, g, b);

                if (g <= 140)
                {
                    lblColor.ForeColor = Color.White;
                }
                else
                {
                    lblColor.ForeColor = Color.Black;
                }
            }
        }

        private void txtGreen_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtGreen.Text, out int value))
            {
                if (value > 255)
                {
                    txtGreen.Text = "";
                    return;
                }

                trbGreen.Value = g = value;
                lblColor.BackColor = Color.FromArgb(r, value, b);

                if (value <= 140)
                {
                    lblColor.ForeColor = Color.White;
                }
                else
                {
                    lblColor.ForeColor = Color.Black;
                }
            }
        }

        private void txtBlue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtBlue.Text, out int value))
            {
                if (value > 255)
                {
                    txtBlue.Text = "";
                    return;
                }

                trbBlue.Value = b = value;
                lblColor.BackColor = Color.FromArgb(r, g, value);

                if (g <= 140)
                {
                    lblColor.ForeColor = Color.White;
                }
                else
                {
                    lblColor.ForeColor = Color.Black;
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
        #endregion < to - txt >

        #region < from - btn >
        private void btnRed_Click(object sender, EventArgs e)
        {
            txtRed.Text = "255";
            txtGreen.Text = "0";
            txtBlue.Text = "0";
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            txtRed.Text = "0";
            txtGreen.Text = "255";
            txtBlue.Text = "0";
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            txtRed.Text = "0";
            txtGreen.Text = "0";
            txtBlue.Text = "255";
        }
        #endregion < to - btn >
        #endregion < to - rgb >

        #region < from - on/off >
        private void btnOn_Click(object sender, EventArgs e)
        {
            LedSetMessage(true);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            LedSetMessage(false);
        }

        private void LedSetMessage(bool mode)
        {
            List<string> ids = this.id;
            string param =
                mode ? string.Format("{{'RED':{0},'GREEN':{1},'BLUE':{2}}}", txtRed.Text, txtGreen.Text, txtBlue.Text) : string.Format("{{'RED':{0},'GREEN':{1},'BLUE':{2}}}", "0", "0", "0");

            if (!chkAllBoat.Checked)
                ids = new List<string>() { cboShipID.Text };

            foreach (string id in ids)
            {
                var parameter = parameters.Find(x => x.ID == int.Parse(id));
                if (parameter.Mode == "GUIDED")
                    continue;

                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(id),
                    cmd = "SETLED",
                    param = param
                };

                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(id));

                if (result == -1)
                {
                    MessageBox.Show("LED 제어 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        #endregion < to - on/off >

        // 모든 선박
        private void chkAllBoat_CheckedChanged(object sender, EventArgs e)
        {
            cboShipID.Enabled = !chkAllBoat.Checked;
        }

        // 선박 변경
        private void cboShipID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkAllBoat.Checked)
            {
                var index = id.Find(x => x == cboShipID.Text);
                var parameter = parameters.Find(x => x.ID == int.Parse(index));
                bool isAbled = true;

                if (parameter != null && parameter.Mode == "GUIDED")
                {
                    isAbled = false;
                }

                grpLedSetting.Enabled = chkAllBoat.Enabled = isAbled;
            }

            txtRed.Text = "255";
            txtGreen.Text = "255";
            txtBlue.Text = "255";
        }
    }
}
