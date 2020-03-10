using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Calculator.Classes;

namespace Calculator
{
    public partial class Form1 : Form
    {
        internal class Keybord
        { 
            public Dictionary<string, Func<decimal, decimal, decimal>> dicFunc;
            
            public Keybord()
            {
                dicFunc = new Dictionary<string, Func<decimal, decimal, decimal>>();
                Func<decimal, decimal, decimal> op = Calculator.Classes.Operations.addition;
                dicFunc.Add("+", Calculator.Classes.Operations.addition);
                dicFunc.Add("-", Calculator.Classes.Operations.subtraction);
                dicFunc.Add("/", Calculator.Classes.Operations.division);
                dicFunc.Add("*", Calculator.Classes.Operations.multiplication);
            }

        }

        Keybord Kbord;
        string operation;
        decimal? operator1;
        decimal? operator2;

        public Form1()
        {
            Kbord = new Keybord();
            InitializeComponent();
        }


        
        
        
        
        private void equalsButt_Click(object sender, EventArgs e)
        {
            try
            {
                operator2 = decimal.Parse(inTextBox.Text);
                resultLabel.Text = Kbord.dicFunc[operation]((decimal)operator1, (decimal)operator2).ToString();
                inTextBox.Text = " ";
                operator1 = null;
                operator2 = null;
            } catch (FormatException)
            {
                inTextBox.Text = " ";
            }
            catch (ArgumentNullException)
            {
                inTextBox.Text = " ";
            }
        }

        #region numbers buttons
        private void ButtNumber(int number) => inTextBox.Text += number.ToString();
        private void butt1_Click_1(object sender, EventArgs e) => ButtNumber(1);
        private void butt2_Click(object sender, EventArgs e) => ButtNumber(2);
        private void butt3_Click(object sender, EventArgs e) => ButtNumber(3);
        private void butt4_Click(object sender, EventArgs e) => ButtNumber(4);
        private void butt5_Click(object sender, EventArgs e) => ButtNumber(5);
        private void butt6_Click(object sender, EventArgs e) => ButtNumber(6);
        private void butt7_Click(object sender, EventArgs e) => ButtNumber(7);
        private void butt8_Click(object sender, EventArgs e) => ButtNumber(8);
        private void butt9_Click(object sender, EventArgs e) => ButtNumber(9);
        #endregion

        private void CButt_Click(object sender, EventArgs e) => inTextBox.Text = " ";

        private void ACButt_Click(object sender, EventArgs e)
        {
            operation = null;
            inTextBox.Text = " ";
            resultLabel.Text = 0.ToString();
            operator1 = null;
            operator2 = null;
        }


        #region operators buttons
        private void ButtOperator(string operation)
        {
            try
            {
                operator1 = decimal.Parse(inTextBox.Text);
                this.operation = operation;
                inTextBox.Text = " ";
            }
            catch (FormatException)
            {
                if(inTextBox.Text == " ")
                    operator1 = decimal.Parse(resultLabel.Text);
                inTextBox.Text = " ";
                Console.WriteLine($"operator1: {operator1} \n operator2: {operator2}");
            }


        }
        private void plusButt_Click(object sender, EventArgs e) => ButtOperator("+");
        private void subButt_Click(object sender, EventArgs e) => ButtOperator("-");
        private void multButt_Click(object sender, EventArgs e) => ButtOperator("*");
        private void divButt_Click(object sender, EventArgs e) => ButtOperator("/");
        #endregion
    }
}
