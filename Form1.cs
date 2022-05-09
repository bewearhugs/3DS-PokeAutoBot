using System.Net;
using System;
using System.Text;
using System.IO;
using PKHeX.Core;
using System.Net.Sockets;
using static _3DS_link_trade_bot.dsbotbase;
using static _3DS_link_trade_bot.Program;
using static _3DS_link_trade_bot.NTRClient;
using static _3DS_link_trade_bot.dsbotbase.Buttons;


namespace _3DS_link_trade_bot
{
    public partial class Form1 : Form
    {
   

        public Form1()
        {
            InitializeComponent();
        }



        public static NTRClient ntr = new();
        public static Socket Connection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,0);
        public static Socket Connection2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);

        private void consoleconnect_Click(object sender, EventArgs e)
        {
            ntr.Connect();
            if (clientNTR.IsConnected)
                ChangeStatus("ntr connected");
            Connection.Connect(Program.form1.IpAddress.Text, 4950);
            if (Connection.Connected)
            {
                
                Log("IR Connected");
            }
            
            
        }
        public static void ChangeStatus(string text)
        {
            Program.form1.statusbox.Text = text;
            
        }
        public static void Log(string text)
        {
            Program.form1.logbox.AppendText(text + "\n");
        }

        private void logbox_TextChanged(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.IpAddress = form1.IpAddress.Text;
            Properties.Settings.Default.discordtoken = form1.discordtoken.Text;
            Properties.Settings.Default.Save();
            ntr.Disconnect();
            Application.Exit();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.IpAddress = form1.IpAddress.Text;
            Properties.Settings.Default.discordtoken = form1.discordtoken.Text;
        }

        private void startlinktrades_Click(object sender, EventArgs e)
        {
            LinkTradeBot.starttrades();
        }

        private void discordconnect_Click(object sender, EventArgs e)
        {
            var bot = new discordmain();
            bot.MainAsync();
            ChangeStatus("Connected to Discord");
            Log("Connected to Discord");
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IpAddress = form1.IpAddress.Text;
            Properties.Settings.Default.discordtoken = form1.discordtoken.Text;
            Properties.Settings.Default.Save();
        }

      
    }
}