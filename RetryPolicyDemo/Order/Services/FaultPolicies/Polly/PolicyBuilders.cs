using Polly;

namespace Order.Services.FaultPolicies.Polly
{
    public static class PolicyBuilders
    {
        public static PolicyBuilder GetCustomBuilder()
        {
            return Policy.Handle<Exception>();
        }
    }
}
