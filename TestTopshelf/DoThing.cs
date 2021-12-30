namespace TestTopshelf
{
    public class DoThing
    {
        private static Timer _timer;

        public Task StartAsync()
        {
            Console.WriteLine($"Timer Start");
            _timer = new Timer(DoWork, null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private int execCount = 0;

        public void DoWork(object state)
        {
            //利用 Interlocked 計數防止重複執行
            Interlocked.Increment(ref execCount);
            if (execCount == 1)
            {
                Console.WriteLine($"Timer go - {DateTime.Now}");
            }
            Interlocked.Decrement(ref execCount);
        }

        public Task StopAsync()
        {
            Console.WriteLine($"Timer Stop");
            //調整Timer為永不觸發，停用定期排程
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
