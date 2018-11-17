using System;

namespace flarebattleship
{
    class HitResult: IHitResult
    {
        public HitResult(string result)
        {
            Result = result;
        }

        public string Result {get; private set;}
    }

    class NullHitResult: IHitResult
    {
        public NullHitResult()
        {
            Result = string.Empty;
        }

        public string Result {get; private set;}
    }
}