using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketProblems
{
    //Bucket Operations
    interface IUnaryBucketOperations
    {
        void FillBucket(Bucket bucket);
        void EmptyBucket(Bucket bucket);
    }

    interface IBinaryBucketOperations
    {
        void Transfer(Bucket source, Bucket target);
        void Transfer(Bucket source, Bucket target, int volume);
    }
}
