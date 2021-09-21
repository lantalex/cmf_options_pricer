using System;
using System.Collections.Generic;
using System.Linq;

namespace OptionsPricer
{
    public class LinearInterpolator
    {
        /// <summary>
        /// Interpolates f(x) = y. Returns linearly interpolated f(z), where z is in (min(x), max(x)).
        /// </summary>
        public static double Interpolate(
            List<double> xs,
            IList<double> ys,
            double z
        )
        {
            if (!xs.Any()) {
                throw new ArgumentException("xs should be not empty");
            }
            if (xs.Count != ys.Count) {
                throw new ArgumentException("xs should have the same count of elements as ys.");
            }
            if (z < xs.First() || z > xs.Last()) {
                throw new ArgumentOutOfRangeException("z should be between min(xs), max(xs).");
            }

            var binarySearchResult = xs.BinarySearch(z);
            if (binarySearchResult >= 0) {
                return ys[binarySearchResult];
            }
            var indexOfTheLargerNeighbor = ~binarySearchResult;
            var xSmaller = xs[indexOfTheLargerNeighbor - 1];
            var xLarger = xs[indexOfTheLargerNeighbor];
            var ySmaller = ys[indexOfTheLargerNeighbor - 1];
            var yLarger = ys[indexOfTheLargerNeighbor];
            return (
                ySmaller
                + (yLarger - ySmaller) * (z - xSmaller) / (xLarger - xSmaller)
            );
        }
    }
}
