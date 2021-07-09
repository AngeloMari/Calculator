using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Memory : Equals
    {
        public String m = "";
        public string txtboxM = "";         //txtboxM and txtboxMemory are hidden text boxes in the calculator design
        public string txtboxMemory = "";    //it can be found by highlighting above MC and C buttons

        public void memoryBtns()
        {
            switch (m)
            {
                case "MC": //for memory clear
                    txtboxM = "";       
                    txtboxMemory = "0"; //zero because the default value of txtboxMemory is also zero
                    break;
                case "MS": //to save the number from txtboxResult
                    if (txtboxResult == "∅")
                    {
                        return;
                    }
                    else
                    {
                        if (txtboxResult.Equals("0"))
                        { //since no one will save zero for later use
                            return;
                        }
                        else
                        {
                            txtboxM = "M";                  
                            txtboxMemory = txtboxResult;   //storing the number from txtboxResult to txtboxMemory
                        }
                    }
                    break;
                case "MR": //to recall the saved number from memory save
                    if (txtboxResult.Equals("0") || (txtboxMemory.Equals("0")))
                    {
                        return;
                    }
                    else
                    {
                        txtboxM = "M";
                        txtboxResult = txtboxMemory;
                    }
                    break;
                case "M+": //to add a number to the saved number.
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
                case "M-": //to subtract a number to the saved number
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
