using Hangfire.Firebird;
using Hangfire.Firebird.Msmq;
using Hangfire.States;

// ReSharper disable once CheckNamespace

namespace Hangfire
{
    public static class MsmqFirebirdExtensions
    {
        public static IGlobalConfiguration<FirebirdStorage> UseMsmqQueues(
            this IGlobalConfiguration<FirebirdStorage> configuration,
            string pathPattern,
            params string[] queues)
        {
            if (queues.Length == 0)
            {
                queues = new[] { EnqueuedState.DefaultQueue };
            }

            var provider = new MsmqJobQueueProvider(pathPattern, queues);
            configuration.Entry.QueueProviders.Add(provider, queues);

            return configuration;
        }

        public static IGlobalConfiguration<FirebirdStorage> UseMsmqQueues(
            this IGlobalConfiguration<FirebirdStorage> configuration,
            string pathPattern)
        {
            return UseMsmqQueues(configuration, pathPattern, new[] { EnqueuedState.DefaultQueue });
        }
    }
}
