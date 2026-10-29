namespace ThreadDemo.Domain;

public class ThreadExperiments
{
    public void RunSequential()
    {
        Work("A");
        Work("B");
    }

    // 
    private void Work(string name)
    {
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine($"Thread {name}; Thread: {Thread.CurrentThread.ManagedThreadId}; index {i}");
            Thread.Sleep(100);
        }
    }
}