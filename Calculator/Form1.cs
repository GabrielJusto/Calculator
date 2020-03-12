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
        internal class Keyboard
        { 
            public Dictionary<string, Func<decimal, decimal, decimal>> dicFunc;
            
            public Keyboard()
            {
                dicFunc = new Dictionary<string, Func<decimal, decimal, decimal>>();
                Func<decimal, decimal, decimal> op = Calculator.Classes.Operations.addition;
                dicFunc.Add("+", Calculator.Classes.Operations.addition);
                dicFunc.Add("-", Calculator.Classes.Operations.subtraction);
                dicFunc.Add("/", Calculator.Classes.Operations.division);
                dicFunc.Add("*", Calculator.Classes.Operations.multiplication);
            }

        }

        Keyboard kbord;
        string operation;
        decimal operator1;
        decimal operator2;
        bool dec;
       

        public Form1()
        {
            kbord = new Keyboard();
            dec = false;
            InitializeComponent();
        }


        private void equalsButt_Click(object sender, EventArgs e)
        {
            try
            {
                dec = false;
                operator2 = decimal.Parse(inLabel.Text);
                resultLabel.Text = kbord.dicFunc[operation](operator1, operator2).ToString();
                inLabel.Text = "";
                opLabel.Text = "";
            } catch (FormatException)
            {
                inLabel.Text = "";
            }
            catch (ArgumentNullException)
            {
                inLabel.Text = "";
            }catch (OverflowException)
            {
                resultLabel.Text = "Overflow";
            }
        }

        private void CButt_Click(object sender, EventArgs e) => inLabel.Text = "";

        private void ACButt_Click(object sender, EventArgs e)
        {
            operation = null;
            inLabel.Text = "";
            resultLabel.Text = 0.ToString();
            dec = false;
            opLabel.Text = "";
        }


        private void signalInvButt_Click(object sender, EventArgs e)
        {
            decimal aux = decimal.Parse(resultLabel.Text.ToString());
            aux = -aux;
            resultLabel.Text = aux.ToString();
        }

        private void decimalButt_Click(object sender, EventArgs e)
        {
            if (inLabel.Text.Length < 8 && !dec)
                inLabel.Text += ".";
            dec = true;
        }



        #region numbers buttons
        private void ButtNumber(int number)
        {
            string decPart;
            if(inLabel.Text.Contains('.'))
            {
                decPart = inLabel.Text.Split('.')[1];
                Console.WriteLine($"number size: {inLabel.Text.Length}"); 
                Console.WriteLine($"decimal size: {decPart.Length}");
                if (inLabel.Text.Length < 9 && decPart.Length < 3)
                {
                    inLabel.Text += number.ToString();
                    Console.WriteLine("cheguei aqui");
                }      
            }else if (inLabel.Text.Length < 8)
                inLabel.Text += number.ToString();
        }
        private void butt1_Click_1(object sender, EventArgs e) => ButtNumber(1);
        private void butt2_Click(object sender, EventArgs e) => ButtNumber(2);
        private void butt3_Click(object sender, EventArgs e) => ButtNumber(3);
        private void butt4_Click(object sender, EventArgs e) => ButtNumber(4);
        private void butt5_Click(object sender, EventArgs e) => ButtNumber(5);
        private void butt6_Click(object sender, EventArgs e) => ButtNumber(6);
        private void butt7_Click(object sender, EventArgs e) => ButtNumber(7);
        private void butt8_Click(object sender, EventArgs e) => ButtNumber(8);
        private void butt9_Click(object sender, EventArgs e) => ButtNumber(9);
        private void butt0_Click(object sender, EventArgs e) => ButtNumber(0);
        #endregion

        #region operators buttons
        private void ButtOperator(string operation)
        {
            try
            {
                dec = false;
                operator1 = decimal.Parse(inLabel.Text);
                this.operation = operation;
                inLabel.Text = "";
                opLabel.Text = operation;
                resultLabel.Text = operator1.ToString();
            }
            catch (FormatException)
            {
                if(inLabel.Text == "")
                {
                    operator1 = decimal.Parse(resultLabel.Text);
                    this.operation = operation;
                    opLabel.Text = operation;
                }
                    inLabel.Text = "";
            }


        }
        private void plusButt_Click(object sender, EventArgs e) => ButtOperator("+");
        private void subButt_Click(object sender, EventArgs e) => ButtOperator("-");
        private void multButt_Click(object sender, EventArgs e) => ButtOperator("*");
        private void divButt_Click(object sender, EventArgs e) => ButtOperator("/");





        #endregion

    }
}
