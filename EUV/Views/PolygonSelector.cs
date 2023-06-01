using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EUV.Views
{
    /// <summary>
    /// 다각형 선택자
    /// </summary>
    public class PolygonSelector
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Delegate
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 다각형 선택 이벤트 핸들러 - PolygonSelectedEventHandler(sender, e)

        /// <summary>
        /// 다각형 선택 이벤트 핸들러
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        public delegate void PolygonSelectedEventHandler(object sender, PolygonEventArgs e);

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Event
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 다각형 선택시 이벤트 - PolygonSelected

        /// <summary>
        /// 다각형 선택시 이벤트
        /// </summary>
        public event PolygonSelectedEventHandler PolygonSelected;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 컨트롤
        /// </summary>
        private Control control;

        /// <summary>
        /// 펜
        /// </summary>
        private Pen pen;

        /// <summary>
        /// 포인트 리스트
        /// </summary>
        private List<Point> pointList;

        /// <summary>
        /// 이용 가능 여부
        /// </summary>
        private bool enabled = true;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 이용 가능 여부 - Enabled

        /// <summary>
        /// 이용 가능 여부
        /// </summary>
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (value == this.enabled)
                {
                    return;
                }

                this.enabled = value;

                if (this.enabled)
                {
                    this.control.MouseDown += control_MouseDown;
                }
                else
                {
                    this.control.MouseDown -= control_MouseDown;
                    this.control.MouseMove -= control_MouseMove;
                    this.control.MouseClick -= control_MouseClick;
                    this.control.Paint -= control_Paint;
                }
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - PolygonSelector(control, pen)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="control">컨트롤</param>
        /// <param name="pen">펜</param>
        public PolygonSelector(Control control, Pen pen) //
        {
            this.control = control;
            this.pen = pen;

            this.control.MouseDown += control_MouseDown;

        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Protected

        #region 다각형 선택시 이벤트 발생시키기 - FirePolygonSelectedEvent()

        /// <summary>
        /// 다각형 선택시 이벤트 발생시키기
        /// </summary>
        protected virtual void FirePolygonSelectedEvent()
        {
            if ((PolygonSelected == null) || (this.pointList.Count < 2))
            {
                this.control.Refresh();
            }
            else
            {
                PolygonEventArgs e = new PolygonEventArgs(this.pointList);

                PolygonSelected(this, e);
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 컨트롤 마우스 DOWN 처리하기 - control_MouseDown(sender, e)

        /// <summary>
        /// 컨트롤 마우스 DOWN 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            this.control.MouseDown -= control_MouseDown;

            this.pointList = new List<Point>();

            this.pointList.Add(e.Location);
            this.pointList.Add(e.Location);

            this.control.MouseMove += control_MouseMove;
            this.control.MouseClick += control_MouseClick;
            this.control.Paint += control_Paint;
        }

        #endregion
        #region 컨트롤 마우스 이동시 처리하기 - control_MouseMove(sender, e)

        /// <summary>
        /// 컨트롤 마우스 이동시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            this.pointList[this.pointList.Count - 1] = e.Location;

            this.control.Refresh();
        }

        #endregion
        #region 컨트롤 마우스 클릭시 처리하기 - control_MouseClick(sender, e)

        /// <summary>
        /// 컨트롤 마우스 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            int pointCount = pointList.Count;

            if (e.Button == MouseButtons.Right)
            {
                this.pointList.RemoveAt(pointCount - 1);

                this.control.MouseMove -= control_MouseMove;
                this.control.MouseClick -= control_MouseClick;
                this.control.Paint -= control_Paint;

                FirePolygonSelectedEvent();

                this.control.MouseDown += control_MouseDown;
            }
            else
            {
                if (this.pointList[pointCount - 1] != this.pointList[pointCount - 2])
                {
                    this.pointList.Add(e.Location);

                    this.control.Refresh();
                }
            }
        }

        #endregion
        #region 컨트롤 페인트시 처리하기 - control_Paint(sender, e)

        /// <summary>
        /// 컨트롤 페인트시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void control_Paint(object sender, PaintEventArgs e)
        {
            if (this.pointList.Count > 1)
            {
                e.Graphics.DrawLines(pen, this.pointList.ToArray());
            }
        }

        #endregion
    }
}