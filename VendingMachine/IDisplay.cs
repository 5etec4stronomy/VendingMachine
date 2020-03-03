namespace VendingMachine
{
    public interface IDisplay
    {
        string Message { get; }

        void SetMessage(string message);
    }
}
