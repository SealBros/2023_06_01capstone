using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Utility
{
    public class DayNightRatio
    {
        private readonly double AxialTilt;
        private readonly double Latitude;
        private readonly double Longitude;

        public DayNightRatio(int month, int day, double latitude, double longitude)
        {
            AxialTilt = DateToAxialTilt(month, day);
            Latitude = latitude;
            Longitude = longitude;
        }

        private double NightRatio()
        {
            if (Math.Abs(AxialTilt) > 90 - Math.Abs(Latitude))
            {
                return AxialTilt * Latitude >= 0 ? 0 : 1;
            }
            double theta3Rad =
                Math.Acos(Math.Tan(ToRad(AxialTilt)) * Math.Tan(ToRad(Latitude)));
            return 2 * ToDeg(theta3Rad) / 360 - 0.00625; // 굴절 9분 보정
        }

        public string DisplayResult()
        {
            StringBuilder sb = new StringBuilder();
            double ratio = NightRatio();
            if (ratio <= 0)
            {
                sb.AppendLine("계속 낮입니다.");
            }
            else if (ratio >= 1)
            {
                sb.AppendLine("계속 밤입니다.");
            }
            else
            {
                TimeSpan sunrise =
                    TimeSpan.FromSeconds(60 * 60 * 24 * ratio / 2);
                sunrise += TimeSpan.FromMinutes((135/*시준 선 현재는 한국 기준 - 외부 서비스 시에는 각 나라별 시준 선 DB필요*/ - Longitude) * 4);
                TimeSpan sunset =
                    TimeSpan.FromSeconds(60 * 60 * 12 + 60 * 60 * 24 * (1 - ratio) / 2);
                sunset += TimeSpan.FromMinutes((135/*시준 선 현재는 한국 기준 - 외부 서비스 시에는 각 나라별 시준 선 DB필요*/ - Longitude) * 4);

                string format = @"hh\:mm\:ss";
                sb.AppendLine($"일출 시간: {sunrise.ToString(format)}");
                sb.AppendLine($"일몰 시간: {sunset.ToString(format)}");
            }
            return sb.ToString();
        }

        // 월, 일 => 자전축 기울기 계산
        private static double DateToAxialTilt(int month, int day)
        {
            // 평년(2019년, 365일) 기준으로 일차 계산
            DateTime VernalEquinox = new DateTime(2022, 3, 21); // 춘분을 기준으로
            DateTime checkDate = new DateTime(2022, month, day);
            int timeSpan = (checkDate - VernalEquinox).Days;
            timeSpan = timeSpan < 0 ? 365 + timeSpan : timeSpan;
            // Sin 함수 적용
            double axialTilt = 23.5 * Math.Sin(ToRad(360 * (double)timeSpan / 365));
            return axialTilt;
        }

        private static double ToRad(double degree) => 2 * Math.PI / 360 * degree;

        private static double ToDeg(double rad) => 360 / (2 * Math.PI) * rad;
    }
}
