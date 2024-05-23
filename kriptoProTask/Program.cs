using kriptoProTask;

class Program
{
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static int _currentUniqeNumber = 0;

    static async Task Main(string[] args)
    {
        var n = 5; 
        await CreateRecords(n);
    }

    static async Task CreateRecords(int n)
    {
        var tasks = new Task[n];
        for (int i = 0; i < n; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                using (var context = new ModelContext())
                {
                    for (int j = 0; j < 200; j++)
                    {
                        await AddRecord(context);
                    }
                }
            });
        }

        await Task.WhenAll(tasks);
    }

    static async Task AddRecord(ModelContext context)
    {
        await _semaphore.WaitAsync();
        try
        {
            var model = new Model
            {
                Number = ++_currentUniqeNumber,
                DateCreated = DateTime.UtcNow,
             
            };

            context.Models.Add(model);
            await context.SaveChangesAsync();

            Console.WriteLine($"Added record with Number: {_currentUniqeNumber}");
            await Task.Delay(1000);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}