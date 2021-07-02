using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PlusMinus
    {
        public string txtboxResult = "";
        public string txtboxExpression = "";

        public void pm()
        {
            if (txtboxResult == "∅")
            {
                return;
            }
            if (txtboxResult != "0")
            {
                if (txtboxResult.Contains("-"))
                {
                    txtboxResult = txtboxResult.Trim('-');
                }
                else
                {
                    txtboxResult = (Convert.ToDouble(txtboxResult) * -1).ToString();
                }
                txtboxExpression = txtboxResult;
            }
            else
            {
                return;
            }
        }
    }
}
