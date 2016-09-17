/*  Copyright (c) MediaArea.net SARL. All Rights Reserved.
 *
 *  Use of this source code is governed by a BSD-style license that can
 *  be found in the License.html file in the root of the source tree.
 */

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//
// Microsoft Visual C# example
//
// To make this example working, you must put MediaInfo.Dll and Example.ogg
// in the "./Bin/__ConfigurationName__" folder
// and add MediaInfoDll.cs to your project
//
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MediaInfoLib;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Taskbar;
using NuiEngine.NuiControl;

namespace MediaInfoLib_MSCS
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private GroupBox gbox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private LinkLabel llFile;
        private Label llSize;
        private TextBox textBox1;
        private TextBox tbCmd;
        private CheckBox cbInterlaced;
        private ComboBox cbPreset;
        private NumericUpDown crf;
        private CheckBox cbHD;
        private NumericUpDown fps;
        private CheckBox cbFPS;
        private CheckBox cb2x;
        private Button btnRun;
        private Button btnStop;
        private Button btnHelp;
        private SaveFileDialog outDlg;
        private NuiEngine.NuiControl.RarProgressBar rarPb;
        private CheckBox cbCopy;
        private static string FileName = "Example.ogg";

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Methode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'editeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbox = new System.Windows.Forms.GroupBox();
            this.cbCopy = new System.Windows.Forms.CheckBox();
            this.cbInterlaced = new System.Windows.Forms.CheckBox();
            this.tbCmd = new System.Windows.Forms.TextBox();
            this.llSize = new System.Windows.Forms.Label();
            this.cbPreset = new System.Windows.Forms.ComboBox();
            this.llFile = new System.Windows.Forms.LinkLabel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.fps = new System.Windows.Forms.NumericUpDown();
            this.cbFPS = new System.Windows.Forms.CheckBox();
            this.cb2x = new System.Windows.Forms.CheckBox();
            this.cbHD = new System.Windows.Forms.CheckBox();
            this.crf = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.outDlg = new System.Windows.Forms.SaveFileDialog();
            this.rarPb = new NuiEngine.NuiControl.RarProgressBar();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crf)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.cbCopy);
            this.gbox.Controls.Add(this.cbInterlaced);
            this.gbox.Controls.Add(this.tbCmd);
            this.gbox.Controls.Add(this.llSize);
            this.gbox.Controls.Add(this.cbPreset);
            this.gbox.Controls.Add(this.llFile);
            this.gbox.Controls.Add(this.btnHelp);
            this.gbox.Controls.Add(this.btnStop);
            this.gbox.Controls.Add(this.btnRun);
            this.gbox.Controls.Add(this.fps);
            this.gbox.Controls.Add(this.cbFPS);
            this.gbox.Controls.Add(this.cb2x);
            this.gbox.Controls.Add(this.cbHD);
            this.gbox.Controls.Add(this.crf);
            this.gbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox.Location = new System.Drawing.Point(10, 6);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(928, 102);
            this.gbox.TabIndex = 0;
            this.gbox.TabStop = false;
            this.gbox.Text = "<Version>";
            // 
            // cbCopy
            // 
            this.cbCopy.AutoSize = true;
            this.cbCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCopy.Location = new System.Drawing.Point(683, 37);
            this.cbCopy.Name = "cbCopy";
            this.cbCopy.Size = new System.Drawing.Size(57, 22);
            this.cbCopy.TabIndex = 13;
            this.cbCopy.Text = "copy";
            this.cbCopy.ThreeState = true;
            this.cbCopy.UseVisualStyleBackColor = true;
            this.cbCopy.CheckStateChanged += new System.EventHandler(this.cmd);
            // 
            // cbInterlaced
            // 
            this.cbInterlaced.AutoSize = true;
            this.cbInterlaced.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbInterlaced.Location = new System.Drawing.Point(207, 35);
            this.cbInterlaced.Name = "cbInterlaced";
            this.cbInterlaced.Size = new System.Drawing.Size(100, 22);
            this.cbInterlaced.TabIndex = 2;
            this.cbInterlaced.Text = "deinterlace";
            this.cbInterlaced.UseVisualStyleBackColor = true;
            this.cbInterlaced.CheckedChanged += new System.EventHandler(this.cmd);
            // 
            // tbCmd
            // 
            this.tbCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbCmd.Location = new System.Drawing.Point(3, 74);
            this.tbCmd.Name = "tbCmd";
            this.tbCmd.Size = new System.Drawing.Size(922, 25);
            this.tbCmd.TabIndex = 10;
            this.tbCmd.WordWrap = false;
            // 
            // llSize
            // 
            this.llSize.AutoSize = true;
            this.llSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.llSize.Location = new System.Drawing.Point(6, 36);
            this.llSize.Name = "llSize";
            this.llSize.Size = new System.Drawing.Size(78, 18);
            this.llSize.TabIndex = 1;
            this.llSize.Text = "<FileSize>";
            // 
            // cbPreset
            // 
            this.cbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPreset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPreset.FormattingEnabled = true;
            this.cbPreset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow",
            "placebo"});
            this.cbPreset.Location = new System.Drawing.Point(314, 36);
            this.cbPreset.Name = "cbPreset";
            this.cbPreset.Size = new System.Drawing.Size(87, 26);
            this.cbPreset.TabIndex = 3;
            this.cbPreset.SelectedIndexChanged += new System.EventHandler(this.cmd);
            // 
            // llFile
            // 
            this.llFile.AutoSize = true;
            this.llFile.Location = new System.Drawing.Point(6, 17);
            this.llFile.Name = "llFile";
            this.llFile.Size = new System.Drawing.Size(81, 18);
            this.llFile.TabIndex = 0;
            this.llFile.TabStop = true;
            this.llFile.Text = "<FilePath>";
            this.llFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFile_LinkClicked);
            // 
            // btnHelp
            // 
            this.btnHelp.Enabled = false;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Location = new System.Drawing.Point(864, 35);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(55, 27);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(803, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 27);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRun.Location = new System.Drawing.Point(742, 35);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(55, 27);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // fps
            // 
            this.fps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fps.DecimalPlaces = 2;
            this.fps.Increment = new decimal(new int[] {
            999,
            0,
            0,
            131072});
            this.fps.Location = new System.Drawing.Point(552, 37);
            this.fps.Maximum = new decimal(new int[] {
            11988,
            0,
            0,
            131072});
            this.fps.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            131072});
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(59, 25);
            this.fps.TabIndex = 7;
            this.fps.Value = new decimal(new int[] {
            2997,
            0,
            0,
            131072});
            this.fps.ValueChanged += new System.EventHandler(this.cmd);
            // 
            // cbFPS
            // 
            this.cbFPS.AutoSize = true;
            this.cbFPS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFPS.Location = new System.Drawing.Point(511, 37);
            this.cbFPS.Name = "cbFPS";
            this.cbFPS.Size = new System.Drawing.Size(45, 22);
            this.cbFPS.TabIndex = 6;
            this.cbFPS.Text = "fps";
            this.cbFPS.ThreeState = true;
            this.cbFPS.UseVisualStyleBackColor = true;
            this.cbFPS.CheckStateChanged += new System.EventHandler(this.cmd);
            // 
            // cb2x
            // 
            this.cb2x.AutoSize = true;
            this.cb2x.Checked = true;
            this.cb2x.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb2x.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb2x.Location = new System.Drawing.Point(464, 37);
            this.cb2x.Name = "cb2x";
            this.cb2x.Size = new System.Drawing.Size(40, 22);
            this.cb2x.TabIndex = 5;
            this.cb2x.Text = "2x";
            this.cb2x.UseVisualStyleBackColor = true;
            this.cb2x.CheckedChanged += new System.EventHandler(this.cmd);
            // 
            // cbHD
            // 
            this.cbHD.AutoSize = true;
            this.cbHD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbHD.Location = new System.Drawing.Point(617, 37);
            this.cbHD.Name = "cbHD";
            this.cbHD.Size = new System.Drawing.Size(67, 22);
            this.cbHD.TabIndex = 8;
            this.cbHD.Text = "hd720";
            this.cbHD.ThreeState = true;
            this.cbHD.UseVisualStyleBackColor = true;
            this.cbHD.VisibleChanged += new System.EventHandler(this.cmd);
            this.cbHD.CheckStateChanged += new System.EventHandler(this.cmdHD);
            // 
            // crf
            // 
            this.crf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crf.DecimalPlaces = 1;
            this.crf.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.crf.Location = new System.Drawing.Point(407, 37);
            this.crf.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.crf.Name = "crf";
            this.crf.Size = new System.Drawing.Size(51, 25);
            this.crf.TabIndex = 4;
            this.crf.Value = new decimal(new int[] {
            195,
            0,
            0,
            65536});
            this.crf.ValueChanged += new System.EventHandler(this.cmd);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(10, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(928, 60);
            this.textBox1.TabIndex = 1;
            // 
            // outDlg
            // 
            this.outDlg.DefaultExt = "mp4";
            this.outDlg.Filter = "mp4|*.mp4|mkv|*.mkv";
            // 
            // rarPb
            // 
            this.rarPb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rarPb.Location = new System.Drawing.Point(10, 146);
            this.rarPb.MarqueePercentage = 25;
            this.rarPb.MarqueeSpeed = 11;
            this.rarPb.MarqueeStep = 1;
            this.rarPb.MasterMaximum = 10;
            this.rarPb.MasterProgressPadding = 0;
            this.rarPb.MasterValue = 0;
            this.rarPb.Maximum = 10;
            this.rarPb.Minimum = 0;
            this.rarPb.Name = "rarPb";
            this.rarPb.PaintMasterFirst = false;
            this.rarPb.ProgressPadding = 0;
            this.rarPb.ProgressType = NuiEngine.NuiControl.ProgressType.Smooth;
            this.rarPb.ShowPercentage = true;
            this.rarPb.Size = new System.Drawing.Size(928, 22);
            this.rarPb.TabIndex = 2;
            this.rarPb.Value = 0;
            this.rarPb.Click += new System.EventHandler(this.rarPb_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(946, 176);
            this.Controls.Add(this.rarPb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbox);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 200);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10, 6, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How to use MediaInfo.Dll";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                FileName = args[0];
            }
            TaskbarList.Instance.HrInit();
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Test if version of DLL is compatible : 3rd argument is "version of DLL tested;Your application name;Your application version"
            String ToDisplay;
            MediaInfo MI = new MediaInfo();
            /*if (IntPtr.Size == 8)
            {
                MI = new MediaInfo64();
            }
            else
            {
                MI = new MediaInfo32();
            }*/

            ToDisplay = MI.Option("Info_Version", "0.7.0.0;MediaInfoDLL_Example_CS;0.7.0.0");
            if (ToDisplay.Length == 0)
            {
                textBox1.Text = "MediaInfo.Dll: this version of the DLL is not compatible";
                return;
            }
            gbox.Text = ToDisplay;

            //Information about MediaInfo
            ToDisplay += "\r\n\r\nInfo_Parameters\r\n";
            //ToDisplay += MI.Option("Info_Parameters");

            ToDisplay += "\r\n\r\nInfo_Capacities\r\n";
            ToDisplay += MI.Option("Info_Capacities");

            ToDisplay += "\r\n\r\nInfo_Codecs\r\n";
            //ToDisplay += MI.Option("Info_Codecs");

            //An example of how to use the library
            ToDisplay += "\r\n\r\nOpen\r\n";
            MI.Open(llFile.Text = FileName);

            ToDisplay += "\r\n\r\nInform with Complete=false\r\n";
            MI.Option("Complete");
            ToDisplay += MI.Inform();

            //ToDisplay += "\r\n\r\nInform with Complete=true\r\n";
            //MI.Option("Complete", "1");
            //ToDisplay += MI.Inform();

            ToDisplay += "\r\n\r\nCustom Inform\r\n";
            MI.Option("Inform", "General;File size is %FileSize% bytes");
            ToDisplay += MI.Inform();

            ToDisplay += "\r\n\r\nGet with Stream=General and Parameter='FileSize'\r\n";
            ToDisplay += (llSize.Text = MI.Get(0, 0, "FileSize"));

            ToDisplay += "\r\n\r\nGet with Stream=General and Parameter=46\r\n";
            ToDisplay += MI.Get(StreamKind.Video, 0, 46);
            for (int i = 0; i < 255; i++)
            {
                ToDisplay += "\r\n" + MI.Get(StreamKind.Video, 0, i) + "\t\t= " + MI.Get(StreamKind.Video, 0, i, InfoKind.Name);
            }

            int cAud;
            ToDisplay += "\r\n\r\nCount_Get with StreamKind=Stream_Audio\r\n";
            ToDisplay += cAud = MI.Count_Get(StreamKind.Audio);

            if (cAud < 1)
            {
                cbCopy.Checked = true;
            }

            ToDisplay += "\r\n\r\nGet with Stream=General and Parameter='AudioCount'\r\n";
            ToDisplay += MI.Get(StreamKind.General, 0, "AudioCount");

            ToDisplay += "\r\n\r\nGet with Stream=Audio and Parameter='StreamCount'\r\n";
            ToDisplay += MI.Get(StreamKind.Audio, 0, "StreamCount");

            llSize.Text = MI.Get(StreamKind.Video, 0, "Duration");
            long durL;
            if (long.TryParse(llSize.Text, out durL))
            {
                long sec = durL / 1000, min = sec / 60, hour = min / 60;
                llSize.Text = String.Format("{0}:{1}:{2}.{3}", hour, min % 60, sec % 60, durL % 1000);
            }

            int frames;
            if (int.TryParse(MI.Get(StreamKind.Video, 0, "FrameCount"), out frames))
            {
                rarPb.MasterMaximum = rarPb.Maximum = frames;
                llSize.Text += " @ " + frames;
            }
            else
            {
                rarPb.ProgressType = ProgressType.MarqueeWrap;
                rarPb.PaintMasterFirst = true;
            }

            string st = MI.Get(StreamKind.Video, 0, "ScanType");
            ToDisplay += "\r\n\r\n:";
            ToDisplay += st;

            char ip = 'p';
            if (st.Length > 0 && !st.StartsWith("p", StringComparison.OrdinalIgnoreCase))
            {
                ip = 'i';
                //cmd += "-deinterlace ";
                cbInterlaced.Checked = true;
            }

            cbPreset.SelectedIndex = 5;
            //cmd += "-i \"" + FileName + "\" -preset ";

            ToDisplay += ":\r\n\r\n";
            decimal fpsD = 0;
            if (decimal.TryParse(MI.Get(StreamKind.Video, 0, "FrameRate"), out fpsD))
            {
                fps.Value = fpsD / 2;
                if (fpsD > 30)
                {
                    cbFPS.Checked = true;
                }
            }
            else if (MI.Get(StreamKind.Video, 0, "FrameRate_Mode").Equals("VFR", StringComparison.OrdinalIgnoreCase))
            {
                cbFPS.CheckState = CheckState.Indeterminate;
            }
            
            short w = 0, h = 0;
            if (short.TryParse(MI.Get(StreamKind.Video, 0, "Width"), out w) &&
                short.TryParse(MI.Get(StreamKind.Video, 0, "Height"), out h))
            {
                double ww = match(w, 1280, 195, 1920, 215) / 10.0;
                double hh = match(h, 720, 200, 1080, 230) / 10.0;
                crf.Value = Math.Max((decimal)ww, (decimal)hh);
            }
            llSize.Text += String.Format("\r\n{0}x{1}{2} @ {3} fps, {4}", w, h, ip, fpsD, st);
            ToDisplay += llSize.Text;

            ToDisplay += "\r\n\r\nClose\r\n";
            MI.Close();

            //Example with a stream
            //ToDisplay+="\r\n"+ExampleWithStream()+"\r\n";

            //Displaying the text
            textBox1.Text = ToDisplay;
            cmd(null, null);
        }

        private int match(short k, short k1, short v1, short k2, short v2)
        {
            return v1 + (k - k1) * (v2 - v1) / (k2 - k1);
        }

        private string cmd()
        {
            string cmd = !cbCopy.Checked && cbInterlaced.Checked ? "-deinterlace " : "";
            cmd += "-i \"" + FileName + "\" ";
            switch (cbCopy.CheckState)
            {
                case CheckState.Checked:
                    cmd += "-vcodec copy ";
                    if (cb2x.Checked)
                    {
                        return cmd + "-acodec copy ";
                    }
                    else
                    {
                        return cmd + "-filter_complex \"[1:a]\" ";
                    }
                case CheckState.Indeterminate:
                    cmd += "-vcodec copy ";
                    if (cb2x.Checked)
                    {
                        return cmd + "-filter_complex \"[0:a]atempo=2.0\" ";
                    }
                    else
                    {
                        return cmd;
                    }
            }
            if (!cbPreset.Text.Equals("medium"))
            {
                cmd += "-preset " + cbPreset.Text + " ";
            }
            cmd += "-crf " + crf.Value.ToString() + " ";
            switch (cbHD.CheckState)
            {
                case CheckState.Checked:
                    cmd += "-s hd720 ";
                    break;
                case CheckState.Indeterminate:
                    cmd += "-s 960x544 ";
                    break;
            }
            if (fps.Enabled = (cbFPS.CheckState == CheckState.Checked))
            {
                cmd += "-r " + fps.Value.ToString() + " ";
            }
            else if (cbFPS.CheckState == CheckState.Indeterminate)
            {
                cmd += "-vsync vfr ";
            }
            if (cb2x.Checked)
            {
                return cmd + "-filter_complex \"[0:v]setpts=0.5*PTS;[0:a]atempo=2.0\" ";
            }
            else
            {
                return "-fix_sub_duration " + cmd + "-c:s mov_text ";
            }
            //return cmd;
        }

        private void cmd(object sender, EventArgs e)
        {
            tbCmd.Text = cmd();// +"\"" + FileName + "s" + crf.Value.ToString("F0") + ".mp4\"";
        }

        private void cmdHD(object sender, EventArgs e)
        {
            switch (cbHD.CheckState)
            {
                case CheckState.Checked:
                    if (crf.Value > (decimal)25)
                    {
                        crf.Value = (decimal)25;
                        return;
                    }
                    break;
                case CheckState.Indeterminate:
                    if (crf.Value > (decimal)23)
                    {
                        crf.Value = (decimal)23;
                        return;
                    }
                    break;
            }
            cmd(sender, e);
        }
        /// <summary>
        /// 委托..  利用这个操作主线程中的控件
        /// </summary>
        public delegate void OutputDataReceived(Object sender, DataReceivedEventArgs e);
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    OutputDataReceived o = new OutputDataReceived(p_OutputDataReceived);
                    Invoke(o, new Object[] { sender, e });//标记2
                }
                else
                {
                    // 可通过调用 CancelOutputRead 取消异步读取操作。可通过调用方或事件处理程序取消读取操作。取消之后，可以再次调用 BeginOutputReadLine 继续进行异步读取操作。 
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        string s = e.Data;
                        if (s.StartsWith("frame=") || s.StartsWith("video:"))// && s.EndsWith("%"))
                        {
                            tbCmd.Text = s;
                            if (s.StartsWith("video:"))
                            {
                                if (rarPb.ProgressType == ProgressType.MarqueeWrap)
                                {
                                    //rarPb.MasterValue = //rarPb.Value;
                                    //  rarPb.Value = rarPb.Maximum;
                                    rarPb.MarqueeStop();
                                }
                            }
                            else /*if (rarPb.ProgressType != ProgressType.MarqueeWrap)
                            {
                                int prog = rarPb.Value + 1;
                                if (prog > rarPb.Maximum)
                                {
                                    prog = 1;
                                }
                                TaskbarList.Instance.SetProgressValue(Handle, (ulong)(rarPb.Value = prog), (ulong)rarPb.Maximum);
                            }
                            else*/
                            {
                                int i = 6, j, k;
                                while (s[i] == ' ') i++;
                                j = i;
                                while (s[j] != ' ') j++;
                                if (int.TryParse(s.Substring(i, j - i), out k))
                                {
                                    if (rarPb.ProgressType == ProgressType.MarqueeWrap || rarPb.MasterMaximum < k)
                                    {
                                        rarPb.MasterMaximum = k;
                                    }
                                    rarPb.MasterValue = k;
                                    i = s.IndexOf("drop=") + 5;
                                    while (s[i] == ' ') i++;
                                    j = i;
                                    while (s[j] != ' ') j++;
                                    if (int.TryParse(s.Substring(i, j - i), out k))
                                    {
                                        k += rarPb.MasterValue;
                                        if (rarPb.ProgressType == ProgressType.MarqueeWrap)
                                        {
                                            rarPb.MasterMaximum = k;
                                        }
                                        else
                                        {
                                            if (rarPb.Maximum < k)
                                            {
                                                rarPb.Maximum = k;
                                            }
                                            rarPb.Value = k;
                                            TaskbarList.Instance.SetProgressValue(Handle, (ulong)rarPb.Value, (ulong)rarPb.Maximum);
                                        }
                                    }
                                    else
                                    {
                                        TaskbarList.Instance.SetProgressValue(Handle, (ulong)rarPb.MasterValue, (ulong)rarPb.MasterMaximum);
                                    }
                                }
                            }
                        }
                        else
                        {
                            textBox1.AppendText(s + "\r\n");
                        }
                        if (s.Trim().EndsWith("[y/N]", StringComparison.OrdinalIgnoreCase))
                        {
                            switch (MessageBox.Show(s, "Cancel to Kill", MessageBoxButtons.YesNoCancel))
                            {
                                case DialogResult.Yes:
                                    textBox1.AppendText("y\r\n");
                                    p.StandardInput.WriteLine("y");
                                    break;
                                case DialogResult.No:
                                    textBox1.AppendText("n\r\n");
                                    p.StandardInput.WriteLine("n");
                                    break;
                                default:
                                    if (!p.HasExited)
                                    {
                                        p.Kill();
                                    }
                                    p.Close();
                                    p = null;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.ToString() + "//线程异常");
            }
        }

        private Process p = null;

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (tbCmd.Text.StartsWith("video:"))
            {
                tbCmd.Text = cmd();
            }
            string outFn = FileName + "s" + crf.Value.ToString("F0") + ".mp4";
            if (FileName.StartsWith("V:\\BDMV"))
            {
                outFn = "D" + outFn.Substring(1);//.Replace("V:\\BDMV", "D:\\980");
                Directory.CreateDirectory(Path.GetDirectoryName(outFn));
            }
            else if (FileName.StartsWith("Y:\\"))
            {
                outFn = "D:\\980\\" + outFn.Substring(3);//.Replace("V:\\BDMV", "D:\\980");
                Directory.CreateDirectory(Path.GetDirectoryName(outFn));
            }
            Boolean existed = File.Exists(outFn);
            while (existed)
            {
                DialogResult dr = MessageBox.Show(outFn, "Override?", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    existed = true;
                    break;
                }
                outDlg.InitialDirectory = Path.GetDirectoryName(outFn);
                outDlg.FileName = Path.GetFileName(outFn);
                dr = outDlg.ShowDialog();
                outFn = outDlg.FileName;
                existed = File.Exists(outFn);
            }
            if (rarPb.ProgressType == ProgressType.MarqueeWrap)
            {
                rarPb.MarqueeStart();
            }
            else
            {
                rarPb.Value = rarPb.MasterValue = 0;
            }
            TaskbarList.Instance.SetProgressState(Handle, TaskbarProgressBarStatus.Indeterminate);

            llFile.Text = outFn;
            if (outFn.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase))
            {
                outFn = "-acodec aac \"" + outFn;
            }
            else
            {
                outFn = '"' + outFn;
            }
            ProcessStartInfo psi = new ProcessStartInfo("ffmpeg.exe", textBox1.Text = tbCmd.Text + outFn + '"');
            textBox1.AppendText("\r\n\r\n");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.CreateNoWindow = true;
            if (p != null)
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
                p.Close();
            }
            p = new Process();
            p.StartInfo = psi;
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.Exited += new EventHandler(reset);
            p.EnableRaisingEvents = true;
            p.Start();
            p.PriorityClass = ProcessPriorityClass.Idle;
            p.ProcessorAffinity = (IntPtr)0x7f;
            //p.StandardInput.Flush();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            if (existed)
            {
                p.StandardInput.WriteLine("y");
            }
            btnStop.Enabled = true;
            btnHelp.Enabled = true;
            btnRun.Enabled = false;
            if (rarPb.ProgressType != ProgressType.MarqueeWrap)
            {
                TaskbarList.Instance.SetProgressValue(Handle, 0, (ulong)rarPb.Maximum);
            }
            Rectangle rec = Screen.GetWorkingArea(this);
            Left = rec.Width - Width;
            Top = rec.Height - Height;
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            if (p != null)
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
                p.Close();
            }
        }

        public delegate void Exited(Object sender, EventArgs e);
        void reset(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Exited o = new Exited(reset);
                    Invoke(o, new Object[] { sender, e });//标记2
                }
                else
                {
                    btnStop.Enabled = false;
                    btnHelp.Enabled = false;
                    btnRun.Enabled = true;
                    TaskbarList.Instance.SetProgressState(Handle, TaskbarProgressBarStatus.NoProgress);
                }
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.ToString() + "//线程异常");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (p != null && !p.HasExited)
            {
                textBox1.AppendText("q\r\n");
                p.StandardInput.WriteLine("q");
                TaskbarList.Instance.SetProgressState(Handle, TaskbarProgressBarStatus.Paused);
                if (rarPb.ProgressType == ProgressType.MarqueeWrap)
                {
                    rarPb.MarqueePause();
                }
            }
            else
            {
                reset(sender, e);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (p != null && !p.HasExited)
            {
                textBox1.AppendText("?\r\n");
                p.StandardInput.WriteLine("?");
            }
            else
            {
                reset(sender, e);
            }
        }

        private void llFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(llFile.Text);
        }

        private void rarPb_Click(object sender, EventArgs e)
        {
            textBox1.Select(textBox1.TextLength, 0);
            textBox1.ScrollToCaret();
        }
    }
}
