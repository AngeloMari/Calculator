﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Memories Mbtns = new();
        Reciprocal oneXbtn = new();
        Percent percentbtn = new();
        PlusMinus plusMinus = new();
        Decimal decimalbtn = new();
        Equals equalbtn = new();
        SquareRoot sqrtbtn = new();
        Double operand = 0;
        String operators = "";
        bool isOperatorPressed = false;
        bool isViewPressed = false;
        bool isEditPressed = false;
        bool isHelpPressed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {//To exit the application
            Application.Exit();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {//To display what number was pressed
            if ((txtboxResult.Text == "∅") || (txtboxResult.Text == "0") || (isOperatorPressed))
            {
                txtboxResult.Clear();
            }
            Button number = (Button)sender;
            txtboxResult.Text += number.Text;
            isOperatorPressed = false;  // Fixed the bug in appending more digits to the second operand.
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {//DECIMAL IS STILL NOT WORKING
            decimalbtn.txtboxResult = txtboxResult.Text;
            decimalbtn.dot();
            txtboxResult.Text = decimalbtn.txtboxResult;
        }

        private void btnOperators_Click(object sender, EventArgs e)
        {//For the operators
            Button operate = (Button)sender;
            if (txtboxResult.Text == "∅")
            {
                return;
            }
            else if (operand != 0)
            {
                btnEquals.PerformClick();
                isOperatorPressed = true;
                operators = operate.Text;
                txtboxExpression.Text = operand + " " + operators;
                txtboxResult.Text = "0"; // It fixed the bug when avoiding multiple decimal points.
            }
            else
            {
                operand = Convert.ToDouble(txtboxResult.Text);
                operators = operate.Text;
                isOperatorPressed = true;
                txtboxExpression.Text = operand + " " + operators;
                txtboxResult.Text = "0";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {//To clear the text box
            txtboxResult.Text = "∅";
            operand = 0;
            txtboxExpression.Clear();
        }

        private void btnCe_Click(object sender, EventArgs e)
        {//To clear entry
            txtboxResult.Text = "∅";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {//To delete one character
            string del = txtboxResult.Text;

            if (del.Length > 1)
            {
                del = del.Substring(0, del.Length - 1);
            }
            else
            {
                del = "∅";
            }
            txtboxResult.Text = del;
        }

        public void btnEquals_Click(object sender, EventArgs e)
        {//EQUAL IS STILL NOT WORKING
            equalbtn.txtboxResult = txtboxResult.Text;
            equalbtn.equal();
            txtboxResult.Text = equalbtn.txtboxResult;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            sqrtbtn.squareRoot();
        }

        private void btnPlusminus_Click(object sender, EventArgs e)
        {
            plusMinus.txtboxResult = txtboxResult.Text;
            plusMinus.txtboxExpression = txtboxExpression.Text;
            plusMinus.pm();
            txtboxResult.Text = plusMinus.txtboxResult;
            txtboxExpression.Text = plusMinus.txtboxResult;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {//STILL NOT WORKING PROPERLY
            percentbtn.txtboxResult = txtboxResult.Text;
            percentbtn.txtboxExpression = txtboxExpression.Text;
            percentbtn.percent();
            txtboxResult.Text = percentbtn.txtboxResult;
            txtboxExpression.Text = percentbtn.txtboxExpression;
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            oneXbtn.txtboxResult = txtboxResult.Text;
            oneXbtn.txtboxExpression = txtboxExpression.Text;
            oneXbtn.reciproc();
            txtboxResult.Text = oneXbtn.txtboxResult;
            txtboxExpression.Text = oneXbtn.txtboxExpression;
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Button M = (Button)sender;
            Mbtns.m = M.Text;

            Mbtns.txtboxM = txtboxM.Text;
            Mbtns.txtboxMemory = txtboxMemory.Text;
            Mbtns.txtboxResult = txtboxResult.Text;
            Mbtns.Memory();
            txtboxM.Text = Mbtns.txtboxM;
            txtboxMemory.Text = Mbtns.txtboxMemory;
            txtboxResult.Text = Mbtns.txtboxResult;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (isViewPressed)
            {
                lstboxView.Visible = false;
                isViewPressed = false;
            }
            else
            {
                lstboxView.Visible = true;
                isViewPressed = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditPressed)
            {
                lstboxEdit.Visible = false;
                isEditPressed = false;
            }
            else
            {
                lstboxEdit.Visible = true;
                isEditPressed = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (isHelpPressed)
            {
                lstboxHelp.Visible = false;
                isHelpPressed = false;
            }
            else
            {
                lstboxHelp.Visible = true;
                isHelpPressed = true;
            }
        }

        private void lstboxHelp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}