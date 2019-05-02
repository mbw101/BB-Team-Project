using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    [Obsolete("Who made this? This is just unnessesary and overly complicated.", true)]
    public partial class PauseScreen : Form
    {
        private static PauseScreen pauseForm;
        private static DialogResult buttonResult = new DialogResult();

        public PauseScreen()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            pauseForm = new PauseScreen();

            pauseForm.ShowDialog();
            return buttonResult;
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "RESUME GAME":
                    buttonResult = DialogResult.Cancel;
                    break;
                case "EXIT GAME":
                    buttonResult = DialogResult.Abort;
                    break;
            }

            pauseForm.Close();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            pauseForm.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            pauseForm.Close();
        }

    }
}
