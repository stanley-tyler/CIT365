﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;
        int addSoundCount = 0;
        int minusSoundCount = 0;
        int multiplySoundCount = 0;
        int divideSoundCount = 0;

        public void StartTheQuiz()
        {
            
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            multiplyLeftLabel.Text = multiplicand.ToString();
            multiplyRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divisionLeftLabel.Text = dividend.ToString();
            divisionRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
            timer1.Start();
        }

    
        public Form1()
        {
            InitializeComponent();
        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            StartButton.Enabled = false;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                timeLabel.BackColor = Color.Empty;
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                StartButton.Enabled = true;
               
            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                if (timeLeft <= 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                playSimpleSound();

            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.BackColor = Color.Empty;
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                StartButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
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

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
          
            if (addend1 + addend2 == sum.Value && addSoundCount == 0)
            {
                simpleSound.Play();
                addSoundCount++;
            }
            else if (minuend - subtrahend == difference.Value && minusSoundCount == 0)
            {
                simpleSound.Play();
                minusSoundCount++;
            }
            else if (multiplicand * multiplier == product.Value && multiplySoundCount == 0)
            {
                simpleSound.Play();
                multiplySoundCount++;
            }
            else if (dividend / divisor == quotient.Value && divideSoundCount == 0)
            {
                simpleSound.Play();
                divideSoundCount++;
            }
        }
    }
}
