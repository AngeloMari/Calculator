using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Percent
    {
        public String operators = "";
        public Double operand = 0;
        public string txtboxResult = "";
        public string txtboxExpression = "";

        public void percent()
        {
            if (txtboxResult == "∅")
            {
                return;
            }
            else if (operators == "")
            {
                txtboxResult = "0";
                txtboxExpression = txtboxResult;
            }
            else
            {
                txtboxResult = (operand * (Convert.ToDouble(txtboxResult) * 0.01)).ToString();
            }
        }
    }
}
