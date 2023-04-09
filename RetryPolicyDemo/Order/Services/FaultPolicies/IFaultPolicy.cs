namespace Order.Services.FaultPolicies
{
    public interface IFaultPolicy
    {
        TResult Execute<TResult>(Func<TResult> action);
    }
}
