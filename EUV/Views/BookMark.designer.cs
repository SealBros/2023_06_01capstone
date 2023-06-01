namespace EUV.Views
{
    partial class BookMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookMark));
            this.panel = new MaterialSkin.Controls.MaterialPanel();
            this.materialPanel1 = new MaterialSkin.Controls.MaterialPanel();
            this.btnLocationTag = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnMapLocation = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAdd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtBookMarkName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnDelete = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAddUI = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtLng = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtLat = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblLng = new MaterialSkin.Controls.MaterialLabel();
            this.lblLat = new MaterialSkin.Controls.MaterialLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel.SuspendLayout();
            this.materialPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.materialPanel1);
            this.panel.Controls.Add(this.btnAdd);
            this.panel.Controls.Add(this.txtBookMarkName);
            this.panel.Controls.Add(this.btnDelete);
            this.panel.Controls.Add(this.btnAddUI);
            this.panel.Controls.Add(this.txtLng);
            this.panel.Controls.Add(this.txtLat);
            this.panel.Controls.Add(this.lblLng);
            this.panel.Controls.Add(this.lblLat);
            this.panel.Controls.Add(this.listView);
            this.panel.Depth = 0;
            this.panel.Location = new System.Drawing.Point(3, 100);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(489, 652);
            this.panel.TabIndex = 3;
            // 
            // materialPanel1
            // 
            this.materialPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialPanel1.Controls.Add(this.btnLocationTag);
            this.materialPanel1.Controls.Add(this.btnMapLocation);
            this.materialPanel1.Depth = 0;
            this.materialPanel1.Location = new System.Drawing.Point(24, 600);
            this.materialPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialPanel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialPanel1.Name = "materialPanel1";
            this.materialPanel1.Size = new System.Drawing.Size(436, 40);
            this.materialPanel1.TabIndex = 15;
            // 
            // btnLocationTag
            // 
            this.btnLocationTag.Depth = 0;
            this.btnLocationTag.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLocationTag.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnLocationTag.Icon = null;
            this.btnLocationTag.Location = new System.Drawing.Point(234, 0);
            this.btnLocationTag.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnLocationTag.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLocationTag.Name = "btnLocationTag";
            this.btnLocationTag.Primary = false;
            this.btnLocationTag.Size = new System.Drawing.Size(202, 40);
            this.btnLocationTag.TabIndex = 13;
            this.btnLocationTag.Text = "위치 태그로";
            this.btnLocationTag.UseVisualStyleBackColor = true;
            this.btnLocationTag.Click += new System.EventHandler(this.btnLocationTag_Click);
            // 
            // btnMapLocation
            // 
            this.btnMapLocation.Depth = 0;
            this.btnMapLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMapLocation.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnMapLocation.Icon = null;
            this.btnMapLocation.Location = new System.Drawing.Point(0, 0);
            this.btnMapLocation.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnMapLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMapLocation.Name = "btnMapLocation";
            this.btnMapLocation.Primary = false;
            this.btnMapLocation.Size = new System.Drawing.Size(202, 40);
            this.btnMapLocation.TabIndex = 8;
            this.btnMapLocation.Text = "지도의 현재 위치로";
            this.btnMapLocation.UseVisualStyleBackColor = true;
            this.btnMapLocation.Click += new System.EventHandler(this.btnMapLocation_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Depth = 0;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(24, 720);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Primary = true;
            this.btnAdd.Size = new System.Drawing.Size(561, 42);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBookMarkName
            // 
            this.txtBookMarkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookMarkName.Depth = 0;
            this.txtBookMarkName.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtBookMarkName.Hint = "";
            this.txtBookMarkName.Location = new System.Drawing.Point(26, 378);
            this.txtBookMarkName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBookMarkName.MaxLength = 32767;
            this.txtBookMarkName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBookMarkName.Name = "txtBookMarkName";
            this.txtBookMarkName.PasswordChar = '\0';
            this.txtBookMarkName.ReadOnly = false;
            this.txtBookMarkName.SelectedText = "";
            this.txtBookMarkName.SelectionLength = 0;
            this.txtBookMarkName.SelectionStart = 0;
            this.txtBookMarkName.Size = new System.Drawing.Size(435, 37);
            this.txtBookMarkName.TabIndex = 8;
            this.txtBookMarkName.TabStop = false;
            this.txtBookMarkName.Text = "즐겨찾기 이름";
            this.txtBookMarkName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBookMarkName.UseSystemPasswordChar = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Depth = 0;
            this.btnDelete.Icon = ((System.Drawing.Image)(resources.GetObject("btnDelete.Icon")));
            this.btnDelete.Location = new System.Drawing.Point(378, 318);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Primary = true;
            this.btnDelete.Size = new System.Drawing.Size(45, 45);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddUI
            // 
            this.btnAddUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUI.Depth = 0;
            this.btnAddUI.Icon = ((System.Drawing.Image)(resources.GetObject("btnAddUI.Icon")));
            this.btnAddUI.Location = new System.Drawing.Point(434, 318);
            this.btnAddUI.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnAddUI.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddUI.Name = "btnAddUI";
            this.btnAddUI.Primary = true;
            this.btnAddUI.Size = new System.Drawing.Size(45, 45);
            this.btnAddUI.TabIndex = 6;
            this.btnAddUI.UseVisualStyleBackColor = true;
            this.btnAddUI.Click += new System.EventHandler(this.btnAddUI_Click);
            // 
            // txtLng
            // 
            this.txtLng.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLng.Depth = 0;
            this.txtLng.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtLng.Hint = "";
            this.txtLng.Location = new System.Drawing.Point(136, 538);
            this.txtLng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLng.MaxLength = 32767;
            this.txtLng.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLng.Name = "txtLng";
            this.txtLng.PasswordChar = '\0';
            this.txtLng.ReadOnly = false;
            this.txtLng.SelectedText = "";
            this.txtLng.SelectionLength = 0;
            this.txtLng.SelectionStart = 0;
            this.txtLng.Size = new System.Drawing.Size(324, 38);
            this.txtLng.TabIndex = 5;
            this.txtLng.TabStop = false;
            this.txtLng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLng.UseSystemPasswordChar = false;
            this.txtLng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            this.txtLng.Leave += new System.EventHandler(this.txtLongitude_Leave);
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Depth = 0;
            this.txtLat.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtLat.Hint = "";
            this.txtLat.Location = new System.Drawing.Point(136, 466);
            this.txtLat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLat.MaxLength = 32767;
            this.txtLat.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLat.Name = "txtLat";
            this.txtLat.PasswordChar = '\0';
            this.txtLat.ReadOnly = false;
            this.txtLat.SelectedText = "";
            this.txtLat.SelectionLength = 0;
            this.txtLat.SelectionStart = 0;
            this.txtLat.Size = new System.Drawing.Size(324, 38);
            this.txtLat.TabIndex = 4;
            this.txtLat.TabStop = false;
            this.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLat.UseSystemPasswordChar = false;
            this.txtLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            this.txtLat.Leave += new System.EventHandler(this.txtLatitude_Leave);
            // 
            // lblLng
            // 
            this.lblLng.AutoSize = true;
            this.lblLng.Depth = 0;
            this.lblLng.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.lblLng.Location = new System.Drawing.Point(20, 546);
            this.lblLng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLng.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLng.Name = "lblLng";
            this.lblLng.Size = new System.Drawing.Size(69, 26);
            this.lblLng.TabIndex = 3;
            this.lblLng.Text = "경도 :";
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Depth = 0;
            this.lblLat.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.lblLat.Location = new System.Drawing.Point(20, 474);
            this.lblLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLat.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(69, 26);
            this.lblLat.TabIndex = 2;
            this.lblLat.Text = "위도 :";
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(4, 4);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(478, 302);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 315;
            // 
            // BookMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(495, 754);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("나눔스퀘어", 15F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3300, 1050);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 513);
            this.Name = "BookMark";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "즐겨찾기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookMark_FormClosed);
            this.Load += new System.EventHandler(this.BookMark_Load);
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.materialPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialPanel panel;
        private System.Windows.Forms.ListView listView;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLng;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLat;
        private MaterialSkin.Controls.MaterialLabel lblLng;
        private MaterialSkin.Controls.MaterialLabel lblLat;
        private MaterialSkin.Controls.MaterialFlatButton btnAddUI;
        private MaterialSkin.Controls.MaterialFlatButton btnDelete;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBookMarkName;
        private MaterialSkin.Controls.MaterialRaisedButton btnAdd;
        private MaterialSkin.Controls.MaterialPanel materialPanel1;
        private MaterialSkin.Controls.MaterialFlatButton btnLocationTag;
        private MaterialSkin.Controls.MaterialFlatButton btnMapLocation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}