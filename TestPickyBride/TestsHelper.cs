using PickyBride;

namespace TestPickyBride;

public class TestsHelper
{

    public const int ContendersNumber = 100;
    public static (RatingContender, RatingContender) GetTwoRandomContenders(int firstRating, int secondRating)
    {
        return (new RatingContender("B", "A", firstRating),
            new RatingContender("Y", "Z", secondRating));
    }
}
