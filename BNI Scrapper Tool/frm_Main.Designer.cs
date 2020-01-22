namespace  Devil7.Automation.BNI.Scrapper
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Keywords = new DevExpress.XtraEditors.TextEdit();
            this.cbl_Countries = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.prog_UserQuery = new DevExpress.XtraEditors.ProgressBarControl();
            this.prog_Search = new DevExpress.XtraEditors.ProgressBarControl();
            this.lbl_User_Name = new DevExpress.XtraEditors.LabelControl();
            this.lbl_User_Count = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Search_Country = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Search_Keyword = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Search_Count = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Start = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cb_Remember = new DevExpress.XtraEditors.CheckEdit();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.txt_Username = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Path_JSON = new DevExpress.XtraEditors.ButtonEdit();
            this.txt_Path_Excel = new DevExpress.XtraEditors.ButtonEdit();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gc_Logs = new DevExpress.XtraGrid.GridControl();
            this.gv_Logs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dlg_JSON = new System.Windows.Forms.SaveFileDialog();
            this.dlg_Excel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Keywords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl_Countries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prog_UserQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prog_Search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Remember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Path_JSON.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Path_Excel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Logs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Logs)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitter1);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(632, 551);
            this.splitContainerControl1.SplitterPosition = 192;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txt_Keywords);
            this.groupControl3.Controls.Add(this.cbl_Countries);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 182);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(192, 160);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "Search Options";
            // 
            // txt_Keywords
            // 
            this.txt_Keywords.Location = new System.Drawing.Point(5, 26);
            this.txt_Keywords.Name = "txt_Keywords";
            this.txt_Keywords.Properties.NullValuePrompt = "Enter Keywords Here (Separate using Comma)";
            this.txt_Keywords.Size = new System.Drawing.Size(182, 20);
            this.txt_Keywords.TabIndex = 2;
            // 
            // cbl_Countries
            // 
            this.cbl_Countries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbl_Countries.Location = new System.Drawing.Point(5, 52);
            this.cbl_Countries.Name = "cbl_Countries";
            this.cbl_Countries.Size = new System.Drawing.Size(182, 102);
            this.cbl_Countries.TabIndex = 1;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.prog_UserQuery);
            this.groupControl4.Controls.Add(this.prog_Search);
            this.groupControl4.Controls.Add(this.lbl_User_Name);
            this.groupControl4.Controls.Add(this.lbl_User_Count);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.lbl_Search_Country);
            this.groupControl4.Controls.Add(this.lbl_Search_Keyword);
            this.groupControl4.Controls.Add(this.lbl_Search_Count);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl4.Location = new System.Drawing.Point(0, 342);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(192, 159);
            this.groupControl4.TabIndex = 9;
            this.groupControl4.Text = "Progress";
            // 
            // prog_UserQuery
            // 
            this.prog_UserQuery.Location = new System.Drawing.Point(76, 143);
            this.prog_UserQuery.Name = "prog_UserQuery";
            this.prog_UserQuery.Size = new System.Drawing.Size(111, 10);
            this.prog_UserQuery.TabIndex = 9;
            // 
            // prog_Search
            // 
            this.prog_Search.Location = new System.Drawing.Point(76, 83);
            this.prog_Search.Name = "prog_Search";
            this.prog_Search.ShowProgressInTaskBar = true;
            this.prog_Search.Size = new System.Drawing.Size(111, 10);
            this.prog_Search.TabIndex = 8;
            // 
            // lbl_User_Name
            // 
            this.lbl_User_Name.Location = new System.Drawing.Point(76, 124);
            this.lbl_User_Name.Name = "lbl_User_Name";
            this.lbl_User_Name.Size = new System.Drawing.Size(4, 13);
            this.lbl_User_Name.TabIndex = 7;
            this.lbl_User_Name.Text = "-";
            // 
            // lbl_User_Count
            // 
            this.lbl_User_Count.Location = new System.Drawing.Point(76, 105);
            this.lbl_User_Count.Name = "lbl_User_Count";
            this.lbl_User_Count.Size = new System.Drawing.Size(28, 13);
            this.lbl_User_Count.TabIndex = 6;
            this.lbl_User_Count.Text = "0 of 0";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "User Query :";
            // 
            // lbl_Search_Country
            // 
            this.lbl_Search_Country.Location = new System.Drawing.Point(76, 64);
            this.lbl_Search_Country.Name = "lbl_Search_Country";
            this.lbl_Search_Country.Size = new System.Drawing.Size(4, 13);
            this.lbl_Search_Country.TabIndex = 3;
            this.lbl_Search_Country.Text = "-";
            // 
            // lbl_Search_Keyword
            // 
            this.lbl_Search_Keyword.Location = new System.Drawing.Point(76, 45);
            this.lbl_Search_Keyword.Name = "lbl_Search_Keyword";
            this.lbl_Search_Keyword.Size = new System.Drawing.Size(4, 13);
            this.lbl_Search_Keyword.TabIndex = 2;
            this.lbl_Search_Keyword.Text = "-";
            // 
            // lbl_Search_Count
            // 
            this.lbl_Search_Count.Location = new System.Drawing.Point(76, 26);
            this.lbl_Search_Count.Name = "lbl_Search_Count";
            this.lbl_Search_Count.Size = new System.Drawing.Size(28, 13);
            this.lbl_Search_Count.TabIndex = 1;
            this.lbl_Search_Count.Text = "0 of 0";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Search Item :";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_Start);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 501);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(192, 50);
            this.panelControl1.TabIndex = 8;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(12, 14);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(164, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cb_Remember);
            this.groupControl2.Controls.Add(this.txt_Password);
            this.groupControl2.Controls.Add(this.txt_Username);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 78);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(192, 104);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Credentials";
            // 
            // cb_Remember
            // 
            this.cb_Remember.Location = new System.Drawing.Point(5, 78);
            this.cb_Remember.Name = "cb_Remember";
            this.cb_Remember.Properties.Caption = "Remember";
            this.cb_Remember.Size = new System.Drawing.Size(75, 20);
            this.cb_Remember.TabIndex = 7;
            this.cb_Remember.CheckedChanged += new System.EventHandler(this.cb_Remember_CheckedChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(5, 52);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.NullValuePrompt = "Password";
            this.txt_Password.Properties.UseSystemPasswordChar = true;
            this.txt_Password.Size = new System.Drawing.Size(182, 20);
            this.txt_Password.TabIndex = 6;
            this.txt_Password.EditValueChanged += new System.EventHandler(this.txt_Password_EditValueChanged);
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(5, 26);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Properties.NullValuePrompt = "Username";
            this.txt_Username.Size = new System.Drawing.Size(182, 20);
            this.txt_Username.TabIndex = 5;
            this.txt_Username.EditValueChanged += new System.EventHandler(this.txt_Username_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txt_Path_JSON);
            this.groupControl1.Controls.Add(this.txt_Path_Excel);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(192, 78);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Output";
            // 
            // txt_Path_JSON
            // 
            this.txt_Path_JSON.Location = new System.Drawing.Point(5, 26);
            this.txt_Path_JSON.Name = "txt_Path_JSON";
            this.txt_Path_JSON.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_Path_JSON.Properties.NullValuePrompt = "Select Output Path for JSON File";
            this.txt_Path_JSON.Properties.ReadOnly = true;
            this.txt_Path_JSON.Size = new System.Drawing.Size(182, 20);
            this.txt_Path_JSON.TabIndex = 4;
            // 
            // txt_Path_Excel
            // 
            this.txt_Path_Excel.Location = new System.Drawing.Point(5, 52);
            this.txt_Path_Excel.Name = "txt_Path_Excel";
            this.txt_Path_Excel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_Path_Excel.Properties.NullValuePrompt = "Select Output Path for Excel File";
            this.txt_Path_Excel.Properties.ReadOnly = true;
            this.txt_Path_Excel.Size = new System.Drawing.Size(182, 20);
            this.txt_Path_Excel.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 365);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(430, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.gc_Logs);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl5.Location = new System.Drawing.Point(0, 368);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(430, 183);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "Logs";
            // 
            // gc_Logs
            // 
            this.gc_Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Logs.Location = new System.Drawing.Point(2, 23);
            this.gc_Logs.MainView = this.gv_Logs;
            this.gc_Logs.Name = "gc_Logs";
            this.gc_Logs.Size = new System.Drawing.Size(426, 158);
            this.gc_Logs.TabIndex = 0;
            this.gc_Logs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Logs});
            // 
            // gv_Logs
            // 
            this.gv_Logs.GridControl = this.gc_Logs;
            this.gv_Logs.Name = "gv_Logs";
            this.gv_Logs.OptionsBehavior.Editable = false;
            this.gv_Logs.OptionsBehavior.ReadOnly = true;
            this.gv_Logs.OptionsView.ShowGroupPanel = false;
            // 
            // dlg_JSON
            // 
            this.dlg_JSON.Filter = "JSON Files (*.json) | *.json";
            // 
            // dlg_Excel
            // 
            this.dlg_Excel.Filter = "Excel Files (*.xlsx) | *.xlsx";
            // 
            // frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(632, 551);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_Main.IconOptions.Icon")));
            this.Name = "frm_Main";
            this.Text = "Devil7 - BNI Scrapper Tool";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Shown += new System.EventHandler(this.frm_Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Keywords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl_Countries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prog_UserQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prog_Search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cb_Remember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Path_JSON.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Path_Excel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Logs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Logs)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Start;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ButtonEdit txt_Path_Excel;
        private DevExpress.XtraEditors.CheckedListBoxControl cbl_Countries;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txt_Keywords;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit cb_Remember;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraEditors.TextEdit txt_Username;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ProgressBarControl prog_UserQuery;
        private DevExpress.XtraEditors.ProgressBarControl prog_Search;
        private DevExpress.XtraEditors.LabelControl lbl_User_Name;
        private DevExpress.XtraEditors.LabelControl lbl_User_Count;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbl_Search_Country;
        private DevExpress.XtraEditors.LabelControl lbl_Search_Keyword;
        private DevExpress.XtraEditors.LabelControl lbl_Search_Count;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txt_Path_JSON;
        private System.Windows.Forms.SaveFileDialog dlg_JSON;
        private System.Windows.Forms.SaveFileDialog dlg_Excel;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gc_Logs;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Logs;
    }
}

