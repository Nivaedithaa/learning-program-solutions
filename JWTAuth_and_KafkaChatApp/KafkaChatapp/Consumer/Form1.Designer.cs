using System.Windows.Forms;

namespace Consumer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtReceivedMessages;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtReceivedMessages = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();

            this.txtReceivedMessages.Location = new System.Drawing.Point(12, 41);
            this.txtReceivedMessages.Multiline = true;
            this.txtReceivedMessages.ReadOnly = true;
            this.txtReceivedMessages.ScrollBars = ScrollBars.Vertical;
            this.txtReceivedMessages.Size = new System.Drawing.Size(776, 397);

            this.lblStatus.Location = new System.Drawing.Point(12, 17);
            this.lblStatus.Text = "Initializing Consumer...";

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtReceivedMessages);
            this.Text = "Kafka Consumer";
        }
    }
}
