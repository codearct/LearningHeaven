namespace Order.Services.FaultPolicies
{
    public interface IFaultPolicy
    {
        TResult Retry<TResult>(Func<TResult> action);
    }
}
