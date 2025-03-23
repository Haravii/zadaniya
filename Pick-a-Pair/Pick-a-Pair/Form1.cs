using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pick_a_Pair
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label firstClicked = null;

        Label secondClicked = null;

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void clickLabel(object sender)
        {

            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Вы нашли все пары!", "Мои поздравления!");
            Close();
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            clickLabel(sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
    }
}
