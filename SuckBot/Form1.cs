using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace SuckBot
{
    public partial class Form1 : Form
    {
        private static Telegram.Bot.TelegramBotClient Bot;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bot = new Telegram.Bot.TelegramBotClient("457946092:AAElfXLBKwULmApll2vSi0fXAwbM9xwa8pI");
            Bot.OnMessage += BotOnMessageReceived;
            Bot.StartReceiving(new UpdateType[] { UpdateType.MessageUpdate });
            MessageBox.Show("The bot has been started");
        }

        private static async void BotOnMessageReceived(object Sender, MessageEventArgs messageEventArgs)
        {
            Telegram.Bot.Types.Message msg = messageEventArgs.Message;
            if (msg == null || msg.Type != MessageType.TextMessage) return;

            String Answer = "";

            switch (msg.Text)
            {
                case "/start": Answer = "Greetings, my friend!"; break;
                case "/taxes": Answer = "Здесь будет список когда я подниму жопу с дивана"; break;
                default: Answer = "Не знаю такой команды :("; break;
            }

            await Bot.SendTextMessageAsync(msg.Chat.Id, Answer);
        }
    }
}
