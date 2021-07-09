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
            if ((txtboxResult.Equals("∅")) || (txtboxResult.Equals(".0")))
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
                    if (txtboxResult.Contains("."))
                    {//to avoid having "-" as a result when the number of digits exceed.
                        if (txtboxResult.Length >= 18)
                        {
                            txtboxResult = Math.Round(Convert.ToDouble(txtboxResult), 15, MidpointRounding.AwayFromZero).ToString();
                        }
                    }
                    else if (!txtboxResult.Contains("."))
                    {//limiting whole number result to 16 characters
                        string round = txtboxResult;

                        if (round.Length == 18)
                        {
                            _ = round.Substring(0, round.Length - 2);
                        }
                        else if (round.Length == 17)
                        {
                            _ = round.Substring(0, round.Length - 1);
                        }
                    }
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

            if (txtboxResult.Contains("."))
            {
                if (txtboxResult.Length >= 18)
                {
                    txtboxResult = Math.Round(Convert.ToDouble(txtboxResult), 15, MidpointRounding.AwayFromZero).ToString();
                }                                                           //there will be an exception when exceeding 15
            }
            else if (!txtboxResult.Contains("."))
            {
                string round = txtboxResult;

                if (round.Length == 18)
                {
                    _ = round.Substring(0, round.Length - 2);
                }
                else if (round.Length == 17)
                {
                    _ = round.Substring(0, round.Length - 1);
                }
            }
        }
    }
}