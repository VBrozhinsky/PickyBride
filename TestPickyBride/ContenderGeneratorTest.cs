﻿using PickyBride;

namespace TestPickyBride;
using Xunit;

public class ContenderGeneratorTest
{
    [Fact]
    public void ContendersUniqueSetTest()
    {
        var contenders = new ContendersGenerator().GetShuffledContenders();
        Assert.Equal(TestsHelper.ContendersNumber, contenders.Count);

        var contendersSet = new HashSet<RatingContender>();
        foreach (var contender in contenders)
        {
            contendersSet.Add(contender);
        }

        Assert.Equal(TestsHelper.ContendersNumber, contendersSet.Count);
    }
}