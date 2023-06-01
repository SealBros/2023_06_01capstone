namespace EUV
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbSelMain = new MaterialSkin.Controls.MaterialTabSelector_Theme();
            this.tbMain = new MaterialSkin.Controls.MaterialTabControl();
            this.tpHome = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainMap = new EUV.Controls.myGMAP();
            this.cmsMap = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.여기로이동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationTagSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationTagDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationTagMovementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnChkBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBattery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVehicleMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTop = new MaterialSkin.Controls.MaterialPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSourceUpload = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnRestart = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnTurnOff = new MaterialSkin.Controls.MaterialRaisedButton();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.tlpLocation = new System.Windows.Forms.TableLayoutPanel();
            this.lblMouseLat = new MaterialSkin.Controls.MaterialLabel();
            this.txtMouseLng = new MaterialSkin.Controls.MaterialLabel();
            this.lblMouseLng = new MaterialSkin.Controls.MaterialLabel();
            this.txtMouseLat = new MaterialSkin.Controls.MaterialLabel();
            this.btnBookMark = new MaterialSkin.Controls.MaterialFlatButton();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.tlpTime = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentTime = new MaterialSkin.Controls.MaterialLabel();
            this.btnSunset = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblStartTimeSet = new MaterialSkin.Controls.MaterialLabel_Color();
            this.lblStartTime = new MaterialSkin.Controls.MaterialLabel();
            this.lblCurrentTimeSet = new MaterialSkin.Controls.MaterialLabel();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.tlpSetting = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartSetting = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnLedSetting = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectiveShip = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnRegisteredShip = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnMousePoistion = new MaterialSkin.Controls.MaterialFlatButton();
            this.grpRoute = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRouteDraw = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tlpControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnRtl = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnArm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBrake = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDisArm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnLoiter = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnGo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnGuided = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnFGo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnManual = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnUOU = new MaterialSkin.Controls.MaterialFlatButton();
            this.tbMain.SuspendLayout();
            this.tpHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsMap.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpLocation.SuspendLayout();
            this.tlpLocation.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.tlpTime.SuspendLayout();
            this.grpSetting.SuspendLayout();
            this.tlpSetting.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpRoute.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tlpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSelMain
            // 
            this.tbSelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelMain.BaseTabControl = null;
            this.tbSelMain.Depth = 0;
            this.tbSelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelMain.Location = new System.Drawing.Point(0, 31);
            this.tbSelMain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbSelMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbSelMain.Name = "tbSelMain";
            this.tbSelMain.Size = new System.Drawing.Size(1806, 41);
            this.tbSelMain.TabIndex = 3;
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.Controls.Add(this.tpHome);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Depth = 0;
            this.tbMain.ItemSize = new System.Drawing.Size(72, 15);
            this.tbMain.Location = new System.Drawing.Point(3, 72);
            this.tbMain.Margin = new System.Windows.Forms.Padding(2);
            this.tbMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1799, 791);
            this.tbMain.TabIndex = 5;
            // 
            // tpHome
            // 
            this.tpHome.Controls.Add(this.splitContainer1);
            this.tpHome.Controls.Add(this.pnlTop);
            this.tpHome.Location = new System.Drawing.Point(4, 19);
            this.tpHome.Margin = new System.Windows.Forms.Padding(2);
            this.tpHome.Name = "tpHome";
            this.tpHome.Padding = new System.Windows.Forms.Padding(2);
            this.tpHome.Size = new System.Drawing.Size(1791, 768);
            this.tpHome.TabIndex = 0;
            this.tpHome.Text = "Home";
            this.tpHome.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 102);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainMap);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(1787, 664);
            this.splitContainer1.SplitterDistance = 1297;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.ContextMenuStrip = this.cmsMap;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.Margin = new System.Windows.Forms.Padding(2);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomEnabled = true;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(1297, 664);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 0D;
            this.MainMap.OnPositionChanged += new GMap.NET.PositionChanged(this.MainMap_OnPositionChanged);
            this.MainMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseDown);
            this.MainMap.MouseLeave += new System.EventHandler(this.MainMap_MouseLeave);
            this.MainMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseMove);
            // 
            // cmsMap
            // 
            this.cmsMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmsMap.Depth = 0;
            this.cmsMap.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.여기로이동ToolStripMenuItem,
            this.LocationTagToolStripMenuItem});
            this.cmsMap.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmsMap.Name = "cmsMap";
            this.cmsMap.Size = new System.Drawing.Size(181, 68);
            // 
            // 여기로이동ToolStripMenuItem
            // 
            this.여기로이동ToolStripMenuItem.Name = "여기로이동ToolStripMenuItem";
            this.여기로이동ToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.여기로이동ToolStripMenuItem.Text = "여기로 이동";
            this.여기로이동ToolStripMenuItem.Click += new System.EventHandler(this.goToHereToolStripMenuItem_Click);
            // 
            // LocationTagToolStripMenuItem
            // 
            this.LocationTagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocationTagSaveToolStripMenuItem,
            this.LocationTagDeleteToolStripMenuItem,
            this.LocationTagMovementToolStripMenuItem});
            this.LocationTagToolStripMenuItem.Name = "LocationTagToolStripMenuItem";
            this.LocationTagToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.LocationTagToolStripMenuItem.Text = "위치 태그";
            // 
            // LocationTagSaveToolStripMenuItem
            // 
            this.LocationTagSaveToolStripMenuItem.Name = "LocationTagSaveToolStripMenuItem";
            this.LocationTagSaveToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.LocationTagSaveToolStripMenuItem.Text = "위치 태그 저장";
            this.LocationTagSaveToolStripMenuItem.Click += new System.EventHandler(this.LocationTagSaveToolStripMenuItem_Click);
            // 
            // LocationTagDeleteToolStripMenuItem
            // 
            this.LocationTagDeleteToolStripMenuItem.Enabled = false;
            this.LocationTagDeleteToolStripMenuItem.Name = "LocationTagDeleteToolStripMenuItem";
            this.LocationTagDeleteToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.LocationTagDeleteToolStripMenuItem.Text = "위치 태그 삭제";
            this.LocationTagDeleteToolStripMenuItem.Click += new System.EventHandler(this.LocationTagDeleteToolStripMenuItem_Click);
            // 
            // LocationTagMovementToolStripMenuItem
            // 
            this.LocationTagMovementToolStripMenuItem.Enabled = false;
            this.LocationTagMovementToolStripMenuItem.Name = "LocationTagMovementToolStripMenuItem";
            this.LocationTagMovementToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.LocationTagMovementToolStripMenuItem.Text = "위치 태그로 이동";
            this.LocationTagMovementToolStripMenuItem.Click += new System.EventHandler(this.LocationTagMovementToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(490, 664);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnChkBox,
            this.columnID,
            this.columnBattery,
            this.columnGPS,
            this.columnVehicleMode});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(2, 30);
            this.listView.Name = "listView";
            this.listView.OwnerDraw = true;
            this.listView.Size = new System.Drawing.Size(486, 632);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.listView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_DrawItem);
            this.listView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView_DrawSubItem);
            this.listView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView_ItemCheck);
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
            // 
            // columnChkBox
            // 
            this.columnChkBox.Text = "";
            this.columnChkBox.Width = 32;
            // 
            // columnID
            // 
            this.columnID.Tag = "Numeric";
            this.columnID.Text = "번호";
            this.columnID.Width = 50;
            // 
            // columnBattery
            // 
            this.columnBattery.Text = "배터리";
            this.columnBattery.Width = 72;
            // 
            // columnGPS
            // 
            this.columnGPS.Text = "위치";
            this.columnGPS.Width = 216;
            // 
            // columnVehicleMode
            // 
            this.columnVehicleMode.Text = "조종 모드";
            this.columnVehicleMode.Width = 100;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tableLayoutPanel1);
            this.pnlTop.Depth = 0;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(2, 2);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1787, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpLocation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpSetting, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpRoute, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1787, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(1160, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(138, 96);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "라즈베리";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSourceUpload, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRestart, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnTurnOff, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(134, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSourceUpload
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnSourceUpload, 2);
            this.btnSourceUpload.Depth = 0;
            this.btnSourceUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSourceUpload.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnSourceUpload.Icon = null;
            this.btnSourceUpload.Location = new System.Drawing.Point(2, 2);
            this.btnSourceUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnSourceUpload.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSourceUpload.Name = "btnSourceUpload";
            this.btnSourceUpload.Primary = true;
            this.btnSourceUpload.Size = new System.Drawing.Size(130, 24);
            this.btnSourceUpload.TabIndex = 7;
            this.btnSourceUpload.Text = "소스 파일";
            this.btnSourceUpload.UseVisualStyleBackColor = true;
            this.btnSourceUpload.Click += new System.EventHandler(this.btnSourceUpload_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Depth = 0;
            this.btnRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestart.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnRestart.Icon = null;
            this.btnRestart.Location = new System.Drawing.Point(2, 30);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Primary = true;
            this.btnRestart.Size = new System.Drawing.Size(63, 24);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "재시작";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Depth = 0;
            this.btnTurnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTurnOff.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnTurnOff.Icon = null;
            this.btnTurnOff.Location = new System.Drawing.Point(69, 30);
            this.btnTurnOff.Margin = new System.Windows.Forms.Padding(2);
            this.btnTurnOff.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Primary = true;
            this.btnTurnOff.Size = new System.Drawing.Size(63, 24);
            this.btnTurnOff.TabIndex = 3;
            this.btnTurnOff.Text = "종료";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.tlpLocation);
            this.grpLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpLocation.Location = new System.Drawing.Point(2, 2);
            this.grpLocation.Margin = new System.Windows.Forms.Padding(2);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Padding = new System.Windows.Forms.Padding(2);
            this.grpLocation.Size = new System.Drawing.Size(317, 96);
            this.grpLocation.TabIndex = 9;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "지도";
            // 
            // tlpLocation
            // 
            this.tlpLocation.ColumnCount = 3;
            this.tlpLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tlpLocation.Controls.Add(this.lblMouseLat, 0, 0);
            this.tlpLocation.Controls.Add(this.txtMouseLng, 1, 1);
            this.tlpLocation.Controls.Add(this.lblMouseLng, 0, 1);
            this.tlpLocation.Controls.Add(this.txtMouseLat, 1, 0);
            this.tlpLocation.Controls.Add(this.btnBookMark, 2, 0);
            this.tlpLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLocation.Location = new System.Drawing.Point(2, 38);
            this.tlpLocation.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLocation.Name = "tlpLocation";
            this.tlpLocation.RowCount = 2;
            this.tlpLocation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLocation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLocation.Size = new System.Drawing.Size(313, 56);
            this.tlpLocation.TabIndex = 0;
            // 
            // lblMouseLat
            // 
            this.lblMouseLat.AutoSize = true;
            this.lblMouseLat.Depth = 0;
            this.lblMouseLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseLat.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblMouseLat.Location = new System.Drawing.Point(2, 2);
            this.lblMouseLat.Margin = new System.Windows.Forms.Padding(2);
            this.lblMouseLat.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMouseLat.Name = "lblMouseLat";
            this.lblMouseLat.Size = new System.Drawing.Size(58, 24);
            this.lblMouseLat.TabIndex = 6;
            this.lblMouseLat.Text = "위도 :";
            this.lblMouseLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMouseLng
            // 
            this.txtMouseLng.AutoSize = true;
            this.txtMouseLng.Depth = 0;
            this.txtMouseLng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMouseLng.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMouseLng.Location = new System.Drawing.Point(64, 30);
            this.txtMouseLng.Margin = new System.Windows.Forms.Padding(2);
            this.txtMouseLng.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMouseLng.Name = "txtMouseLng";
            this.txtMouseLng.Size = new System.Drawing.Size(196, 24);
            this.txtMouseLng.TabIndex = 11;
            this.txtMouseLng.Text = "-";
            this.txtMouseLng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMouseLng
            // 
            this.lblMouseLng.AutoSize = true;
            this.lblMouseLng.Depth = 0;
            this.lblMouseLng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseLng.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblMouseLng.Location = new System.Drawing.Point(2, 30);
            this.lblMouseLng.Margin = new System.Windows.Forms.Padding(2);
            this.lblMouseLng.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMouseLng.Name = "lblMouseLng";
            this.lblMouseLng.Size = new System.Drawing.Size(58, 24);
            this.lblMouseLng.TabIndex = 10;
            this.lblMouseLng.Text = "경도 :";
            this.lblMouseLng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMouseLat
            // 
            this.txtMouseLat.AutoSize = true;
            this.txtMouseLat.Depth = 0;
            this.txtMouseLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMouseLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMouseLat.Location = new System.Drawing.Point(64, 2);
            this.txtMouseLat.Margin = new System.Windows.Forms.Padding(2);
            this.txtMouseLat.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMouseLat.Name = "txtMouseLat";
            this.txtMouseLat.Size = new System.Drawing.Size(196, 24);
            this.txtMouseLat.TabIndex = 10;
            this.txtMouseLat.Text = "-";
            this.txtMouseLat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBookMark
            // 
            this.btnBookMark.Depth = 0;
            this.btnBookMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBookMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBookMark.Icon = ((System.Drawing.Image)(resources.GetObject("btnBookMark.Icon")));
            this.btnBookMark.Location = new System.Drawing.Point(264, 2);
            this.btnBookMark.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookMark.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBookMark.Name = "btnBookMark";
            this.btnBookMark.Primary = false;
            this.tlpLocation.SetRowSpan(this.btnBookMark, 2);
            this.btnBookMark.Size = new System.Drawing.Size(47, 52);
            this.btnBookMark.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnBookMark, "장소 즐겨찾기");
            this.btnBookMark.UseVisualStyleBackColor = true;
            this.btnBookMark.Click += new System.EventHandler(this.btnBookMark_Click);
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.tlpTime);
            this.grpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpTime.Location = new System.Drawing.Point(483, 2);
            this.grpTime.Margin = new System.Windows.Forms.Padding(2);
            this.grpTime.Name = "grpTime";
            this.grpTime.Padding = new System.Windows.Forms.Padding(2);
            this.grpTime.Size = new System.Drawing.Size(442, 96);
            this.grpTime.TabIndex = 14;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "시간";
            // 
            // tlpTime
            // 
            this.tlpTime.ColumnCount = 3;
            this.tlpTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpTime.Controls.Add(this.lblCurrentTime, 0, 0);
            this.tlpTime.Controls.Add(this.btnSunset, 2, 0);
            this.tlpTime.Controls.Add(this.lblStartTimeSet, 1, 1);
            this.tlpTime.Controls.Add(this.lblStartTime, 0, 1);
            this.tlpTime.Controls.Add(this.lblCurrentTimeSet, 1, 0);
            this.tlpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTime.Location = new System.Drawing.Point(2, 38);
            this.tlpTime.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTime.Name = "tlpTime";
            this.tlpTime.RowCount = 2;
            this.tlpTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTime.Size = new System.Drawing.Size(438, 56);
            this.tlpTime.TabIndex = 0;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Depth = 0;
            this.lblCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTime.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblCurrentTime.Location = new System.Drawing.Point(2, 2);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(2);
            this.lblCurrentTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCurrentTime.Size = new System.Drawing.Size(140, 24);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "현재 시간 :";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSunset
            // 
            this.btnSunset.Depth = 0;
            this.btnSunset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSunset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSunset.Icon = global::EUV.Properties.Resources.sunset;
            this.btnSunset.Location = new System.Drawing.Point(386, 2);
            this.btnSunset.Margin = new System.Windows.Forms.Padding(2);
            this.btnSunset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSunset.Name = "btnSunset";
            this.btnSunset.Primary = false;
            this.tlpTime.SetRowSpan(this.btnSunset, 2);
            this.btnSunset.Size = new System.Drawing.Size(50, 52);
            this.btnSunset.TabIndex = 9;
            this.toolTip.SetToolTip(this.btnSunset, "일출·일몰 시간");
            this.btnSunset.UseVisualStyleBackColor = true;
            this.btnSunset.Click += new System.EventHandler(this.btnSunset_Click);
            // 
            // lblStartTimeSet
            // 
            this.lblStartTimeSet.AutoSize = true;
            this.lblStartTimeSet.Depth = 0;
            this.lblStartTimeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTimeSet.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblStartTimeSet.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStartTimeSet.Location = new System.Drawing.Point(146, 30);
            this.lblStartTimeSet.Margin = new System.Windows.Forms.Padding(2);
            this.lblStartTimeSet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStartTimeSet.Name = "lblStartTimeSet";
            this.lblStartTimeSet.Size = new System.Drawing.Size(236, 24);
            this.lblStartTimeSet.TabIndex = 6;
            this.lblStartTimeSet.Text = "[ - ]";
            this.lblStartTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Depth = 0;
            this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTime.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(2, 30);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(2);
            this.lblStartTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(140, 24);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "시작 예정 시간 :";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentTimeSet
            // 
            this.lblCurrentTimeSet.AutoSize = true;
            this.lblCurrentTimeSet.Depth = 0;
            this.lblCurrentTimeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTimeSet.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblCurrentTimeSet.Location = new System.Drawing.Point(146, 2);
            this.lblCurrentTimeSet.Margin = new System.Windows.Forms.Padding(2);
            this.lblCurrentTimeSet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCurrentTimeSet.Name = "lblCurrentTimeSet";
            this.lblCurrentTimeSet.Size = new System.Drawing.Size(236, 24);
            this.lblCurrentTimeSet.TabIndex = 1;
            this.lblCurrentTimeSet.Text = "[ 2022.04.21 15:49:00 ]";
            this.lblCurrentTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpSetting
            // 
            this.grpSetting.Controls.Add(this.tlpSetting);
            this.grpSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpSetting.Location = new System.Drawing.Point(1018, 2);
            this.grpSetting.Margin = new System.Windows.Forms.Padding(2);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Padding = new System.Windows.Forms.Padding(2);
            this.grpSetting.Size = new System.Drawing.Size(138, 96);
            this.grpSetting.TabIndex = 10;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "설정";
            // 
            // tlpSetting
            // 
            this.tlpSetting.ColumnCount = 1;
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetting.Controls.Add(this.btnStartSetting, 0, 0);
            this.tlpSetting.Controls.Add(this.btnLedSetting, 0, 1);
            this.tlpSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetting.Location = new System.Drawing.Point(2, 38);
            this.tlpSetting.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSetting.Name = "tlpSetting";
            this.tlpSetting.RowCount = 2;
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSetting.Size = new System.Drawing.Size(134, 56);
            this.tlpSetting.TabIndex = 0;
            // 
            // btnStartSetting
            // 
            this.btnStartSetting.Depth = 0;
            this.btnStartSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartSetting.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnStartSetting.Icon = null;
            this.btnStartSetting.Location = new System.Drawing.Point(2, 2);
            this.btnStartSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartSetting.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartSetting.Name = "btnStartSetting";
            this.btnStartSetting.Primary = true;
            this.btnStartSetting.Size = new System.Drawing.Size(130, 24);
            this.btnStartSetting.TabIndex = 6;
            this.btnStartSetting.Text = "운항";
            this.btnStartSetting.UseVisualStyleBackColor = true;
            this.btnStartSetting.Click += new System.EventHandler(this.btnStartSetting_Click);
            // 
            // btnLedSetting
            // 
            this.btnLedSetting.Depth = 0;
            this.btnLedSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLedSetting.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnLedSetting.Icon = null;
            this.btnLedSetting.Location = new System.Drawing.Point(2, 30);
            this.btnLedSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnLedSetting.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLedSetting.Name = "btnLedSetting";
            this.btnLedSetting.Primary = true;
            this.btnLedSetting.Size = new System.Drawing.Size(130, 24);
            this.btnLedSetting.TabIndex = 4;
            this.btnLedSetting.Text = "LED";
            this.btnLedSetting.UseVisualStyleBackColor = true;
            this.btnLedSetting.Click += new System.EventHandler(this.btnLedSetting_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.Location = new System.Drawing.Point(323, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(156, 96);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "위치 이동";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btnSelectiveShip, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnRegisteredShip, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMousePoistion, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(152, 56);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnSelectiveShip
            // 
            this.btnSelectiveShip.Depth = 0;
            this.btnSelectiveShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectiveShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectiveShip.Icon = global::EUV.Properties.Resources.선택선박;
            this.btnSelectiveShip.Location = new System.Drawing.Point(102, 2);
            this.btnSelectiveShip.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectiveShip.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSelectiveShip.Name = "btnSelectiveShip";
            this.btnSelectiveShip.Primary = true;
            this.btnSelectiveShip.Size = new System.Drawing.Size(48, 52);
            this.btnSelectiveShip.TabIndex = 12;
            this.btnSelectiveShip.Text = "선택 선박 중심";
            this.toolTip.SetToolTip(this.btnSelectiveShip, "선택된 선박의 중심 위치로 이동");
            this.btnSelectiveShip.UseVisualStyleBackColor = true;
            this.btnSelectiveShip.Click += new System.EventHandler(this.btnSelectiveShip_Click);
            // 
            // btnRegisteredShip
            // 
            this.btnRegisteredShip.Depth = 0;
            this.btnRegisteredShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegisteredShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegisteredShip.Icon = global::EUV.Properties.Resources.등록선박;
            this.btnRegisteredShip.Location = new System.Drawing.Point(52, 2);
            this.btnRegisteredShip.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegisteredShip.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegisteredShip.Name = "btnRegisteredShip";
            this.btnRegisteredShip.Primary = true;
            this.btnRegisteredShip.Size = new System.Drawing.Size(46, 52);
            this.btnRegisteredShip.TabIndex = 13;
            this.toolTip.SetToolTip(this.btnRegisteredShip, "등록된 모든 선박 중심 위치로 이동");
            this.btnRegisteredShip.UseVisualStyleBackColor = true;
            this.btnRegisteredShip.Click += new System.EventHandler(this.btnRegisteredShip_Click);
            // 
            // btnMousePoistion
            // 
            this.btnMousePoistion.Depth = 0;
            this.btnMousePoistion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMousePoistion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMousePoistion.Icon = ((System.Drawing.Image)(resources.GetObject("btnMousePoistion.Icon")));
            this.btnMousePoistion.Location = new System.Drawing.Point(2, 2);
            this.btnMousePoistion.Margin = new System.Windows.Forms.Padding(2);
            this.btnMousePoistion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMousePoistion.Name = "btnMousePoistion";
            this.btnMousePoistion.Primary = false;
            this.btnMousePoistion.Size = new System.Drawing.Size(46, 52);
            this.btnMousePoistion.TabIndex = 12;
            this.btnMousePoistion.Tag = "";
            this.toolTip.SetToolTip(this.btnMousePoistion, "위치 태그로 이동");
            this.btnMousePoistion.UseVisualStyleBackColor = true;
            this.btnMousePoistion.Click += new System.EventHandler(this.btnMousePoistion_Click);
            // 
            // grpRoute
            // 
            this.grpRoute.Controls.Add(this.tableLayoutPanel4);
            this.grpRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpRoute.Location = new System.Drawing.Point(929, 2);
            this.grpRoute.Margin = new System.Windows.Forms.Padding(2);
            this.grpRoute.Name = "grpRoute";
            this.grpRoute.Padding = new System.Windows.Forms.Padding(2);
            this.grpRoute.Size = new System.Drawing.Size(85, 96);
            this.grpRoute.TabIndex = 12;
            this.grpRoute.TabStop = false;
            this.grpRoute.Text = "경로";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btnRouteDraw, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(81, 56);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnRouteDraw
            // 
            this.btnRouteDraw.Depth = 0;
            this.btnRouteDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRouteDraw.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnRouteDraw.Icon = null;
            this.btnRouteDraw.Location = new System.Drawing.Point(2, 2);
            this.btnRouteDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnRouteDraw.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRouteDraw.Name = "btnRouteDraw";
            this.btnRouteDraw.Primary = true;
            this.btnRouteDraw.Size = new System.Drawing.Size(77, 52);
            this.btnRouteDraw.TabIndex = 9;
            this.btnRouteDraw.Text = "등록";
            this.toolTip.SetToolTip(this.btnRouteDraw, "사용자 지정 경로");
            this.btnRouteDraw.UseVisualStyleBackColor = true;
            this.btnRouteDraw.Click += new System.EventHandler(this.btnRouteDraw_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tlpControl);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Enabled = false;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.groupBox4.Location = new System.Drawing.Point(1303, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(481, 94);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "제어";
            // 
            // tlpControl
            // 
            this.tlpControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpControl.ColumnCount = 5;
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpControl.Controls.Add(this.btnRtl, 4, 1);
            this.tlpControl.Controls.Add(this.btnArm, 0, 0);
            this.tlpControl.Controls.Add(this.btnBrake, 3, 1);
            this.tlpControl.Controls.Add(this.btnDisArm, 1, 0);
            this.tlpControl.Controls.Add(this.btnLoiter, 2, 1);
            this.tlpControl.Controls.Add(this.btnGo, 2, 0);
            this.tlpControl.Controls.Add(this.btnGuided, 1, 1);
            this.tlpControl.Controls.Add(this.btnFGo, 3, 0);
            this.tlpControl.Controls.Add(this.btnManual, 0, 1);
            this.tlpControl.Location = new System.Drawing.Point(5, 39);
            this.tlpControl.Margin = new System.Windows.Forms.Padding(2);
            this.tlpControl.Name = "tlpControl";
            this.tlpControl.RowCount = 2;
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControl.Size = new System.Drawing.Size(471, 54);
            this.tlpControl.TabIndex = 0;
            // 
            // btnRtl
            // 
            this.btnRtl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRtl.Depth = 0;
            this.btnRtl.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnRtl.Icon = null;
            this.btnRtl.Location = new System.Drawing.Point(378, 29);
            this.btnRtl.Margin = new System.Windows.Forms.Padding(2);
            this.btnRtl.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRtl.Name = "btnRtl";
            this.btnRtl.Primary = true;
            this.btnRtl.Size = new System.Drawing.Size(91, 23);
            this.btnRtl.TabIndex = 7;
            this.btnRtl.Text = "RTL";
            this.btnRtl.UseVisualStyleBackColor = true;
            this.btnRtl.Click += new System.EventHandler(this.btnRtl_Click);
            // 
            // btnArm
            // 
            this.btnArm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArm.Depth = 0;
            this.btnArm.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnArm.Icon = null;
            this.btnArm.Location = new System.Drawing.Point(2, 2);
            this.btnArm.Margin = new System.Windows.Forms.Padding(2);
            this.btnArm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnArm.Name = "btnArm";
            this.btnArm.Primary = true;
            this.btnArm.Size = new System.Drawing.Size(90, 23);
            this.btnArm.TabIndex = 5;
            this.btnArm.Text = "ARM";
            this.btnArm.UseVisualStyleBackColor = true;
            this.btnArm.Click += new System.EventHandler(this.btnArm_Click);
            // 
            // btnBrake
            // 
            this.btnBrake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrake.Depth = 0;
            this.btnBrake.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnBrake.Icon = null;
            this.btnBrake.Location = new System.Drawing.Point(284, 29);
            this.btnBrake.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrake.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrake.Name = "btnBrake";
            this.btnBrake.Primary = true;
            this.btnBrake.Size = new System.Drawing.Size(90, 23);
            this.btnBrake.TabIndex = 8;
            this.btnBrake.Text = "Brake";
            this.btnBrake.UseVisualStyleBackColor = true;
            this.btnBrake.Click += new System.EventHandler(this.btnBrake_Click);
            // 
            // btnDisArm
            // 
            this.btnDisArm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisArm.Depth = 0;
            this.btnDisArm.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnDisArm.Icon = null;
            this.btnDisArm.Location = new System.Drawing.Point(96, 2);
            this.btnDisArm.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisArm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDisArm.Name = "btnDisArm";
            this.btnDisArm.Primary = true;
            this.btnDisArm.Size = new System.Drawing.Size(90, 23);
            this.btnDisArm.TabIndex = 6;
            this.btnDisArm.Text = "DISARM";
            this.btnDisArm.UseVisualStyleBackColor = true;
            this.btnDisArm.Click += new System.EventHandler(this.btnDisArm_Click);
            // 
            // btnLoiter
            // 
            this.btnLoiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoiter.Depth = 0;
            this.btnLoiter.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnLoiter.Icon = null;
            this.btnLoiter.Location = new System.Drawing.Point(190, 29);
            this.btnLoiter.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoiter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoiter.Name = "btnLoiter";
            this.btnLoiter.Primary = true;
            this.btnLoiter.Size = new System.Drawing.Size(90, 23);
            this.btnLoiter.TabIndex = 1;
            this.btnLoiter.Text = "Loiter";
            this.btnLoiter.UseVisualStyleBackColor = true;
            this.btnLoiter.Click += new System.EventHandler(this.btnLoiter_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Depth = 0;
            this.btnGo.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnGo.Icon = null;
            this.btnGo.Location = new System.Drawing.Point(190, 2);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGo.Name = "btnGo";
            this.btnGo.Primary = true;
            this.btnGo.Size = new System.Drawing.Size(90, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnGuided
            // 
            this.btnGuided.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuided.Depth = 0;
            this.btnGuided.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnGuided.Icon = null;
            this.btnGuided.Location = new System.Drawing.Point(96, 29);
            this.btnGuided.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuided.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuided.Name = "btnGuided";
            this.btnGuided.Primary = true;
            this.btnGuided.Size = new System.Drawing.Size(90, 23);
            this.btnGuided.TabIndex = 0;
            this.btnGuided.Text = "Guided";
            this.btnGuided.UseVisualStyleBackColor = true;
            this.btnGuided.Click += new System.EventHandler(this.btnGuided_Click);
            // 
            // btnFGo
            // 
            this.btnFGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpControl.SetColumnSpan(this.btnFGo, 2);
            this.btnFGo.Depth = 0;
            this.btnFGo.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnFGo.Icon = null;
            this.btnFGo.Location = new System.Drawing.Point(284, 2);
            this.btnFGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnFGo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFGo.Name = "btnFGo";
            this.btnFGo.Primary = true;
            this.btnFGo.Size = new System.Drawing.Size(185, 23);
            this.btnFGo.TabIndex = 4;
            this.btnFGo.Text = "경로 - 첫번째 위치";
            this.btnFGo.UseVisualStyleBackColor = true;
            this.btnFGo.Click += new System.EventHandler(this.btnFGo_Click);
            // 
            // btnManual
            // 
            this.btnManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManual.Depth = 0;
            this.btnManual.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnManual.Icon = null;
            this.btnManual.Location = new System.Drawing.Point(2, 29);
            this.btnManual.Margin = new System.Windows.Forms.Padding(2);
            this.btnManual.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnManual.Name = "btnManual";
            this.btnManual.Primary = true;
            this.btnManual.Size = new System.Drawing.Size(90, 23);
            this.btnManual.TabIndex = 2;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 19);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1791, 768);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            // 
            // btnUOU
            // 
            this.btnUOU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUOU.Depth = 0;
            this.btnUOU.Icon = global::EUV.Properties.Resources.UOU;
            this.btnUOU.Location = new System.Drawing.Point(1610, 25);
            this.btnUOU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUOU.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUOU.Name = "btnUOU";
            this.btnUOU.Primary = false;
            this.btnUOU.Size = new System.Drawing.Size(196, 46);
            this.btnUOU.TabIndex = 6;
            this.btnUOU.UseVisualStyleBackColor = true;
            this.btnUOU.Click += new System.EventHandler(this.btnUOU_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 866);
            this.Controls.Add(this.btnUOU);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.tbSelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(1688, 663);
            this.Name = "MainForm";
            this.Sizable = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Controls.SetChildIndex(this.tbSelMain, 0);
            this.Controls.SetChildIndex(this.tbMain, 0);
            this.Controls.SetChildIndex(this.btnUOU, 0);
            this.tbMain.ResumeLayout(false);
            this.tpHome.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsMap.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpLocation.ResumeLayout(false);
            this.tlpLocation.ResumeLayout(false);
            this.tlpLocation.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.tlpTime.ResumeLayout(false);
            this.tlpTime.PerformLayout();
            this.grpSetting.ResumeLayout(false);
            this.tlpSetting.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.grpRoute.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tlpControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector_Theme tbSelMain;
        private MaterialSkin.Controls.MaterialTabControl tbMain;
        private System.Windows.Forms.TabPage tpHome;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialPanel pnlTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialRaisedButton btnLedSetting;
        private MaterialSkin.Controls.MaterialLabel lblStartTime;
        private MaterialSkin.Controls.MaterialLabel lblCurrentTimeSet;
        private MaterialSkin.Controls.MaterialLabel lblCurrentTime;
        private System.Windows.Forms.Timer Timer;
        public Controls.myGMAP MainMap;
        public MaterialSkin.Controls.MaterialLabel_Color lblStartTimeSet;
        private System.Windows.Forms.TableLayoutPanel tlpControl;
        private MaterialSkin.Controls.MaterialRaisedButton btnArm;
        private MaterialSkin.Controls.MaterialRaisedButton btnDisArm;
        private MaterialSkin.Controls.MaterialRaisedButton btnGo;
        private MaterialSkin.Controls.MaterialRaisedButton btnFGo;
        private MaterialSkin.Controls.MaterialRaisedButton btnRtl;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrake;
        private MaterialSkin.Controls.MaterialRaisedButton btnLoiter;
        private MaterialSkin.Controls.MaterialRaisedButton btnGuided;
        private MaterialSkin.Controls.MaterialRaisedButton btnManual;
        private MaterialSkin.Controls.MaterialRaisedButton btnRestart;
        private MaterialSkin.Controls.MaterialRaisedButton btnTurnOff;
        private MaterialSkin.Controls.MaterialRaisedButton btnSourceUpload;
        private System.Windows.Forms.GroupBox grpLocation;
        private System.Windows.Forms.TableLayoutPanel tlpLocation;
        private MaterialSkin.Controls.MaterialFlatButton btnSelectiveShip;
        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.TableLayoutPanel tlpSetting;
        private MaterialSkin.Controls.MaterialFlatButton btnRegisteredShip;
        private MaterialSkin.Controls.MaterialFlatButton btnBookMark;
        private MaterialSkin.Controls.MaterialLabel lblMouseLat;
        private MaterialSkin.Controls.MaterialLabel lblMouseLng;
        private MaterialSkin.Controls.MaterialLabel txtMouseLng;
        private MaterialSkin.Controls.MaterialLabel txtMouseLat;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.TableLayoutPanel tlpTime;
        private MaterialSkin.Controls.MaterialFlatButton btnSunset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnChkBox;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnBattery;
        private System.Windows.Forms.ColumnHeader columnGPS;
        private System.Windows.Forms.ColumnHeader columnVehicleMode;
        private MaterialSkin.Controls.MaterialContextMenuStrip cmsMap;
        private System.Windows.Forms.ToolStripMenuItem 여기로이동ToolStripMenuItem;
        private MaterialSkin.Controls.MaterialRaisedButton btnStartSetting;
        private MaterialSkin.Controls.MaterialFlatButton btnMousePoistion;
        public System.Windows.Forms.ToolStripMenuItem LocationTagToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem LocationTagSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocationTagDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocationTagMovementToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpRoute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialRaisedButton btnRouteDraw;
        private MaterialSkin.Controls.MaterialFlatButton btnUOU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

