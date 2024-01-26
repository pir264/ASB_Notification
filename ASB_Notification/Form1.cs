using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Text;

namespace ASB_Notification
{
    public partial class Form1 : Form
    {
        bool isLoaded = false;
        string conversationId = "4613BEB0-75E5-414C-9533-1BAB2FDA90F3";
        string headerId = "6E9051FF-B7EF-477E-A25F-DEDE8C6BA409";
        string _asbConnection = string.Empty;
        bool _deleteMessage = false;
        int _timerInterval = 60000;

        public Form1(IConfigurationRoot builder)
        {
            InitializeComponent();
            var settings = builder.GetSection("Configuration").Get<Settings>();
            _asbConnection = settings.ASB_Connectionstring;
            _deleteMessage = settings.DeleteMessage;

            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Interval = settings.TimerInterval;
            tmr.AutoReset = true;
            tmr.Enabled = true;
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Start();

        }

        private async void Tmr_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (!String.IsNullOrEmpty(_asbConnection))
            {
                var messages = await GetMessages(_asbConnection);
                foreach (var message in messages)
                {
                    new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", conversationId)
                .AddHeader(headerId, "Home Assistent send you a notification", "")
                .AddText($"{message.EnqueueDateTime.ToString("dd-MMM-yyyy HH:mm")} {message.Subject}: {message.Message}")

                .SetToastDuration(ToastDuration.Long)
                .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _asbConnection = ASBConnectionString.Text;
            _deleteMessage = cbDeleteMessage.Checked;
            _timerInterval = int.Parse(tbTimerInterval.Text) * 60000;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!isLoaded)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                isLoaded = true;
            }
        }

        private async Task<List<NotificationMessage>> GetMessages(string connectionString)
        {
            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            var _client = new ServiceBusClient(connectionString, clientOptions);

            var receiver = _client.CreateReceiver("notifications", new ServiceBusReceiverOptions
            {
                ReceiveMode = ServiceBusReceiveMode.PeekLock
            });

            var messages = await receiver.ReceiveMessagesAsync(4);
            var NotificationMessages = new List<NotificationMessage>();
            foreach (var message in messages)
            {
                NotificationMessages.Add(ProcessMessage(message));
            }

            return NotificationMessages;
        }

        private NotificationMessage ProcessMessage(ServiceBusReceivedMessage message)
        {
            return new NotificationMessage()
            {
                Subject = message.Subject,
                Message = Encoding.UTF8.GetString(message.Body),
                EnqueueDateTime = message.EnqueuedTime.DateTime

            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ASBConnectionString.Text = _asbConnection;
            cbDeleteMessage.Checked = _deleteMessage;
            tbTimerInterval.Text = (_timerInterval / 60000).ToString();
        }

        private void btnTestConnetion_Click(object sender, EventArgs e)
        {
            GetMessages(ASBConnectionString.Text);
        }
    }
}
