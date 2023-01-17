//using Moq;
//using Moq.Protected;
using PickyBride;

namespace TestPickyBride;

public class PrincessTest
{
    [Fact]
    public void ChooseBestContenderTest()
    {
        var hall = new Hall();
        var friend = new Friend();
        var princess = new Princess(friend, hall);
        var contenders = new List<RatingContender>();
        for (var i = TestsHelper.ContendersNumber - 2; i >= 0; --i)
        {
            contenders.Add(new RatingContender("", "", i));
        }

        contenders.Add(new RatingContender("", "", TestsHelper.ContendersNumber - 1));

        hall.InviteContenders(contenders);
        var chosenContender = princess.MakeChoice();
        Assert.NotNull(chosenContender);
        Assert.Equal(TestsHelper.ContendersNumber - 1, ((RatingContender)chosenContender).Rating);
    }

    [Fact]
    public void NotChooseAnyContenderTest()
    {
        var hall = new Hall();
        var friend = new Friend();
        var princess = new Princess(friend, hall);
        var contenders = new List<RatingContender>();
        for (var i = TestsHelper.ContendersNumber - 1; i >= 0; --i)
        {
            contenders.Add(new RatingContender("", "", i));
        }

        hall.InviteContenders(contenders);
        var chosenContender = princess.MakeChoice();
        Assert.Null(chosenContender);
    }

    [Fact]
    public void ExceptionWhileAskNextTest()
    {
        var hall = new Hall();
        var friend = new Friend();
        var princess = new Princess(friend, hall);
        var contenders = new List<RatingContender>();
        hall.InviteContenders(contenders);
        Assert.Throws<ArgumentException>(() => princess.MakeChoice());
    }
}
