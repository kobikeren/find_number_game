using System;
using System.Windows.Forms;

namespace FindNumberGame
{
    //*******************************************************************
    //****************** Created by kobi keren **************************
    //******************     on 17/01/2017     **************************
    //*******************************************************************

    public partial class frmFindNumberGame : Form
    {
        private Random random;
        private int targetNumber;

        public frmFindNumberGame()
        {
            string rules;
            InitializeComponent();

            //set the text of the label lblRules
            rules = "Try to find the unknown target number as fast as you can.\n\n" +
                "Enter a number between the lower and the upper limits.";
            lblRules.Text = rules;

            //prepare the variable 'random' and prepare the first game
            random = new Random();
            ResetGame();
        }

        private void ResetGame()
        {
            //set values for the various controls and use the 'random' variable to
            //select a target number for the new game
            lblMessage.Text = "";
            targetNumber = random.Next(1, 1001);
            lblLowerLimit.Text = "1";
            lblUpperLimit.Text = "1000";
            lblNumberOfSteps.Text = "0";
            txtNumber.Text = "";
            txtNumber.Focus();
        }

        private void PrintMessage(string message)
        {
            //display the message
            lblMessage.Text = message;
            txtNumber.Focus();
            txtNumber.SelectAll();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string message;
            int lowerLimit = int.Parse(lblLowerLimit.Text);
            int upperLimit = int.Parse(lblUpperLimit.Text);
            int number;
            int newNumberOfSteps = int.Parse(lblNumberOfSteps.Text) + 1;

            if (txtNumber.Text == "")
            {
                message = "Error: invalid input\n\nThe text box is empty";
                PrintMessage(message);
                return;
            }
            
            if (!int.TryParse(txtNumber.Text,out number))
            {
                message = "Error: invalid input\n\n'" + txtNumber.Text + 
                    "' is not a number";
                PrintMessage(message);
                return;
            }

            number = int.Parse(txtNumber.Text);
            if (number < lowerLimit || number > upperLimit)
            {
                message = "Error: invalid input\n\n'" + txtNumber.Text + 
                    "' is out of range";
                PrintMessage(message);
                return;
            }

            if (number < targetNumber)
            {
                message = "the target number is bigger than " + number.ToString();                
                lblLowerLimit.Text = (number + 1).ToString();
                lblNumberOfSteps.Text = newNumberOfSteps.ToString();
                PrintMessage(message);
                return;
            }

            if (number > targetNumber)
            {
                message = "the target number is smaller than " + number.ToString();                
                lblUpperLimit.Text = (number - 1).ToString();
                lblNumberOfSteps.Text = newNumberOfSteps.ToString();
                PrintMessage(message);
                return;
            }

            if (number == targetNumber)
            {                
                message = "WOW !!   GOOD JOB !!\n\nThe target number is: " + 
                    targetNumber.ToString() + "\nYou found it in " +
                    newNumberOfSteps.ToString() + " steps";
                lblNumberOfSteps.Text = newNumberOfSteps.ToString();
                lblMessage.Text = message;
                MessageBox.Show(message, "Message");
                ResetGame();
            }            
        }        

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the application
            Application.Exit();
        }
    }
}
