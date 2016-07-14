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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;
using MediaInfoLib;

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
        private const string FileName = "Example.ogg";

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
            this.gbox = new System.Windows.Forms.GroupBox();
            this.llSize = new System.Windows.Forms.Label();
            this.llFile = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.llSize);
            this.gbox.Controls.Add(this.llFile);
            this.gbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox.Location = new System.Drawing.Point(10, 6);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(752, 100);
            this.gbox.TabIndex = 1;
            this.gbox.TabStop = false;
            this.gbox.Text = "<Version>";
            // 
            // llSize
            // 
            this.llSize.AutoSize = true;
            this.llSize.Location = new System.Drawing.Point(12, 47);
            this.llSize.Name = "llSize";
            this.llSize.Size = new System.Drawing.Size(65, 12);
            this.llSize.TabIndex = 1;
            this.llSize.Text = "<FileSize>";
            // 
            // llFile
            // 
            this.llFile.AutoSize = true;
            this.llFile.Location = new System.Drawing.Point(12, 26);
            this.llFile.Name = "llFile";
            this.llFile.Size = new System.Drawing.Size(65, 12);
            this.llFile.TabIndex = 0;
            this.llFile.TabStop = true;
            this.llFile.Text = "<FilePath>";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(10, 106);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(752, 400);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(770, 514);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10, 6, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How to use MediaInfo.Dll";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Test if version of DLL is compatible : 3rd argument is "version of DLL tested;Your application name;Your application version"
            String ToDisplay;
            MediaInfo MI = new MediaInfo();

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
            ToDisplay += MI.Get(0, 0, 46);

            ToDisplay += "\r\n\r\nCount_Get with StreamKind=Stream_Audio\r\n";
            ToDisplay += MI.Count_Get(StreamKind.Audio);

            ToDisplay += "\r\n\r\nGet with Stream=General and Parameter='AudioCount'\r\n";
            ToDisplay += MI.Get(StreamKind.General, 0, "AudioCount");

            ToDisplay += "\r\n\r\nGet with Stream=Audio and Parameter='StreamCount'\r\n";
            ToDisplay += MI.Get(StreamKind.Audio, 0, "StreamCount");

            long dur = long.Parse(MI.Get(StreamKind.Video, 0, "Duration"));
            long sec = dur / 1000, min = sec / 60, hour = min / 60;
            llSize.Text = String.Format("{0}:{1}:{2}.{3}", hour, min % 60, sec % 60, dur % 1000);

            string st = MI.Get(StreamKind.Video, 0, "ScanType");
            ToDisplay += "\r\n\r\n";
            ToDisplay += st;
            char ip = st.StartsWith("p", StringComparison.OrdinalIgnoreCase) ? 'p' : 'i';

            ToDisplay += "\r\n\r\n";
            llSize.Text += String.Format("\r\n{0}x{1}{2} @ {3} fps, {4}", MI.Get(StreamKind.Video, 0, "Width"),
                MI.Get(StreamKind.Video, 0, "Height"), ip, MI.Get(StreamKind.Video, 0, "FrameRate"), st);
            ToDisplay += llSize.Text;

            ToDisplay += "\r\n\r\nClose\r\n";
            MI.Close();

            //Example with a stream
            //ToDisplay+="\r\n"+ExampleWithStream()+"\r\n";

            //Displaying the text
            textBox1.Text = ToDisplay;
        }

        String ExampleWithStream()
        {
            //Initilaizing MediaInfo
            MediaInfo MI = new MediaInfo();

            //From: preparing an example file for reading
            FileStream From = new FileStream("Example.ogg", FileMode.Open, FileAccess.Read);

            //From: preparing a memory buffer for reading
            byte[] From_Buffer = new byte[64 * 1024];
            int From_Buffer_Size; //The size of the read file buffer

            //Preparing to fill MediaInfo with a buffer
            MI.Open_Buffer_Init(From.Length, 0);

            //The parsing loop
            do
            {
                //Reading data somewhere, do what you want for this.
                From_Buffer_Size = From.Read(From_Buffer, 0, 64 * 1024);

                //Sending the buffer to MediaInfo
                System.Runtime.InteropServices.GCHandle GC = System.Runtime.InteropServices.GCHandle.Alloc(From_Buffer, System.Runtime.InteropServices.GCHandleType.Pinned);
                IntPtr From_Buffer_IntPtr = GC.AddrOfPinnedObject();
                Status Result = (Status)MI.Open_Buffer_Continue(From_Buffer_IntPtr, (IntPtr)From_Buffer_Size);
                GC.Free();
                if ((Result & Status.Finalized) == Status.Finalized)
                    break;

                //Testing if MediaInfo request to go elsewhere
                if (MI.Open_Buffer_Continue_GoTo_Get() != -1)
                {
                    Int64 Position = From.Seek(MI.Open_Buffer_Continue_GoTo_Get(), SeekOrigin.Begin); //Position the file
                    MI.Open_Buffer_Init(From.Length, Position); //Informing MediaInfo we have seek
                }
            }
            while (From_Buffer_Size > 0);

            //Finalizing
            MI.Open_Buffer_Finalize(); //This is the end of the stream, MediaInfo must finnish some work

            //Get() example
            return "Container format is " + MI.Get(StreamKind.General, 0, "Format");
        }
    }
}
