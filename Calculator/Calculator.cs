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
        Double operand = 0;
        String operators = "";
        bool isOperatorPressed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {//To exit the application
            Application.Exit();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {//To display what number was pressed
            if ((txtboxResult.Text == "∅") || (txtboxResult.Text == "0") || (isOperatorPressed))
            {
                txtboxResult.Clear();
            }
            Button number = (Button)sender;
            txtboxResult.Text += number.Text;
            isOperatorPressed = false;  // Fixed the bug in appending more digits to the second operand.
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if ((txtboxResult.Text.Contains(".")))
            {
                return;
            }
            else if ((txtboxResult.Text == "∅") || (isOperatorPressed))
            {
                txtboxResult.Clear();
                if (!txtboxResult.Text.Contains("."))
                {
                    if (txtboxResult.Text == "")
                    {
                        txtboxResult.Clear();
                        txtboxResult.Text = "0" + "." + txtboxResult.Text;
                    }
                }
            }
            else if (txtboxResult.Text != "")
            {
                txtboxResult.Text += ".";
            }

            isOperatorPressed = false;
        }

        private void btnOperators_Click(object sender, EventArgs e)
        {//For the operators
            Button operate = (Button)sender;
            operand = Convert.ToDouble(txtboxResult.Text);
            operators = operate.Text;
            isOperatorPressed = true;
            txtboxExpression.Text = operand + " " + operators;
            txtboxResult.Text = "0"; // It fixed the bug when avoiding multiple decimal points.
        }

        private void btnC_Click(object sender, EventArgs e)
        {//To clear the text box
            txtboxResult.Text = "∅";
            operand = 0;
            txtboxExpression.Clear();
        }

        private void btnCe_Click(object sender, EventArgs e)
        {//To clear entry
            txtboxResult.Text = "∅";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {//To delete one character
            string del = txtboxResult.Text;

            if (del.Length > 1)
            {
                del = del.Substring(0, del.Length - 1);
            }
            else
            {
                del = "∅";
            }

            txtboxResult.Text = del;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            txtboxExpression.Clear();
                switch (operators)
            {
                case "x":
                    txtboxResult.Text = (operand * Convert.ToDouble(txtboxResult.Text)).ToString();
                    break;
                case "÷":
                    txtboxResult.Text = (operand / Convert.ToDouble(txtboxResult.Text)).ToString();
                    break;
                case "+":
                    txtboxResult.Text = (operand + Convert.ToDouble(txtboxResult.Text)).ToString();
                    break;
                case "-":
                    txtboxResult.Text = (operand - Convert.ToDouble(txtboxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            isOperatorPressed = false;
        }
    }
}
