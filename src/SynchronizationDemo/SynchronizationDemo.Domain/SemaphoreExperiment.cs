namespace SynchronizationDemo.Domain;

public class SemaphoreExperiment
{
    public void Run()
    {
        var stampante = new SemaphoreSlim(1, 1);
        Thread[] lavoratori = new Thread[4];

        for (int i = 0; i < lavoratori.Length; i++)
        {
            int idLavoratore = i; // Dichiarata dentro il ciclo per evitare problemi di closure
            lavoratori[i] = new Thread(() =>
            {
                Console.WriteLine($"ID {idLavoratore}, vuole accedere alla risorsa condivisa");
                stampante.Wait();
                Console.WriteLine($"ID {idLavoratore}, ottiene la risorsa condivisa");
                Thread.Sleep(1500);
                Console.WriteLine($"ID {idLavoratore}, rilascio la risorsa condivisa");

                stampante.Release();
            });
        } // <--- Il ciclo for va chiuso qui

        Console.WriteLine("Starting threads....");

        foreach (Thread lavoratore in lavoratori)
        {
            lavoratore.Start();
        }

        foreach (Thread lavoratore in lavoratori)
        {
            lavoratore.Join();
        }

        Console.WriteLine("All finished");
    }
}