using System;
using System.Threading;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public static class SystemClock
    {
        private static readonly ThreadLocal<Func<DateTime>> GetDateTime =
            new ThreadLocal<Func<DateTime>>(() => () => DateTime.Now);

        /// <inheritdoc cref="DateTime.Today"/>
        public static DateTime Today => GetDateTime.Value().Date;

        /// <inheritdoc cref="DateTime.Now"/>
        public static DateTime Now => GetDateTime.Value();

        /// <inheritdoc cref="DateTime.UtcNow"/>
        public static DateTime UtcNow => GetDateTime.Value().ToUniversalTime();

        /// <summary>
        /// Sets a fixed (deterministic) time for the current thread to return by <see cref="SystemClock"/>.
        /// </summary>
        public static void Set(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Local)
                dateTime = dateTime.ToLocalTime();

            GetDateTime.Value = () => dateTime;
        }

        /// <summary>
        /// Resets <see cref="SystemClock"/> to return the current <see cref="DateTime.Now"/>.
        /// </summary>
        public static void Reset()
        {
            GetDateTime.Value = () => DateTime.Now;
        }
    }
}