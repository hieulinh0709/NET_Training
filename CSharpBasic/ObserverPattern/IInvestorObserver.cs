namespace ObserverPattern
{
    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    public interface IInvestorObserver
    {
        void Update(Stock stock);
    }
}
