using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Media;

namespace BrickBreaker
{
    
    public partial class Form1 : Form
    {
        //TESTING List
        //items in the "highScore" are "scores" but in string form, 
        //the items from the "highScore" can be converted back for comparison
        //XML file will only save the high scores
        
        public static List<HighScore> highScores = new List<HighScore>();
        /// <summary>
        /// The Game's Soundplayer.
        /// Note that remember that playSoundFrom and preloadSound will save lines of code when used
        /// </summary>
        public static SoundPlayer SoundPlayer = new SoundPlayer();
        public static GameScreen currentGame;
        public Form1()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(Program.FilePath);//Set the program to put files in the created directory
        }

        /// <summary>
        /// Gets a .wav file from the file path and plays it
        /// </summary>
        /// <param name="filePath"></param>
        public static void playSoundFrom(string filePath)
        {
            if (File.Exists(filePath))
            {
                SoundPlayer.SoundLocation = filePath;
                SoundPlayer.PlaySync();
            }
            else
                throw new Exception("Could not find the required file");
        }

        /// <summary>
        /// Gets the .wav file from specified location and loads it into the soundplayer
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool preloadSound(string filePath)
        {
            if(File.Exists(filePath))
            {
                SoundPlayer.SoundLocation = filePath;
                SoundPlayer.Load();
                return true;
            }
            return false;
        }

        public void ChangeScreen(UserControl remove, UserControl add)

        {
            Controls.Add(add);
            Controls.Remove(remove);
            remove.Dispose();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Plans for next step...determine if the score should be saved to the list (5 scores should be in high scores)
            //Set variables to each of the score like highScores[0]...highScores[4]...as these will be displayed 
            //if the list contains the same score, then do not add it again to the list
            //if (highScores.Contains(the same score))
            //{
            //  Do not display, just proceed
            //}
            //if the list does not contain the same score, check if the score is more or less than the scores in highScores
            //{
            //  if the score is more, then display
            //  if the score is less, then do not display
            //}
            StartScreen ss = new StartScreen();
            this.Controls.Add(ss);

            ss.Location = new Point((this.Width - ss.Width) / 2, (this.Height - ss.Height) / 2);

        }
    }
}
