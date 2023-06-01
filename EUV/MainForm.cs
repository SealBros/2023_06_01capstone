using EUV.Commons;
using EUV.Messages;
using EUV.Sockets;
using EUV.Utility;
using EUV.Views;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MaterialSkin.Controls;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace EUV
{
    public partial class MainForm : MaterialForm
    {
        public Theme theme; // 테마

        public List<Parameter> parameters = new List<Parameter>();

        // 스레드
        Thread connectionThread;
        bool isConnectionThread = false;

        // 경로
        GMapOverlay VehiclesOverlay = new GMapOverlay("vehicles");
        GMapOverlay RouteOverlay = new GMapOverlay("routes");
        GMapOverlay AllRoutesOverlay = new GMapOverlay("aRoutes");
        List<GMapRoute> ViewRoute = new List<GMapRoute>();
        public List<Route> routes = new List<Route>();
        public bool isMapPositionChanged = false;
        PointLatLng MouseDownStart;

        // 자식폼
        StartSettings startSetting;
        LEDSettings ledSetting;
        BookMark bookMark;
        RouteDraw routeDraw;
        AlgorithmsForm algorithmsForm;

        //음악
        private MediaPlayer mMediaPlayer = new MediaPlayer();
        System.Timers.Timer timer; // 음악 예약

        // 설정
        public string musicStartTime = "[ - ]";
        public string BoatStartCount = "0";
        public string MusicStartCount = "0";
        public PointLatLng CenterGps = new PointLatLng();
        public int Heading = 0;

        // 마우스 위치;
        GMapOverlay MarkerOverlay = new GMapOverlay("markers");
        GMarkerGoogle gMarker;
        bool isMouseFixed = false;
        public PointLatLng point;

        ListViewItem p2;

        //선택한 드론 갯수
        public static int selectDroneNum;

        //이나경 추가 05-20
        public List<string> ids = new List<string>();
        public List<string> gpsValues = new List<string>();

        public List<string> ids_forCheck = new List<string>();
        public List<string> gpsValues_forCheck = new List<string>();
        //05-20


        public MainForm()
        {
            InitializeComponent();
            MainMapInitializing();

            #region < 테마 >
            theme = new Theme(this, Container);
            theme.BackColorChangedControl = new Control[] { btnUOU/*, btnExitFullScreen*/ };
            theme.ThemeMode = false;
            #endregion < 테마 >
            
            listView.ListViewItemSorter = new Sorter();
        }

        #region < from - 메인폼 관련 이벤트 >
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartProgram();
            LoadConfiguration();
            StartConnectionThread();
            listView.DoubleBuffered(true);
            Console.WriteLine(btnMousePoistion.Tag);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopConnectionThread(); // 스레드 종료
            ExitProgram();  // 소켓 서버 종료
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // listView column 크기 조절
            columnChkBox.Width = (int)(listView.Width * 0.05);
            columnID.Width = (int)(listView.Width * 0.1);
            columnBattery.Width = (int)(listView.Width * 0.215);
            columnGPS.Width = (int)(listView.Width * 0.45);
            columnVehicleMode.Width = listView.Width - columnChkBox.Width - columnID.Width - columnBattery.Width - columnGPS.Width;
        }
        #endregion < to - 메인폼 관련 이벤트 >

        #region < from - Configuration >
        // 운항경로 로드
        public void LoadConfiguration(string name, Parameter p)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[name] ?? string.Empty;
                if (result != string.Empty)
                {
                    var split = result.Split(',');
                    p.RouteFileName = split[0];
                    if (routes.Find(x => x.FileName == p.RouteFileName) != null)
                    {
                        p.Points = routes.Find(x => x.FileName == p.RouteFileName).Points;
                        p.pointToGps(CenterGps, Heading);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
        }
        // 이외의 설정
        public void LoadConfiguration()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result;

                List<string> items = new List<string>();
                foreach (string key in appSettings.AllKeys)
                {
                    if (key.Contains("운항경로"))
                    { continue; }
                    else if (key.Contains("경로"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        if (result != string.Empty)
                        {
                            var fileName = key.Substring(key.IndexOf("-") + 1);

                            FileStream fs = new FileStream(result, FileMode.Open);
                            int length = Math.Min((int)fs.Length, 12);
                            byte[] data = new byte[length];
                            string hex = "";
                            string x0, z0;
                            List<Point> targetXYZ = new List<Point>();
                            int j = 0;
                            for (int i = 0; fs.Read(data, 0, length) != 0; i++)
                            {
                                Array.Reverse(data);

                                foreach (byte byteStr in data)
                                {
                                    hex += string.Format("{0:X2}", byteStr);
                                }

                                if (j % 5 == 0)
                                {
                                    x0 = hex.Substring(hex.Length - 4, 4);
                                    z0 = hex.Substring(hex.Length - 12, 4);
                                    int x = short.Parse(x0, NumberStyles.HexNumber);
                                    int z = short.Parse(z0, NumberStyles.HexNumber);
                                    targetXYZ.Add(new Point(x, z));
                                }
                                hex = "";
                            }
                            this.routes.Add(new Route(result, targetXYZ));
                            items.Add(fileName);
                            fs.Dispose();
                        }
                    }
                    else if (key.Contains("음악"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        if (result != string.Empty)
                        {
                            mMediaPlayer.Open(new Uri(result, UriKind.RelativeOrAbsolute));
                            mMediaPlayer.Volume = 20;
                        }
                    }
                    else if (key.Contains("시작좌표"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        if (result != string.Empty)
                        {
                            var split = result.Split(',');
                            CenterGps = new PointLatLng(double.Parse(split[0]), double.Parse(split[1]));
                            Heading = int.Parse(split[2]);
                        }
                    }
                    else if (key.Contains("출발시간"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        var split = result.Split(',');
                        if (result != string.Empty)
                        {
                            lblStartTimeSet.Text = split[0];
                            BoatStartCount = split[1];
                        }
                    }
                    else if (key.Contains("시작시간"))
                    {
                        result = appSettings[key] ?? string.Empty;
                        var split = result.Split(',');
                        if (result != string.Empty)
                        {
                            musicStartTime = split[0];
                            MusicStartCount = split[1];
                        }
                    }
                }

                items.Sort(new StrCmpLogicalComparer());
                //cboRoute.InvokeIfNeeded(() => cboRoute.Items.AddRange(items.ToArray()));

                if (items.Count <= 0)
                {
                    //cboRoute.Items.Add("-");
                }
                //cboRoute.SelectedIndex = 0;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Configration error exception occur!");
            }
            catch { }
        }

        public void SaveConfiguration(string name, string fullName)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;
                int i = listView.Items.Count;

                if (appSettings[name] == null)
                {
                    appSettings.Add(name, string.Format("{0}", fullName));
                }
                else
                {
                    appSettings.Remove(name);
                    appSettings.Add(name, string.Format("{0}", fullName));
                }

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
        #endregion < to - Configration >

        #region < from - thread >
        private void StartConnectionThread()
        {
            StopConnectionThread();

            connectionThread = new Thread(() =>
            {
                isConnectionThread = true;
                Thread.Sleep(1);
                while (isConnectionThread)
                {
                    updateMap();
                    updateView();
                    Thread.Sleep(1000);
                    checkedConnection();
                }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Connection Check Thread"
            };

            connectionThread.Start();
        }

        private void StopConnectionThread()
        {
            if (connectionThread != null)
            {
                if (Thread.CurrentThread != connectionThread)
                {
                    isConnectionThread = false;
                    connectionThread.Abort();
                }
                connectionThread = null;
            }
        }
        /*
        private void StartViewRouteThread()
        {
            Thread viewRouteThread = new Thread(() =>
            {
                btnRoute.InvokeIfNeeded(() =>
                {
                    if (btnRoute.Text == "경로 숨기기")
                    {
                        var viewRoute = ViewRoute.Find(x => x.Name == string.Format("route{0}", cboRoute.SelectedIndex));
                        RouteOverlay.Routes.Remove(viewRoute);
                        AllRoutesOverlay.Routes.Remove(viewRoute);
                        ViewRoute.Remove(viewRoute);
                        btnRoute.Text = "경로 보기";
                    }
                    else
                    {
                        cboRoute.InvokeIfNeeded(() =>
                        {
                            if (cboRoute.SelectedIndex >= 0)
                            {
                                List<PointLatLng> targetGPS = new List<PointLatLng>();

                                listView.InvokeIfNeeded(() =>
                                {
                                    if (listView.CheckedItems.Count < 1)
                                    {
                                        targetGPS = AddTargetGPS(MainMap.Position);
                                    }
                                    else
                                    {
                                        foreach (ListViewItem row in listView.CheckedItems)
                                        {
                                            var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));
                                            targetGPS = AddTargetGPS(CenterGps, Heading);
                                        }
                                    }
                                    GMapRoute gRoute = new GMapRoute(targetGPS, string.Format("route{0}", cboRoute.SelectedIndex))
                                    {
                                        Stroke = new System.Drawing.Pen(ColorPalettes.GetColor(cboRoute.SelectedIndex + 1), 4)
                                    };
                                    RouteOverlay.Routes.Add(gRoute);
                                    ViewRoute.Add(gRoute);
                                    btnRoute.Text = "경로 숨기기";
                                });
                            }
                            else
                            {
                                Console.WriteLine("경로를 선택해주세요.");
                            }
                        });
                    }
                });
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "View Route Thread"
            };
            viewRouteThread.Start();
        }
        */

        /*
        private void StartAllRoutesThread()
        {
            Thread allRoutesThread = new Thread(() =>
            {
                btnAllRoutes.InvokeIfNeeded(() =>
                {
                    if (btnAllRoutes.Text == "전체 경로 숨기기")
                    {
                        AllRoutesOverlay.Routes.Clear();
                        RouteOverlay.Routes.Clear();
                        ViewRoute.Clear();
                        btnAllRoutes.Text = "전체 경로 보기";
                        btnRoute.Text = "경로 보기";
                    }
                    else
                    {
                        cboRoute.InvokeIfNeeded(() =>
                        {
                            for (int i = 0; i < cboRoute.Items.Count; i++)
                            {
                                List<PointLatLng> targetGPS = new List<PointLatLng>();

                                listView.InvokeIfNeeded(() =>
                                {
                                    if (ViewRoute.Find(x => x.Name == string.Format("route{0}", i)) == null)
                                    {
                                        if (listView.CheckedItems.Count < 1)
                                        {
                                            targetGPS = AddTargetGPS(CenterGps, Heading, i);
                                        }
                                        else
                                        {
                                            foreach (ListViewItem row in listView.CheckedItems)
                                            {
                                                var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));
                                                targetGPS = AddTargetGPS(CenterGps, Heading, i);
                                            }
                                        }
                                        GMapRoute gRoute = new GMapRoute(targetGPS, string.Format("route{0}", i))
                                        {
                                            Stroke = new System.Drawing.Pen(ColorPalettes.GetColor(i + 1), 4)
                                        };
                                        ViewRoute.Add(gRoute);
                                        AllRoutesOverlay.Routes.Add(gRoute);
                                    }
                                });
                            }
                            btnAllRoutes.Text = "전체 경로 숨기기";
                            if (cboRoute.SelectedIndex >= 0)
                                btnRoute.Text = "경로 숨기기";
                        });
                    }
                });
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "All Routes Thread"
            };
            allRoutesThread.Start();
        }
        */

        private List<PointLatLng> AddTargetGPS(PointLatLng centerPoint, int heading = 0, int mode = -1)
        {
            try
            {
                Route route;
                if (mode != -1)
                    route = routes[mode];
                //else
                //    route = routes[cboRoute.SelectedIndex];

                var targetGPS = new List<PointLatLng>();
                /*
                foreach (var point in route.Points)
                {
                    PointLatLng p = getLocationMetres(centerPoint, point.Y / 100.0, point.X / 100.0, heading);

                    targetGPS.Add(p);
                    //Console.WriteLine(string.Format("X : {0}, Z : {1}", point.X, point.Y));
                }
                */
                return targetGPS;
            }
            catch { return null; }
        }
        private PointLatLng getLocationMetres(PointLatLng original_location, double dNorth, double dEast, int dHeading = 0)
        {
            var h = -dHeading;
            var dy = dEast * Math.Sin(h * Math.PI / 180) + dNorth * Math.Cos(h * Math.PI / 180);
            var dx = dEast * Math.Cos(h * Math.PI / 180) - dNorth * Math.Sin(h * Math.PI / 180);

            var earth_radius = 6378137.0;
            var dLat = dy / earth_radius;
            var dLng = dx / (earth_radius * Math.Cos(Math.PI * original_location.Lat / 180));

            var newLat = original_location.Lat + (dLat * 180 / Math.PI);
            var newLng = original_location.Lng + (dLng * 180 / Math.PI);
            return new PointLatLng(newLat, newLng);
        }

        /*
        private void StartUploadRouteThread()
        {
            Thread uploadRouteThread = new Thread(() =>
            {
                //open file dialog
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    FileName = "Select a path file",
                    Filter = "Path file (*.PATH)|*.PATH",
                    Title = "Select a Path file for vehicle number ",
                    Multiselect = true
                };

                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        var index = routes.FindIndex(x => x.FullName == file);
                        var fileName = file.Substring(file.LastIndexOf(@"\") + 1);
                        if (index != -1)
                        {
                            var result = MessageBox.Show("같은 경로의 파일이 이미 존재합니다. 덮어쓰시겠습니까?", "파일 덮어 쓰기", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                            if (result == DialogResult.Yes)
                            {
                                cboRoute.InvokeIfNeeded(() => cboRoute.Items.RemoveAt(cboRoute.FindString(fileName)));
                                this.routes.RemoveAt(index);
                            }
                            else
                            {
                                continue;
                            }
                        }

                        try
                        {
                            FileStream fs = new FileStream(file, FileMode.Open);
                            int length = Math.Min((int)fs.Length, 12);
                            byte[] data = new byte[length];
                            string hex = "";
                            string x0, z0;
                            List<Point> targetXYZ = new List<Point>();
                            int j = 0;
                            for (int i = 0; fs.Read(data, 0, length) != 0; i++)
                            {
                                Array.Reverse(data);

                                foreach (byte byteStr in data)
                                {
                                    hex += string.Format("{0:X2}", byteStr);
                                }
                                //Console.WriteLine(hex);

                                if (j % 5 == 0)
                                {
                                    x0 = hex.Substring(hex.Length - 4, 4);
                                    z0 = hex.Substring(hex.Length - 12, 4);
                                    int x = short.Parse(x0, NumberStyles.HexNumber);
                                    int z = short.Parse(z0, NumberStyles.HexNumber);
                                    targetXYZ.Add(new Point(x, z));
                                }
                                hex = "";
                            }
                            this.routes.Add(new Route(file, targetXYZ));
                            cboRoute.InvokeIfNeeded(() => cboRoute.Items.Add(fileName));
                            fs.Dispose();
                            SaveConfiguration(string.Format("경로-{0}", fileName), file);
                        }
                        catch (IOException e) {
                            Console.WriteLine(e.ToString());
                            MessageBox.Show("파일이 다른 프로세스에서 사용 중이므로 프로세스에서 액세스할 수 없습니다.");
                        }
                    }
                }
                else
                {
                    return;
                }

                List<string> items = new List<string>();
                foreach (string i in cboRoute.Items)
                {
                    if (i != "-")
                        items.Add(i);
                }
                items.Sort(new StrCmpLogicalComparer());

                BeginInvoke((Action)delegate
                {
                    cboRoute.Items.Clear();
                    cboRoute.Items.AddRange(items.ToArray());
                    if (cboRoute.Items.Count <= 0)
                    {
                        cboRoute.Items.Add("-");
                    }
                    cboRoute.SelectedIndex = 0;
                });

            })
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Upload Route Thread"
            };
            uploadRouteThread.SetApartmentState(ApartmentState.STA);
            uploadRouteThread.Start();
        }
       
        #endregion < to - thread >
        */

        Dictionary<int,ListViewItem> list = new Dictionary<int, ListViewItem>();
        #region < from - listView >
        public void updateView()
        {
            try
            {
                listView.InvokeIfNeeded(() => listView.BeginUpdate());

                /*for (int i = 1; i <= 32; i++)
                {
                    if (i != 17 && i != 18)
                    {
                        string[] l = new string[] { "true", i.ToString(), "15(100)", MainMap.Position.Lat.ToString() + ", " + MainMap.Position.Lng.ToString(), "Manual" };
                        if (parameters.FindIndex((x => x.ID == i)) == -1)
                        {
                            var p = new Parameter(i, "Manual");
                            p.IsArm = true;
                            parameters.Add(p);
                            LoadConfiguration(string.Format("운항경로-{0}", i.ToString()), p);
                            p.TargetCount = 1000;

                            ListViewItem newitem = new ListViewItem(l)
                            {
                                Name = i.ToString(),
                                Tag = "true"
                            };
                            newitem.Checked = true;
                            list.Add(i, newitem);
                            listView.InvokeIfNeeded(() => listView.Items.Add(newitem));
                        }
                    }
                }*/

                AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach((vm =>
                {
                    string select = vm.selected.ToString();
                    string id = vm.id.ToString();
                    string battery = vm.battery_voltage + "(" + vm.battery_level.ToString() + ")";
                    string gps = vm.gps_c_lat.ToString() + "," + vm.gps_c_lng; // 드론 좌표
                    string mode = vm.mode.Replace("VehicleMode:", "");
                    bool IsArm = vm.arm;
                    bool isLowBattery = vm.battery_voltage <= 14.8 ? true : false;
                    

                    string[] lvi = new string[] { select, id, battery, gps, mode };
                    Parameter parameter;
                    if ((parameter = parameters.Find(x => x.ID == vm.id)) == null)
                    {
                        // 첫 리스트 업
                        parameter = new Parameter(vm.id, mode);

                        parameter.IsArm = IsArm;
                        parameter.IsAlive = true;

                        parameters.Add(parameter);
                        
                        LoadConfiguration(string.Format("운항경로-{0}", id), parameter);

                        ListViewItem newitem = new ListViewItem(lvi)
                        {
                            Name = id,
                            Tag = select,
                        };

                        BeginInvoke((Action)delegate
                        {
                            if (select != "")
                                newitem.Checked = bool.Parse(select);
                            if (isLowBattery)
                                newitem.BackColor = System.Drawing.Color.OrangeRed;
                        });

                        list.Add(vm.id, newitem);
                        listView.InvokeIfNeeded(() => listView.Items.Add(newitem));
                    }
                    else
                    {
                        // 이후 리스트 업
                        parameter.IsArm = IsArm;
                        parameter.IsAlive = true;

                        int index = -1;
                        listView.InvokeIfNeeded(() => index = listView.Items.IndexOfKey(id));

                        if (index == -1)
                        {
                            LoadConfiguration(string.Format("운항경로-{0}", id), parameter);

                            ListViewItem newitem = new ListViewItem(lvi)
                            {
                                Name = id,
                                Tag = select
                            };

                            BeginInvoke((Action)delegate
                            {
                                if (select != "")
                                    newitem.Checked = bool.Parse(select);
                                if (isLowBattery)
                                    newitem.BackColor = System.Drawing.Color.Red;
                            });

                            list.Add(vm.id, newitem);
                            listView.InvokeIfNeeded(() => listView.Items.Add(newitem));
                            return;
                        }
                        BeginInvoke((Action)delegate
                        {

                            if (isLowBattery)
                                listView.Items[index].BackColor = System.Drawing.Color.Red;
                            else
                                listView.Items[index].BackColor = System.Drawing.Color.Transparent;

                        });
                        bool isChange = false;
                        listView.InvokeIfNeeded(() => isChange = listView.Items[index].SubItems[2].Text != battery);
                        if (isChange)
                            listView.InvokeIfNeeded(() => listView.Items[index].SubItems[2].Text = battery);

                        listView.InvokeIfNeeded(() => isChange = listView.Items[index].SubItems[3].Text != gps);
                        if (isChange)
                            listView.InvokeIfNeeded(() => listView.Items[index].SubItems[3].Text = gps);

                        listView.InvokeIfNeeded(() => isChange = listView.Items[index].SubItems[4].Text != mode);
                        if (isChange)
                        {
                            listView.InvokeIfNeeded(() => listView.Items[index].SubItems[4].Text = mode);
                            parameter.Mode = mode;
                        }

                        listView.InvokeIfNeeded(() => list[vm.id] = listView.Items[index]);
                    }
                }));

                BeginInvoke((Action)delegate
                {
                    bool isArm = true;
                    bool isGuided = false;

                    foreach (ListViewItem row in listView.CheckedItems)
                    {
                        var parameter = parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));
                        if (!parameter.IsArm)
                            isArm = false;
                        if (!parameter.IsAlive)
                        {
                            parameters.Remove(parameter);
                            list.Remove(int.Parse(row.SubItems[1].Text));
                            listView.Items.Remove(row);
                            continue;
                        }
                        if (row.SubItems[4].Text == "GUIDED")
                            isGuided = true;
                    }
                    foreach (ListViewItem r in listView.Items)
                    {
                        var parameter = parameters.Find(x => x.ID == int.Parse(r.SubItems[1].Text));
                        if (!parameter.IsAlive)
                        {
                            parameters.Remove(parameter);
                            list.Remove(int.Parse(r.SubItems[1].Text));
                            listView.Items.Remove(r);
                            continue;
                        }
                        parameter.IsAlive = false;
                    }


                    btnArm.Enabled = !isArm;
                    btnDisArm.Enabled = isArm;

                    if (isGuided)
                        btnGo.Enabled = btnFGo.Enabled = false;
                    else
                        btnGo.Enabled = btnFGo.Enabled = true;

                });

                //이나경 추가
                foreach (ListViewItem item in listView.Items)
                {
                    string id = item.SubItems[0].Text; //*************** 이나경 05-22
                    string gps = item.SubItems[2].Text;

                    ids.Add(id);
                    gpsValues.Add(gps);
                }

                //확인용
                double lat_forCheck1 = 35.6097280230333; double lng_forCheck1 = 129.37530189742645;
                double lat_forCheck2 = 35.60973456361103; double lng_forCheck2 = 129.37498922332017;
                double lat_forCheck3 = 35.60960444999368; double lng_forCheck3 = 129.37501082150965;

                string gps1 = lat_forCheck1.ToString() + "," + lng_forCheck1;
                string gps2 = lat_forCheck2.ToString() + "," + lng_forCheck2;
                string gps3 = lat_forCheck3.ToString() + "," + lng_forCheck3;

                ids_forCheck = ids; // *************************** 이나경 05-22 나중에 고쳐
                gpsValues_forCheck = gpsValues;

                //ids_forCheck = new List<string> { "1", "2", "3" }; //********************** 이나경 05-22
                //gpsValues_forCheck = new List<string> { gps1, gps2, gps3 };

                /*
                for (int i = 0; i < ids_forCheck.Count && i < gpsValues_forCheck.Count; i++)
                {
                    Console.WriteLine($"algo_ids: {ids_forCheck[i]}, algo_gpsValues: {gpsValues_forCheck[i]}");
                }
                */

                //AlgorithmsForm algorithmsForm = new AlgorithmsForm();
                //algorithmsForm.SetDroneValue(ids, gpsValues);

                /*
                Console.WriteLine("IDs:");
                foreach (string id in ids)
                {
                    Console.WriteLine(id);
                }

                Console.WriteLine("GPS Values:");
                foreach (string gps in gpsValues)
                {
                    Console.WriteLine(gps);
                }
                */
                //추가
            }
            catch { }
            finally
            {
                listView.InvokeIfNeeded(() => listView.EndUpdate());
            }
        }

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if ((e.ColumnIndex == 0))
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch { }
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

        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (AllAboutMessages._getInstance().VehicleMessages.Count < 1)
                    return;

                var index = e.Index;
                var vm_id = listView.Items[index].SubItems[1].Text;
                var vm_index = AllAboutMessages._getInstance().VehicleMessages.FindIndex(i => i.id.ToString() == vm_id);
                if (int.Parse(vm_id) == 17 || int.Parse(vm_id) == 18)
                {
                    if (e.CurrentValue != e.NewValue)
                    {
                        // 수정
                        AllAboutMessages._getInstance().VehicleMessages[vm_index].selected = e.NewValue.ToString() == "Checked";
                    }

                }
            }
            catch { }
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (listView.Items.Count < 1)
                    return;

                bool value = Convert.ToBoolean(listView.Columns[0].Tag);
                if (listView.Items.Count != listView.CheckedItems.Count)
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

                if (listView.CheckedItems.Count < 1)
                {
                    // 선택 없을 경우 선박 관련 버튼 선택 불가
                    btnLedSetting.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox4.Enabled = false;
                    return;
                }

                bool isArm = true;
                bool isGuided = false;
                foreach(ListViewItem row in listView.CheckedItems)
                {
                    var parameter = parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    if (!parameter.IsArm)
                        isArm = false;
                    if (parameter.Mode == "GUIDED")
                        isGuided = true;
                }

                btnArm.Enabled = !isArm;
                btnDisArm.Enabled = isArm;

                if (isGuided)
                    btnGo.Enabled = btnFGo.Enabled = false;
                else
                    btnGo.Enabled = btnFGo.Enabled = true;

                btnLedSetting.Enabled = true;
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
            }
            catch { }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(listView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                listView.Columns[e.Column].Tag = !value;

                foreach (ListViewItem item in listView.Items)
                    item.Checked = !value;

                listView.Invalidate();
                return;
            }

            if (listView.Sorting == SortOrder.Ascending)
                listView.Sorting = SortOrder.Descending;
            else
                listView.Sorting = SortOrder.Ascending;

            Sorter s = (Sorter)listView.ListViewItemSorter;
            s.Order = listView.Sorting;
            s.Column = e.Column;
            listView.Sort();
            // Determine if clicked column is already the column that is being sorted.
            /*if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                { lvwColumnSorter.Order = SortOrder.Descending; }
                else
                { lvwColumnSorter.Order = SortOrder.Ascending; }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

           // Perform the sort with these new sort options.

            listView.Sort();*/
        }
        #endregion < to - listView >

        #region < from - map >
        public void updateMap()
        {
            BeginInvoke((Action)delegate
            {
                if (MainMap == null)
                    return;

                VehiclesOverlay.Markers.Clear();

                AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach(vm => // 드론 좌표 함수 참고!
                {
                    var parameter = this.parameters.Find(x => x.ID == vm.id);
                    var gps = new PointLatLng(vm.gps_c_lat, vm.gps_c_lng);

                    if (parameter != null)
                    {

                        parameter.BoatMarker = new GMapMarkerBoat(gps, (float)vm.heading, 0, 0, 0, vm.id);
                        parameter.CurrentGps = gps;

                        VehiclesOverlay.Markers.Add(parameter.BoatMarker);
                    }
                });
            });
        }

        // 마우스 위치 디스플레이
        public void SetMouseDisplay(double lat, double lng)
        {
            txtMouseLat.InvokeIfNeeded(() => txtMouseLat.Text = lat.ToString());
            txtMouseLng.InvokeIfNeeded(() => txtMouseLng.Text = lng.ToString());
        }

        private void MainMapInitializing()
        {
            #region < 맵 초기화 >
            try
            {
                System.Net.IPHostEntry e =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
                      "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }

            //config map
            GMapProvider mapprovider = GMapProviders.GoogleHybridMap;
            string settingprovider = "";//MAPPROVIDER.Text;
            foreach (var mp in GMapProviders.List)
            {
                if (mp.Name == settingprovider)
                {
                    mapprovider = mp;
                    break;
                }
            }
            MainMap.MapProvider = mapprovider;
            MainMap.Position = new PointLatLng(35.609816038724, 129.375128746033);

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.UseDirectionsCache = true;
            GMaps.Instance.UseRouteCache = true;

            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.ShowCenter = false;

            MainMap.CanDragMap = true;
            MainMap.DragButton = MouseButtons.Left;

            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 25;
            MainMap.Zoom = 18; //기본값

            //map Zoom
            /*if (int.TryParse(MIN_ZOOM.Text, out int minzoom))
                MainMap.MinZoom = minzoom;
            if (int.TryParse(MAX_ZOOM.Text, out int maxzoom))
                MainMap.MaxZoom = maxzoom;
            if (int.TryParse(ZOOM.Text, out int zoom))
                MainMap.Zoom = zoom; //기본값

            //overlay
            routes = new GMapOverlay("routes");

            MainMap.Overlays.Add(routes);*/
            MainMap.Overlays.Add(VehiclesOverlay);
            MainMap.Overlays.Add(RouteOverlay);
            MainMap.Overlays.Add(AllRoutesOverlay);
            MainMap.Overlays.Add(MarkerOverlay);
            #endregion 맵 초기화
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseFixed)
            {
                point = MainMap.FromLocalToLatLng(e.X, e.Y);
                SetMouseDisplay(point.Lat, point.Lng);
            }
        }

        private void MainMap_MouseLeave(object sender, EventArgs e)
        {
            if (!isMouseFixed)
            {
                txtMouseLat.Text = "-";
                txtMouseLng.Text = "-";
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownStart = MainMap.FromLocalToLatLng(e.X, e.Y);
        }

        private void MainMap_OnPositionChanged(PointLatLng point)
        {
            isMapPositionChanged = true;
        }
        #endregion < to - map >

        #region < from - socket >
        public void checkedConnection()
        {
            try {
                foreach (var _ci in TcpSocket._getInstance()._connections)
                {
                    bool isConnected = _ci._socketInfo.Connected;

                    if (!isConnected)
                    {
                        int id = _ci._idInfo;
                        removeVehicle(id);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("연결이 끊겼습니다.");
            }
        }
        public void removeVehicle(int id)
        {
            var index = AllAboutMessages._getInstance().VehicleMessages.FindIndex(c => c.id == id);
            if (index >= 0)
                AllAboutMessages._getInstance().VehicleMessages.RemoveAt(index);
        }

        private void StartProgram()
        {
            StartSocket();  //소켓 서버 시작
        }
        private void StartSocket()
        {
            #region (프로그램 시작 후 최초 1회)소켓 서버 시작 여부 확인(초기값은 DB에서 읽어옮)
            if (Envi._socketThreadInitRunning)
            {
                if (!Sockets.TcpSocket._getInstance()._checkSocket)
                    Sockets.TcpSocket._getInstance()._start();
            }
            else
            { Sockets.TcpSocket._getInstance()._closedSocket(); }
            #endregion

            #region datetimepicker 현재날짜로
            //btn_0min_Click(null, null);
            #endregion
        }
        private void ExitSocket()
        {
            Sockets.TcpSocket._getInstance()._closedSocket();   // 소켓 서버 종료
        }
        private void ExitProgram()
        {
            isConnectionThread = false;
            ExitSocket();
        }
        #endregion <to - socket >

        #region < from - btn >
        private void btnSkysys_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://skysys.co.kr");
        }

        private void btnUOU_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ulsan.ac.kr/kor/Main.do");
        }

        private void btnSelectiveShip_Click(object sender, EventArgs e)
        {
            //드론 리스트에서 선택한 드론의 중앙 GPS 좌표 구하기
            double sum_lat = 0;
            double sum_lng = 0;
            int count = 0;

            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                sum_lat += parameter.CurrentGps.Lat;
                sum_lng += parameter.CurrentGps.Lng;
                count++;
            }

            selectDroneNum = count;

            try
            {
                if (count != 0)
                {
                    MainMap.Position = new PointLatLng(sum_lat / count, sum_lng / count);
                    txtMouseLat.Text = (sum_lat / count).ToString();
                    txtMouseLng.Text = (sum_lng / count).ToString();
                }
            }
            catch { }
        }

        private void btnRegisteredShip_Click(object sender, EventArgs e)
        {
            //드론 리스트에 등록된 드론의 중앙 GPS 좌표 구하기
            double sum_lat = 0;
            double sum_lng = 0;
            int count = 0;

            AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach(vm =>
            {
                sum_lat += vm.gps_c_lat;
                sum_lng += vm.gps_c_lng;
                count++;
            });

            try
            {
                if (count != 0)
                {
                    MainMap.Position = new PointLatLng(sum_lat / count, sum_lng / count);
                    txtMouseLat.Text = (sum_lat / count).ToString();
                    txtMouseLng.Text = (sum_lng / count).ToString();
                }
            }
            catch { }
        }

        private void btnSunset_Click(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            double latitude = MainMap.Position.Lat;
            double longitude = MainMap.Position.Lng;

            DayNightRatio testCase = new DayNightRatio(month, day, latitude, longitude);
            Console.WriteLine(testCase.DisplayResult());
            MessageBox.Show(testCase.DisplayResult(), "일출 / 일몰", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion < to - btn >

        #region < from - 자식폼 >
        private void btnBookMark_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "BookMark") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return;
                }
            }

            bookMark = new BookMark
            {
                Owner = this
            };
            bookMark.Show();
        }

        private void btnRouteDraw_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "RouteDraw") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return;
                }
            }

            routeDraw = new RouteDraw(this)
            {
                Owner = this
            };

            //routeDraw.SetDroneValue1(ids, gpsValues);
            routeDraw.SetDroneValue1(ids_forCheck, gpsValues_forCheck);
            routeDraw.Show();
        }

        private void btnStartSetting_Click(object sender, EventArgs e)
        {
            List<string> id = new List<string>();
            List<PointLatLng> gps = new List<PointLatLng>();
            bool isGuided = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "TimeSettings") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return;
                }
            }

            if (listView.CheckedItems.Count > 0)
            {
                foreach (ListViewItem row in listView.CheckedItems)
                {
                    var split = row.SubItems[3].Text.Split(',');
                    if (split.Length > 0)
                    {
                        if (double.TryParse(split[0], out double lat) && double.TryParse(split[1], out double lng))
                        {
                            id.Add(row.SubItems[1].Text);
                            gps.Add(new PointLatLng(lat, lng));
                        }
                    }
                }
                startSetting = new StartSettings(id)
                {
                    Owner = this
                };
            }
            else
            {
                startSetting = new StartSettings()
                {
                    Owner = this
                };
            }
            startSetting.Show();
        }

        private void btnLedSetting_Click(object sender, EventArgs e)
        {
            List<string> id = new List<string>();
            bool isGuided = false;

            /*if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                if (row.SubItems[4].Text == "GUIDED")
                {
                    isGuided = true;
                }
                id.Add(row.SubItems[1].Text);
            }*/

            id.Add("1");
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "LEDSettings") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return;
                }
            }

            ledSetting = new LEDSettings(id)
            {
                Owner = this
            };
            ledSetting.Show();
        }
        #endregion < to - 자식폼 >

        #region < from - 선박 제어 >
        private void btnArm_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "ARM",
                    param = "testparam" //라즈베리에서는 ignore
                };
                string jstr = JsonSerializer.Serialize(cmdMessage); //json string
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text)); //

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnDisArm_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "DISARM",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(musicStartTime, out DateTime dt) || dt < DateTime.Now)
            {
                mMediaPlayer.Stop();
                mMediaPlayer.Play();
            }
            else
            {
                int hours = dt.Hour - DateTime.Now.Hour;
                int minute =  dt.Minute - DateTime.Now.Minute;
                int second = dt.Second - DateTime.Now.Second + int.Parse(MusicStartCount);

                int interval = ((hours * 60 * 60) + (minute * 60) + second) * 1000;
                Console.WriteLine("interval : " + interval);
                timer = new System.Timers.Timer();
                timer.Interval = interval;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick);
                timer.Start();
            }

            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            if (!DateTime.TryParse(Regex.Replace(lblStartTimeSet.Text.Replace(".", "-"), @"\[ | \]", ""), out DateTime time))
            {
                time = DateTime.Now;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }

                var id = int.Parse(row.SubItems[1].Text);
                var parameter = this.parameters.Find(x => x.ID == id);

                if (parameter.RouteFileName == "-" || parameter.RouteFileName == null)
                {
                    MessageBox.Show(string.Format("[ {0}번 ] : 설정 경로 없음.", row.SubItems[1].Text, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly));
                    return;
                }

                SendMessage cmdMessage = new SendMessage
                {
                    id = id,
                    cmd = "GOSWARM",
                    param = string.Format("{{'SHOWTIME':'{0}','CENTER-LAT':{1},'CENTER-LNG':{2},'CENTER-ALT':10,'HEADING':{3},'COUNTDOWN':1,'SLEEPTIME':{4}}}", time.ToString("yyyy-MM-dd HH:mm:ss"), CenterGps.Lat, CenterGps.Lng, Heading, BoatStartCount) //-35.3632624 149.1651968 //중괄호 중첩 필요, ex> string.Format("{{aaa{0}{1}aaa}}",p1, p2);
                };

                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));
            }
        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                mMediaPlayer.Stop();
                mMediaPlayer.Play();
                timer.Stop();
                timer.Enabled = false;
            });
        }

        private void btnFGo_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                var id = int.Parse(row.SubItems[1].Text);
                var parameter = this.parameters.Find(x => x.ID == id);

                if (parameter.RouteFileName == "-" || parameter.RouteFileName == null)
                {
                    MessageBox.Show(string.Format("[ {0}번 ] : 설정 경로 없음.", row.SubItems[1].Text), "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    continue;
                }

                SendMessage cmdMessage = new SendMessage
                {
                    id = id,
                    cmd = "FirstPOSITION",
                    param = string.Format("{{'CENTER-LAT':{0},'CENTER-LNG':{1},'CENTER-ALT':{2},'HEADING':{3}}}", CenterGps.Lat, CenterGps.Lng, "5", Heading) //-35.3632624 149.1651968 //중괄호 중첩 필요, ex> string.Format("{{aaa{0}{1}aaa}}",p1, p2);
                };

                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));
                if (result == -1)
                {
                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void goToHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            string id = "";
            int i = 0;
            foreach (ListViewItem row in listView.CheckedItems)
            {
                if (i == 0)
                    id += row.SubItems[1].Text;
                else
                    id += ", " + row.SubItems[1].Text;
                i++;
            }

            DialogResult dialog = MessageBox.Show(string.Format("  해당 위치로 이동하시겠습니까?\n\n  (선택 선박 : {0})", id), "여기로 이동", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (dialog == DialogResult.Yes)
            {
                if (MouseDownStart.Lat == 0.0 || MouseDownStart.Lng == 0.0)
                {
                    Console.WriteLine("선택된 좌표가 없습니다.");
                    return;
                }

                foreach (ListViewItem row in listView.CheckedItems)
                {
                    //메시지 작성
                    //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }
                    SendMessage cmdMessage = new SendMessage
                    {
                        id = int.Parse(row.SubItems[1].Text),
                        cmd = "GOHERE",
                        param = string.Format("{{'LAT':'{0}','LNG':{1},'ALT':{2}}}", MouseDownStart.Lat, MouseDownStart.Lng, "0")
                    };
                    string jstr = JsonSerializer.Serialize(cmdMessage);
                    int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                    //int result = -1;

                    if (result == -1)
                    {
                        listView.Items.Remove(row);
                        removeVehicle(cmdMessage.id);
                    }
                }
            }
        }
        #endregion < to - 선박 제어 >

        #region < from - 선박 모드 >
        private void btnManual_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "MANUAL",
                    param = "testparam"
                };

                string jstr = JsonSerializer.Serialize(cmdMessage);

                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));
                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnGuided_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "GUIDED",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnLoiter_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "LOITER",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnBrake_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }
            mMediaPlayer.Stop();
            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "BRAKE",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    listView.Items.Remove(row);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnRtl_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "RTL",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }

        }
        #endregion < from - 선박 모드 >

        #region < from - RPi 제어 >
        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "SHUTDOWN",
                    param = "now"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                //int result = -1;

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "REBOOT",
                    param = "now"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    //cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }
        }

        private void btnSourceUpload_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            //open file dialog
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Select a python source file",
                Filter = "Python file (*.py)|*.py",
                Title = "Select a Source file"
            };

            DialogResult dr = ofd.ShowDialog();

            foreach (ListViewItem row in listView.CheckedItems)
            {
                if (dr == DialogResult.OK)
                {
                    btnSourceUpload.Enabled = false;
                    btnSourceUpload.Text = "파일 전송중...";

                    string fileName = ofd.SafeFileName;
                    string fullName = ofd.FileName;
                    string filePath = fullName.Replace(fileName, "");
                    string host = TcpSocket._getInstance()._getRemoteEndPoint(int.Parse(row.SubItems[1].Text));
                    int port = 22;
                    string username = "pi";
                    string password = "raspberry";

                    var client = new SftpClient(host, port, username, password);
                    client.Connect();

                    if (client.IsConnected)
                    {
                        Console.WriteLine("client is Connected");
                    }
                    var fileStream = new FileStream(fullName, FileMode.Open, FileAccess.Read);
                    if (fileStream != null)
                    {
                        Console.WriteLine("file is not null");
                    }
                    client.BufferSize = 4096;//4 * 1024;
                    client.UploadFile(fileStream, "/home/pi/" + "around.py", null);
                    client.Disconnect();
                    client.Dispose();
                }
                btnSourceUpload.Text = "소스 파일";
                btnSourceUpload.Enabled = true;
            }
        }
        #endregion < to - RPi 제어 >

        /*
        #region < from - 경로 >
        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            StartUploadRouteThread();
        }
        */

        /*
        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            if (cboRoute.Text == "" || cboRoute.Text == "-")
                return;

            var t = routes.Find(x => x.FileName.Contains(cboRoute.Text));
            routes.Remove(t);
            cboRoute.Items.Remove(cboRoute.Text);
            DeleteConfiguration(string.Format("경로-{0}", t.FileName, t.FullName));
            if (cboRoute.Items.Count < 1)
            {
                cboRoute.Items.Insert(0, "-");
            }
            cboRoute.SelectedIndex = 0;
        }
        */

        /*
        private void btnRoute_Click(object sender, EventArgs e)
        {
            StartViewRouteThread();
        }
        */

        /*
        private void btnAllRoutes_Click(object sender, EventArgs e)
        {
            StartAllRoutesThread();
        }
        */

        /*
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            AllRoutesOverlay.Routes.Clear();
            RouteOverlay.Routes.Clear();
            ViewRoute.Clear();

            btnAllRoutes.Text = "전체 경로 보기";
            btnRoute.Text = "경로 보기";
            
            foreach (var i in cboRoute.Items)
            {
                var t = routes.Find(x => x.FileName.Contains(i.ToString()));
                routes.Remove(t);
                if (t != null)
                    DeleteConfiguration(string.Format("경로-{0}", t.FileName, t.FullName));
            }
            cboRoute.Items.Clear();
            cboRoute.Items.Add("-");
            cboRoute.SelectedIndex = 0;
        }
        */

        /*
        private void cboRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewRoute.Find(x => x.Name == string.Format("route{0}", cboRoute.SelectedIndex)) != null)
            {
                btnRoute.Text = "경로 숨기기";
            }
            else
            {
                btnRoute.Text = "경로 보기";
            }
        }
        #endregion < to - 경로 >
        */

        /*
        #region < from - 오디오 >
        private void btnAudioSet_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Select a path file",
                Filter = "Wave file (*.wav)|*.WAV|MP3 file(*.mp3)|*.MP3",
                Title = "Select a audio file",
            };

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                mMediaPlayer.Open(new Uri(ofd.FileName, UriKind.RelativeOrAbsolute));
                mMediaPlayer.Volume = 20;
                //SaveMusicConfiguration(ofd.FileName);
            }
        }
        */

        /*
        private void btnAudioOn_Click(object sender, EventArgs e)
        {
            mMediaPlayer.Stop();
            mMediaPlayer.Play();
           /* if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }
                var p = parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "SETLED",
                    param = string.Format("{{'SHOWTIME':'{0}','COUNTDOWN':{1},'SLEEPTIME':{2}}}", Regex.Replace(lblStartTimeSet.Text.Replace(".", "-"), @"\[ | \]", ""), "0", "1000") //-35.3632624 149.1651968 //중괄호 중첩 필요, ex> string.Format("{{aaa{0}{1}aaa}}",p1, p2);
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                //int result = -1;

                if (result == -1)
                {
                    listView.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }*/
        //}
        
        /*
        private void btnAudioOff_Click(object sender, EventArgs e)
        {
            mMediaPlayer.Stop();
            /*if (listView.CheckedItems.Count < 1)
            {
                Console.WriteLine("선택한 항목이 없습니다.");
                return;
            }

            foreach (ListViewItem row in listView.CheckedItems)
            {
                //메시지 작성
                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(row.SubItems[1].Text),
                    cmd = "BRAKE",
                    param = "testparam"
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                if (result == -1)
                {
                    var parameter = this.parameters.Find(x => x.ID == int.Parse(row.SubItems[1].Text));

                    listView.Items.Remove(row);
                    this.parameters.Remove(parameter);
                    list.Remove(parameter.ID);
                    cboRoute.Items.Remove(row);
                    removeVehicle(cmdMessage.id);
                }
            }*/
        //}
        //#endregion < to - 오디오 >
        
        #region < from - tmr >
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblCurrentTimeSet.Text = string.Format("[ {0} ]", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
        }

        #endregion < to - tmr >

        private void btnMousePoistion_Click(object sender, EventArgs e)
        {
            if (LocationTagToolStripMenuItem.Checked)
                MainMap.Position = new PointLatLng(point.Lat, point.Lng);
            else
                MessageBox.Show("저장 위치 태그 없음.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        /*
        private void cboRoute_TextChanged(object sender, EventArgs e)
        {
            if(cboRoute.Text=="-")
            {
                btnAllRoutes.Enabled = false;
                btnRoute.Enabled = false;
                btnDeleteAll.Enabled = false;
                btnDeleteRoute.Enabled = false;
            }
            else
            {
                if(!btnAllRoutes.Enabled)
                {
                    btnAllRoutes.Enabled = true;
                    btnRoute.Enabled = true;
                    btnDeleteAll.Enabled = true;
                    btnDeleteRoute.Enabled = true;
                }
            }
        }
        */

        #region < from - 위치 태그 >
        private void LocationTagSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                isMouseFixed = true;
                SetMouseDisplay(point.Lat, point.Lng);

                gMarker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                gMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                gMarker.ToolTipText = string.Format("고정 위치\n ({0}, {1})", point.Lat, point.Lng);
                gMarker.ToolTip.TextPadding = new Size(10, 10);
                gMarker.ToolTip.Fill = new SolidBrush(System.Drawing.Color.DimGray);
                gMarker.ToolTip.Foreground = new SolidBrush(System.Drawing.Color.White);
                gMarker.ToolTip.Offset = new Point(10, -30);
                gMarker.ToolTip.Stroke = new System.Drawing.Pen(System.Drawing.Color.Transparent, .0f);
                MarkerOverlay.Markers.Add(gMarker);
                LocationTagSaveToolStripMenuItem.Enabled = false;
                LocationTagDeleteToolStripMenuItem.Enabled = true;
                LocationTagMovementToolStripMenuItem.Enabled = true;
                LocationTagToolStripMenuItem.Checked = true;
            }
            catch { }
        }

        private void LocationTagDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                point = new PointLatLng();
                LocationTagSaveToolStripMenuItem.Enabled = true;
                LocationTagDeleteToolStripMenuItem.Enabled = false;
                LocationTagMovementToolStripMenuItem.Enabled = false;
                LocationTagToolStripMenuItem.Checked = false;
                MarkerOverlay.Markers.Remove(gMarker);
                isMouseFixed = false;
            }
            catch { }
        }

        private void LocationTagMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.CheckedItems.Count < 1)
                {
                    Console.WriteLine("선택한 항목이 없습니다.");
                    return;
                }

                string id = "";
                int i = 0;
                foreach (ListViewItem row in listView.CheckedItems)
                {
                    if (i == 0)
                        id += row.SubItems[1].Text;
                    else
                        id += ", " + row.SubItems[1].Text;
                    i++;
                }
                DialogResult dialog = MessageBox.Show(string.Format("  위치 태그로 이동하시겠습니까?\n\n  (선택 선박 :{0})", id), "위치 태그로 이동", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);

                if (dialog == DialogResult.Yes)
                {
                    foreach (ListViewItem row in listView.CheckedItems)
                    {
                        //메시지 작성
                        //메시지 형식 { id = 1, cmd = "arm", param = {param1 = "ex1", param2 = "ex2" } }
                        SendMessage cmdMessage = new SendMessage
                        {
                            id = int.Parse(row.SubItems[1].Text),
                            cmd = "GOHERE",
                            param = string.Format("{{'LAT':'{0}','LNG':{1},'ALT':{2}}}", point.Lat, point.Lng, "0")
                        };
                        string jstr = JsonSerializer.Serialize(cmdMessage);
                        int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(row.SubItems[1].Text));

                        //int result = -1;

                        if (result == -1)
                        {
                            listView.Items.Remove(row);
                            removeVehicle(cmdMessage.id);
                        }
                    }
                }
            }
            catch { }
        }

        #endregion < to - 위치 태그 >

        //리스트뷰 ids, gps 전달

    }
}
#endregion