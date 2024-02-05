namespace MorseCode.Contracts
{
    public interface IMorseAdapter
    {
        Task MorseAsync(IEnumerable<Symbol> symbols);
    }
}