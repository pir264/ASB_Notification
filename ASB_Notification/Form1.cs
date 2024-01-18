using Microsoft.Toolkit.Uwp.Notifications;

namespace ASB_Notification
{
    public partial class Form1 : Form
    {
        bool isLoaded = false;
        string conversationId = "4613BEB0-75E5-414C-9533-1BAB2FDA90F3";
        string headerId = "6E9051FF-B7EF-477E-A25F-DEDE8C6BA409";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var messages = GetMessages();
            foreach (var message in messages)
            {
                new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", conversationId)
            .AddHeader(headerId, "Home Assistent send you a notification", "")
            .AddText(message)

            .SetToastDuration(ToastDuration.Long)
            .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater

            }
        }

        private List<string> GetMessages()
        {
            return new List<string> { "aaa", "bbb" };
        }
    }
}
