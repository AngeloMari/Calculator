using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class AdvancedOperators : Equals
    {
        bool isPlusminusPressed = false; //to be able to compute negative reciprocals

        public void oprtrSqrt()
        {
            if (txtboxResult.Equals("∅"))
            {
                return;
            }
            else
            {
                operand = Convert.ToDouble(txtboxResult);
                if (txtboxResult.Equals("0"))
                {
                    txtboxResult = "0";
                    txtboxExpression = "√0";
                }
                else if ((operand != 0) && (!isOperatorPressed))
                {
                    if (txtboxResult.Contains("-"))
                    {//because the square root of any negative number does not exist among the set of real numbers
                        txtboxResult = "does not exist";
                    }
                    else
                    {
                        txtboxResult = Math.Sqrt(operand).ToString();
                        sqrtOperand = Convert.ToDouble(txtboxResult);
                        if (isSqrtPressed)
                        {//so there will be no confusion in the txtboxExpression when performing operation between two square roots
                            isSqrtPressed = false;
                        }
                        else
                        {
                            txtboxExpression = "√" + operand;
                        }
                    }
                }
                isSqrtPressed = true;
            }
        }

        public void oprtrPlusminus()
        {//to change the number either to postivie or negative
            isPlusminusPressed = true;
            if (txtboxResult.Equals("∅"))
            {
                return;
            }
            if (txtboxResult != "0")
            {
                if (txtboxResult.Contains("-"))
                {//bringing back to positive
                    txtboxResult = txtboxResult.Trim('-');
                }
                else
                {//changing to negative
                    txtboxResult = (Convert.ToDouble(txtboxResult) * -1).ToString();
                }
                txtboxExpression = txtboxResult;
            }
            else
            {
                return;
            }
            isPlusminusPressed = false;
        }

        public void oprtr1x()
        {//to reciprocate a number
            if (txtboxResult.Equals("∅"))
            {
                return;
            }
            else if (txtboxResult.Equals("0"))
            {//any number cannot be divided by zero
                txtboxResult = "Cannot divide by zero";
                txtboxExpression = "reciproc(0)";
            }
            else if (isPlusminusPressed)
            {
                txtboxExpression = "reciproc(" + txtboxResult + ")";
                txtboxResult = ((1 / Convert.ToDouble(txtboxResult)) * (-1)).ToString();
            }
            else
            {
                txtboxExpression = "reciproc(" + txtboxResult + ")";
                txtboxResult = (1 / Convert.ToDouble(txtboxResult)).ToString();
            }
        }
    }
}