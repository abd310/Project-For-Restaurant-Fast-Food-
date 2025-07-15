using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Fast_Food_Restaurant
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        float PriceFries, PriceChicken, PriceCheese, PriceSandwich,
            PriceSalads, PriceBurger, PriceTea, PriceCola, PriceWater, PricePancake
            , PriceOrangous, PriceChoco;

        float SupTotal = 0;
        float Tax;
        float PercentTax = (float)0.16;

        public float PriceEachItem(System.Windows.Forms.CheckBox check, System.Windows.Forms.TextBox textBox)
        {
            return  Convert.ToSingle(textBox.Text) * Convert.ToSingle(check.Tag);
        }


        private void button1_Click(object sender, EventArgs e)
        {
           richTextBox1.Clear();
            checkBox1.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            label4.Text = "Rs/--";
            label6.Text = "Rs/--";
            label27.Text = "Rs/--";
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text + " \nSubtotal " + label4.Text + "\n Tax: "+  label6.Text + "\nTotal " + label27.Text, new Font(" Century Gothic", 12, FontStyle.Regular), Brushes.Blue, new Point(130));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        public float CalcSupTotal()
        {
            SupTotal = 0;
            if (CheckTheCheck(checkBox1))
                SupTotal += PriceEachItem(checkBox1, textBox1);
            if (CheckTheCheck(checkBox13))
                SupTotal += PriceEachItem(checkBox13, textBox2);
            if (CheckTheCheck(checkBox14))
                SupTotal += PriceEachItem(checkBox14, textBox3);
            if (CheckTheCheck(checkBox15))
                SupTotal += PriceEachItem(checkBox15, textBox4);
            if (CheckTheCheck(checkBox16))
                SupTotal += PriceEachItem(checkBox16, textBox5);
            if (CheckTheCheck(checkBox17))
                SupTotal += PriceEachItem(checkBox17, textBox6);
            if (CheckTheCheck(checkBox18))
                SupTotal += PriceEachItem(checkBox18, textBox7);
            if (CheckTheCheck(checkBox19))
                SupTotal += PriceEachItem(checkBox19, textBox8);
            if (CheckTheCheck(checkBox20))
                SupTotal += PriceEachItem(checkBox20, textBox9);
            if (CheckTheCheck(checkBox23))
                SupTotal += PriceEachItem(checkBox23, textBox12);
            if (CheckTheCheck(checkBox22))
                SupTotal += PriceEachItem(checkBox22, textBox11);
            if (CheckTheCheck(checkBox21))
                SupTotal += PriceEachItem(checkBox21, textBox10);

            return SupTotal;
        }
        public bool CheckTheCheck(System.Windows.Forms.CheckBox check)
        {
            if(check.Checked) return true;
            else return false;
        }
        
        public void UpdateSupTotal()
        {
            label4.Text = "RS/ " + CalcSupTotal().ToString();
        }

        public void UpdateTax()
        {
            Tax = CalcSupTotal() * PercentTax;
            label6.Text = "Rs/ " + Tax.ToString();
        }

        public void UpdateTotal()
        {
            float Total = 0;
            Tax = CalcSupTotal() * PercentTax;
            Total = Tax + CalcSupTotal();
            label27.Text = "Rs/ " + Total.ToString();
        }
        public void TurnText(System.Windows.Forms.TextBox textBox)
        {
             textBox.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("\t\t\t  SNACK SHEIHA            "+ label26.Text + Environment.NewLine);
            richTextBox1.AppendText("\t\t\t***********************************" + Environment.NewLine);
            UpdateSupTotal();
            UpdateTax();
            UpdateTotal();
            if (CheckTheCheck(checkBox1))
            richTextBox1.AppendText("\t\t\t Fries: " + PriceEachItem(checkBox1, textBox1) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox13))
            richTextBox1.AppendText("\t\t\t Burger: " + PriceEachItem(checkBox13, textBox2) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox14))
            richTextBox1.AppendText("\t\t\t Salads: " + PriceEachItem(checkBox14, textBox3) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox15))
            richTextBox1.AppendText("\t\t\t Sandwich: " + PriceEachItem(checkBox15, textBox4) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox16))
            richTextBox1.AppendText("\t\t\t Chicken: " + PriceEachItem(checkBox16, textBox5) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox17))
            richTextBox1.AppendText("\t\t\t Cheese: " + PriceEachItem(checkBox17, textBox6) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox23))
            richTextBox1.AppendText("\t\t\t Tea: " + PriceEachItem(checkBox23, textBox12) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox22))
            richTextBox1.AppendText("\t\t\t Cola: " + PriceEachItem(checkBox22, textBox11) + " Rs"+ Environment.NewLine);
            if (CheckTheCheck(checkBox21))
            richTextBox1.AppendText("\t\t\t Water: " + PriceEachItem(checkBox21, textBox10) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox20))
                richTextBox1.AppendText("\t\t\t ChocoDrink: " + PriceEachItem(checkBox20, textBox9) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox19))
            richTextBox1.AppendText("\t\t\t Pancake: " + PriceEachItem(checkBox19, textBox8) + " Rs" + Environment.NewLine);
            if (CheckTheCheck(checkBox18))
            richTextBox1.AppendText("\t\t\t Orangous: " + PriceEachItem(checkBox18, textBox7) + " Rs" + Environment.NewLine);

        }

        public void TurnText(System.Windows.Forms.CheckBox checkBox,System.Windows.Forms.TextBox textBox)
        {
            if (checkBox.Checked) textBox.Enabled = true;
            else
            {
                textBox.Enabled = false;
                textBox.Text = "0";
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            TurnText(checkBox1, textBox1);
            TurnText(checkBox13, textBox2);
            TurnText(checkBox14, textBox3);
            TurnText(checkBox15, textBox4);
            TurnText(checkBox16, textBox5);
            TurnText(checkBox17, textBox6);
            TurnText(checkBox18, textBox7);
            TurnText(checkBox23, textBox12);
            TurnText(checkBox22, textBox11);
            TurnText(checkBox21, textBox10);
            TurnText(checkBox20, textBox9);
            TurnText(checkBox19, textBox8);
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }
    }
}
