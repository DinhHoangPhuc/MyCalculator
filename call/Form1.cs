using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace call
{
    public partial class Form1 : Form
    {

        double result=0;
        String operation = "";
        bool enter_value = false;

        string fst, scnd,rs,a;
        double MemoryStore = 0;



        public Form1()
        {
            InitializeComponent();
        }

       

        private void numbers_Only(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;
        

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    
                    txtDisplay.Text = txtDisplay.Text + b.Text;
                a = txtDisplay.Text;
              

            }


            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
                a = txtDisplay.Text;
                
            }




        }

        private void operators_click(object sender, EventArgs e)
        {
             try
            {
            Button b = (Button)sender;

            if  (result != 0) 
            {
               
                enter_value = true;
                operation = b.Text;
                lblShowOps.Text = result + "  " + operation;

            }

          

            else
            {

                operation = b.Text;
                result = double.Parse(txtDisplay.Text);
                enter_value = true;
               
                lblShowOps.Text = result + "  "+operation; 
          
            }
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {

              try
            {

            txtDisplay.Text = a;
           
            lblShowOps.Text = "";
   
            scnd = txtDisplay.Text;
            rs = result + "";

        

            switch (operation)
            {
                case "+":

                   
                    result = (result + Double.Parse(txtDisplay.Text));
                   
                    break;
                case "-":
                   
                    result = (result - Double.Parse(txtDisplay.Text));
                    break;
                case "*":
                  
                    result = (result * Double.Parse(txtDisplay.Text));
                    break;
                case "/":
                  
                    result = (result / Double.Parse(txtDisplay.Text));
                    break;
                default:

                    break;
            }

           
           
            fst = rs + "  " + operation;

           
            txtDisplay.Text = result + "";

            }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }

           

            //

            btnclrhs.Visible = true;
            displayhs.AppendText(fst + "    " + scnd + " " + "\n");
            displayhs.AppendText("\n\t" + " = " + result + "\n\t\n");
            lbhs.Text = "";


           

        }

     

        private void btnce_Click(object sender, EventArgs e)
        {
            txtDisplay.Show();
            txtDisplay.Text = "0";
            result = 0;
            lblShowOps.Text = "";
            scnd = "0";
            rs = "0";
            a = "0";

        }



        private void btnc_Click(object sender, EventArgs e)
        {
            txtDisplay.Show();
            txtDisplay.Text = "0";
            result = 0;
            lblShowOps.Text = "";
            scnd = "0";
            rs  = "0";
           a = "0";

        }



        private void btnx_Click(object sender, EventArgs e)
        {
            txtDisplay.Show();
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);

            
            
            }
            if (txtDisplay.Text == "")
            {

                txtDisplay.Text = "0";
            
            }

        }


        private void btnclrhs_Click(object sender, EventArgs e)
        {
            displayhs.Clear();
            if (lbhs.Text == "")
            {

                lbhs.Text = "There Are No History";

            }

            btnclrhs.Visible = false;
           



        }


        //===

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //===

        private void btnmc_Click(object sender, EventArgs e)
        {
            //MC
            this.MemoryStore = 0;
            return;
        }

        private void btnmr_Click(object sender, EventArgs e)
        {
            //MR
            txtDisplay.Text = this.MemoryStore.ToString();
            return;
        }

        private void btnmpls_Click(object sender, EventArgs e)
        {
            // M+

            this.MemoryStore += double.Parse(this.txtDisplay.Text);
            return;
        }

        private void btnmns_Click(object sender, EventArgs e)
        {
            // M-

            this.MemoryStore -= double.Parse(this.txtDisplay.Text);
            return;
        }


        //====

        private void pb1_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {

                this.WindowState = FormWindowState.Minimized;

            }
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //====



        //Moving Window

        int Togmove;
        int MVX;
        int MVY;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Togmove = 1;
            MVX = e.X;
            MVY = e.Y;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (Togmove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MVX, MousePosition.Y - MVY);
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Togmove = 0;

        }
    }
}
