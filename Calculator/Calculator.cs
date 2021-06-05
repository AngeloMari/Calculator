using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void num_Click(object sender, EventArgs e)
        {
            if (txtboxDisplay.Text == "∅")
            {
                txtboxDisplay.Clear();
                Button number = (Button)sender;
                txtboxDisplay.Text = txtboxDisplay.Text + number.Text;
                txtboxExpression.Text = txtboxDisplay.Text;
            }
            else if (txtboxDisplay.Text == ".")
            {
                Button number = (Button)sender;
                txtboxDisplay.Text = "0" + txtboxDisplay.Text + number.Text;
                txtboxExpression.Text = txtboxDisplay.Text;
            }
            else
            {
                Button number = (Button)sender;
                txtboxDisplay.Text = txtboxDisplay.Text + number.Text;
                txtboxExpression.Text = txtboxDisplay.Text;
            }
        }

        private void operators_Click(object sender, EventArgs e)
        {
            Button operate = (Button)sender;
            txtboxDisplay.Text = txtboxDisplay.Text + operate.Text;
            txtboxExpression.Text = txtboxDisplay.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtboxDisplay.Text = "∅";
            txtboxExpression.Clear();
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtboxDisplay.Text = "∅";
        }
    }
}
