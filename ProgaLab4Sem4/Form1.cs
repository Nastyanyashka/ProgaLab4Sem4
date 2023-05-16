using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace ProgaLab4Sem4
{
    public partial class Form1 : Form
    {
        Socket tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int port = 49002;
        string currentPath = "";
        bool txtFile = false;
        public Form1()
        {
            InitializeComponent();
        }
        async private void Connect_Click(object sender, EventArgs e)
        {
            await tcpSocket.ConnectAsync(IPAddress.Parse(ipAddress_textBox.Text), port);
            await tcpSocket.SendAsync(Encoding.UTF8.GetBytes("SomeSecretWord"));
            Connect.Enabled = false;
            Disconnect.Enabled = true;
            transefToServerButton.Enabled = true;
            byte[] data = new byte[512];
            int bytes = await tcpSocket.ReceiveAsync(data);
            string response = Encoding.UTF8.GetString(data, 0, bytes);
            string drive = "";
            for (int i = 0; i < response.Length; i++)
            {
                if (response[i] == ' ')
                {
                    comboBox1.Items.Add(drive);
                    drive = "";
                }
                else
                {
                    drive += response[i];
                }
            }
            label3.Text = "Подключен к серверу";


        }

        async private void Disconnect_Click(object sender, EventArgs e)
        {
            tcpSocket.Shutdown(SocketShutdown.Both);
            await tcpSocket.DisconnectAsync(true);
            Connect.Enabled = true;
            Disconnect.Enabled = false;
            label3.Text = "Нет подключения к серверу";
        }

        async private void transefToServerButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 && comboBox1.SelectedItem.ToString() != "")
            {
                currentPath += comboBox1.SelectedItem.ToString();
                await tcpSocket.SendAsync(Encoding.UTF8.GetBytes(currentPath));

            }
            else if (listBox1.SelectedItem.ToString().Contains(".txt"))
            {
                await tcpSocket.SendAsync(Encoding.UTF8.GetBytes(currentPath+listBox1.SelectedItem.ToString()));
                txtFile = true;
            }
            else
            {
                currentPath += listBox1.SelectedItem.ToString();
                await tcpSocket.SendAsync(Encoding.UTF8.GetBytes(currentPath));
            }
            transefToServerButton.Enabled = false;
            transferToClientButton.Enabled = true;
        }

        private async void transferToClientButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            int bytes = await tcpSocket.ReceiveAsync(data);
            string response = Encoding.UTF8.GetString(data, 0, bytes);
            string item = "";
            if (txtFile == true)
            {
                txtFile = false;
                textBox2.Text = response;
            }
            else
            {
                listBox1.Items.Clear();
                for (int i = 0; i < response.Length; i++)
                {
                    if (response[i] == ' ')
                    {
                        listBox1.Items.Add(item);
                        item = "";
                    }
                    else
                    {
                        item += response[i];
                    }
                }
            }
            transefToServerButton.Enabled = true;
            transferToClientButton.Enabled = false;
        }

    }
}