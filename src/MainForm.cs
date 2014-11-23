using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Reader {
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form {
        bool shift = false;
        Timer moveTimer = new Timer(); //Timer used to move the form using the TitleBar.
        Timer sizeTimer = new Timer(); //Timer used to size the form using the ResizeBar.
        Point onClickMousePos = new Point(); //Location of mouse when first clicked.
        Point onClickWindowPos = new Point(); //Location of window when first clicked.
        Point hotCorner = new Point(10, 10); //Set the bounds of the hot corner.
        Size minSize = new Size(350, 350); //The minimum size of the form.

        public MainForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        Main reads = new Main();
        //        Point windowLocation = new Point();

        void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        void QuitToolStripMenuItemClick(object sender, EventArgs e) {
            this.Close();
        }

        void AboutToolStripMenuItemClick(object sender, EventArgs e) {
            AboutForm j = new AboutForm();
            j.ShowDialog();
        }

        void ErrorToolStripMenuItemClick(object sender, EventArgs e) {
            richTextBox1.Text += "(ErrorSound) ";
        }

        void EsclamitionToolStripMenuItemClick(object sender, EventArgs e) {
            richTextBox1.Text += "(WarningSound) ";
        }

        void InformationToolStripMenuItemClick(object sender, EventArgs e) {
            richTextBox1.Text += "(InfoSound) ";
        }

        void ReadAllToolStripMenuItemClick(object sender, EventArgs e) {
            //    if (showTalkerToolStripMenuItem.Checked == true) {
            //        reads.Talker = true;
            //    }
            //    else reads.Talker = false;
            reads.Speak(richTextBox1.Text);
        }

        void EditToolStripMenuItemClick(object sender, EventArgs e) {

        }

        void ShowTalkerToolStripMenuItemClick(object sender, EventArgs e) {

        }

        private void MainForm_Load(object sender, EventArgs e) {
            //        this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            reads.setRate(1);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //        Application.Exit();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            //        timer1.Enabled = true;
        }

        private void readToFileToolStripMenuItem_Click(object sender, EventArgs e) {
            reads.SpeakToFile(richTextBox1.Text);
        }

        void ToolStripComboBox1Click(object sender, EventArgs e) {

        }

        void ToolStripComboBox1DropDownClosed(object sender, EventArgs e) {
            reads.setRate(int.Parse(toolStripComboBox1.SelectedItem.ToString()));
        }

        private void readSelectionToolStripMenuItem_Click(object sender, EventArgs e) {
            reads.Speak(richTextBox1.SelectedText);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Restart();
        }
        bool vkb = false;
        private void virtualKeyboardToolStripMenuItem_Click(object sender, EventArgs e) {
 
        }

        #region Link virtual keyboard keys
        private void label1_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("Q");
            else SendKeys.Send("q");
        }

        private void label2_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("W");
            else SendKeys.Send("w");
        }

        private void label3_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("E");
            else SendKeys.Send("e");
        }

        private void label4_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("R");
            else SendKeys.Send("r");
        }

        private void label5_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("T");
            else SendKeys.Send("t");
        }

        private void label6_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("Y");
            else SendKeys.Send("y");
        }

        private void label7_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("U");
            else SendKeys.Send("u");
        }

        private void label8_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("I");
            else SendKeys.Send("i");
        }

        private void label9_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("O");
            else SendKeys.Send("o");
        }

        private void label10_Click(object sender, EventArgs e) {
            richTextBox1.Focus();
            if (shift) SendKeys.Send("P");
            else SendKeys.Send("p");
        } 
        #endregion

        void t_Tick(object sender, EventArgs e) {
            //Make the window follow the mouse. 
            Location = new Point(MousePosition.X - onClickMousePos.X + onClickWindowPos.X,
                                 MousePosition.Y - onClickMousePos.Y + onClickWindowPos.Y);
            
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e) {
            moveTimer.Enabled = false; //Stop moving the window when the mouse button is released.
            if (Location.X < hotCorner.X && Location.Y < hotCorner.Y) //Form is in the hot corner.
                WindowState = FormWindowState.Maximized; //Maximize the window when it's moved to the hot corner.
        }        

        private void panel2_MouseDown(object sender, MouseEventArgs e) {
            onClickMousePos = new Point(MousePosition.X, MousePosition.Y); //Record the current MousePosition.
            onClickWindowPos = Location; //Record the current Location.
            moveTimer.Tick += new EventHandler(t_Tick); //Set an EventHandler for moveTimer.
            moveTimer.Interval = 1; //Set the interval as low as we can.
            moveTimer.Enabled = true; //Start the moveTimer, the mouse is down.
        }
        

        void sizeTimer_Tick(object sender, EventArgs e) {
            this.Size = new Size(MousePosition.X - Location.X, MousePosition.Y - Location.Y); //Make the form resize to where the mouse is.
        }

        private void label1_Click_1(object sender, EventArgs e) {

        }

        private void label2_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }

        private void panel2_DoubleClick(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            }
            else WindowState = FormWindowState.Maximized;
        }

        private void formFadeInTimer_Tick(object sender, EventArgs e) {
            if (Size.Width > 757) {
                this.Size = new Size(Size.Width - 4, Size.Height - 4);
                this.Location = new Point(Location.X + 2, Location.Y + 2);
                this.Opacity += 0.04;
            }

            else {
                this.Opacity = 1;
                formFadeInTimer.Enabled = false;
                toolStripContainer1.ContentPanel.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void ResizeBar_MouseDown(object sender, MouseEventArgs e) {
            sizeTimer.Tick += new EventHandler(sizeTimer_Tick); //Set an EventHandler for sizeTimer.
            sizeTimer.Interval = 1; //Set the interval as low as we can.
            sizeTimer.Enabled = true; //Start the sizeTimer, the mouse is down.
        }

        private void ResizeBar_MouseUp(object sender, MouseEventArgs e) {
            sizeTimer.Enabled = false; //Stop sizing the windows when the mouse button is released.
            if (Size.Width < minSize.Width || Size.Height < minSize.Height) //The form is smaller than minSize.
                Size = minSize; //Restrict the form size.
        }

        private void MainForm_Deactivate(object sender, EventArgs e) {
            toolStripContainer1.ContentPanel.BorderStyle = BorderStyle.None;
            Size = new Size(Size.Width - 1, Size.Height - 1);
        }

        private void MainForm_Activated(object sender, EventArgs e) {
            toolStripContainer1.ContentPanel.BorderStyle = BorderStyle.FixedSingle;
            Size = new Size(Size.Width + 1, Size.Height + 1);

        }
    }
}
