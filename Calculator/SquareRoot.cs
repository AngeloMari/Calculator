using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SquareRoot : Equals
    {
        Double operand = 0;
        String operators = "";
        String squareroot = "";
        bool isOperatorPressed = false;
        public string txtboxExpression = "";

        public void squareRoot()
        {
            if (txtboxResult == "∅")
            {
                return;
            }
            else if (operand != 0)
            {
                if (isOperatorPressed)
                {
                    isOperatorPressed = true;
                    squareroot = "√";
                    txtboxExpression = squareroot + "(" + operand + ")";
                    equal();
                }
                else
                {
                    isOperatorPressed = true;
                    squareroot = "√";
                    txtboxExpression = squareroot + "(" + operand + ")";
                    txtboxResult = (Math.Sqrt(operand).ToString());
                }
            }
            else
            {
                operand = Convert.ToDouble(txtboxResult);
                operators = "√";
                isOperatorPressed = true;
                txtboxExpression = "√(" + operand + ")";
                txtboxResult = (Math.Sqrt(operand).ToString());
            }
        }
    }
}
