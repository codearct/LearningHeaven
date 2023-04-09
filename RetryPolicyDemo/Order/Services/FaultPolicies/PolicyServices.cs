using Polly;
using Polly.Retry;

namespace Order.Services.FaultPolicies
{
    public static class PolicyServices
    {
        public static void AddCustomPolicyService(this IServiceCollection services, string policySectionName,IConfiguration configuration)
        {
            var policyConfig = new PolicyConfig();
            configuration.Bind(policySectionName, policyConfig);

            var retryPolicyConfig = (IRetryPolicyConfig)policyConfig;

            services.AddRetryPolicyHandler(retryPolicyConfig);
        }
        public static void AddRetryPolicyHandler(this IServiceCollection services,IRetryPolicyConfig config)
        {
            services.AddSingleton<ISyncPolicy>(RetryPolicies.GetCustomRetryPolicy(config));
        }
    }

}
