using System;
using System.Windows.Forms;
using Confluent.Kafka;

namespace Producer
{
    public partial class Form1 : Form
    {
        private ProducerConfig _producerConfig;
        private IProducer<Null, string> _producer;

        private const string KafkaBootstrapServers = "localhost:9092";
        private const string KafkaTopic = "your-topic-name";

        public Form1()
        {
            InitializeComponent();
            InitializeKafkaProducer();
        }

        private void InitializeKafkaProducer()
        {
            _producerConfig = new ProducerConfig
            {
                BootstrapServers = KafkaBootstrapServers
            };

            try
            {
                _producer = new ProducerBuilder<Null, string>(_producerConfig).Build();
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Kafka producer: {ex.Message}");
                btnSend.Enabled = false;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string messageToSend = txtMessage.Text;
            try
            {
                var deliveryReport = await _producer.ProduceAsync(KafkaTopic, new Message<Null, string> { Value = messageToSend });
                MessageBox.Show($"Message sent successfully to topic '{KafkaTopic}'!");
                txtMessage.Clear();
            }
            catch (ProduceException<Null, string> ex)
            {
                MessageBox.Show($"Failed to send message: {ex.Error.Reason}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _producer?.Flush(TimeSpan.FromSeconds(10));
            _producer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
