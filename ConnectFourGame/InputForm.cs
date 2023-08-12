using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class InputForm : Form
    {
        public string PlayerName { get; private set; }
        public InputForm()
        {
            InitializeComponent();
        }

        public int getID()
        {
            
            return int.Parse(textBox2.Text);
        }

        public string GetName()
        {
            return textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the player name entered by the user
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Show an error message if the input is empty or contains only whitespace
                MessageBox.Show("Name should contain at least one character.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
