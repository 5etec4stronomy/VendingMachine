namespace VendingMachine
{
    public class MatchedCoinResult
    {
        public Coin Coin { get; set; }
        public bool ValidCoin => Coin != null;
    }
}
