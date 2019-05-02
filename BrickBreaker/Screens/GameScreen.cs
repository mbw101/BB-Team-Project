using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, ADown, DDown;

        // TODO: Work on block collision

        // Paddle and Ball objects
        public static Paddle paddle;
        public static List<Ball> ballList = new List<Ball>();
        public static List<Ball> removeBalls = new List<Ball>();
        public static int paddleWidth = 80;
        public static int paddleHeight = 20;
        int paddleX;
        int paddleY;

        // random for powerups
        Random random = new Random();

        // list of all currentlevel for current level
        List<Block> currentlevel = new List<Block>();



        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        Pen linePen = new Pen(Color.White);
        Pen testPen = new Pen(Color.Red);

        //Testing: Declaring variables;
        // Lives
        public int player1Lives = 5;
        public int? player2Lives = null;
        public static int score = 0;
        #endregion

        // start for game loop
        public static bool start = false;

        // Creates a new ball
        int xSpeed = 12;
        int ySpeed = 12;
        int ballSize = 20;

        // angle change buttons
        int angleposition = 3;

        public static bool start = false;

        // angle points for the line aim
        Point p1, p2;


        // font and brush for text
        Font textFont;
        SolidBrush sb = new SolidBrush(Color.White);

        // level variables
        List<XmlReader> levelList = new List<XmlReader>();
        int currentlevelnum = 4;
        bool levelLoadstart = true;
        
        public GameScreen(bool multiplayer = false)
        {
            InitializeComponent();
            OnStart();
            if (multiplayer)
                player2Lives = 3;
        }

        public void levelLoad()
        {
            if (levelLoadstart)
            {
                // need ten total items, think of list as actual level number -1
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/testlevel.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level1.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level2.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level3.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level4.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level5.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level6.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level7.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level8.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level9.xml"));
                levelList.Add(XmlReader.Create("https://raw.githubusercontent.com/DimaPokusaev/BB-Team-Project/master/level10.xml"));
            }

            XmlReader reader = levelList[1];
            switch (currentlevelnum)
            {
                case 0:
                    reader = levelList[0];
                    break;
                case 1:
                    reader = levelList[1];
                    break;
                case 2:
                    reader = levelList[2];
                    break;
                case 3:
                    reader = levelList[3];
                    break;
                case 4:
                    reader = levelList[4];
                    break;
                case 5:
                    reader = levelList[5];
                    break;
                case 6:
                    reader = levelList[6];
                    break;
                case 7:
                    reader = levelList[7];
                    break;
                case 8:
                    reader = levelList[8];
                    break;
                case 9:
                    reader = levelList[9];
                    break;
            }

            currentlevel.Clear();
            while (reader.Read())
            {
                string X, Y, HP;
                reader.ReadToFollowing("brick");
                X = reader.GetAttribute("x");
                Y = reader.GetAttribute("y");
                HP = reader.GetAttribute("hp");

                currentlevel.Add(new Block(X, Y, HP));
            }
            currentlevel.RemoveAt(currentlevel.Count - 1);
            reader.Close();
        }

        public void OnStart()
        {
            levelLoad();

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // reset score
            score = 0;

            // create text graphics
            textFont = new Font("Verdana", 20, FontStyle.Regular);

            // setup starting paddle values and create paddle object
            paddleX = ((this.Width / 2) - (paddleWidth / 2));
            paddleY = (this.Height - paddleHeight);
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = ((paddle.x - ballSize) + (paddle.width / 2));
            int ballY =  paddle.y - 21;
            ballList.Clear();
            ballList.Add(new Ball(ballX, ballY, xSpeed, ySpeed, ballSize, 1, -1));
            
            // start the game engine loop
            gameTimer.Enabled = true;

           
            
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    start = true;
                    break;
                case Keys.Escape:
                    break;
                default:
                    break;
            }

            if (!start)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        // move left
                        if (angleposition >= 1 && angleposition < 6)
                        {
                            angleposition++;
                        }
                        break;
                    case Keys.D:
                        // move right
                        if (angleposition <= 6 && angleposition > 1)
                        {
                            angleposition--;
                        }
                        break;
                }
            }
        }

        private void anglechange()
        {
            switch (angleposition)
            {
                // right
                case 1:
                    ballList[0].Xangle = 1;
                    ballList[0].Yangle = -0.5;                         
                    break;
                case 2:
                    ballList[0].Xangle = 0.5;
                    ballList[0].Yangle = -1;
                    break;
                case 3:
                    ballList[0].Xangle = -1;
                    ballList[0].Yangle = -0.5;
                    break;
                case 4:

                    ballList[0].Xangle = -0.5;
                    ballList[0].Yangle = -1;
                    break;
                case 5:
                    ballList[0].Xangle = 1;
                    ballList[0].Yangle = -1;
                    break;
                case 6:                   
                    ballList[0].Xangle = -1;
                    ballList[0].Yangle = -0.5;
                    break;
                    // left
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        //Nit: Can you make the ball fall a little farther before resetting the ball, something doesn't feel right when it falls
        //Nit: Can you make the ball go in whatever the player last moved
        //Note Form1 has a soundplayer, you can access it with Form1.SoundPlayer
        private void gameTimer_Tick(object sender, EventArgs e)
        {
         //   angleLable.Text = angleposition.ToString();
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }
           
            if (start)
            {
                // Move ball
                foreach (Ball b in ballList)
                {
                    anglechange();

                    // Move ball
                    b.Move();

                    // Check for collision with top and side walls
                    b.WallCollision(this);

                    // Check for ball hitting bottom of screen and if there is only one ball
                    if (b.BottomCollision(this, paddle) && ballList.Count == 1)
                    {
                        // decrease player 1 lives
                        player1Lives--;

                        // move the ball and paddle back
                        start = false;

                        // reset ball angle
                        angleposition = 3;

                        // reset paddle x and y
                        paddle.x = paddleX;
                        paddle.y = paddleY;

                        ballList[0].x = ((paddle.x - ballSize) + (paddle.width / 2));
                        ballList[0].y = paddle.y - 40;
                        ballList[0].Yangle *= -1;

                        // reset x and y speeds
                        ballList[0].xSpeed = xSpeed;
                        ballList[0].ySpeed = ySpeed;

                        if (player1Lives <= 1)
                        {
                            start = false;                            
                            if (player2Lives < 0)
                            {
                                gameTimer.Enabled = false;
                                OnEnd();
                            }
                            // TODO: Why is this here?
                            gameTimer.Enabled = false;
                            OnEnd();
                        }
                    }
                    else if (b.BottomCollision(this, paddle))
                    {
                        // add the ball to the remove list
                        removeBalls.Add(b);
                    }

                    // Check for collision of ball with paddle, (incl. paddle movement)
                    b.PaddleCollision(paddle, leftArrowDown, rightArrowDown);
                }
                // remove any balls that need to be removed
                foreach (Ball b in removeBalls)
                {
                    gameTimer.Enabled = false;
                    //testing
                    scores();
                }
            }

            //Testing Purposes: Score Tracker...1st Tracker...Adding the number to scores
            foreach (Block b in currentlevel)
            {
                if (ballSize[0].ScoreTracker(b))
                {
                    score++;
                }
            }
            

            // Check for collision of ball with paddle, (incl. paddle movement)
            balls[0].PaddleCollision(paddle, leftArrowDown, rightArrowDown);


            // Check if ball has collided with any currentlevel
            foreach (Block b in currentlevel)
            {
                if (ball.BlockCollision(b))
                    ballList.Remove(b);
                }
                // Check if ball has collided with any currentlevel
                {
                    for (int i = 0; i < currentlevel.Count(); i++)
                    {
                        //changed
                        gameTimer.Enabled = false;
                        scores();
                        Block b = currentlevel[i];
                        // TODO: Check if the ball hits the top, bottom, left, or right
                        if (ba.BlockCollision(b))
                        {
                            b.hp--;
                            if(b.hp < 1)
                                currentlevel.Remove(b);
                                
                            score += 100;

                            // powerups random
                            if (random.Next(1, 11) <= 2)
                            {
                                // 20 % chance
                                // TODO: powerups
                            }

                            if (currentlevel.Count < 1)
                            {
                                if(currentlevelnum == levelList.Count())
                                {
                                    OnEnd();
                                }
                                else
                                {
                                    currentlevelnum++;
                                    levelLoad();
                                    start = false;
                                    ballList[0].x = paddle.x + (paddle.width / 2) - (ballList[0].size / 2);
                                    ballList[0].y = paddle.y - 21;
                                }
                            }
                            break;
                        }
                    }
                }
                        else
            {
                // center the ball over the paddle
                ballList[0].x = paddle.x + (paddle.width / 2) - (ballList[0].size / 2);
                ballList[0].y = paddle.y - 21;

                // draw line to show ball aim
                p1 = new Point(Convert.ToInt16(ballList[0].x + (ballList[0].size / 2)), Convert.ToInt16(ballList[0].y));

                // TODO: Fix problem with angle shooting while moving
                switch (angleposition)
                {
                    // right
                    case 1:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) + 200, Convert.ToInt16(ballList[0].y) - 120);
                        break;

                    case 2:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) + 75, Convert.ToInt16(ballList[0].y) - 120);
                        break;

                    case 3:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) + 50, Convert.ToInt16(ballList[0].y) - 120);
                        break;

                    case 4:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) - 15, Convert.ToInt16(ballList[0].y) - 120);
                        break;

                    case 5:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) - 25, Convert.ToInt16(ballList[0].y) - 120);
                        break;

                    case 6:
                        p2 = new Point(Convert.ToInt16(ballList[0].x) - 200, Convert.ToInt16(ballList[0].y) - 120);
                        break;
                    // left
                    default:

                        break;
                }
            }

            //redraw the screen
            Refresh();
        }
         

        //testing 
        public void scores()
        {
            string scoreNumber = score.ToString();
            HighScore s = new HighScore(scoreNumber);
            Form1.highScores.Add(s);
            
            OnEnd();
            //GameOver();
        }
        

        //testing
        public void saveScoresRK()
        {
            XmlWriter writer = XmlWriter.Create("Resources/HighScores.xml", null);

            writer.WriteStartElement("TheScores");

            foreach (HighScore s in Form1.highScores)
            {
                writer.WriteStartElement("TheScore");

                writer.WriteElementString("Score", s.score);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
        }
        

        //testing
        public void GameOver()
        {
            Form form = this.FindForm();
            GameOverScreen ps = new GameOverScreen();
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void OnEnd()
        {
            //Testing: Saving the scores
            saveScoresRK();
            // Goes to the game over screen //changed
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);
            // Goes to the game over screen
            Form1 form = FindForm() as Form1;
            form.ChangeScreen(this, new MenuScreen());

        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws currentlevel
            foreach (Block b in currentlevel)
            {
                blockBrush = new SolidBrush(b.colour());
                e.Graphics.FillRectangle(blockBrush, Convert.ToInt32(b.x), Convert.ToInt32(b.y), b.width, b.height);
                e.Graphics.DrawRectangle(testPen, Convert.ToInt32(b.x), Convert.ToInt32(b.y), b.width, b.height);
            }

            // Draws ball
            foreach (Ball b in ballList)
            {
                e.Graphics.FillEllipse(ballBrush, Convert.ToSingle(b.x), Convert.ToInt32(b.y), b.size, b.size);
            }

            // draw line aim
            if (!start)
            {
                e.Graphics.DrawLine(linePen, p1, p2);
            }

            // Draw lives and score
            e.Graphics.DrawString("angle position: " + angleposition.ToString(), textFont, sb, new Point(25, this.Height - 100));
            e.Graphics.DrawString("block number: " + currentlevel.Count().ToString(), textFont, sb, new Point(this.Width - 300, this.Height - 100));

            switch(player1Lives)
            {
                case 4:
                    life5Output.Visible = false;
                    break;
                case 3:
                    life4Output.Visible = false;
                    break;
                case 2:
                    life3Output.Visible = false;
                    break;
                case 1:
                    life2Output.Visible = false;
                    break;
                case 0:
                    life1Output.Visible = false;
                    break;
                default:
                    break;
            }
        }

        [Obsolete("Please rename this method to what it is supposed to do", true)]
        public void NickMethod()
        {
            //set all button presses to false.
            leftArrowDown = rightArrowDown = ADown = DDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2)) - ((this.Width / 2) / 2);
            int newPaddleX = ((this.Width / 2) - (paddleWidth / 2)) + ((this.Width / 2) / 2);
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.Firebrick);
            //newPaddle = new Paddle(newPaddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.RoyalBlue);

            // setup starting ball values
            int ballX = (this.Width / 2 - 10) - ((this.Width / 2) / 2);
            int ballY = this.Height - paddle.height - 80;

            /// BallList[0] is P1
            /// BallList[1] is P2
            ballList.Clear();
            ballList.Add(new Ball(ballX, ballY, 6, 6, 20, 1, 1));
            ballList.Add(new Ball(ballX, this.Height - ballY, 6, 6, 20, 1, 1));
            // Creates a new ball

            #region Creates currentlevel for generic level. Need to replace with code that loads levels.
            //int x = 10;

            //while (currentlevel.Count < 12)
            //{
            //    x += 57;
            //    Block b1 = new Block(x, 10, 1, Color.White);
            //    currentlevel.Add(b1);
            //}

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
        }
    }
}
