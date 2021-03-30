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
        bool FillBucket(Bucket bucket);
        bool EmptyBucket(Bucket bucket);
    }

    interface IBinaryBucketOperations
    {
        bool Transfer(Bucket source, Bucket target);
        bool Transfer(Bucket source, Bucket target, int volume);
    }
}
