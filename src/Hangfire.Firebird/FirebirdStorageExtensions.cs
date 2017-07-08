using Hangfire.Annotations;
using System;

namespace Hangfire.Firebird
{
    public static class FirebirdStorageExtensions
    {
        public static IGlobalConfiguration<FirebirdStorage> UseFirebirdStorage(
            [NotNull] this IGlobalConfiguration configuration,
            [NotNull] string nameOrConnectionString)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (nameOrConnectionString == null) throw new ArgumentNullException("nameOrConnectionString");

            var storage = new FirebirdStorage(nameOrConnectionString);
            return configuration.UseStorage(storage);
        }

        public static IGlobalConfiguration<FirebirdStorage> UseFirebirdStorage(
            [NotNull] this IGlobalConfiguration configuration,
            [NotNull] string nameOrConnectionString,
            [NotNull] FirebirdStorageOptions options)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (nameOrConnectionString == null) throw new ArgumentNullException("nameOrConnectionString");
            if (options == null) throw new ArgumentNullException("options");

            var storage = new FirebirdStorage(nameOrConnectionString, options);
            return configuration.UseStorage(storage);
        }
    }
}
