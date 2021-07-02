using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Reciprocal
    {
        public string txtboxResult = "";
        public string txtboxExpression = "";

        public void reciproc()
        {
            if (txtboxResult == "∅")
            {
                return;
            }
            else if (txtboxResult == "0")
            {
                txtboxResult = "Cannot divide by zero";
                txtboxExpression = "reciproc(0)";
            }
            else
            {
                txtboxExpression = "reciproc(" + txtboxResult + ")";
                txtboxResult = (1 / Convert.ToDouble(txtboxResult)).ToString();
            }
        }
    }
}
