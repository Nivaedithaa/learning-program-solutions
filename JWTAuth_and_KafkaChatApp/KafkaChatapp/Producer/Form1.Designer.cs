namespace Producer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();

            this.txtMessage.Location = new System.Drawing.Point(30, 30);
            this.txtMessage.Size = new System.Drawing.Size(400, 26);

            this.btnSend.Location = new System.Drawing.Point(450, 30);
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Text = "Kafka Sender";
        }
    }
}
