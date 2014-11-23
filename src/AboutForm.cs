using System;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Reader
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}
		
		Main mainClass = new Main();
		
		void Label7Click(object sender, EventArgs e)
		{
			mainClass.Speak("Cool");
		}
		
		void Label2Click(object sender, EventArgs e)
		{
            mainClass.Speak("Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,Text Reader,");
		}
		
		void AboutFormClick(object sender, EventArgs e)
		{
			this.Close();
		}

        private void label13_Click(object sender, EventArgs e) {
            Close();
        }
	}
}
