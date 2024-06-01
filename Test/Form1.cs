using Binance.Net.Clients;
using Binance.Net.Clients.SpotApi;
using Bitget.Net.Clients;
using Bybit.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Kucoin.Net.Clients;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;


namespace Test
{
    public partial class Form1 : Form
    {
        //BinanceRestClient client;
        string BT_Binance = "BTCUSDT";
        string BT_Kucoin = "BTC-USDT";
        string BT_Bitget = "BTCUSDT_SPBL";
        
        private string[] imagePaths = { "BU.jpg", "EU.jpg", "PU.jpg" };

        private string[] coin = { "BTCUSDT", "BTC-USDT", "BTCUSDT_SPBL", "ETHUSDT", "ETH-USDT", "ETHUSDT_SPBL", "MATICUSDT", "MATIC-USDT", "MATICUSDT_SPBL" };

        public int coinCount = 0;
        public int coinCount1 = 1;
        public int coinCount2 = 2;
        public Form1()
        {
            InitializeComponent();

            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start(); // Начать таймер

            
            
            ImageLoad();
        }



        private void ImageLoad()
        {
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", "BU.jpg"));
            pictureBox2.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", "one.png"));
            pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", "two.jpg"));
            pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", "three.png"));
            pictureBox5.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", "four.jpg"));

        }

        private async void UpdateQuote()
        {
            // Ваш асинхронный метод для получения котировки BTCUSDT
            string quote = await GetBtcUsdtQuote(coinCount);
            string quote1 = await GetBtcUsdtQuote1(coinCount);
            string quote2 = await GetBtcUsdtQuote2(coinCount1);
            string quote3 = await GetBtcUsdtQuote3(coinCount2);
            // Обновление label с полученными данными
            label3.Text = quote;
            label4.Text = quote1;
            label5.Text = quote2;
            label6.Text = quote3;
        }

        private async Task<string> GetBtcUsdtQuote(int a)
        {
            // Ваш код для запроса и получения котировки с Binance.net
            // Здесь вам нужно вызвать свой метод для подключения к Binance и получения данных
            var client = new BinanceRestClient();
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync(coin[a]);
            var lastprice = ticker.Data.LastPrice;

            // Возвращаем полученные данные (для примера возвращаем фейковые данные)
            return lastprice.ToString()+"usdt"; // Пример значения котировки
        }

        private async Task<string> GetBtcUsdtQuote1(int a)
        {
            // Ваш код для запроса и получения котировки с Binance.net
            // Здесь вам нужно вызвать свой метод для подключения к Binance и получения данных
            var restClient = new BybitRestClient();
            var tickerResult = await restClient.V5Api.ExchangeData.GetSpotTickersAsync(coin[a]);
            var lastprice = tickerResult.Data.List.First().LastPrice;


            // Возвращаем полученные данные (для примера возвращаем фейковые данные)
            return lastprice.ToString() + "usdt"; // Пример значения котировки
        }
        private async Task<string> GetBtcUsdtQuote2(int a)
        {
            // Ваш код для запроса и получения котировки с Binance.net
            // Здесь вам нужно вызвать свой метод для подключения к Binance и получения данных
            var restClient = new KucoinRestClient();
            var tickerResult = await restClient.SpotApi.ExchangeData.GetTickerAsync(coin[a]);
            var lastprice = tickerResult.Data.LastPrice;


            // Возвращаем полученные данные (для примера возвращаем фейковые данные)
            return lastprice.ToString() + "usdt"; // Пример значения котировки
        }
        private async Task<string> GetBtcUsdtQuote3(int a)
        {
            // Ваш код для запроса и получения котировки с Binance.net
            // Здесь вам нужно вызвать свой метод для подключения к Binance и получения данных
            var restClient = new BitgetRestClient();
            var tickerResult = await restClient.SpotApi.ExchangeData.GetTickerAsync(coin[a]);
            var lastprice = tickerResult.Data.ClosePrice;


            // Возвращаем полученные данные (для примера возвращаем фейковые данные)
            return lastprice.ToString()+"usdt"; // Пример значения котировки
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            UpdateQuote();
        }

        

        private void Listcoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (listcoin.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", imagePaths[0]));
                    
                    coinCount = 0;
                    coinCount1 = 1;
                    coinCount2 = 2;

                    break;
                case 1:
                    pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", imagePaths[1]));
                    

                    coinCount = 3;
                    coinCount1 = 4;
                    coinCount2 = 5;
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Assets", imagePaths[2]));
                    

                    coinCount = 6;
                    coinCount1 = 7;
                    coinCount2 = 8;
                    break;

            }
            


        }
    }

}

