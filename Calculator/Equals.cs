using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Equals
    {
        Double operand = 0;
        String operators = "";
        String squareroot = "";
        public string txtboxResult = "";

        public void equal()
        {
            if (txtboxResult == "∅")
            {
                return;
            }
            switch (operators)
            {
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

            switch (squareroot)
            {
                case "x":
                    txtboxResult = (Convert.ToDouble(txtboxResult) * Math.Sqrt(Convert.ToDouble(txtboxResult))).ToString();
                    break;
                case "÷":
                    txtboxResult = (Convert.ToDouble(txtboxResult) / Math.Sqrt(Convert.ToDouble(txtboxResult))).ToString();
                    break;
                case "+":
                    txtboxResult = (Convert.ToDouble(txtboxResult) + Math.Sqrt(Convert.ToDouble(txtboxResult))).ToString();
                    break;
                case "-":
                    txtboxResult = (Convert.ToDouble(txtboxResult) - Math.Sqrt(Convert.ToDouble(txtboxResult))).ToString();
                    break;
                default:
                    break;
            }

            operand = Convert.ToDouble(txtboxResult);
            operators = "";
        }
    }
}
