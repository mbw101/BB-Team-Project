using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class WinScreen : UserControl
    {
        Ball b;

        List<Ball> followers = new List<Ball>();
        List<Ball> others = new List<Ball>();
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush2 = new SolidBrush(Color.Red);
        int b1speed = 30;
        int b1size = 100;
        
        int followercounter;
        int otherscounter;
        int n = 0;

        //random generator 
        Random randGen = new Random();

        public WinScreen()
        {
            InitializeComponent();
            winnerTimer.Enabled = true;
            winnerLabel.Visible = false;

            //initial position 
            b = new Ball(this.Width/2 - b1size/2, this.Height - b1size, b1speed, b1speed, b1size);
            


        }

        private void winnerTimer_Tick(object sender, EventArgs e)
        {
            //moving the "winner" up 
            b.WinMove();
            //making followers
            if (b.y > this.Height / 4 - b1size / 2)
            {
                followercounter++;
            }

            if (followercounter == 3)
            {
                FollowerMaker();
            }
            
            if (b.y < 0)
            {
                otherscounter++;
                followers.Clear();
                winnerLabel.Visible = true;
                winnerLabel.Text = "You are the winner!";
            }

            if (otherscounter == 1)
            {
                OthersMaker();
            }

            Refresh();

        }

        private void FollowerMaker()
        {
            followercounter = 0;
            int followerx = randGen.Next(b.x, b.x + b.size);
            int followery = randGen.Next(b.y, b.y + b.size);
            int followerspeed = randGen.Next(40, 51); //in this case, xspeed or yspeed does not matter because I am going to set them as the same
            int followersize = randGen.Next(1, b.size/2 + 1);

            Ball follower = new Ball(followerx, followery, followerspeed, followerspeed, followersize);
            followers.Add(follower);

            foreach (Ball f in followers)
            {
                f.GameOverMove();
            }

            
        }

        private void OthersMaker()
        {
            otherscounter = 0;
            int othersx = randGen.Next(0, this.Width);
            int othersy = randGen.Next(b.y, b.y + b.size);
            int otherspeed = randGen.Next(40, 51); //in this case, xspeed or yspeed does not matter because I am going to set them as the same
            int othersize = randGen.Next(1, b.size / 2 + 1);

            Ball other = new Ball(othersx, othersy, otherspeed, otherspeed, othersize);
            others.Add(other);

            foreach (Ball o in others)
            {
                o.GameOverMove();
            }


        }

        private void WinScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(ballBrush, b.x, b.y, b.size, b.size);

            foreach (Ball f in followers)
            {
                e.Graphics.FillRectangle(ballBrush, f.x, f.y, f.size, f.size);
            }

            foreach (Ball o in others)
            {
                e.Graphics.FillRectangle(ballBrush2, o.x, o.y, o.size, o.size);
            }

        }
    }
}
