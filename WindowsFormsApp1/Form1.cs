using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private readonly UserActivityHook _actHook;

        private void LogWrite(string txt)
        {
            richTextBox1.AppendText(txt + Environment.NewLine);
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        public Form1()
        {
            InitializeComponent();

            _actHook = new UserActivityHook(true, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            _actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            _actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            _actHook.KeyUp += new KeyEventHandler(MyKeyUp);
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            Text = string.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);

            if (e.Clicks > 0)
            {
                LogWrite("MouseButton 	- " + e.Button.ToString());
            }
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            LogWrite("KeyDown 	- " + e.KeyData.ToString());
        }

        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            LogWrite("KeyPress 	- " + e.KeyChar);
        }

        private void MyKeyUp(object sender, KeyEventArgs e)
        {
            LogWrite("KeyUp 		- " + e.KeyData.ToString());
        }

    }
}
