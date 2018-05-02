using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = new int[5] { 1, 3, 6, 2, 5 };
            int j = 1;
            bool isExists=false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (!isExists)
                {
                    //if (j <= arr.Length - 1 && (i + j) < arr.Length)
                    //{
                    //    if (arr[i] + arr[i + j] == 8)
                    //    {
                    //        isExists = true;
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        i = i - 1;
                    //        j++;
                    //    }
                    //}
                    //else
                    //{
                    //    j = i + 1;
                    //}
                }
            }

            if (isExists)
                label1.Text = "Numbers Exists";
            else
                label1.Text = "Numbers Does not Exists";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
