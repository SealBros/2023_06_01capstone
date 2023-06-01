using EUV.Commons;
using EUV.Sockets;
using EUV.Utility;
using GMap.NET;
using MaterialSkin.Controls;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Views
{
    public partial class StartSettings : MaterialForm
    {
        Theme theme;
        List<string> ids;
        List<Parameter> parameters;

        PointLatLng CenterGps = new PointLatLng();
        PointLatLng Point = new PointLatLng();
        int Heading = 0;

        // 생성자
        public StartSettings()
        {
            InitializeComponent();

            theme = new Theme(this, Container);
        }
        public StartSettings(List<string> ids)
        {
            InitializeComponent();

            this.ids = ids;
            theme = new Theme(this, Container);
        }

        #region < from - 폼 관련 >
        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                this.parameters = ((MainForm)(Owner)).parameters;
                theme = new Theme(this, Container);
                theme.ThemeMode = ((MainForm)(Owner)).theme.ThemeMode;
                CenterGps = ((MainForm)(Owner)).CenterGps;
                Heading = ((MainForm)(Owner)).Heading;
                Point = ((MainForm)(Owner)).point;

                // 시작 위치
                txtLat.Text = CenterGps.Lat.ToString();
                txtLng.Text = CenterGps.Lng.ToString();
                txtHeading.Text = Heading.ToString();

                // 시작시간
                var date = Regex.Replace(((MainForm)(Owner)).lblStartTimeSet.Text.Replace(".", "-"), @"\[ | \]", "");
                if (DateTime.TryParse(date, out DateTime time))
                    dtpStartTime.Text = date;

                if (DateTime.TryParse(((MainForm)(Owner)).musicStartTime, out time))
                    dtpStartTime2.Text = ((MainForm)(Owner)).musicStartTime;

                txtCountDown.Text = ((MainForm)(Owner)).BoatStartCount;
                txtCountDown2.Text = ((MainForm)(Owner)).MusicStartCount;

                if (dtpStartTime.Value != dtpStartTime2.Value || txtCountDown.Text != txtCountDown2.Text)
                    checkbox.Checked = false;

                // 모드 별 폼 사이즈
                this.Size = ids == null ? checkbox.Checked ? new Size(325, 513) : new Size(650, 513) : checkbox.Checked ? new Size(325, 670) : new Size(650, 670);

                foreach(ListViewItem row in ((MainForm)(Owner)).listView.Items)
                {
                    var param = parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    if (param != null && param.Mode == "GUIDED")
                    {
                        grpLocation.Enabled = false;
                    }
                }

                if (ids == null)
                    return;

                // 운항 경로
                ids.Sort(new StrCmpLogicalComparer());
                cboShipID.Items.AddRange(ids.ToArray());

                List<string> list = new List<string>();
                List<string[]> split = new List<string[]>();

                /*
                foreach (var t in ((MainForm)(Owner)).cboRoute.Items)
                {
                    list.Add(t.ToString());
                }
                */

                list.Sort(new StrCmpLogicalComparer());

                cboRoute.Items.AddRange(list.ToArray());
                if (cboRoute.Items.Count <= 0)
                    cboRoute.Items.Insert(0, "-");

                if (cboShipID.Items.Contains(ids[0].ToString()))
                    cboShipID.SelectedItem = ids[0].ToString();
                else
                    cboShipID.SelectedIndex = 0;

                LoadConfiguration(string.Format("운항경로-{0}", cboShipID.Text));
                
            }
            catch { }
        }

        private void StartSettings_SizeChanged(object sender, EventArgs e)
        {
            btnLocationTag.Width = btnMapLocation.Width = this.Width == 325 ? 130 : 280;
        }
        #endregion < from - 폼 관련 >

        #region < from - Location >
        private void txtLat_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtLat.Text, out double lat))
            {
                if (-90 <= lat && lat <= 90)
                {
                    if (txtLat.Text.LastIndexOf('.') == txtLat.TextLength - 1)
                        txtLat.Text += '.';
                    return;
                }
            }
            MessageBox.Show("범위 내의 값을 입력하세요. (위도 범위 : -90˚ ~ 90˚)", "위도", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtLat.Focus();
        }

        private void txtLng_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtLng.Text, out double lng))
            {
                if (-180 <= lng && lng <= 180)
                {
                    if (txtLng.Text.LastIndexOf('.') == txtLng.TextLength - 1)
                        txtLng.Text += '.';
                    return;
                }
            }
            MessageBox.Show("범위 내의 값을 입력하세요. (경도 범위 : -180˚ ~ 180˚)", "경도", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtLng.Focus();
        }

        private void btnMapLocation_Click(object sender, EventArgs e)
        {
            var position = ((MainForm)(Owner)).MainMap.Position;
            BeginInvoke((Action)delegate {
                txtLat.Text = position.Lat.ToString();
                txtLng.Text = position.Lng.ToString();
            });
        }

        private void btnLocationTag_Click(object sender, EventArgs e)
        {
            if (((MainForm)(Owner)).LocationTagToolStripMenuItem.Checked)
            {
                txtLat.Text = Point.Lat.ToString();
                txtLng.Text = Point.Lng.ToString();
            }
        }
        #endregion < to - Location >

        #region < from - boat time >
        private void btnTimeSet_Click(object sender, EventArgs e)
        {
            dtpStartTime.Value = DateTime.Now;
        }

        private void btnMinPlus_Click(object sender, EventArgs e)
        {
            dtpStartTime.Value = dtpStartTime.Value.AddMinutes(1);
        }

        private void btnMinMinus_Click(object sender, EventArgs e)
        {
            dtpStartTime.Value = dtpStartTime.Value.AddMinutes(-1);
        }

        private void txtCountDown_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtCountDown.Text, out double countdown))
            {
                if (0 <= countdown)
                {
                    return;
                }
            }
            MessageBox.Show("범위 내의 값을 입력하세요. (카운트다운 범위 : 0s ~ )", "카운트다운", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtCountDown.Focus();
        }
        #endregion < to - boat time >

        #region < from - music time >
        private void btnTimeSet2_Click(object sender, EventArgs e)
        {
            dtpStartTime2.Value = DateTime.Now;
        }

        private void btnMinPlus2_Click(object sender, EventArgs e)
        {
            dtpStartTime2.Value = dtpStartTime2.Value.AddMinutes(1);
        }

        private void btnMinMinus2_Click(object sender, EventArgs e)
        {
            dtpStartTime2.Value = dtpStartTime2.Value.AddMinutes(-1);
        }

        private void txtCountDown2_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtCountDown2.Text, out double countdown))
            {
                if (0 <= countdown)
                {
                    return;
                }
            }
            MessageBox.Show("범위 내의 값을 입력하세요. (카운트다운 범위 : 0s ~ )", "카운트다운", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtCountDown2.Focus();
        }
        #endregion < to -boat time >

        #region < from - ship >

        private void chkAllBoat_CheckedChanged(object sender, EventArgs e)
        {
            cboShipID.Enabled = cboRoute.Enabled = !chkAllBoat.Checked;
        }

        private void cboShipID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkAllBoat.Checked)
            {
                var index = ids.Find(x => x == cboShipID.Text);
                var parameter = parameters.Find(x => x.ID == int.Parse(index));
                bool isAbled = true;

                if (parameter != null && parameter.Mode == "GUIDED")
                {
                    isAbled = false;
                }

                btnSetting.Enabled = grpBoatTimeSetting.Enabled = grpMusicTimeSetting.Enabled = chkAllBoat.Enabled = lblRoute.Enabled = cboRoute.Enabled = btnSetRoute.Enabled = isAbled;

                LoadConfiguration(string.Format("운항경로-{0}", cboShipID.Text));
            }
        }

        private void btnSetRoute_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ids;

                if (!chkAllBoat.Checked)
                    ids = new List<string>() { cboShipID.Text };
                else
                    ids = this.ids;

                foreach (string id in ids)
                {
                    var parameter = parameters.Find(x => x.ID == int.Parse(id));
                    Route route = ((MainForm)(Owner)).routes.Find(x => x.FileName == string.Format("APM-{0}.PATH", id));

                    if (route == null || parameter.Mode == "GUIDED")
                        continue;

                    try
                    {
                        btnSetRoute.Enabled = false;
                        btnSetRoute.Text = "파일 전송중...";
                        //upload file
                        FileInfo f = new FileInfo(route.FullName);
                        string host = TcpSocket._getInstance()._getRemoteEndPoint(int.Parse(id));
                        int port = 22;
                        string username = "pi";
                        string password = "raspberry";

                        var client = new SftpClient(host, port, username, password);
                        client.Connect();

                        if (client.IsConnected)
                        {
                            Console.WriteLine("client is Connected");
                        }

                        var fileStream = new FileStream(route.FullName, FileMode.Open);
                        if (fileStream != null)
                        {
                            Console.WriteLine("file is not null");
                        }
                        client.BufferSize = 4096;//4 * 1024;
                        client.UploadFile(fileStream, "/home/pi/path/" + "SCENE.PATH", null);
                        client.Disconnect();
                        client.Dispose();
                        fileStream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("파일 전송에 실패했습니다.", "파일 전송", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        continue;
                    }
                    finally
                    {
                        btnSetRoute.Text = "경로 등록";
                        btnSetRoute.Enabled = true;
                    }

                    parameter.RouteFileName = cboRoute.Text;
                    parameter.RouteColor = ColorPalettes.GetColor(parameter.ID);
                    parameter.Points = route.Points;
                    parameter.pointToGps(CenterGps, Heading);

                    SaveConfiguration(string.Format("운항경로-{0}", id), cboRoute.Text);
                }
            }
            catch { }
        }

        #endregion < to - ship >

        #region < from - Configuration >
        public void LoadConfiguration(string name)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[name] ?? string.Empty;
                if (result != string.Empty)
                {
                    cboShipID.Text = name.Substring(name.LastIndexOf("-") + 1);
                    cboRoute.Text = result;
                }
                else
                {
                    if (int.TryParse(cboShipID.Text, out var shipId))
                    {
                        var parameter = ((MainForm)(Owner)).parameters.Find(x => x.ID == shipId);
                        cboRoute.Text = "-";
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
        }

        public void SaveConfiguration(string name,  string value1, string value2=null, string value3= null)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;
                string format;

                if(name.Contains("시간"))
                    format = string.Format("{0},{1}", value1, value2);
                else if(name =="시작좌표")
                    format = string.Format("{0},{1},{2}", value1, value2,value3);
                else
                    format = value1;

                if (appSettings[name] != null)
                    appSettings.Remove(name);
                appSettings.Add(name, format);

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
            catch { }
        }
        #endregion < to - Configuration >

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ((MainForm)(Owner)).lblStartTimeSet.Text = dtpStartTime.Value.ToString("[ yyyy.MM.dd HH:mm:ss ]");
            ((MainForm)(Owner)).BoatStartCount = txtCountDown.Text;
            if (checkbox.Checked)
            {
                dtpStartTime2.Value = dtpStartTime.Value;
                txtCountDown2 = txtCountDown;
            }
            ((MainForm)(Owner)).musicStartTime = dtpStartTime2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            ((MainForm)(Owner)).MusicStartCount = txtCountDown2.Text;
            ((MainForm)(Owner)).CenterGps = new PointLatLng(double.Parse(txtLat.Text), double.Parse(txtLng.Text));
            ((MainForm)(Owner)).Heading = int.Parse(txtHeading.Text);

            SaveConfiguration("출발시간", ((MainForm)(Owner)).lblStartTimeSet.Text, txtCountDown.Text);
            SaveConfiguration("시작시간", dtpStartTime2.Value.ToString("yyyy-MM-dd HH:mm:ss"), txtCountDown2.Text);
            SaveConfiguration("시작좌표", txtLat.Text, txtLng.Text, txtHeading.Text);
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            grpMusicTimeSetting.Visible = !checkbox.Checked;

            if (checkbox.Checked)
                this.Width = 325;
            else
                this.Width = 650;
        }

        // int or double 타입인지 체크
        private void txtDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
                e.Handled = true;
        }
        private void txtInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
    }
}
