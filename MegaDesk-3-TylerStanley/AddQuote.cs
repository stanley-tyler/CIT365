using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;

namespace MegaDesk_3_TylerStanley
{
    public partial class AddQuote : Form
    {
        
        int width = 0;
        int depth = 0;
        int drawers = 0; //number of desk drawers
        int price = 0;
        int materialCost = 0;
        int rushCost = 0;
        string material;
        string customerName;
        string rushOrder;
        string[] lines = new string[7];
        
        

        public AddQuote()
        {
            InitializeComponent();
        }

        //parses the users input data
        private void submit_Click(object sender, EventArgs e)
        {
            try
            {

                width = int.Parse(widthTextBox.Text);
                depth = int.Parse(depthTextBox.Text);
                drawers = int.Parse(numDrawersTextBox.Text);
                material = materialTextBox.Text;
                customerName = customerNameTextBox.Text;
                rushOrder = rushOrderOptionTextBox.Text;

                switch (rushOrder)
                {
                    case "3 day":
                        rushCost = 60;
                        break;
                    case "5 day":
                        rushCost = 40;
                        break;
                    case "7 day":
                        rushCost = 30;
                        break;
                    default:
                        break;
                }

                switch (material)
                {
                    case "Oak":
                        materialCost = 200;
                        break;
                    case "Laminate":
                        materialCost = 100;
                        break;
                    case "Pine":
                        materialCost = 50;
                        break;
                    case "Rosewood":
                        materialCost = 300;
                        break;
                    case "Veneer":
                        materialCost = 125;
                        break;
                    default:
                        MessageBox.Show("No Material Selected");
                        break;

                }

                price = ((200 + (width * depth) + (50 * drawers)) + materialCost) + rushCost;
                string priceString = price.ToString();
                lines[4] = widthTextBox.Text;
                lines[1] = depthTextBox.Text;
                lines[2] = numDrawersTextBox.Text;
                lines[3] = materialTextBox.Text;
                lines[5] = rushOrderOptionTextBox.Text;
                lines[6] = priceString;
                lines[0] = customerNameTextBox.Text;


                string csv = string.Format("{0},{1},{2},{3},{4},{5},{6}\n", lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6]);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Quotes.txt", csv);
            }
            catch(Exception)
            {
                throw;
            }
            

    }

        private void ValidateWidthInput(object sender, CancelEventArgs e)
        {
            int w;            
            if (int.TryParse(widthTextBox.Text, out w))
            {
                if (w > 96 || w < 24)
                {
                    widthTextBox.Text = "";
                    MessageBox.Show("Please enter a value between 24 and 96 inches");
                    widthTextBox.Focus();
                }
            }           
        }

        private void ValidateNumofDrawers(object sender, CancelEventArgs e)
        {

        }

        private void ValidateName(object sender, CancelEventArgs e)
        {

        }

        private void ValidateDepthInput(object sender, KeyPressEventArgs e)
        {
            int d;
            if (int.TryParse(depthTextBox.Text, out d))
            {
                if (d > 48 || d < 12)
                {
                 
                    
                }
                
            }
        }
    }
}
