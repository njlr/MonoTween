using System;

namespace MonoTween.Interpolators
{
    sealed class SequenceInterpolator : IInterpolator
    {
        private readonly IInterpolator first;
        private readonly IInterpolator second;

        private readonly float transtionPoint;

        public SequenceInterpolator(IInterpolator first, IInterpolator second, float transtionPoint)
            : base()
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if ((transtionPoint < 0f) || (transtionPoint > 1f))
            {
                throw new ArgumentOutOfRangeException("transtionPoint", "The transition point must be between 1 and 0. ");
            }

            this.first = first;
            this.second = second;

            this.transtionPoint = transtionPoint;
        }

        public float Evaluate(float t)
        {
            t = TweenHelpers.Saturate(t);

            if (t < transtionPoint)
            {
                return first.Evaluate(t / transtionPoint);
            }
            else
            {
                return second.Evaluate((t - transtionPoint) / (1f - transtionPoint));
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SequenceInterpolator))
            {
                return false;
            }
            else
            {
                var other = (SequenceInterpolator)obj;

                return ((first == other.first) && 
                    (second == other.second) && 
                    (transtionPoint == other.transtionPoint));
            }
        }

        public override int GetHashCode()
        {
            return 73 + 19 ^ first.GetHashCode() + 7 ^ second.GetHashCode() + 11 ^ transtionPoint.GetHashCode();
        }

        public override string ToString()
        {
            return "SequenceInterpolator[" + first + ", " + second + ", " + transtionPoint + "]";
        }
    }

    public static class SequenceInterpolatorExtensions
    {
        public static IInterpolator Sequence(this IInterpolator first, IInterpolator second, float transtionPoint)
        {
            return new SequenceInterpolator(first, second, transtionPoint);
        }
    }
}
