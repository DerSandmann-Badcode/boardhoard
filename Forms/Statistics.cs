using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardHoard.Forms
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int buttonInt = rnd.Next(100);
            string buttonText = string.Empty;

            switch (buttonInt)
            {
                case 5:
                    buttonText = "Shame on you";
                    break;
                case 69:
                    buttonText = "l-lewd! B-baka!";
                    break;
                case 42:
                    buttonText = "Shame on you...!";
                    break;
                default:
                    buttonText = "Shame on you";
                    break;
            }

            btnClose.Text = buttonText;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
