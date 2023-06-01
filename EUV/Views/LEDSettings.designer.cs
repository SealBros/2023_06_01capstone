using System.Windows.Forms;

namespace EUV.Views
{
    partial class LEDSettings
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
            this.panel = new MaterialSkin.Controls.MaterialPanel();
            this.grpLedSetting = new System.Windows.Forms.GroupBox();
            this.lblColor = new MaterialSkin.Controls.MaterialLabel_Color();
            this.btnOff = new MaterialSkin.Controls.MaterialRaisedButton();
            this.trbBlue = new MetroFramework.Controls.MetroTrackBar();
            this.btnOn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtBlue = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblBlue = new MaterialSkin.Controls.MaterialLabel();
            this.btnBlue = new MaterialSkin.Controls.MaterialFlatButton();
            this.trbGreen = new MetroFramework.Controls.MetroTrackBar();
            this.txtGreen = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblGreen = new MaterialSkin.Controls.MaterialLabel();
            this.btnGreen = new MaterialSkin.Controls.MaterialFlatButton();
            this.trbRed = new MetroFramework.Controls.MetroTrackBar();
            this.txtRed = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnRed = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblRed = new MaterialSkin.Controls.MaterialLabel();
            this.grpShipID = new System.Windows.Forms.GroupBox();
            this.chkAllBoat = new MaterialSkin.Controls.MaterialCheckBox();
            this.cboShipID = new MetroFramework.Controls.MetroComboBox();
            this.panel.SuspendLayout();
            this.grpLedSetting.SuspendLayout();
            this.grpShipID.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.grpLedSetting);
            this.panel.Controls.Add(this.grpShipID);
            this.panel.Depth = 0;
            this.panel.Location = new System.Drawing.Point(3, 99);
            this.panel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(591, 789);
            this.panel.TabIndex = 3;
            // 
            // grpLedSetting
            // 
            this.grpLedSetting.Controls.Add(this.lblColor);
            this.grpLedSetting.Controls.Add(this.btnOff);
            this.grpLedSetting.Controls.Add(this.trbBlue);
            this.grpLedSetting.Controls.Add(this.btnOn);
            this.grpLedSetting.Controls.Add(this.txtBlue);
            this.grpLedSetting.Controls.Add(this.lblBlue);
            this.grpLedSetting.Controls.Add(this.btnBlue);
            this.grpLedSetting.Controls.Add(this.trbGreen);
            this.grpLedSetting.Controls.Add(this.txtGreen);
            this.grpLedSetting.Controls.Add(this.lblGreen);
            this.grpLedSetting.Controls.Add(this.btnGreen);
            this.grpLedSetting.Controls.Add(this.trbRed);
            this.grpLedSetting.Controls.Add(this.txtRed);
            this.grpLedSetting.Controls.Add(this.btnRed);
            this.grpLedSetting.Controls.Add(this.lblRed);
            this.grpLedSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLedSetting.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.grpLedSetting.Location = new System.Drawing.Point(0, 148);
            this.grpLedSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLedSetting.Name = "grpLedSetting";
            this.grpLedSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLedSetting.Size = new System.Drawing.Size(591, 639);
            this.grpLedSetting.TabIndex = 36;
            this.grpLedSetting.TabStop = false;
            this.grpLedSetting.Text = "설정";
            // 
            // lblColor
            // 
            this.lblColor.Depth = 0;
            this.lblColor.Font = new System.Drawing.Font("나눔스퀘어", 10F);
            this.lblColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblColor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblColor.Location = new System.Drawing.Point(27, 504);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(526, 54);
            this.lblColor.TabIndex = 31;
            this.lblColor.Text = "선택한 색";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOff
            // 
            this.btnOff.Depth = 0;
            this.btnOff.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnOff.Icon = null;
            this.btnOff.Location = new System.Drawing.Point(310, 579);
            this.btnOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOff.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOff.Name = "btnOff";
            this.btnOff.Primary = true;
            this.btnOff.Size = new System.Drawing.Size(243, 44);
            this.btnOff.TabIndex = 20;
            this.btnOff.Text = "끄기";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // trbBlue
            // 
            this.trbBlue.BackColor = System.Drawing.Color.Transparent;
            this.trbBlue.Location = new System.Drawing.Point(123, 429);
            this.trbBlue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trbBlue.Maximum = 255;
            this.trbBlue.Name = "trbBlue";
            this.trbBlue.Size = new System.Drawing.Size(430, 36);
            this.trbBlue.TabIndex = 30;
            this.trbBlue.Text = "metroTrackBar3";
            this.trbBlue.Value = 255;
            this.trbBlue.ValueChanged += new System.EventHandler(this.trbBlue_ValueChanged);
            // 
            // btnOn
            // 
            this.btnOn.Depth = 0;
            this.btnOn.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnOn.Icon = null;
            this.btnOn.Location = new System.Drawing.Point(32, 579);
            this.btnOn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOn.Name = "btnOn";
            this.btnOn.Primary = true;
            this.btnOn.Size = new System.Drawing.Size(248, 44);
            this.btnOn.TabIndex = 19;
            this.btnOn.Text = "켜기";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // txtBlue
            // 
            this.txtBlue.Depth = 0;
            this.txtBlue.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtBlue.Hint = "";
            this.txtBlue.Location = new System.Drawing.Point(27, 417);
            this.txtBlue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBlue.MaxLength = 32767;
            this.txtBlue.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.PasswordChar = '\0';
            this.txtBlue.ReadOnly = false;
            this.txtBlue.SelectedText = "";
            this.txtBlue.SelectionLength = 0;
            this.txtBlue.SelectionStart = 0;
            this.txtBlue.Size = new System.Drawing.Size(86, 38);
            this.txtBlue.TabIndex = 29;
            this.txtBlue.TabStop = false;
            this.txtBlue.Text = "255";
            this.txtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBlue.UseSystemPasswordChar = false;
            this.txtBlue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtBlue.TextChanged += new System.EventHandler(this.txtBlue_TextChanged);
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Depth = 0;
            this.lblBlue.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.lblBlue.Location = new System.Drawing.Point(116, 358);
            this.lblBlue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(135, 26);
            this.lblBlue.TabIndex = 28;
            this.lblBlue.Text = "(B) (0~255)";
            // 
            // btnBlue
            // 
            this.btnBlue.Depth = 0;
            this.btnBlue.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnBlue.Icon = null;
            this.btnBlue.Location = new System.Drawing.Point(27, 360);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnBlue.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Primary = false;
            this.btnBlue.Size = new System.Drawing.Size(80, 57);
            this.btnBlue.TabIndex = 27;
            this.btnBlue.Text = "파랑";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // trbGreen
            // 
            this.trbGreen.BackColor = System.Drawing.Color.Transparent;
            this.trbGreen.Location = new System.Drawing.Point(123, 273);
            this.trbGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trbGreen.Maximum = 255;
            this.trbGreen.Name = "trbGreen";
            this.trbGreen.Size = new System.Drawing.Size(430, 36);
            this.trbGreen.TabIndex = 26;
            this.trbGreen.Text = "metroTrackBar2";
            this.trbGreen.Value = 255;
            this.trbGreen.ValueChanged += new System.EventHandler(this.trbGreen_ValueChanged);
            // 
            // txtGreen
            // 
            this.txtGreen.Depth = 0;
            this.txtGreen.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtGreen.Hint = "";
            this.txtGreen.Location = new System.Drawing.Point(27, 261);
            this.txtGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGreen.MaxLength = 32767;
            this.txtGreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.PasswordChar = '\0';
            this.txtGreen.ReadOnly = false;
            this.txtGreen.SelectedText = "";
            this.txtGreen.SelectionLength = 0;
            this.txtGreen.SelectionStart = 0;
            this.txtGreen.Size = new System.Drawing.Size(86, 38);
            this.txtGreen.TabIndex = 25;
            this.txtGreen.TabStop = false;
            this.txtGreen.Text = "255";
            this.txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGreen.UseSystemPasswordChar = false;
            this.txtGreen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtGreen.TextChanged += new System.EventHandler(this.txtGreen_TextChanged);
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Depth = 0;
            this.lblGreen.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.lblGreen.Location = new System.Drawing.Point(116, 192);
            this.lblGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(136, 26);
            this.lblGreen.TabIndex = 24;
            this.lblGreen.Text = "(G) (0~255)";
            // 
            // btnGreen
            // 
            this.btnGreen.Depth = 0;
            this.btnGreen.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnGreen.Icon = null;
            this.btnGreen.Location = new System.Drawing.Point(27, 195);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnGreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Primary = false;
            this.btnGreen.Size = new System.Drawing.Size(80, 57);
            this.btnGreen.TabIndex = 23;
            this.btnGreen.Text = "초록";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // trbRed
            // 
            this.trbRed.BackColor = System.Drawing.Color.Transparent;
            this.trbRed.Location = new System.Drawing.Point(123, 123);
            this.trbRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trbRed.Maximum = 255;
            this.trbRed.Name = "trbRed";
            this.trbRed.Size = new System.Drawing.Size(430, 36);
            this.trbRed.TabIndex = 22;
            this.trbRed.Text = "metroTrackBar1";
            this.trbRed.Value = 255;
            this.trbRed.ValueChanged += new System.EventHandler(this.trbRed_ValueChanged);
            // 
            // txtRed
            // 
            this.txtRed.Depth = 0;
            this.txtRed.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.txtRed.Hint = "";
            this.txtRed.Location = new System.Drawing.Point(27, 111);
            this.txtRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRed.MaxLength = 32767;
            this.txtRed.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRed.Name = "txtRed";
            this.txtRed.PasswordChar = '\0';
            this.txtRed.ReadOnly = false;
            this.txtRed.SelectedText = "";
            this.txtRed.SelectionLength = 0;
            this.txtRed.SelectionStart = 0;
            this.txtRed.Size = new System.Drawing.Size(86, 38);
            this.txtRed.TabIndex = 21;
            this.txtRed.TabStop = false;
            this.txtRed.Text = "255";
            this.txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRed.UseSystemPasswordChar = false;
            this.txtRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtRed.TextChanged += new System.EventHandler(this.txtRed_TextChanged);
            // 
            // btnRed
            // 
            this.btnRed.Depth = 0;
            this.btnRed.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.btnRed.Icon = null;
            this.btnRed.Location = new System.Drawing.Point(27, 44);
            this.btnRed.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnRed.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRed.Name = "btnRed";
            this.btnRed.Primary = false;
            this.btnRed.Size = new System.Drawing.Size(80, 57);
            this.btnRed.TabIndex = 20;
            this.btnRed.Text = "빨강";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Depth = 0;
            this.lblRed.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.lblRed.Location = new System.Drawing.Point(116, 42);
            this.lblRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRed.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(135, 26);
            this.lblRed.TabIndex = 19;
            this.lblRed.Text = "(R) (0~255)";
            // 
            // grpShipID
            // 
            this.grpShipID.Controls.Add(this.chkAllBoat);
            this.grpShipID.Controls.Add(this.cboShipID);
            this.grpShipID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpShipID.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.grpShipID.Location = new System.Drawing.Point(0, 0);
            this.grpShipID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpShipID.Name = "grpShipID";
            this.grpShipID.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpShipID.Size = new System.Drawing.Size(591, 148);
            this.grpShipID.TabIndex = 35;
            this.grpShipID.TabStop = false;
            this.grpShipID.Text = "선박 번호";
            // 
            // chkAllBoat
            // 
            this.chkAllBoat.Depth = 0;
            this.chkAllBoat.Font = new System.Drawing.Font("나눔스퀘어", 12F);
            this.chkAllBoat.Location = new System.Drawing.Point(32, 50);
            this.chkAllBoat.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllBoat.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkAllBoat.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkAllBoat.Name = "chkAllBoat";
            this.chkAllBoat.Ripple = true;
            this.chkAllBoat.Size = new System.Drawing.Size(195, 28);
            this.chkAllBoat.TabIndex = 35;
            this.chkAllBoat.Text = "전체 선박 선택";
            this.chkAllBoat.UseVisualStyleBackColor = true;
            this.chkAllBoat.CheckedChanged += new System.EventHandler(this.chkAllBoat_CheckedChanged);
            // 
            // cboShipID
            // 
            this.cboShipID.FormattingEnabled = true;
            this.cboShipID.ItemHeight = 23;
            this.cboShipID.Location = new System.Drawing.Point(32, 88);
            this.cboShipID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboShipID.Name = "cboShipID";
            this.cboShipID.Size = new System.Drawing.Size(520, 29);
            this.cboShipID.TabIndex = 32;
            this.cboShipID.UseSelectable = true;
            this.cboShipID.SelectedIndexChanged += new System.EventHandler(this.cboShipID_SelectedIndexChanged);
            // 
            // LEDSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(597, 891);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("나눔스퀘어", 15F);
            this.Margin = new System.Windows.Forms.Padding(8, 14, 8, 14);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LEDSettings";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED 설정";
            this.Load += new System.EventHandler(this.LEDSettings_Load);
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.grpLedSetting.ResumeLayout(false);
            this.grpLedSetting.PerformLayout();
            this.grpShipID.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialPanel panel;
        private MaterialSkin.Controls.MaterialRaisedButton btnOff;
        private MaterialSkin.Controls.MaterialRaisedButton btnOn;
        private GroupBox grpShipID;
        private MetroFramework.Controls.MetroComboBox cboShipID;
        private GroupBox grpLedSetting;
        private MaterialSkin.Controls.MaterialLabel_Color lblColor;
        private MetroFramework.Controls.MetroTrackBar trbBlue;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBlue;
        private MaterialSkin.Controls.MaterialLabel lblBlue;
        private MaterialSkin.Controls.MaterialFlatButton btnBlue;
        private MetroFramework.Controls.MetroTrackBar trbGreen;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtGreen;
        private MaterialSkin.Controls.MaterialLabel lblGreen;
        private MaterialSkin.Controls.MaterialFlatButton btnGreen;
        private MetroFramework.Controls.MetroTrackBar trbRed;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRed;
        private MaterialSkin.Controls.MaterialFlatButton btnRed;
        private MaterialSkin.Controls.MaterialLabel lblRed;
        private MaterialSkin.Controls.MaterialCheckBox chkAllBoat;
    }
}