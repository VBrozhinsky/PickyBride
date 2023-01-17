namespace PickyBride;

public class Princess
{
    private const double ContendersToSkipFactor = 1 / Math.E;
    private const double ContendersLimitFactor = 0.96;

    private readonly List<Contender> _visitedContenders = new();

    //private readonly TaskContext _context;

    private readonly Friend _friend;

    private readonly Hall _hall;

    public Princess(Friend friend, Hall hall)
    {
        _friend = friend;
        _hall = hall;
    }

    private void RememberVisitedContender(Contender contender, Friend friend)
    {
        _visitedContenders.Add(contender);
        friend.NotifyAboutContender((RatingContender)contender);
        Console.WriteLine(contender.GetFullName());
    }

    private void SkipForeverByFactor(Hall hall, Friend friend)
    {
        var queueCount = hall.QueueInitialCount;
        if (queueCount == 0)
        {
            throw new ArgumentException("Empty contenders collection");
        }
        for (var i = 0; i < queueCount * ContendersToSkipFactor; i++)
        {
            RememberVisitedContender(hall.GetNextContender(), friend);
        }
    }

    public Contender? MakeChoice()
    {
        SkipForeverByFactor(_hall, _friend);
        while (_hall.GetQueueCount() > 0)
        {
            var contender = _hall.GetNextContender();
            var contendersCounter = 0;
            foreach (var visitedContender in _visitedContenders)
            {
                var friendAnswer = _friend.ReplyToComparison(
                    newContender: contender,
                    oldContender: visitedContender);
                if (friendAnswer)
                {
                    contendersCounter++;
                }
            }

            if (contendersCounter >= _hall.QueueInitialCount * ContendersToSkipFactor * ContendersLimitFactor)
            {
                return contender;
            }

            RememberVisitedContender(contender, _friend);
        }

        return null;
    }
}
