namespace Order.Services.FaultPolicies
{
    public interface IRetryPolicyConfig
    {
        int RetryCount { get; set; }
    }
    public class PolicyConfig : IRetryPolicyConfig
    {
        public int RetryCount { get; set; }

    }
}
