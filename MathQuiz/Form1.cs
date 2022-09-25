using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        //addition variables
        int addend1;
        int addend2;

        //substraction variables
        int minuend;
        int subtraend;

        //multiplication variables
        int multiplicand;
        int multiplier;

        //division variables
        int dividend;
        int divisor;

        //variable to keep track of remaining time
        int timeLeft;




        //Start the quiz by filling up problems and 
        //and starts the timer
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            //substraction problem
            minuend = randomizer.Next(1, 101);
            subtraend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtraend.ToString();
            difference.Value = 0;

            //multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timeLeftLabel.Text = multiplicand.ToString();
            timeRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //division problem
            divisor = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            dividend = divisor * tempQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();


        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtraend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();

            DateTime thisDay = DateTime.Today;
            String toDate = String.Format("{0:d MMMM yyyy}", thisDay);

            dateLabel.Text = toDate;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                //if all the answers are correct
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                   "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0) //if the answers arent correct
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + "seconds";
                if(timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
   
            else //if runs out of time
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtraend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = DefaultBackColor;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void check_answer(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Windows\Media\notify.wav");

            if (answerBox.Name == "sum")
            {
                
                if (answerBox.Value == addend1 + addend2)
                {
                    player.Play();
                }

            }

            if (answerBox.Name == "difference")
            {

                if (answerBox.Value == minuend - subtraend)
                {
                    player.Play();
                }

            }

            if (answerBox.Name == "product")
            {

                if (answerBox.Value == multiplicand * multiplier)
                {
                    player.Play();
                }

            }

            if (answerBox.Name == "quotient")
            {

                if (answerBox.Value == dividend / divisor)
                {
                    player.Play();
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
