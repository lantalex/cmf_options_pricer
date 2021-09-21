using System;
using System.Collections.Generic;
using Xunit;
using OptionsPricer;

namespace OptionsPricer.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Interpolate_AtEnds()
        {
            var xs = new List<double>{-5, 5, 10, 20, 50, 70.7};
            var ys = new List<double>{10.1, 50.5, 30.3, -70.7, -70.7, -90.9};
            Assert.Equal(
                10.1,
                OptionsPricer.LinearInterpolator.Interpolate(xs, ys, -5),
                14
            );
            Assert.Equal(
                -90.9,
                OptionsPricer.LinearInterpolator.Interpolate(xs, ys, 70.7),
                14
            );
        }

        [Fact]
        public void Interpolate_AtSomePointInTheMiddle()
        {
            var xs = new List<double>{-5, 5, 10, 20, 50, 70.7};
            var ys = new List<double>{10.1, 50.5, 30.3, -70.7, -70.7, -90.9};
            Assert.Equal(
                -70.7,
                OptionsPricer.LinearInterpolator.Interpolate(xs, ys, 20),
                14
            );
        }

        [Fact]
        public void Interpolate_BetweenPoints()
        {
            var xs = new List<double>{-5, 5, 10, 20, 50, 70.7};
            var ys = new List<double>{10.1, 50.5, 30.3, -70.7, -70.7, -90.9};
            Assert.Equal(
                -20.2,
                OptionsPricer.LinearInterpolator.Interpolate(xs, ys, 15),
                14
            );
            Assert.Equal(
                -40.4,
                OptionsPricer.LinearInterpolator.Interpolate(xs, ys, 17),
                14
            );
        }
    }
}
