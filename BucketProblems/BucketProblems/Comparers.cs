using System.Collections.Generic;
using System.Linq;

namespace BucketProblems
{
    public class Comparers
    {
        public static List<List<int[]>> GetUniqueSequences(List<List<int[]>> sequences)
        {
            //return new HashSet<List<int[]>>(sequences).ToList();

            var output = sequences.Select(t => t.Distinct(new ArrayComparer<int>()).ToList()).ToList();

            return output.Distinct(new ListOfArrayComparer<int>()).ToList();
        }
    }

    public class ArrayComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            return ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }

        public int GetHashCode(T[] obj)
        {
            return 0;
        }
    }

    public class ListOfArrayComparer<T> : IEqualityComparer<List<T[]>>
    {
        public bool Equals(List<T[]> x, List<T[]> y)
        {
            return ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y, new ArrayComparer<T>()));
        }

        public int GetHashCode(List<T[]> obj)
        {
            return 0;
        }
    }
}
