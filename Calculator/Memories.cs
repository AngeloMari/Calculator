using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Memories
    {
        public String m = "";
        public string txtboxM = "";
        public string txtboxResult = "";
        public string txtboxMemory = "";

        public void Memory()
        {
            switch (m)
            {
                case "MC":
                    txtboxM = "";
                    break;
                case "MR":
                    if (txtboxResult == "∅")
                    {
                        return;
                    }
                    else
                    {
                        txtboxM = "M";
                        txtboxResult = txtboxMemory;
                    }
                    break;
                case "MS":
                    if (txtboxResult == "∅")
                    {
                        return;
                    }
                    else
                    {
                        txtboxM = "M";
                        txtboxMemory = txtboxResult;
                    }
                    break;
                case "M+":
                    if (txtboxResult == "∅")
                    {
                        return;
                    }
                    else
                    {
                        txtboxM = "M";
                        txtboxMemory = (Convert.ToDouble(txtboxMemory) + Convert.ToDouble(txtboxResult)).ToString();
                    }
                    break;
                case "M-":
                    if (txtboxResult == "∅")
                    {
                        return;
                    }
                    else
                    {
                        txtboxM = "M";
                        txtboxMemory = (Convert.ToDouble(txtboxMemory) - Convert.ToDouble(txtboxResult)).ToString();
                    }
                    break;
            }
        }
    }
}
