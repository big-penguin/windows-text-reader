using System;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Reader
{
	/// <summary>
	/// Description of Talker.
	/// </summary>
	public partial class Talker : Form
	{
		public Talker()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public bool isOn = false;
        
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void TalkerLoad(object sender, EventArgs e)
		{
            Timer timer1 = new Timer();
            Timer timer2 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
			isOn = true;
		}

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {

        }

        void timer2_Tick(object sender, EventArgs e) {
            label1.Text = ":O";
            if (isOn == false) this.Close();
        }
        void timer1_Tick(object sender, EventArgs e) {
            label1.Text = ":)";
        }
	}
}
