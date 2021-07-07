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
        String memory = "";
        bool isOperatorPressed = false;
        bool isSqrtPressed = false;
        bool isEqualPressed = false;
        bool menuHider = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {//To exit the application
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {//To minimize the application
            this.WindowState = FormWindowState.Minimized;
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
        {//To delete one digit at a time
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
            if ((txtboxResult.Text.Equals("∅")) || (isEqualPressed))
            {
                return;
            }
            else if ((operators.Equals("÷")) && (txtboxResult.Text.Equals("0")))
            {//because infinity is not a number, and it should not be the answer
                txtboxResult.Text = "undefined";
            }
            else
            {
                if (isSqrtPressed)
                {
                    sqrtSwitch();
                    isSqrtPressed = false; //it avoids confusion for the basic operations
                    txtboxExpression.Text = sqrtOperand + " " + operators + " √" + operand;
                }
                else
                {
                    txtboxExpression.Text = operand + " " + operators;
                    operatorsSwitch();
                }
                operand = Convert.ToDouble(txtboxResult.Text);
                operators = "";
            }
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
                    txtboxResult.Text = "0"; //It fixed the bug when avoiding multiple decimal points.
                    txtboxExpression.Text = operand + " " + operators;
                }
                else
                {
                    operand = Convert.ToDouble(txtboxResult.Text);
                    isOperatorPressed = true;
                    operators = operate.Text;
                    txtboxResult.Text = "0";
                    txtboxExpression.Text = operand + " " + operators;
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
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else
            {
                operand = Convert.ToDouble(txtboxResult.Text);
                if (txtboxResult.Text.Equals("0"))
                {
                    txtboxResult.Text = "0";
                    txtboxExpression.Text = "√0";
                }
                else if ((operand != 0) && (!isOperatorPressed))
                {
                    if (txtboxResult.Text.Contains("-"))
                    {//because the square root of any negative number does not exist among the set of real numbers
                        txtboxResult.Text = "does not exist"; 
                    }
                    else
                    {
                        txtboxResult.Text = Math.Sqrt(operand).ToString();
                        sqrtOperand = Convert.ToDouble(txtboxResult.Text);
                        txtboxExpression.Text = "√" + operand;
                    }
                }
                isSqrtPressed = true;
            }
        }

        private void btnPlusminus_Click(object sender, EventArgs e)
        {//to change the number either to postivie or negative
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            if (txtboxResult.Text != "0")
            {
                if (txtboxResult.Text.Contains("-"))
                {//bringing back to positive
                    txtboxResult.Text = txtboxResult.Text.Trim('-');
                }
                else
                {//changing to negative
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
            {//the answer should always be zero until the user choose an operator and another number.
                txtboxResult.Text = "0";
                txtboxExpression.Text = txtboxResult.Text;
            }
            else
            {//gets the percentage and perform specific operation
                txtboxResult.Text = (operand * (Convert.ToDouble(txtboxResult.Text) * 0.01)).ToString();
                txtboxExpression.Text = operand + " " + operators + "" + txtboxResult.Text + "%";
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {//to reciprocate a number
            if (txtboxResult.Text.Equals("∅"))
            {
                return;
            }
            else if (txtboxResult.Text.Equals("0"))
            {//any number cannot be divided by zero
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
                case "MC": //for memory clear
                    txtboxM.Text = "";
                    break;
                case "MR": //to recall the saved number from memory save
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
                case "MS": //to save the number from txtboxResult
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
                case "M+": //to add a number to the saved number.
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
                case "M-": //to subtract a number to the saved number
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

        private void sqrtSwitch()
        {
            switch (operators)
            {
                case "x":
                    txtboxResult.Text = (sqrtOperand * Math.Sqrt(operand)).ToString();
                    break;
                case "÷":
                    txtboxResult.Text = (sqrtOperand / Math.Sqrt(operand)).ToString();
                    break;
                case "+":
                    txtboxResult.Text = (sqrtOperand + Math.Sqrt(operand)).ToString();
                    break;
                case "-":
                    txtboxResult.Text = (sqrtOperand - Math.Sqrt(operand)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnCopy.Hide(); //to hide other menus when other is clicked,
            btnCut.Hide();
            btnPaste.Hide();
            btnAbout.Hide();
            btnFAQ.Hide(); 

            if (menuHider)
            {//so the user can hide the menu if they accidentally clicked or decided not to click among the choices
                btnLight.Visible = false;
                btnDark.Visible = false;
                menuHider = false;
            }
            else
            {
                btnLight.Visible = true;
                btnDark.Visible = true;
                menuHider = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnLight.Hide();
            btnDark.Hide();
            btnAbout.Hide();
            btnFAQ.Hide();

            if (menuHider)
            {
                btnCopy.Visible = false;
                btnCut.Visible = false;
                btnPaste.Visible = false;
                menuHider = false;
            }
            else
            {
                btnCopy.Visible = true;
                btnCut.Visible = true;
                btnPaste.Visible = true;
                menuHider = true;

                if (txtboxEdit.Text.Equals("")) //since the txtboxEdit is empty by default
                {
                    btnPaste.Enabled = false;
                }
                else
                {
                    btnPaste.Enabled = true;
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnLight.Hide();
            btnDark.Hide();
            btnCopy.Hide();
            btnCut.Hide();
            btnPaste.Hide();

            if (menuHider)
            {
                btnAbout.Visible = false;
                btnFAQ.Visible = false;
                menuHider = false;
            }
            else
            {
                btnAbout.Visible = true;
                btnFAQ.Visible = true;
                menuHider = true;
            }
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            menuHider = false; //so the user can see the menu again with just one click instead of double.
            btnLight.Hide();
            btnDark.Hide();
            //to change the appearance to light mode
            this.BackColor = Color.Gray;
            btnMinimize.BackColor = Color.LightGray;
            btnMaximize.BackColor = Color.LightGray;
            btnView.BackColor = Color.LightGray;
            btnEdit.BackColor = Color.LightGray;
            btnHelp.BackColor = Color.LightGray;
            btnLight.BackColor = Color.LightGray;
            btnDark.BackColor = Color.LightGray;
            btnCopy.BackColor = Color.LightGray;
            btnCut.BackColor = Color.LightGray;
            btnPaste.BackColor = Color.LightGray;
            btnAbout.BackColor = Color.LightGray;
            btnFAQ.BackColor = Color.LightGray;
            btnMC.BackColor = Color.FromArgb(175, 175, 175);
            btnMR.BackColor = Color.Silver;
            btnMS.BackColor = Color.FromArgb(175, 175, 175);
            btnMplus.BackColor = Color.Silver;
            btnMminus.BackColor = Color.FromArgb(175, 175, 175);
            btnSqrt.BackColor = Color.Silver;
            btnPercent.BackColor = Color.FromArgb(175, 175, 175);
            btn1x.BackColor = Color.Silver;
            btnDecimal.BackColor = Color.Silver;
            btnPlusminus.BackColor = Color.Silver;
            btnDivide.BackColor = Color.FromArgb(175, 175, 175);
            btnMultiply.BackColor = Color.Silver;
            btnAdd.BackColor = Color.Silver;
            btnSubtract.BackColor = Color.FromArgb(175, 175, 175);
            btnC.BackColor = Color.Silver;
            btnCe.BackColor = Color.FromArgb(175, 175, 175);
            btnDel.BackColor = Color.Silver;
            btn0.BackColor = Color.FromArgb(175, 175, 175);
            btn1.BackColor = Color.FromArgb(175, 175, 175);
            btn2.BackColor = Color.Silver;
            btn3.BackColor = Color.FromArgb(175, 175, 175);
            btn4.BackColor = Color.Silver;
            btn5.BackColor = Color.FromArgb(175, 175, 175);
            btn6.BackColor = Color.Silver;
            btn7.BackColor = Color.FromArgb(175, 175, 175);
            btn8.BackColor = Color.Silver;
            btn9.BackColor = Color.FromArgb(175, 175, 175);
            txtboxExpression.BackColor = Color.Silver;
            txtboxResult.BackColor = Color.Silver;
            txtboxM.BackColor = Color.Silver;
            btnEquals.BackColor = Color.FromArgb(255, 179, 71);

            btnMinimize.ForeColor = Color.Black;
            btnView.ForeColor = Color.Black;
            btnEdit.ForeColor = Color.Black;
            btnHelp.ForeColor = Color.Black;
            btnLight.ForeColor = Color.Black;
            btnDark.ForeColor = Color.Black;
            btnCopy.ForeColor = Color.Black;
            btnCut.ForeColor = Color.Black;
            btnPaste.ForeColor = Color.Black;
            btnAbout.ForeColor = Color.Black;
            btnFAQ.ForeColor = Color.Black;
            btnMC.ForeColor = Color.Black;
            btnMR.ForeColor = Color.Black;
            btnMS.ForeColor = Color.Black;
            btnMplus.ForeColor = Color.Black;
            btnMminus.ForeColor = Color.Black;
            btnSqrt.ForeColor = Color.Black;
            btnPercent.ForeColor = Color.Black;
            btn1x.ForeColor = Color.Black;
            btnPlusminus.ForeColor = Color.Black;
            btnDecimal.ForeColor = Color.Black;
            btnDivide.ForeColor = Color.Black;
            btnMultiply.ForeColor = Color.Black;
            btnAdd.ForeColor = Color.Black;
            btnSubtract.ForeColor = Color.Black;
            btnEquals.ForeColor = Color.Black;
            btnC.ForeColor = Color.Black;
            btnCe.ForeColor = Color.Black;
            btnDel.ForeColor = Color.Black;
            btn0.ForeColor = Color.Black;
            btn1.ForeColor = Color.Black;
            btn2.ForeColor = Color.Black;
            btn3.ForeColor = Color.Black;
            btn4.ForeColor = Color.Black;
            btn5.ForeColor = Color.Black;
            btn6.ForeColor = Color.Black;
            btn7.ForeColor = Color.Black;
            btn8.ForeColor = Color.Black;
            btn9.ForeColor = Color.Black;
            txtboxExpression.ForeColor = Color.Black;
            txtboxResult.ForeColor = Color.Black;
            txtboxM.ForeColor = Color.Black;
        }

        private void btnDark_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnLight.Hide();
            btnDark.Hide();
            //to change the appearance to dark mode
            this.BackColor = Color.FromArgb(41, 41, 41);
            btnMinimize.BackColor = Color.FromArgb(100, 100, 100);
            btnMaximize.BackColor = Color.FromArgb(100, 100, 100);
            btnView.BackColor = Color.FromArgb(100, 100, 100);
            btnEdit.BackColor = Color.FromArgb(100, 100, 100);
            btnHelp.BackColor = Color.FromArgb(100, 100, 100);
            btnMR.BackColor = Color.FromArgb(100, 100, 100);
            btnMplus.BackColor = Color.FromArgb(100, 100, 100);
            btnSqrt.BackColor = Color.FromArgb(100, 100, 100);
            btn1x.BackColor = Color.FromArgb(100, 100, 100);
            btnLight.BackColor = Color.Gray;
            btnDark.BackColor = Color.Gray;
            btnCopy.BackColor = Color.Gray;
            btnCut.BackColor = Color.Gray;
            btnPaste.BackColor = Color.Gray;
            btnAbout.BackColor = Color.Gray;
            btnFAQ.BackColor = Color.Gray;
            btnMC.BackColor = Color.Gray;
            btnMS.BackColor = Color.Gray;
            btnMminus.BackColor = Color.Gray;
            btnPercent.BackColor = Color.Gray;
            btnPlusminus.BackColor = Color.Gray;
            btnDecimal.BackColor = Color.FromArgb(232, 150, 17);
            btnMultiply.BackColor = Color.FromArgb(232, 150, 17);
            btnAdd.BackColor = Color.FromArgb(232, 150, 17);
            btnDivide.BackColor = Color.FromArgb(227, 108, 20);
            btnSubtract.BackColor = Color.FromArgb(227, 108, 20);
            btnC.BackColor = Color.FromArgb(28, 78, 170);
            btnCe.BackColor = Color.FromArgb(47, 45, 146);
            btnDel.BackColor = Color.FromArgb(28, 78, 170);
            btn0.BackColor = Color.FromArgb(47, 45, 146);
            btn1.BackColor = Color.FromArgb(47, 45, 146);
            btn2.BackColor = Color.FromArgb(28, 78, 170);
            btn3.BackColor = Color.FromArgb(47, 45, 146);
            btn4.BackColor = Color.FromArgb(28, 78, 170);
            btn5.BackColor = Color.FromArgb(47, 45, 146);
            btn6.BackColor = Color.FromArgb(28, 78, 170);
            btn7.BackColor = Color.FromArgb(47, 45, 146);
            btn8.BackColor = Color.FromArgb(28, 78, 170);
            btn9.BackColor = Color.FromArgb(47, 45, 146);
            txtboxExpression.BackColor = Color.FromArgb(100, 100, 100);
            txtboxResult.BackColor = Color.FromArgb(100, 100, 100);
            txtboxM.BackColor = Color.FromArgb(100, 100, 100);

            btnMinimize.ForeColor = Color.White;
            btnView.ForeColor = Color.White;
            btnEdit.ForeColor = Color.White;
            btnHelp.ForeColor = Color.White;
            btnLight.ForeColor = Color.White;
            btnDark.ForeColor = Color.White;
            btnCopy.ForeColor = Color.White;
            btnCut.ForeColor = Color.White;
            btnPaste.ForeColor = Color.White;
            btnAbout.ForeColor = Color.White;
            btnFAQ.ForeColor = Color.White;
            btnMC.ForeColor = Color.White;
            btnMR.ForeColor = Color.White;
            btnMS.ForeColor = Color.White;
            btnMplus.ForeColor = Color.White;
            btnMminus.ForeColor = Color.White;
            btnSqrt.ForeColor = Color.White;
            btnPercent.ForeColor = Color.White;
            btn1x.ForeColor = Color.White;
            btnPlusminus.ForeColor = Color.White;
            btnDecimal.ForeColor = Color.White;
            btnDivide.ForeColor = Color.White;
            btnMultiply.ForeColor = Color.White;
            btnAdd.ForeColor = Color.White;
            btnSubtract.ForeColor = Color.White;
            btnEquals.ForeColor = Color.White;
            btnC.ForeColor = Color.White;
            btnCe.ForeColor = Color.White;
            btnDel.ForeColor = Color.White;
            btn0.ForeColor = Color.White;
            btn1.ForeColor = Color.White;
            btn2.ForeColor = Color.White;
            btn3.ForeColor = Color.White;
            btn4.ForeColor = Color.White;
            btn5.ForeColor = Color.White;
            btn6.ForeColor = Color.White;
            btn7.ForeColor = Color.White;
            btn8.ForeColor = Color.White;
            btn9.ForeColor = Color.White;
            txtboxExpression.ForeColor = Color.White;
            txtboxResult.ForeColor = Color.White;
            txtboxM.ForeColor = Color.White;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnCopy.Hide();
            btnCut.Hide();
            btnPaste.Hide();

            if ((txtboxResult.Text.Equals("∅")) || (txtboxResult.Text.Equals("0")))
            {//should not copy when txtboxResult is ∅ or 0
                return;
            }
            else
            {
                txtboxEdit.Text = txtboxResult.Text;
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnCopy.Hide();
            btnCut.Hide();
            btnPaste.Hide();
            if ((txtboxResult.Text.Equals("∅")) || (txtboxResult.Text.Equals("0")))
            {//should not cut when txtboxResult is ∅ or 0
                return;
            }
            else
            {
                txtboxEdit.Text = txtboxResult.Text;
                txtboxResult.Text = "0";
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnCopy.Hide();
            btnCut.Hide();
            btnPaste.Hide();

            txtboxResult.Text = txtboxEdit.Text; //pasting the cut or copied number/
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnAbout.Hide();
            btnFAQ.Hide();

            AboutCalculator calcAbout = new(); //to show the About Calculator form
            calcAbout.Show();
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            menuHider = false;
            btnAbout.Hide();
            btnFAQ.Hide();

            FAQ calcFAQ = new(); //to show the FAQ form
            calcFAQ.Show();
        }
    }
}