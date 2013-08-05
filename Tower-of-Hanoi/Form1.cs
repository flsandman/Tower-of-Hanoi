//  Computational Complexity
//  Florida Institute Of Technology
//  Fall 2010
//  Samuel Barlow

using System;
using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;

namespace CC_Proj_1
{
    public partial class Form1 : Form
    {
        int moves = 0;
        int times = 0;
        string outputS = "";

        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Tower af Hanoi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize variables
            int temp;
            moves = 0;
            times = 0;
            outputS = "";

            
            // Get the number of discs
            int disc = (int)numDisc.Value;
            
            // Initialize the stacks
            Stack<int> s1 = new Stack<int>(disc);
            Stack<int> s2 = new Stack<int>(disc);
            Stack<int> s3 = new Stack<int>(disc);
            s1.Push(0);
            s2.Push(0);
            s3.Push(0);

            // Populate the first stack
            for(int x = disc; x > 0; x--)
            {
                s1.Push(x);
            }

            // Start the clock
            DateTime startTime = DateTime.Now;

            // Call recursive algorithm to solve tower
            move(s1, s3, s2, '1', '3', '2', disc);
            
            // Stop the clock
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;


            // Output Results
            output.Text += outputS;
            output.Text += "\r\n\r\nResults:\r\n";
            output.Text += "Total moves = " + moves;
            output.Text += "\r\nrecursion calls : " + times;
            output.Text += "\r\nTotal time = " + duration.Minutes + " minutes " + duration.Seconds + " seconds " + duration.Milliseconds + " milliseconds ";
            output.Text += "\r\nColumn 3:" ;
            for (int x = 0; x < disc; x++)
            {
                temp= s3.Pop();
                output.Text += "\r\n" + temp;
            }
            
            
        } // end

        // **************************************************************************
        // Recursive algorithm, to solve hanoi puzzle                               *
        // Algorithm modified from: http://www.dreamincode.net/code/snippet474.htm  *
        // **************************************************************************
        void move(Stack<int> s1, Stack<int> s3, Stack<int> s2, char a, char c, char b, int disc) //, int last)
        {
            int temp;
            times++;
            if (disc > 0)
            {  
                move(s1, s2, s3, a, b, c, disc-1);
                outputS = outputS + "\r\r\n Move " + disc + " from " + a + " to " + c;
                moves++;
                temp = s1.Pop();
                s3.Push(temp);
                move(s2, s3, s1, b, c, a, disc-1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
