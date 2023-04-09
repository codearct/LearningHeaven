﻿using Polly;
using Polly.Retry;

namespace Order.Services.FaultPolicies
{
    public static class RetryPolicies
    {
        public static RetryPolicy GetCustomRetryPolicy(IRetryPolicyConfig config)
        {
            return PolicyBuilders.GetCustomBuilder()
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