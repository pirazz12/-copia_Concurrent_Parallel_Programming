namespace ThreadDemo.Domain;

public class ThreadExperiments
{
    public void RunSequential()
    {
        Work("A");
        Work("B");
    }

     
public void RunThreads()
    {
        Thread threadA = new Thread(() => Work("A"));
        Thread threadB = new Thread(() => Work("B"));
        Console.WriteLine("Starting Threads...");
        
        threadA.Start();
        threadB.Start();

        Console.WriteLine("This line is written by main thread");
        
        threadA.Join();
        threadB.Join();
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