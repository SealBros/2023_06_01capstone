namespace EUV.Views
{
    partial class RouteDraw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSave = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSeeRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.drawSaveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveDraw = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDeletePoly = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSavePoly = new MaterialSkin.Controls.MaterialRaisedButton();
            this.drawPolygonCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.btnNodeSelect = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAutoSelect = new MaterialSkin.Controls.MaterialRaisedButton();
            this.droneNum = new System.Windows.Forms.Label();
            this.labelDroneNum = new System.Windows.Forms.Label();
            this.numTest = new System.Windows.Forms.Label();
            this.grpDraw = new System.Windows.Forms.GroupBox();
            this.tlpAudio = new System.Windows.Forms.TableLayoutPanel();
            this.btnPath = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RouteMap = new EUV.Controls.myGMAP();
            this.grpSave.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpDraw.SuspendLayout();
            this.tlpAudio.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSave
            // 
            this.grpSave.Controls.Add(this.tableLayoutPanel2);
            this.grpSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpSave.Location = new System.Drawing.Point(1230, 2);
            this.grpSave.Margin = new System.Windows.Forms.Padding(2);
            this.grpSave.Name = "grpSave";
            this.grpSave.Padding = new System.Windows.Forms.Padding(2);
            this.grpSave.Size = new System.Drawing.Size(212, 86);
            this.grpSave.TabIndex = 16;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "경로 저장";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSeeRoute, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.drawSaveBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 65);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSeeRoute
            // 
            this.btnSeeRoute.Depth = 0;
            this.btnSeeRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeeRoute.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnSeeRoute.Icon = null;
            this.btnSeeRoute.Location = new System.Drawing.Point(106, 2);
            this.btnSeeRoute.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeeRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSeeRoute.Name = "btnSeeRoute";
            this.btnSeeRoute.Primary = true;
            this.btnSeeRoute.Size = new System.Drawing.Size(100, 41);
            this.btnSeeRoute.TabIndex = 10;
            this.btnSeeRoute.Text = "경로 보기";
            this.btnSeeRoute.UseVisualStyleBackColor = true;
            this.btnSeeRoute.Click += new System.EventHandler(this.btnSeeRoute_Click);
            // 
            // drawSaveBtn
            // 
            this.drawSaveBtn.Depth = 0;
            this.drawSaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawSaveBtn.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.drawSaveBtn.Icon = null;
            this.drawSaveBtn.Location = new System.Drawing.Point(2, 2);
            this.drawSaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.drawSaveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.drawSaveBtn.Name = "drawSaveBtn";
            this.drawSaveBtn.Primary = true;
            this.drawSaveBtn.Size = new System.Drawing.Size(100, 41);
            this.drawSaveBtn.TabIndex = 9;
            this.drawSaveBtn.Text = "지점 저장";
            this.drawSaveBtn.UseVisualStyleBackColor = true;
            this.drawSaveBtn.Click += new System.EventHandler(this.drawSaveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.numTest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1224, 86);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "그리기 도구";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveDraw, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeletePoly, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSavePoly, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawPolygonCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboPoly, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNodeSelect, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoSelect, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.droneNum, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDroneNum, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1220, 65);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnRemoveDraw
            // 
            this.btnRemoveDraw.AutoSize = true;
            this.btnRemoveDraw.Depth = 0;
            this.btnRemoveDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveDraw.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnRemoveDraw.Icon = null;
            this.btnRemoveDraw.Location = new System.Drawing.Point(708, 2);
            this.btnRemoveDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveDraw.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveDraw.Name = "btnRemoveDraw";
            this.btnRemoveDraw.Primary = true;
            this.btnRemoveDraw.Size = new System.Drawing.Size(81, 41);
            this.btnRemoveDraw.TabIndex = 26;
            this.btnRemoveDraw.Text = "지우기";
            this.btnRemoveDraw.UseVisualStyleBackColor = true;
            this.btnRemoveDraw.Click += new System.EventHandler(this.btnRemoveDraw_Click);
            // 
            // btnDeletePoly
            // 
            this.btnDeletePoly.AutoSize = true;
            this.btnDeletePoly.Depth = 0;
            this.btnDeletePoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeletePoly.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnDeletePoly.Icon = null;
            this.btnDeletePoly.Location = new System.Drawing.Point(586, 2);
            this.btnDeletePoly.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeletePoly.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeletePoly.Name = "btnDeletePoly";
            this.btnDeletePoly.Primary = true;
            this.btnDeletePoly.Size = new System.Drawing.Size(118, 41);
            this.btnDeletePoly.TabIndex = 25;
            this.btnDeletePoly.Text = "다각형 삭제";
            this.btnDeletePoly.UseVisualStyleBackColor = true;
            this.btnDeletePoly.Click += new System.EventHandler(this.btnDeletePoly_Click);
            // 
            // btnSavePoly
            // 
            this.btnSavePoly.AutoSize = true;
            this.btnSavePoly.Depth = 0;
            this.btnSavePoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePoly.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnSavePoly.Icon = null;
            this.btnSavePoly.Location = new System.Drawing.Point(464, 2);
            this.btnSavePoly.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePoly.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSavePoly.Name = "btnSavePoly";
            this.btnSavePoly.Primary = true;
            this.btnSavePoly.Size = new System.Drawing.Size(118, 41);
            this.btnSavePoly.TabIndex = 24;
            this.btnSavePoly.Text = "다각형 저장";
            this.btnSavePoly.UseVisualStyleBackColor = true;
            this.btnSavePoly.Click += new System.EventHandler(this.btnSavePoly_Click);
            // 
            // drawPolygonCheckBox
            // 
            this.drawPolygonCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.drawPolygonCheckBox.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.drawPolygonCheckBox.Location = new System.Drawing.Point(55, 3);
            this.drawPolygonCheckBox.Name = "drawPolygonCheckBox";
            this.drawPolygonCheckBox.Size = new System.Drawing.Size(155, 39);
            this.drawPolygonCheckBox.TabIndex = 17;
            this.drawPolygonCheckBox.Text = "다각형 그리기";
            this.drawPolygonCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.drawPolygonCheckBox.UseVisualStyleBackColor = true;
            this.drawPolygonCheckBox.CheckedChanged += new System.EventHandler(this.drawPolygonCheckBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EUV.Properties.Resources.경로그리기;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // cboPoly
            // 
            this.cboPoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPoly.Font = new System.Drawing.Font("나눔스퀘어", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPoly.FormattingEnabled = true;
            this.cboPoly.Location = new System.Drawing.Point(221, 3);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(238, 33);
            this.cboPoly.TabIndex = 23;
            this.cboPoly.Text = "- 저장 다각형 -";
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // btnNodeSelect
            // 
            this.btnNodeSelect.Depth = 0;
            this.btnNodeSelect.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNodeSelect.Icon = null;
            this.btnNodeSelect.Location = new System.Drawing.Point(1128, 2);
            this.btnNodeSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnNodeSelect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNodeSelect.Name = "btnNodeSelect";
            this.btnNodeSelect.Primary = true;
            this.btnNodeSelect.Size = new System.Drawing.Size(89, 41);
            this.btnNodeSelect.TabIndex = 18;
            this.btnNodeSelect.Text = "지점 선택";
            this.btnNodeSelect.UseVisualStyleBackColor = true;
            this.btnNodeSelect.Click += new System.EventHandler(this.btnNodeSelect_Click);
            // 
            // btnAutoSelect
            // 
            this.btnAutoSelect.Depth = 0;
            this.btnAutoSelect.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSelect.Icon = null;
            this.btnAutoSelect.Location = new System.Drawing.Point(1037, 2);
            this.btnAutoSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutoSelect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAutoSelect.Name = "btnAutoSelect";
            this.btnAutoSelect.Primary = true;
            this.btnAutoSelect.Size = new System.Drawing.Size(87, 41);
            this.btnAutoSelect.TabIndex = 22;
            this.btnAutoSelect.Text = "자동 선택";
            this.btnAutoSelect.UseVisualStyleBackColor = true;
            this.btnAutoSelect.Click += new System.EventHandler(this.btnAutoSelect_Click);
            // 
            // droneNum
            // 
            this.droneNum.AutoSize = true;
            this.droneNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneNum.Font = new System.Drawing.Font("나눔스퀘어", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.droneNum.Location = new System.Drawing.Point(977, 0);
            this.droneNum.Name = "droneNum";
            this.droneNum.Size = new System.Drawing.Size(55, 45);
            this.droneNum.TabIndex = 21;
            this.droneNum.Text = "-";
            this.droneNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDroneNum
            // 
            this.labelDroneNum.AutoSize = true;
            this.labelDroneNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDroneNum.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.labelDroneNum.Location = new System.Drawing.Point(794, 0);
            this.labelDroneNum.Name = "labelDroneNum";
            this.labelDroneNum.Size = new System.Drawing.Size(177, 45);
            this.labelDroneNum.TabIndex = 20;
            this.labelDroneNum.Text = "선택 수상드론 개수";
            this.labelDroneNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numTest
            // 
            this.numTest.AutoSize = true;
            this.numTest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.numTest.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.numTest.Location = new System.Drawing.Point(776, 14);
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(34, 22);
            this.numTest.TabIndex = 22;
            this.numTest.Text = "12";
            this.numTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDraw
            // 
            this.grpDraw.Controls.Add(this.tlpAudio);
            this.grpDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpDraw.Location = new System.Drawing.Point(1446, 2);
            this.grpDraw.Margin = new System.Windows.Forms.Padding(2);
            this.grpDraw.Name = "grpDraw";
            this.grpDraw.Padding = new System.Windows.Forms.Padding(2);
            this.grpDraw.Size = new System.Drawing.Size(359, 86);
            this.grpDraw.TabIndex = 15;
            this.grpDraw.TabStop = false;
            this.grpDraw.Text = "설정";
            this.grpDraw.Enter += new System.EventHandler(this.grpDraw_Enter);
            // 
            // tlpAudio
            // 
            this.tlpAudio.ColumnCount = 2;
            this.tlpAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAudio.Controls.Add(this.btnPath, 1, 0);
            this.tlpAudio.Controls.Add(this.cboRoute, 0, 0);
            this.tlpAudio.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpAudio.Location = new System.Drawing.Point(2, 38);
            this.tlpAudio.Margin = new System.Windows.Forms.Padding(2);
            this.tlpAudio.Name = "tlpAudio";
            this.tlpAudio.RowCount = 2;
            this.tlpAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAudio.Size = new System.Drawing.Size(355, 65);
            this.tlpAudio.TabIndex = 0;
            // 
            // btnPath
            // 
            this.btnPath.Depth = 0;
            this.btnPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPath.Font = new System.Drawing.Font("나눔스퀘어", 9.999999F);
            this.btnPath.Icon = null;
            this.btnPath.Location = new System.Drawing.Point(250, 2);
            this.btnPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPath.Name = "btnPath";
            this.btnPath.Primary = true;
            this.btnPath.Size = new System.Drawing.Size(103, 41);
            this.btnPath.TabIndex = 9;
            this.btnPath.Text = "최단 경로";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // cboRoute
            // 
            this.cboRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRoute.Font = new System.Drawing.Font("나눔스퀘어", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(3, 3);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(242, 33);
            this.cboRoute.TabIndex = 10;
            this.cboRoute.Text = "- 저장 경로 -";
            this.cboRoute.SelectedIndexChanged += new System.EventHandler(this.cboRoute_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.RouteMap, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.grpSave, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.grpDraw, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1807, 802);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // RouteMap
            // 
            this.RouteMap.Bearing = 0F;
            this.RouteMap.CanDragMap = true;
            this.tableLayoutPanel3.SetColumnSpan(this.RouteMap, 3);
            this.RouteMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.RouteMap.GrayScaleMode = false;
            this.RouteMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.RouteMap.LevelsKeepInMemmory = 5;
            this.RouteMap.Location = new System.Drawing.Point(3, 93);
            this.RouteMap.MarkersEnabled = true;
            this.RouteMap.MaxZoom = 2;
            this.RouteMap.MinZoom = 2;
            this.RouteMap.MouseWheelZoomEnabled = true;
            this.RouteMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.RouteMap.Name = "RouteMap";
            this.RouteMap.NegativeMode = false;
            this.RouteMap.PolygonsEnabled = true;
            this.RouteMap.RetryLoadTile = 0;
            this.RouteMap.RoutesEnabled = true;
            this.RouteMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.RouteMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.RouteMap.ShowTileGridLines = false;
            this.RouteMap.Size = new System.Drawing.Size(1801, 706);
            this.RouteMap.TabIndex = 0;
            this.RouteMap.Zoom = 0D;
            this.RouteMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.RouteMap_OnMarkerClick);
            this.RouteMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.RouteMap_OnMapZoomChanged);
            this.RouteMap.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteMap_Paint);
            this.RouteMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RouteMap_MouseUp);
            // 
            // RouteDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 866);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("나눔스퀘어", 15F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RouteDraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "경로 그리기";
            this.Load += new System.EventHandler(this.RouteDraw_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.grpSave.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpDraw.ResumeLayout(false);
            this.tlpAudio.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.myGMAP RouteMap;
        private System.Windows.Forms.GroupBox grpSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialRaisedButton drawSaveBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label droneNum;
        private System.Windows.Forms.CheckBox drawPolygonCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnNodeSelect;
        private System.Windows.Forms.Label labelDroneNum;
        private System.Windows.Forms.Label numTest;
        private System.Windows.Forms.GroupBox grpDraw;
        private System.Windows.Forms.TableLayoutPanel tlpAudio;
        private MaterialSkin.Controls.MaterialRaisedButton btnPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cboRoute;
        private MaterialSkin.Controls.MaterialRaisedButton btnAutoSelect;
        private System.Windows.Forms.ComboBox cboPoly;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeletePoly;
        private MaterialSkin.Controls.MaterialRaisedButton btnSavePoly;
        private MaterialSkin.Controls.MaterialRaisedButton btnRemoveDraw;
        private MaterialSkin.Controls.MaterialRaisedButton btnSeeRoute;
    }
}