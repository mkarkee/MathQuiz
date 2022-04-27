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



        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
    }
}
