using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ArduLED_Clitent_Test_Program
{
    public partial class MainForm : Form
    {
        TcpClient Client = new TcpClient();

        IPAddress IPAddress = IPAddress.Parse("127.0.0.1");

        int PortNumber = 8888;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting.....");
            try
            {
                IPAddress = IPAddress.Parse(textBox3.Text);
                PortNumber = Int32.Parse(textBox4.Text);
                Client.Connect(IPAddress, PortNumber);
                textBox1.Text += Environment.NewLine + "Connected";
                textBox1.Text += Environment.NewLine + "Enter the string to be transmitted";
            }
            catch { }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Client.Connected)
            {
                String TextboxString = textBox2.Text + "$";
                Stream DataStream = Client.GetStream();
                DataStream.ReadTimeout = 1000;
                DataStream.WriteTimeout = 1000;

                ASCIIEncoding Encodings = new ASCIIEncoding();
                byte[] WriteBytes = Encodings.GetBytes(TextboxString);

                try
                {
                    textBox1.Text += Environment.NewLine + "Transmitting...";

                    DataStream.Write(WriteBytes, 0, WriteBytes.Length);

                    byte[] ReadBytes = new byte[1024];
                    int Good = DataStream.Read(ReadBytes, 0, 1024);

                    string Response = Encoding.ASCII.GetString(ReadBytes);

                    textBox1.Text += Environment.NewLine + "Response from server: " + Response;
                }
                catch
                {
                    textBox1.Text += Environment.NewLine + "Server not responding!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting.....");
            try
            {
                IPAddress = IPAddress.Parse(textBox3.Text);
                PortNumber = Int32.Parse(textBox4.Text);
                Client.Close();
                Client = new TcpClient();
                Client.Connect(IPAddress, PortNumber);
                textBox1.Text += Environment.NewLine + "Connected";
                textBox1.Text += Environment.NewLine + "Enter the string to be transmitted";
            }
            catch { }
        }
    }
}