using Microsoft.Extensions.Hosting;

namespace PickyBride;

public class TaskSimulator : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly Task _makeChoiceTask;

    //private readonly TaskContext _context;

    private readonly Princess _princess;

    private readonly Friend _friend;

    private readonly Hall _hall;

    private readonly ContendersGenerator _generator;

    public TaskSimulator(ContendersGenerator generator, Princess princess, Friend friend, Hall hall,
        IHostApplicationLifetime applicationLifetime)
    {
        _generator = generator;
        _applicationLifetime = applicationLifetime;
        _princess = princess;
        _friend = friend;
        _hall = hall;
        _makeChoiceTask = new Task(Simulate);
    }

    private void Simulate()
    {
        try
        {
            _hall.InviteContenders(_generator.GetShuffledContenders());
            var princessChoice = _princess.MakeChoice();
            Console.WriteLine("_____");
            var princessHappiness = HappinessEstimator.EstimatePrincessHappiness(princessChoice);
            Console.WriteLine(princessHappiness);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
            Console.WriteLine(e.Message);
        }
        finally
        {
            _applicationLifetime.StopApplication();
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _makeChoiceTask.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
