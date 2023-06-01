using GMap.NET;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EUV.Views
{
    public partial class RouteSave : MaterialForm
    {
        public List<PointLatLng> markerLocations = new List<PointLatLng>();

        public List<List<PointLatLng>> markerLocationsList { get; private set; } = new List<List<PointLatLng>>();

        private string droneNum;

        public void SetNumTestValue(string value)
        {
            droneNum = value;
        }

        public RouteSave()
        {
            InitializeComponent();
            LoadConfiguration();
        }

        private void RouteSave_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        public void SetMarkerLocations(List<PointLatLng> locations)
        {
            markerLocations = locations;
        }

        private void btnRouteSet_Click(object sender, EventArgs e)
        {
            if (cboRoute2.Text != "" && cboRoute2.Text != "- 저장 경로명 -")
            {
                Console.WriteLine();
                Console.WriteLine("RouteName: " + cboRoute2.Text);

                markerLocationsList.Clear();

                // 리스트뷰 아이템을 순회하며 데이터 추출
                foreach (ListViewItem item in listView2.Items)
                {
                    string name = item.SubItems[0].Text;
                    int index = int.Parse(item.SubItems[1].Text);

                    string selectedKey = "MarkerLocations-" + item.SubItems[0].Text; // 리스트뷰 경로명

                    // 설정 파일에서 문자열로 변환된 경로리스트
                    string configValue = ConfigurationManager.AppSettings[selectedKey];

                    string[] locationStrings = configValue.Split(';');

                    List<PointLatLng> tempLocations = new List<PointLatLng>();
                    tempLocations.Clear();

                    foreach (string locationString in locationStrings)
                    {
                        string[] coordinates = locationString.Split(',');
                        double latitude = double.Parse(coordinates[0]);
                        double longitude = double.Parse(coordinates[1]);
                        PointLatLng point = new PointLatLng(latitude, longitude);
                        // 분할된 문자열로부터 PointLatLng 인스턴스를 생성하여 리스트에 추가합니다.

                        tempLocations.Add(point);
                    }
                    markerLocationsList.Add(tempLocations);

                    // 출력
                    Console.WriteLine("Name: " + name + ", Index: " + index);
                }

                foreach (var locations in markerLocationsList)
                {
                    Console.WriteLine();
                    foreach (var location in locations)
                    {
                        Console.WriteLine("위도: {0}, 경도: {1}", location.Lat, location.Lng);
                    }
                }

                //markerLocationList 저장
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                string key2 = "MarkerList-" + cboRoute2.Text; // ex) MarkerList-경로확인1

                List<string> routeCheck = new List<string>();// [[경로명, 인덱스], [,], []]
                routeCheck.Clear();

                foreach (ListViewItem item in listView2.Items)
                {
                    string routeIndexString = $"{item.SubItems[0].Text},{int.Parse(item.SubItems[1].Text)}";

                    routeCheck.Add(routeIndexString);
                }

                string stringValue = string.Join(";", routeCheck);

                appSettings.Add(key2, stringValue);

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                // txtAllRouteSaveName 텍스트 초기화
                cboRoute2.Text = "- 저장 경로명 -";
            }
            else
            {
                MessageBox.Show("경로명을 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                txtRouteSaveName.SelectAll();
            }
        }

        private void btnRouteAdd_Click(object sender, EventArgs e)
        {
            if (txtRouteSaveName.Text != "" && txtRouteSaveName.Text != "- 경로 추가 -")
            {
                int requiredMarkerCount = int.Parse(droneNum);
                //Console.WriteLine("드론갯수 출력: " + requiredMarkerCount);

                // 마커 위치가 필요한 갯수만큼 선택되었는지 확인
                if (markerLocations.Count < requiredMarkerCount)
                {
                    MessageBox.Show("지점 선택이 끝나지 않았습니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ListViewItem newItem = new ListViewItem(txtRouteSaveName.Text);

                // 아이템에 새로운 서브아이템을 추가하며, 이 서브아이템의 텍스트를 현재 리스트뷰의 아이템 수와 markerLocationsList의 인덱스로 설정합니다.
                newItem.SubItems.Add(listView2.Items.Count.ToString());
                //newItem.SubItems.Add((markerLocationsList.Count - 1).ToString()); // 마지막에 추가된 마커 위치 리스트의 인덱스 사용

                listView2.Items.Add(newItem);

                // markerLocationsList를 현재 선택한 지점의 위치로 설정합니다.
                //SetMarkerLists(markerLocations);

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                string key2 = "MarkerLocations-" + txtRouteSaveName.Text; // ex) MarkerLocations-경로1

                // 리스트 데이터를 문자열로 변환하여 저장
                string value2 = ConvertMarkerLocationsToString(markerLocations);
                appSettings.Add(key2, value2);

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                SaveConfiguration();

                txtRouteSaveName.Text = "- 경로 추가 -";
            }
            else
            {
                MessageBox.Show("경로명을 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                txtRouteSaveName.SelectAll();
            }
        }

        public void LoadConfiguration()
        {
            //수정1
            try
            {
                listView2.Items.Clear();

                var appSettings = ConfigurationManager.AppSettings;

                // Configuration에서 저장된 항목을 가져와서 리스트뷰에 추가합니다.
                int index = 0;
                while (true)
                {
                    string key = string.Format("Route-{0}", index);
                    string result = appSettings[key];

                    if (result == null)
                        break;

                    string[] values = result.Split(';');
                    ListViewItem item = new ListViewItem(values[0]);
                    item.SubItems.Add(values[1]);
                    listView2.Items.Add(item);

                    index++;
                }

                if (cboRoute2.InvokeRequired)
                {
                    cboRoute2.Invoke(new Action(() =>
                    {
                        foreach (var key in appSettings.AllKeys)
                        {
                            if (key.StartsWith("MarkerList-"))
                            {
                                string routeName = key.Substring("MarkerList-".Length);
                                cboRoute2.Items.Add(routeName);
                            }
                        }
                    }));
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        if (key.StartsWith("MarkerList-"))
                        {
                            string routeName = key.Substring("MarkerList-".Length);
                            cboRoute2.Items.Add(routeName);
                        }
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configuration error exception occurred!");
            }
        }

        public void SaveConfiguration()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                // 기존에 저장된 모든 항목을 제거합니다.
                for (int i = appSettings.Count - 1; i >= 0; i--)
                {
                    if (appSettings.AllKeys[i]?.StartsWith("Route-") ?? false)
                        appSettings.Remove(appSettings.AllKeys[i]);
                }

                // 리스트뷰의 항목을 순회하며 Configuration에 저장합니다.
                int index = 0;
                foreach (ListViewItem item in listView2.Items)
                {
                    string key1 = string.Format("Route-{0}", index);
                    string value1 = item.SubItems[0].Text + ";" + item.SubItems[1].Text;
                    appSettings.Add(key1, value1);

                    index++;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configuration error exception occurred!");
            }
        }


        private string ConvertMarkerLocationsToString(List<PointLatLng> locations)
        {
            List<string> locationStrings = new List<string>();
            foreach (PointLatLng location in locations)
            {
                string latLngString = $"{location.Lat},{location.Lng}";
                locationStrings.Add(latLngString);
            }

            return string.Join(";", locationStrings);
        }

        private void DeleteConfiguration(string name)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                // 해당 name을 가진 항목 제거
                string key = appSettings.AllKeys.FirstOrDefault(k => k.EndsWith(name));
                if (key != null)
                {
                    appSettings.Remove(key);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configuration error exception occurred!");
            }
        }

        private void btnRouteDelete_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count < 1)
                return;

            foreach (ListViewItem row in listView2.SelectedItems)
            {
                int index = row.Index;
                listView2.Items.Remove(row);

                // 삭제된 항목 이후의 인덱스 업데이트
                for (int i = index; i < listView2.Items.Count; i++)
                {
                    listView2.Items[i].SubItems[1].Text = i.ToString();
                }

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                string name1 = "MarkerLocations-" + txtRouteSaveName.Text; // ex) MarkerLocations-경로1
                string key = appSettings.AllKeys.FirstOrDefault(k => k.EndsWith(name1));
                // 해당 name을 가진 항목 제거
                if (key != null)                                                      
                {
                    appSettings.Remove(key);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                // 설정 파일에서 해당 항목 삭제
                string name2 = string.Format("Route-{0}", index); //리스트뷰 정보
                DeleteConfiguration(name2);
            }

            // 삭제 후의 상태를 저장
            SaveConfiguration();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = listView2.SelectedItems[0];
            int selectedIndex = selectedItem.Index;

            if (selectedIndex < listView2.Items.Count - 1)
            {
                listView2.Items.Remove(selectedItem);
                listView2.Items.Insert(selectedIndex + 1, selectedItem);

                // 선택한 항목을 아래로 이동시킴
                listView2.Items[selectedIndex + 1].Selected = true;
                listView2.Items[selectedIndex + 1].EnsureVisible();

                // 리스트뷰의 인덱스 업데이트
                UpdateListViewItemIndexes();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = listView2.SelectedItems[0];
            int selectedIndex = selectedItem.Index;

            if (selectedIndex > 0)
            {
                listView2.Items.Remove(selectedItem);
                listView2.Items.Insert(selectedIndex - 1, selectedItem);
                
                // 선택한 항목을 위로 이동시킴
                listView2.Items[selectedIndex - 1].Selected = true;
                listView2.Items[selectedIndex - 1].EnsureVisible();

                // 리스트뷰의 인덱스 업데이트
                UpdateListViewItemIndexes();
            }
        }

        private void UpdateListViewItemIndexes()
        {
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                listView2.Items[i].SubItems[1].Text = i.ToString();
            }
        }

        private void btnRouteSetDel_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;

            string name1 = "MarkerLocations-" + cboRoute2.SelectedItem.ToString();
            string name2 = "MarkerList-" + cboRoute2.SelectedItem.ToString();

            string key1 = appSettings.AllKeys.FirstOrDefault(k => k.EndsWith(name1));
            string key2 = appSettings.AllKeys.FirstOrDefault(k => k.EndsWith(name2));

            // 해당 name을 가진 항목 제거
            if (key1 != null || key2 != null)
            {
                appSettings.Remove(key1);
                appSettings.Remove(key2);
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            cboRoute2.Text = "- 저장 경로명 -";
        }

        private void btnListViewDrop_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem item in listView2.SelectedItems)
            {
                item.Remove();
            }
        }
    }
}