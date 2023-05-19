using Polly;
using Polly.Retry;

namespace Order.Services.FaultPolicies.Polly
{
    public static class RetryPolicies
    {
        public static RetryPolicy GetRetryPolicy(IRetryPolicyConfig config)
        {
            return PolicyBuilders.GetCustomBuilder()
                    .WaitAndRetry(config.RetryCount,
                                  ComputeDuration,
                                  (result, timeSpan, retryCount, context) =>
                                  {
                                      OnCustomRetry(result, timeSpan, retryCount);
                                  });
        }

        public static RetryPolicy GetHttpRequestRetryPolicy(IRetryPolicyConfig config)
        {
            return PolicyBuilders.GetHttpFailureBuilder()
                    .WaitAndRetry(config.RetryCount,
                                  ComputeDuration,
                                  (result, timeSpan, retryCount, context) =>
                                  {
                                      OnCustomRetry(result, timeSpan, retryCount);
                                  });
        }
        private static void OnCustomRetry(Exception result, TimeSpan timeSpan, int retryCount)
        {
            if (result != null)
                Console.WriteLine($"Request failed with --{result.Message}--.Waiting {timeSpan} before next retry.Retry attempt {retryCount}");
            else
                Console.WriteLine($"Request failed with unknown reason.Waiting {timeSpan} before next retry.Retry attempt {retryCount}");
        }
        private static TimeSpan ComputeDuration(int input)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
        }
    }
}
