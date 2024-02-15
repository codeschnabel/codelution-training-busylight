// See https://aka.ms/new-console-template for more information


using MorseCode;
using MorseCode.Contracts;

var adapter = new LightMorseAdapter(new HttpClient());
//var adapter = new SoundMorseAdapter();

var symbols = new List<Symbol>()
{
    new Dit(), new Pause(), new Dit(), new Pause(), new Dit(), // S
    new Pause(), new Pause(), new Pause(),
    new Dah(), new Pause(), new Dah(), new Pause(), new Dah(), // O
    new Pause(), new Pause(), new Pause(),
    new Dit(), new Pause(), new Dit(), new Pause(), new Dit(), // S
    new Pause() // off
};

await adapter.MorseAsync(symbols);

Console.ReadLine();