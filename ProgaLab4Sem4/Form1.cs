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
        int port = 49002;
        StringBuilder currentPath = new StringBuilder();
        bool txtFile = false;
        TcpClient tcpClient;
        NetworkStream stream;
        bool fromStart = true;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        async private void Connect_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            tcpClient = new TcpClient(System.Net.Sockets.AddressFamily.InterNetwork);
            await tcpClient.ConnectAsync(IPAddress.Parse(ipAddress_textBox.Text), port);
            if (tcpClient.Connected)
                textBox2.Text = ($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено");
            else
                textBox2.Text = ("Не удалось подключиться");
            stream = tcpClient.GetStream();
            await stream.WriteAsync(Encoding.UTF8.GetBytes("SomeSecretWord"));
            Connect.Enabled = false;
            Disconnect.Enabled = true;
            transefToServerButton.Enabled = true;
            byte[] data = new byte[512];
            int bytes = await stream.ReadAsync(data);
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

        private void Disconnect_Click(object sender, EventArgs e)
        {
            tcpClient.Dispose();
            Connect.Enabled = true;
            Disconnect.Enabled = false;
            label3.Text = "Нет подключения к серверу";
        }

        private void transefToServerButton_Click(object sender, EventArgs e)
        {
            if (fromStart == true)
            {
                currentPath.Clear();
                currentPath.Append(comboBox1.SelectedItem.ToString());
                transferToServer(currentPath.ToString());
                fromStart = false;
            }
            else if (listBox1.SelectedItem.ToString().Contains(".txt"))
            {
                if (currentPath.ToString().EndsWith('\\'))
                {
                    transferToServer(currentPath.ToString() + listBox1.SelectedItem.ToString());
                }
                else
                {
                    transferToServer(currentPath.ToString() + "\\" + listBox1.SelectedItem.ToString());
                }

                txtFile = true;
            }
            else
            {
                currentPath.Append("\\"+listBox1.SelectedItem.ToString());
                transferToServer(currentPath.ToString());
            }

            transferToClient();
        }
        private async void transferToServer(string currentPath)
        {
            await stream.WriteAsync(Encoding.UTF8.GetBytes(currentPath));
        }
        private async void transferToClient()
        {
            byte[] data = new byte[10240];
            int bytes = await stream.ReadAsync(data);
            string response = Encoding.UTF8.GetString(data, 0, bytes);
            string item = "";
            bool flag = false;
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
                    if (response[i] == ':')
                    {
                        flag = true;
                    }
                    else if (response[i] == ' ' && flag)
                    {
                        listBox1.Items.Add(item);
                        item = "";
                    }
                    else
                    {
                        item += response[i];
                        flag = false;
                    }
                }
            }
        }
        private void goBack_button_Click(object sender, EventArgs e)
        {
            bool find = false;
            for (int i = currentPath.Length - 1; i >= 0; i--)
            {
                if (currentPath[i] == '\\')
                {
                    find = true;
                    currentPath.Remove(i, currentPath.Length - i);
                    if (currentPath[i - 1] == ':')
                    {
                        fromStart = true;
                    }
                    break;
                }
               
            }
            if(find == false)
            {
                return;
            }
            listBox1.SelectedItem = null;
            transferToServer(currentPath.ToString());
            transferToClient();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromStart = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromStart = false;
        }
    }
}