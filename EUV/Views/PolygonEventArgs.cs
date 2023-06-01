using System.Collections.Generic;
using System.Drawing;

namespace EUV.Views
{
    /// <summary>
    /// 다각형 이벤트 인자
    /// </summary>
    public class PolygonEventArgs
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 포인트 리스트
        /// </summary>
        public List<Point> PointList;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - PolygonEventArgs(pointList)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="pointList">포인트 리스트</param>
        public PolygonEventArgs(List<Point> pointList)
        {
            PointList = pointList;
        }

        #endregion
    }
}