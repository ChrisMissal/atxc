using System;

namespace Core
{
    public static class SystemClock
    {
        private static Func<DateTime> _getUtcNow = () => DateTime.UtcNow;

        public static DateTime UtcNow
        {
            get { return _getUtcNow(); }
        }

        public static IDisposable Stub(DateTime dateTime)
        {
            _getUtcNow = () => dateTime;
            return new DisposableStub();
        }

        private class DisposableStub : IDisposable
        {
            public void Dispose()
            {
                _getUtcNow = () => DateTime.UtcNow;
            }
        }
    }
}
