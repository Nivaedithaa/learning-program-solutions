using System;
using System.Windows.Forms;
using Confluent.Kafka;
using System.Threading.Tasks;

namespace Consumer
{
    public partial class Form1 : Form
    {
        private ConsumerConfig _consumerConfig;
        private IConsumer<Ignore, string> _consumer;

        private const string KafkaBootstrapServers = "localhost:9092";
        private const string KafkaConsumerGroupId = "my_consumer_group";
        private const string KafkaTopic = "your-topic-name"; // ✅

        public Form1()
        {
            InitializeComponent();
            InitializeKafkaConsumer();
        }

        private void InitializeKafkaConsumer()
        {
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = KafkaBootstrapServers,
                GroupId = KafkaConsumerGroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                _consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig)
                    .SetErrorHandler((c, e) =>
                    {
                        if (e.IsFatal)
                            MessageBox.Show($"Fatal Kafka error: {e.Reason}");
                    }).Build();

                _consumer.Subscribe(KafkaTopic); // ✅ KEY LINE

                Task.Run(() => ConsumeMessages());

                lblStatus.Text = $"Listening to topic: {KafkaTopic}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Kafka consumer: {ex.Message}");
                lblStatus.Text = "Consumer failed.";
            }
        }

        private void ConsumeMessages()
        {
            try
            {
                while (_consumer != null)
                {
                    var consumeResult = _consumer.Consume(TimeSpan.FromSeconds(1));

                    if (consumeResult?.Message?.Value != null)
                    {
                        string receivedMessage = consumeResult.Message.Value;
                        if (txtReceivedMessages.InvokeRequired)
                        {
                            txtReceivedMessages.Invoke(new Action(() =>
                            {
                                txtReceivedMessages.AppendText($"Received: {receivedMessage}{Environment.NewLine}");
                            }));

                        }
                        else
                        {
                            txtReceivedMessages.AppendText($"Received: {receivedMessage}{Environment.NewLine}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during consumption: {ex.Message}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { _consumer?.Close(); } catch { }
            _consumer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
