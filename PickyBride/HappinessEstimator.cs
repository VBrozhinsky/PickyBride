namespace PickyBride;

public static class HappinessEstimator
{
    public static int EstimatePrincessHappiness(Contender? contender)
    {
        if (contender == null)
        {
            return 10;
        }

        var ratingContender = (RatingContender)contender;
        return ratingContender.Rating switch
        {
            //>= 50 => ratingContender.Rating + 1,
            //<= 0 => 10,
            99 => 20,
            97 => 50,
            95 => 100,
            _ => 0
        };
    }
}
