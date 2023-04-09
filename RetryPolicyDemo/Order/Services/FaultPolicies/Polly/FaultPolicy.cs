using Polly;

namespace Order.Services.FaultPolicies.Polly
{
    public class FaultPolicy : IFaultPolicy
    {
        private readonly ISyncPolicy _policy;

        public FaultPolicy(ISyncPolicy policy)
        {
            _policy = policy;
        }

        public TResult Execute<TResult>(Func<TResult> action)
        {
            return _policy.Execute(action);
        }
    }
}
