using EUV.Messages;
using EUV.Utility;
using GMap.NET;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Views
{
    public partial class BookMark : MaterialForm
    {
        Theme theme;    // 테마

        // 스레드
        Thread thread;
        bool isThread = false;

        ListViewColumnSorter lvwColumnSorter;   // ListView 정렬

        string bookMarkName = "";   // 즐겨찾기 이름
        bool isAdd = false; // 즐겨찾기 추가

        PointLatLng Point;

        public BookMark()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            listView.ListViewItemSorter = lvwColumnSorter;
        }

        #region < from - 폼 관련 >
        private void BookMark_Load(object sender, EventArgs e)
        {
            theme = new Theme(this, Container);
            theme.ThemeMode = ((MainForm)(Owner)).theme.ThemeMode;
            Point = ((MainForm)(Owner)).point;

            LoadConfiguration();

            txtLat.Text = ((MainForm)(Owner)).MainMap.Position.Lat.ToString();
            txtLng.Text = ((MainForm)(Owner)).MainMap.Position.Lng.ToString();

            StartThread();
        }

        private void BookMark_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopThread();
        }
        #endregion < to - 폼 관련 >

        #region < from - thread >
        private void StartThread()
        {
            StopThread();

            thread = new Thread(() =>
            {
                try
                {
                    isThread = true;
                    while (isThread)
                    {
                            if (((MainForm)(Owner)).isMapPositionChanged)
                            {
                                txtBookMarkName.InvokeIfNeeded(() => txtBookMarkName.Text = bookMarkName);
                                txtLat.InvokeIfNeeded(() => txtLat.Text = ((MainForm)(Owner)).MainMap.Position.Lat.ToString());
                                txtLng.InvokeIfNeeded(() => txtLng.Text = ((MainForm)(Owner)).MainMap.Position.Lng.ToString());
                                Thread.Sleep(20);
                                ((MainForm)(Owner)).isMapPositionChanged = false;
                            }
                    }
                }
                catch { }
            });

            thread.Start();
        }

        private void StopThread()
        {
            if (thread != null)
            {
                if (Thread.CurrentThread != thread)
                {
                    isThread = false;
                    thread.Abort();
                }
                thread = null;
            }
        }
        #endregion < to - thread >

        #region < from - listView >
        /*private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if ((e.ColumnIndex == 0))
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4), value == true ?
                    System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
                return;

            bool value = Convert.ToBoolean(listView.Columns[0].Tag);
            if (listView.Items.Count != listView.CheckedItems.Count || listView.Items.Count == 0)
            {
                if (value != false)
                {
                    listView.Columns[0].Tag = false;
                    listView.Refresh();
                }
            }
            else
            {
                if (value != true)
                {
                    listView.Columns[0].Tag = true;
                    listView.Refresh();
                }
            }
        }
        */
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.listView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.listView.Columns[e.Column].Tag = !value;

                foreach (ListViewItem item in this.listView.Items)
                    item.Checked = !value;

                this.listView.Invalidate();
            }

            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count < 1)
                return;

            int SelectRow = listView.SelectedItems[0].Index;
            bookMarkName = listView.Items[SelectRow].SubItems[0].Text;

            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["즐겨찾기-" + bookMarkName] ?? string.Empty;
            string[] split = result.Split(',');

            if (double.TryParse(split[0], out double lat) && double.TryParse(split[1], out double lng))
                ((MainForm)(Owner)).MainMap.Position = new PointLatLng(lat, lng);
        }
        #endregion < to - listView >

        #region < from - btn >
        private void btnAddUI_Click(object sender, EventArgs e)
        {
            if (txtBookMarkName.Text != "" && txtBookMarkName.Text != "즐겨찾기 이름")
            {
                SaveConfiguration(string.Format("즐겨찾기-{0}", txtBookMarkName.Text));
                BeginInvoke((Action)delegate
                {
                    listView.Items.Clear();
                });
                LoadConfiguration();
            }
            else
            {
                MessageBox.Show("즐겨찾기 이름 확인", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                txtBookMarkName.SelectAll();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count < 1)
                return;

            foreach (ListViewItem row in listView.SelectedItems)
            { 
                BeginInvoke((Action)delegate
                {
                    listView.Items.Remove(row);
                });

                DeleteConfiguration(string.Format("즐겨찾기-{0}", row.SubItems[0].Text));
            }
            txtLat.Text = txtLng.Text = txtBookMarkName.Text = "";
        }
        #endregion < to - btn >

        #region < from - Configuration >
        public void LoadConfiguration()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result;

                foreach (string key in appSettings.AllKeys)
                {
                    if (key.Contains("즐겨찾기"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        if (result != string.Empty)
                        {
                            string[] lvi = new string[] { key.Substring(key.LastIndexOf("-") + 1) };
                            ListViewItem newitem = new ListViewItem(lvi);

                            BeginInvoke((Action)delegate
                            {
                                listView.Items.Add(newitem);
                            });
                        }
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
        }

        public void SaveConfiguration(string name)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;
                int i = listView.Items.Count;

                if (appSettings[name] != null)
                    appSettings.Remove(name);
                appSettings.Add(name, string.Format("{0},{1}", txtLat.Text, txtLng.Text));

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
        }

        private void DeleteConfiguration(string name)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;
                int i = listView.Items.Count;

                if (appSettings[name] != null)
                {
                    appSettings.Remove(name);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
        }
        #endregion < to - Configuration >

        #region < from - txt >
        private void txtDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
                e.Handled = true;
        }

        private void txtLatitude_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtLat.Text, out double lat))
            {
                if (-90 <= lat && lat <= 90)
                {
                    if (txtLat.Text.LastIndexOf('.') == txtLat.TextLength - 1)
                        txtLat.Text += "0";
                    return;
                }
            }
            MessageBox.Show("위도 범위 확인\n(위도 범위 : -90˚ ~ 90˚)", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtLat.Focus();
        }

        private void txtLongitude_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtLng.Text, out double lng))
            {
                if (-180 <= lng && lng <= 180)
                {
                    if (txtLng.Text.LastIndexOf('.') == txtLng.TextLength - 1)
                        txtLng.Text += "0";
                    return;
                }
            }
            MessageBox.Show("경도 범위 확인\n(경도 범위 : -180˚ ~ 180˚)", "경도 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            txtLng.Focus();
        }
        #endregion < to - txt >

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
    }
}
