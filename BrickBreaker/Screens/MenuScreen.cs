using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public void scoreOutput()
        {
            highScoreLabel.Text = "High Scores\n";
            //testing: displaying the scores
            foreach (HighScore s in Form1.highScores)
            {

                highScoreLabel.Text += s.score + " " + "\n";

                //highScoreLabel.Text = s.score[0] + " " + "\n" + s.score[1] + " " + "\n" + s.score[2]
                //    + " " + "\n" + s.score[3] + " " + "\n" + s.score[4] + " " + "\n";
            }
        }
        //testing
        public void loadScoresRK()
        {
            //creating Xml reader file 
            XmlReader reader = XmlReader.Create("Resources/HighScores.xml", null);
            string newScoreString;

            //basically highScore1String is going to be highScore #1...and on...etc
            //plan: "highScores" should only contain 5 high "scores"

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    newScoreString = reader.ReadString();

                    HighScore newScore = new HighScore(newScoreString);
                    Form1.highScores.Add(newScore);

                }
            }

            reader.Close();
        }
        private static int index = 0;
        private List<Button> buttons = new List<Button>();
        public MenuScreen()
        {

            InitializeComponent();                   

        }

        /// <summary>
        /// Only for buttons made by Thayen
        /// </summary>
        private void gainFocus(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Red;
        }

        /// <summary>
        /// Only for buttons made by Thayen
        /// </summary>
        private void lostFocus(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Black;
        }

        /// <summary>
        /// The event code for when the exist button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The event code for when the play button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            var form = FindForm() as Form1;
            form.ChangeScreen(this, new GameScreen());
        }

        
       
        /// <summary>
        /// The event code for when the Menu Screen finishes initializing loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuScreen_Load(object sender, EventArgs e)
        {
            var buttonGap = 50;
            var maxSpace = buttons[0].Height * buttons.Count() + (buttonGap * (buttons.Count() - 1));
            //For every button in the screen set the location to the middle X of the screen and the Height divided by the number of buttons
            for (int i = 0; i < buttons.Count; i++)
            {
                var space = maxSpace / (1 + i);
                buttons[i].Location = new Point((Width / 2) - (buttons[i].Width / 2), space);
            }
        }

        /// <summary>
        /// The event code for when the Main Menu detects a key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _newButton(-1).Focus();
                    break;
                case Keys.Down:
                    _newButton(1).Focus();
                    break;
            }
        }

        /// <summary>
        /// Gets the newly selected button based on where the last one was. Pass a negative to go back in the list of buttons
        /// </summary>
        /// <param name="changeInIndex"></param>
        /// <returns></returns>
        private Button _newButton(int changeInIndex)
        {
            //Thayen
            index += changeInIndex;
            //If the button is out of range set the button within range
            if (index < 0)
                index = 0;
            else if (index >= buttons.Count)
                index = buttons.Count - 1;
            return buttons[index];

        }
    }
}
