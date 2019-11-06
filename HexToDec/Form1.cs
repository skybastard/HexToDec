using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculationItems;

namespace HexToDec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        HexToDecimal converter = new HexToDecimal();

        public string[] populateInputArray()
        {
            string rawInput = inputTextBox.Text;
            // check for hex elements only
            
            string[] splitInput = rawInput.Split(' ');
            return splitInput;
        }

        public bool HexInStringCStyle(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");
        }

        public bool HexInStringNormal(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0 - 9a - fA - F] +\b\Z");
        }

        public void convertToDecimal(string[] input)
        {
            string output = "";
            foreach(var item in input)
            {
                //check for clean hex inputs
                if (HexInStringCStyle(item) || HexInStringNormal(item))
                {
                    int answer = Convert.ToInt32(item, 16);
                    outputTextBox.AppendText(answer + " ");
                }
                else
                {
                    outputTextBox.AppendText($" >>>Bad Format>>>{ item }<<<");
                }
                //Convert.ToInt64(hexValue, 16);
                
            }
            
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            
            convertToDecimal(populateInputArray());
        }

        private void copyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputTextBox.Text);
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            outputTextBox.Clear();
        }
    }
}
