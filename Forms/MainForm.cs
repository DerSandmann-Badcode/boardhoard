using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardHoard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            
        }

        private void addThreadButton_Click(object sender, EventArgs e)
        {
            BoardContainer.Add(threadUrlTextBox.Text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BoardContainer.Boards = new List<Board>();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
