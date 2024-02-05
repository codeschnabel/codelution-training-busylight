using MorseCode.Contracts;
using System.Media;
using System.Net.Http;

namespace MorseCode
{
    public class LightMorseAdapter : IMorseAdapter
    {
        private readonly HttpClient httpClient;

        public LightMorseAdapter(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task MorseAsync(IEnumerable<Symbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                await this.httpClient.GetAsync($"http://localhost:8989/?action=light&red={symbol.Red}&green={symbol.Green}&blue={symbol.Blue}");
                //Thread.Sleep(symbol.DurationInMilliseconds);
                await Task.Delay(symbol.DurationInMilliseconds);
            }
        }
    }
}