using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Polly;
using Polly.Registry;
using Polly.Retry;

namespace Order.Services.FaultPolicies.Polly
{
    public static class PolicyServices
    {
        public static void AddPolicyService(this IServiceCollection services, string policySectionName, IConfiguration configuration)
        {
            var policyConfig = new PolicyConfig();
            configuration.Bind(policySectionName, policyConfig);

            var retryPolicyConfig = (IRetryPolicyConfig)policyConfig;

            services.AddRetryPolicyHandler(retryPolicyConfig);
            services.AddHttpFailureRetryPolicyHandler(retryPolicyConfig);
        }
        public static void AddRetryPolicyHandler(this IServiceCollection services, IRetryPolicyConfig config)
        {
            services.AddSingleton<ISyncPolicy>(RetryPolicies.GetRetryPolicy(config));
        }
        public static void AddHttpFailureRetryPolicyHandler(this IServiceCollection services, IRetryPolicyConfig config)
        {
            services.AddSingleton<ISyncPolicy>(RetryPolicies.GetHttpRequestRetryPolicy(config));
        }
    }
}
