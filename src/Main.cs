using System.Speech.Synthesis;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System;

namespace Text_Reader {
    /// <summary>
    /// Just a bunch of code.
    /// </summary>
    public class Main {
        SpeechSynthesizer speaker = new SpeechSynthesizer();
        string textToRead = "";
        public Point windowLocation = new Point();
        public bool Talker = false;

        System.ComponentModel.BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

        public int getRate() {
            return speaker.Rate;
        }

        public void setRate(int rate) {
            speaker.Rate = rate;
        }
        bool isOn = true;
        public void Speak(string text_To_Read) {
            SoundPlayer sounds = new SoundPlayer();



            if (text_To_Read.IndexOf("(ErrorSound)") != -1) {
                text_To_Read.Substring(text_To_Read.IndexOf("(ErrorSound)") + 12, text_To_Read.IndexOf("(ErrorSound)"));

                try {
                    SystemSounds.Beep.Play();
                }
                catch (System.IO.FileNotFoundException) { MessageBox.Show(":O  Oops. Excption has happened."); }
            }

            if (text_To_Read.IndexOf("(WarningSound)") != -1) {
                text_To_Read.Remove(text_To_Read.IndexOf("(WarningSound)"), 12);

                try {
                    SystemSounds.Exclamation.Play();
                }

                catch (System.IO.FileNotFoundException) { MessageBox.Show(":O  Oops. Excption has happened."); }
            }

            if (text_To_Read.IndexOf("(InfoSound)") != -1) {
                text_To_Read.Remove(text_To_Read.IndexOf("(InfoSound)"), 12);

                try {
                    SystemSounds.Asterisk.Play();
                }

                catch (System.IO.FileNotFoundException) { MessageBox.Show(":O  OopsExcption has happened."); }
            }


            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);

            backgroundWorker1.RunWorkerAsync();
            textToRead = text_To_Read.ToLower().Replace("lol", "lull").Replace("xd", "Ha Ha").Replace(":)", "smiley face").Replace("wii", "we")
                .Replace("microshaft", "The best company in the world").Replace("bsod", "a fatal execption 0e has occurred at 0028, c0011e36 in" +
                "uxd vmm, 01, 00010e36. the current application will be terminated. Press any key to terminate the current application. " +
                "press control alt delete to restart your computer. you will lose any unsaved data in all applications.");
            speaker.Speak(textToRead);
        }

        void BackgroundWorker1DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
        }

        public void SpeakToFile(string text_To_Read) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Wave Sound|*.wav";

            DialogResult saveResult = saveFileDialog1.ShowDialog();

            if (saveResult == DialogResult.OK) {
                speaker.SetOutputToWaveFile(saveFileDialog1.FileName);
                speaker.Speak(text_To_Read);
                speaker.SetOutputToDefaultAudioDevice();
            }
        }
    }
}
