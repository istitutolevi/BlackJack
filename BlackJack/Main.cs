using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Main : Form
    {
        private CardDeck carddeck = new CardDeck(CardDeck.CardDeckType.WithoutJokers);
        private List<PictureBox> windowstack = new List<PictureBox>(0);
        private Random rand = new Random();
        private bool _isPlaying = false, gameover = false, win = false, draw = false;
        private int pcmcount = 0, mymcount = 0, _count = 0, _id = 0;
        private int mystackValue = 0, pcstackValue = 0;
        private Image img;

        public Main()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void ControlRules(bool allin = false)
        {
            myscore.Text = "ME(" + mystackValue.ToString() + ")";
            pcscore.Text = "PC(" + pcstackValue.ToString() + ")";

            if (allin)
            {
                win = ((mystackValue <= 21) && (mystackValue > pcstackValue));
                draw = (pcstackValue == mystackValue);
                gameover = true;
            }
            else if (pcstackValue == mystackValue)
            {
                draw = true;
                win = false;
            }
            else if ((mystackValue > 21) | (pcstackValue == 21))
            {
                win = false;
                draw = false;
                gameover = true;
            }
            else if ((mystackValue > pcstackValue && mystackValue <= 21) | (mystackValue == 21) | (pcstackValue > 21))
            {
                win = true;
                draw = false;
                gameover = true;
            }
            else
            {
                draw = false;
                win = false;
            }


            if (gameover) ShowResults();
        }

        private void MessageBox1(string msg, Color color)
        {
            msgbox1.ForeColor = color;
            msgbox1.Text = msg;
        }
        private void MessageBox2(string msg, Color color)
        {
            msgbox2.ForeColor = color;
            msgbox2.Text = msg;
        }

        public void InitializeGameSession()
        {
            pbScreen.Image = null;
            start.Visible = false;
            msgbox1.Visible = false;
            msgbox2.Visible = false;
            myscore.Visible = true;
            pcscore.Visible = true;
            blackjacksign.ForeColor = Color.Black;
            signblinker.Enabled = false;

            if (start.Visible == false)
            {
                foreach (PictureBox btn in windowstack)
                {
                    btn.Visible = false;
                    Controls.Remove(btn);
                    _count = 0;
                }
            }
            ///Refresh Predefined Values For Loop
            _isPlaying = true; gameover = false; win = false; draw = false;
            pcmcount = 0; mymcount = 0; pcstackValue = 0; mystackValue = 0;
            windowstack = new List<PictureBox>();
            carddeck = new CardDeck(CardDeck.CardDeckType.WithoutJokers);
            msgbox1.Text = string.Empty;;
            msgbox2.Text = string.Empty;;
            myscore.Text = "ME(0)";
            pcscore.Text = "PC(0)";
            carddeck.ExtremeShuffle();
            pcplay.Enabled = true;
        }
        public void ShowResults()
        {
            if (gameover)
            {
                _isPlaying = false;
                img = null;
                start.Visible = true;
                msgbox1.Visible = true;
                msgbox2.Visible = true;

                hitbtn.Visible = false;
                holdbtn.Visible = false;
                // End of game actions
                if (pcstackValue > 21) MessageBox2("PC BUST!!!", Color.LightBlue);
                else if (mystackValue > 21) MessageBox2("BUST!!!", Color.Red);
                else if (pcstackValue == 21) MessageBox2("PC BLACKJACK!!!", Color.Red);
                else if (mystackValue == 21)
                {
                    signblinker.Enabled = true;
                    MessageBox2("BLACKJACK", Color.LightGreen);
                }

                if (draw & !win) MessageBox1("It's A DRAW!", Color.LightBlue);
                else if (win) MessageBox1("You Win!", Color.LightGreen);
                else MessageBox1("You Lose!", Color.Red);
            }
        }
        private void pcHit()
        {
            if ((21 - pcstackValue) >= rand.Next(6, 9) && !gameover)//Decide PC Risk Taking At Random
            {
                Card card = carddeck.Pop();
                pcstackValue += card.Value;
                PictureBox newcard = card.CardPicture();
                int id = _id;
                newcard.Tag = id;
                newcard.Location = new Point((pcmcount++ * (120 + 2)) - (pcmcount > 1 ? (pcmcount - 1) * 60 : 0), 0);
                newcard.Name = "pccard_" + id;
                newcard.BringToFront();
                windowstack.Insert(_count++, newcard);

                DrawCards();
                ControlRules();
            }
            else
            {
                if (!gameover)
                {
                    userHit();
                    hitbtn.Visible = true;
                    holdbtn.Visible = true;
                }
                pcplay.Enabled = false;
            }
        }

        private void DrawCards()
        {
            if (img == null)
                img = new Bitmap(pbScreen.Width, pbScreen.Height);

            using (var gfx = Graphics.FromImage(img))
            {
                foreach (var picture in windowstack)
                {
                    gfx.DrawImage(picture.BackgroundImage, picture.Location.X, picture.Location.Y, picture.Size.Width, picture.Size.Height);
                }
            }
            pbScreen.BackgroundImage = null;
            pbScreen.Image = img;
        }

        private void userHit()
        {
            carddeck.ExtremeShuffle();
            var card = carddeck.Pop();
            mystackValue += card.Value;
            var newcard = card.CardPicture();
            int id = _id++;
            newcard.Tag = id;
            newcard.Location = new Point((mymcount++ * (120 + 2)) - (mymcount > 1 ? (mymcount - 1) * 60 : 0), 165);
            newcard.Name = "mycard_" + id;
            newcard.BringToFront();
            windowstack.Insert(_count++, newcard);

            DrawCards();
            ControlRules();
        }

        private void move_Click(object sender, EventArgs e)
        {
            if (_isPlaying && pcplay.Enabled == false)
            {
                UI.MonoControls.MonoButton thisbutton = (UI.MonoControls.MonoButton)sender;
                switch (thisbutton.TabIndex)
                {
                    case 0://hit
                        userHit();
                        break;
                    default://hold
                        ControlRules(true);
                        break;
                }
            }

        }
        private void start_Click(object sender, EventArgs e)
        {
            InitializeGameSession();
        }

        private void signblinker_Tick(object sender, EventArgs e)
        {
            if (blackjacksign.ForeColor != Color.Green) blackjacksign.ForeColor = Color.Green;
            else blackjacksign.ForeColor = Color.Black;
        }
        private void pcpause_Tick(object sender, EventArgs e)
        {
            pcHit();
        }
    }
}
