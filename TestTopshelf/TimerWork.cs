using System.Timers;

namespace TestTopshelf
{
    public class TimerWork
    {
        private static System.Timers.Timer aTimer;

        public TimerWork()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        public void Start()
        {
            Console.WriteLine($"Timer Start");
            aTimer.Start();
        }

        public void Stop()
        {
            aTimer.Stop();
            Console.WriteLine($"Timer Stop");
        }
    }
}
