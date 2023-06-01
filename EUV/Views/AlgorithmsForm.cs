using EUV.Messages;
using GMap.NET;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Accord.Math.Optimization;
using EUV.Sockets;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using EUV.Commons;

namespace EUV.Views
{
   
    public partial class AlgorithmsForm : MaterialForm
    {
        public List<List<PointLatLng>> droneLocationsList { get; private set; } = new List<List<PointLatLng>>();
       
        private static AllAboutMessages _instance;

        private List<VehicleMessage> vehicleMessages = new List<VehicleMessage>();

        public double[][] drone_distance;

        public double[] drone_Lng;
        public double[] drone_Lat;

        public double[] marker_Lng;
        public double[] marker_Lat;

        public string[] drone_id;
        public string[] marker_id;

        public int numDrone;

        private MainForm mainForm;
        public List<string> algo_ids { get; set; } = new List<string>();
        public List<string> algo_gpsValues { get; set; } = new List<string>();

        public AlgorithmsForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public void SetDroneValue2(List<string> ids, List<string> gpsValues)
        {
            algo_ids.Clear(); // Clear the existing items before populating
            algo_gpsValues.Clear(); // Clear the existing items before populating

            algo_ids.AddRange(ids); // Add all items from the 'ids' list
            algo_gpsValues.AddRange(gpsValues); // Add all items from the 'gpsValues' list
        }


        public void SetLocationsValue(List<List<PointLatLng>> value)
        {
            droneLocationsList = value;
        }

        public List<VehicleMessage> VehicleMessages
        {
            get => vehicleMessages;
            //set => vehicleMessages = value;
        }

        private static AllAboutMessages _getInstance()
        {
            if (_instance == null)
            {
                _instance = new AllAboutMessages();
            }
            return _instance;
        }

        private void AlgorithmsForm_Load(object sender, EventArgs e)
        {
        
        }
        private void btnAlgorithms_Click(object sender, EventArgs e)
        {
            foreach (var droneList in droneLocationsList)
            {
                numDrone = droneList.Count;
            }

            drone_id = new string[numDrone];
            marker_id = new string[numDrone];


            marker_Lng = new double[numDrone];
            marker_Lat = new double[numDrone];


            drone_Lng = new double[numDrone]; // ******* 이나경 
            drone_Lat = new double[numDrone]; //



            int droneIndex = 0; // 드론 인덱스 변수 추가

            AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach((vm =>
            {
                string select = vm.selected.ToString();
                string id = vm.id.ToString();
                double lat = vm.gps_c_lat;
                double lng = vm.gps_c_lng;

                if (droneIndex < numDrone)
                {
                    drone_id[droneIndex] = id;
                    drone_Lat[droneIndex] = lat;
                    drone_Lng[droneIndex] = lng;
                    Console.WriteLine(drone_id[droneIndex]);
                    Console.WriteLine(drone_Lat[droneIndex]);
                    Console.WriteLine(drone_Lng[droneIndex]);
                    droneIndex++;
                }
            }));

            int cnt2 = 0;

            // 서지훈 0531
            foreach (var locations in droneLocationsList)
            {
                for (int i = 0; i < locations.Count; i++)
                {
                    var location = locations[i];
                    marker_id[i] = i.ToString();
                    marker_Lat[i] = location.Lat;
                    marker_Lng[i] = location.Lng;
                    cnt2++;
                }
            }

            /*
            // drone_distance 배열 초기화
            drone_distance = new double[numDrone][];
            for (int i = 0; i < numDrone; i++)
            {
                drone_distance[i] = new double[numDrone];
            }
            for (int i = 0; i < numDrone; i++)
            {
                for (int j = 0; j < numDrone; j++)
                {
                    drone_distance[i][j] = HaversineDistance(drone_Lat[i], drone_Lng[i], marker_Lat[j], marker_Lng[j]);
                    richTextBox1.Text += drone_distance[i][j] + "\t";
                }
                richTextBox1.Text += "\n";
            }
            */

            // 서지훈 0531
            drone_distance_func();

            // 서지훈 0531
            double[] sol = shortest_path_algorithm(drone_distance);

            for (int i = 0; i < sol.Length; i++)
            {
                richTextBox1.Text += "드론" + drone_id[i] + "번" + ">>>>>" + "마커" + marker_id[(int)sol[i]] + "번" + "\n";
            }

        }
        // 서지훈 0531
        public void drone_distance_func()
        {
            drone_distance = new double[numDrone][];
            for (int i = 0; i < numDrone; i++)
            {
                drone_distance[i] = new double[numDrone];
            }
            for (int i = 0; i < numDrone; i++)
            {
                for (int j = 0; j < numDrone; j++)
                {
                    drone_distance[i][j] = HaversineDistance(drone_Lat[i], drone_Lng[i], marker_Lat[j], marker_Lng[j]);
                    richTextBox1.Text += drone_distance[i][j] + "\t";
                }
                richTextBox1.Text += "\n";
            }
        }

        private System.Threading.Timer timer; //타이머 변수
        private void btnDroneMove_Click(object sender, EventArgs e)
        {
            /*
            double[] sol = shortest_path_algorithm(drone_distance);

            for (int i = 0; i < sol.Length; i++)
            {
                string paramJson = string.Format("{{'LAT':'{0}','LNG':{1},'ALT':{2}}}", marker_Lat[(int)sol[i]], marker_Lng[(int)sol[i]], "0");

                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(drone_id[i]),
                    cmd = "GOHERE",
                    param = paramJson
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(drone_id[i]));

                if (result == -1)
                {
                    removeVehicle(cmdMessage.id);
                }

                timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            }
            */
            drone_Move();
        }
        // 서지훈 0531 드론 gohere 함수 추가
        public void drone_Move()
        {
            double[] sol = shortest_path_algorithm(drone_distance);

            for (int i = 0; i < sol.Length; i++)
            {
                string paramJson = string.Format("{{'LAT':'{0}','LNG':{1},'ALT':{2}}}", marker_Lat[(int)sol[i]], marker_Lng[(int)sol[i]], "0");

                SendMessage cmdMessage = new SendMessage
                {
                    id = int.Parse(drone_id[i]),
                    cmd = "GOHERE",
                    param = paramJson
                };
                string jstr = JsonSerializer.Serialize(cmdMessage);
                int result = TcpSocket._getInstance()._sendmessage(jstr, int.Parse(drone_id[i]));

                if (result == -1)
                {
                    removeVehicle(cmdMessage.id);
                }

                timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            }
        }

        //서지훈 0531 드론 모드 추가
        public string[] drone_mode;
        //추가
        private void TimerCallback(object state)
        {
            int droneIndex = 0; // 드론 인덱스 변수 추가

            drone_Lng = new double[numDrone];
            drone_Lat = new double[numDrone];
            drone_mode = new string[numDrone];

            AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach((vm =>
            {
                string select = vm.selected.ToString();
                string id = vm.id.ToString();
                double lat = vm.gps_c_lat;
                double lng = vm.gps_c_lng;
                string mode = vm.mode.Replace("VehicleMode:", "");

                if (droneIndex < numDrone)
                {
                    drone_mode[droneIndex] = mode;
                    drone_id[droneIndex] = id;
                    drone_Lat[droneIndex] = lat;
                    drone_Lng[droneIndex] = lng;
                    droneIndex++;
                }
            }));

            double[] sol = shortest_path_algorithm(drone_distance);

            for (int i = 0; i < sol.Length; i++)
            {
                int remaining_distance = (int)HaversineDistance(drone_Lat[i], drone_Lng[i], marker_Lat[(int)sol[i]], marker_Lng[(int)sol[i]]);
                Console.WriteLine($"{drone_id[i]}번 드론의 남은거리: {remaining_distance} m");

                if (drone_mode[i] == "LOITER")
                {
                    DialogResult result = MessageBox.Show("다음 시나리오를 실행하시겠습니까?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // User clicked Yes
                        Array.Resize(ref marker_Lat, marker_Lat.Length - numDrone); // 드론 갯수 만큼 인덱스 요소 삭제
                        Array.Resize(ref marker_Lng, marker_Lat.Length - numDrone);
                        next_scenario();
                    }
                    else if (result == DialogResult.No)
                    {
                        // User clicked No
                    }
                    timer.Change(Timeout.Infinite, Timeout.Infinite); // 타이머 멈춤
                }
            }
        }

        private void next_scenario()
        {
            int droneIndex = 0; // 드론 인덱스 변수 추가

            drone_Lng = new double[numDrone];
            drone_Lat = new double[numDrone];
            drone_mode = new string[numDrone];

            AllAboutMessages._getInstance().VehicleMessages.ToList().ForEach((vm =>
            {
                string select = vm.selected.ToString();
                string id = vm.id.ToString();
                double lat = vm.gps_c_lat;
                double lng = vm.gps_c_lng;
                string mode = vm.mode.Replace("VehicleMode:", "");

                if (droneIndex < numDrone)
                {
                    drone_mode[droneIndex] = mode;
                    drone_id[droneIndex] = id;
                    drone_Lat[droneIndex] = lat;
                    drone_Lng[droneIndex] = lng;
                    droneIndex++;
                }
            }));

            drone_distance_func();

            drone_Move();

        }

        //서지훈 0531 최단경로 알고리즘 함수 추가
        public double[] shortest_path_algorithm(double[][] drone_distance)
        {
            Munkres m = new Munkres(drone_distance);

            bool success = m.Minimize();    // solve it (should return true)
            double[] solution = m.Solution; // Solution will be 0, 1, 2
            double minimumCost = m.Value;

            return solution;
        }
        public void removeVehicle(int id)
        {
            var index = AllAboutMessages._getInstance().VehicleMessages.FindIndex(c => c.id == id);
            if (index >= 0)
                AllAboutMessages._getInstance().VehicleMessages.RemoveAt(index);
        }
        public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; //지구 반지름 (km)
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c * 1000; // m 단위 거리
            return d;
        }
        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
