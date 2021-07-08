using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Equals
    {
        public Double operand = 0;
        public Double sqrtOperand = 0;
        public String operators = "";
        public bool isOperatorPressed = false;
        public bool isSqrtPressed = false;
        public bool isEqualPressed = false;
        public String txtboxResult = "";
        public String txtboxExpression = "";

        public void equalSign()
        {
            if ((txtboxResult.Equals("∅")) || (isEqualPressed))
            {
                return;
            }
            else if ((operators.Equals("÷")) && (txtboxResult.Equals("0")))
            {//because infinity is not a number, and it should not be the answer
                txtboxResult = "undefined";
            }
            else
            {
                if (isSqrtPressed)
                {
                    sqrtSwitch();
                    isSqrtPressed = false; //it avoids confusion for the basic operations
                    txtboxExpression = sqrtOperand + " " + operators + " √" + operand;
                }
                else
                {
                    operatorsSwitch();
                    txtboxExpression = "";
                }

                if (txtboxResult.Equals("-0"))
                {//because there is no negative zero
                    txtboxResult = "0";
                }
                operand = Convert.ToDouble(txtboxResult);
                operators = "";
            }
        }

        private void operatorsSwitch()
        {
            switch (operators)
            {//To find which operaion to be used.
                case "x":
                    txtboxResult = (operand * Convert.ToDouble(txtboxResult)).ToString();
                    break;
                case "÷":
                    txtboxResult = (operand / Convert.ToDouble(txtboxResult)).ToString();
                    break;
                case "+":
                    txtboxResult = (operand + Convert.ToDouble(txtboxResult)).ToString();
                    break;
                case "-":
                    txtboxResult = (operand - Convert.ToDouble(txtboxResult)).ToString();
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
                    txtboxResult = (sqrtOperand * Math.Sqrt(operand)).ToString();
                    break;
                case "÷":
                    txtboxResult = (sqrtOperand / Math.Sqrt(operand)).ToString();
                    break;
                case "+":
                    txtboxResult = (sqrtOperand + Math.Sqrt(operand)).ToString();
                    break;
                case "-":
                    txtboxResult = (sqrtOperand - Math.Sqrt(operand)).ToString();
                    break;
                default:
                    break;
            }
        }

    }
}
