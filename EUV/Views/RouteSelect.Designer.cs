namespace EUV.Views
{
    partial class RouteSelect
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cboRoute = new MetroFramework.Controls.MetroComboBox();
            this.btnDeleteRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(8, 75);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(478, 302);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 315;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(67, 395);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(373, 117);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "경로";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.Controls.Add(this.materialSingleLineTextField1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboRoute, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteRoute, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRoute, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // materialSingleLineTextField1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.materialSingleLineTextField1, 5);
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(3, 44);
            this.materialSingleLineTextField1.MaxLength = 32767;
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.ReadOnly = false;
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(224, 41);
            this.materialSingleLineTextField1.TabIndex = 0;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.Text = "-경로명-";
            this.materialSingleLineTextField1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // cboRoute
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboRoute, 5);
            this.cboRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.ItemHeight = 23;
            this.cboRoute.Location = new System.Drawing.Point(2, 2);
            this.cboRoute.Margin = new System.Windows.Forms.Padding(2);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(226, 29);
            this.cboRoute.TabIndex = 15;
            this.cboRoute.UseSelectable = true;
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.Depth = 0;
            this.btnDeleteRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteRoute.Icon = null;
            this.btnDeleteRoute.Location = new System.Drawing.Point(301, 2);
            this.btnDeleteRoute.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Primary = true;
            this.btnDeleteRoute.Size = new System.Drawing.Size(66, 37);
            this.btnDeleteRoute.TabIndex = 17;
            this.btnDeleteRoute.Text = "삭제";
            this.btnDeleteRoute.UseVisualStyleBackColor = true;
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.Depth = 0;
            this.btnAddRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddRoute.Icon = null;
            this.btnAddRoute.Location = new System.Drawing.Point(232, 2);
            this.btnAddRoute.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Primary = true;
            this.btnAddRoute.Size = new System.Drawing.Size(65, 37);
            this.btnAddRoute.TabIndex = 16;
            this.btnAddRoute.Text = "등록";
            this.btnAddRoute.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(69, 542);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(297, 127);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "경로 선택";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 73);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // RouteSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 754);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(0, 513);
            this.Name = "RouteSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "경로 선택";
            this.Controls.SetChildIndex(this.listView, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        public MetroFramework.Controls.MetroComboBox cboRoute;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteRoute;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddRoute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}