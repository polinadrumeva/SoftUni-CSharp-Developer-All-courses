namespace Singleton
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            var db1 = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;


        }
    }
}
