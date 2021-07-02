using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Decimal
    {
        bool isOperatorPressed = false;
        public string txtboxResult = "";

        public void dot()
        {
            if ((txtboxResult.Contains(".")))
            {
                return;
            }
            else if ((txtboxResult == "∅") || (isOperatorPressed))
            {
                txtboxResult = "";
                if (!txtboxResult.Contains("."))
                {
                    if (txtboxResult == "")
                    {
                        txtboxResult = "";
                        txtboxResult = "0" + "." + txtboxResult;
                    }
                }
            }
            else if (txtboxResult != "")
            {
                txtboxResult += ".";
            }

            isOperatorPressed = false;
        }
    }
}
