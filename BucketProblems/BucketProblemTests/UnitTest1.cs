using System.Collections.Generic;
using BucketProblems;
using NUnit.Framework;

namespace BucketProblemTests
{
    namespace BucketProblemsUnitTesting
    {
        [TestFixture]
        public class WhenUniqueSequencesCalled
        {
            [Test]
            public void IfAllSequencesEqual_ThenOnlyOneSequenceReturned()
            {
                List<int[]> sequence = new List<int[]>();

                sequence.Add(new int[] { 0, 0, 0 });
                sequence.Add(new int[] { 5, 0, 5 });
                sequence.Add(new int[] { 5, 3, 8 });

                List<List<int[]>> sequences = new List<List<int[]>>();

                sequences.Add(new List<int[]>(sequence));
                sequences.Add(new List<int[]>(sequence));
                sequences.Add(new List<int[]>(sequence));

                var dedupedSequences = Comparers.GetUniqueSequences(sequences);

                Assert.AreEqual(1, dedupedSequences.Count);
            }
        }
    }

}

