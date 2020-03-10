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
            }

        }


        bool Empty;
        Keybord Kbord;
        public Form1()
        {
            Empty = true;
            Kbord = new Keybord();
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tabel1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtNumber(int number)
        {
            if (Empty)
            {
                inTextBox.Text = number.ToString();
                Empty = false;
            }
            else
                inTextBox.Text += number.ToString();
        }

        private void butt1_Click_1(object sender, EventArgs e)
        {
            ButtNumber(1);
        }
    }
}
