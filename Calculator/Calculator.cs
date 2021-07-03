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
        Double sqrtOperand = 0;
        String operators = "";
        String squareroot = "";
        String memory = "";
        bool isOperatorPressed = false;
        bool isViewPressed = false;
        bool isEditPressed = false;
        bool isHelpPressed = false;
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
            if ((txtboxResult.Text.Equals("∅")) || (txtboxResult.Text.Equals("0")) || (isOperatorPressed))
            {
                txtboxResult.Clear();
            }
            Button number = (Button)sender;
            txtboxResult.Text += number.Text;
            isOperatorPressed = false;  // Fixed the bug in appending more digits to the second operand.
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {//For the decimal button
            if ((txtboxResult.Text.Contains(".")))
            {
                return; //to avoid exception error
            }
            else if ((txtboxResult.Text.Equals("∅")) || (isOperatorPressed))
            {
                txtboxResult.Clear();
                if (!txtboxResult.Text.Contains(".")) //to add a the first decimal button for numbers < 1
                {
                    if (txtboxResult.Text.Equals(""))
                    {
                        txtboxResult.Clear();
                        txtboxResult.Text = "0" + "." + txtboxResult.Text;
                    }
                }
            }
            else if (txtboxResult.Text != "") //decimal button for numbers > 1
            {
                txtboxResult.Text += ".";
            }
            isOperatorPressed = false;
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
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else
            {
                operatorsSwitch();
                squarerootSwitch();
            }
            operand = Convert.ToDouble(txtboxResult.Text);
            operators = "";
        }

        private void btnOperators_Click(object sender, EventArgs e)
        {//For the operators
            Button operate = (Button)sender;
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else if (!isOperatorPressed)
            {
                if (operand != 0)
                {
                    btnEquals.PerformClick(); //It helps in appending new operand instead of clicking equal button every time.
                    isOperatorPressed = true;
                    operators = operate.Text;
                    txtboxExpression.Text = operand + " " + operators;
                    txtboxResult.Text = "0"; //It fixed the bug when avoiding multiple decimal points.
                }
                else
                {
                    operand = Convert.ToDouble(txtboxResult.Text);
                    operators = operate.Text;
                    isOperatorPressed = true;
                    txtboxExpression.Text = operand + " " + operators;
                    txtboxResult.Text = "0";
                }
            }
            else
            {//It allows the user to change the operator without having any errors.
                operators = operate.Text;
                txtboxExpression.Text = operand + " " + operators;
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
         ////////////////////////////////////////////////////////////////
        }

        private void btnPlusminus_Click(object sender, EventArgs e)
        {
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            if (txtboxResult.Text != "0")
            {
                if (txtboxResult.Text.Contains("-"))
                {
                    txtboxResult.Text = txtboxResult.Text.Trim('-');
                }
                else
                {
                    txtboxResult.Text = (Convert.ToDouble(txtboxResult.Text) * -1).ToString();
                }
                txtboxExpression.Text = txtboxResult.Text;
            }
            else
            {
                return;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else if (operators.Equals(""))
            {
                txtboxResult.Text = "0";
                txtboxExpression.Text = txtboxResult.Text;
            }
            else
            {
                txtboxResult.Text = (operand * (Convert.ToDouble(txtboxResult.Text) * 0.01)).ToString();
                txtboxExpression.Text = operand + " " + operators + "" + txtboxResult.Text + "%";
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else if (txtboxResult.Text.Equals("0"))
            {
                txtboxResult.Text = "Cannot divide by zero";
                txtboxExpression.Text = "reciproc(0)";
            }
            else
            {
                txtboxExpression.Text = "reciproc(" + txtboxResult.Text + ")";
                txtboxResult.Text = (1 / Convert.ToDouble(txtboxResult.Text)).ToString();
            }
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Button M = (Button)sender;
            memory = M.Text;

            switch (memory)
            {
                case "MC":
                    txtboxM.Text = "";
                    break;
                case "MR":
                    if (txtboxMemory.Text.Equals("0"))
                    {
                        return;
                    }
                    else
                    {
                        txtboxM.Text = "M";
                        txtboxResult.Text = txtboxMemory.Text;
                    }
                    break;
                case "MS":
                    if (txtboxResult.Text.Equals("∅"))
                    {
                        return;
                    }
                    else
                    {
                        if (txtboxResult.Text.Equals("0"))
                        {
                            return;
                        }
                        else
                        {
                            txtboxM.Text = "M";
                            txtboxMemory.Text = txtboxResult.Text;
                        }
                    }
                    break;
                case "M+":
                    if (txtboxResult.Text.Equals("∅"))
                    {
                        return;
                    }
                    else
                    {
                        txtboxM.Text = "M";
                        txtboxMemory.Text = (Convert.ToDouble(txtboxMemory.Text) + Convert.ToDouble(txtboxResult.Text)).ToString();
                    }
                    break;
                case "M-":
                    if (txtboxResult.Text.Equals("∅"))
                    {
                        return;
                    }
                    else
                    {
                        txtboxM.Text = "M";
                        txtboxMemory.Text = (Convert.ToDouble(txtboxMemory.Text) - Convert.ToDouble(txtboxResult.Text)).ToString();
                    }
                    break;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (isViewPressed)
            {
                lstboxView.Visible = false;
                isViewPressed = false;
            }
            else
            {
                lstboxView.Visible = true;
                isViewPressed = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditPressed)
            {
                lstboxEdit.Visible = false;
                isEditPressed = false;
            }
            else
            {
                lstboxEdit.Visible = true;
                isEditPressed = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (isHelpPressed)
            {
                lstboxHelp.Visible = false;
                isHelpPressed = false;
            }
            else
            {
                lstboxHelp.Visible = true;
                isHelpPressed = true;
            }
        }

        private void operatorsSwitch()
        {
            switch (operators)
            {//To find which operaion to be used.
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
        }

        private void squarerootSwitch()
        {
            switch (squareroot)
            {//To properly calculate square root depending on the chosen operator.
                case "x":
                    txtboxResult.Text = (sqrtOperand * (Math.Sqrt(Convert.ToDouble(txtboxResult.Text)))).ToString();
                    break;
                case "÷":
                    txtboxResult.Text = (sqrtOperand / (Math.Sqrt(Convert.ToDouble(txtboxResult.Text)))).ToString();
                    break;
                case "+":
                    txtboxResult.Text = (sqrtOperand + (Math.Sqrt(Convert.ToDouble(txtboxResult.Text)))).ToString();
                    break;
                case "-":
                    txtboxResult.Text = (sqrtOperand - (Math.Sqrt(Convert.ToDouble(txtboxResult.Text)))).ToString();
                    break;
                default:
                    break;
            }
        }
    }
}