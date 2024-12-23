

namespace UIBusinessLayer.Pages
{
    public static class Pages
    {
        public static T Create<T>(params object[] args) where T : class
        {
            var instance = Activator.CreateInstance(typeof(T), args) as T;
            if (instance == null)
            {
                throw new InvalidOperationException($"Failed to create an instance of {typeof(T).Name}.");
            }
            return instance;
        }
    }
}
