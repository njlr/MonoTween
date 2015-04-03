using System;

namespace MonoTween
{
    sealed class RepeatMovement : IMovement
    {
        private readonly IMovement underlying;

        private readonly int times;

        public float Start
        {
            get { return underlying.Start; }
        }

        public float End
        {
            get { return underlying.End; }
        }

        public float Duration
        {
            get { return underlying.Duration * times; }
        }

        public RepeatMovement(IMovement underlying, int times)
            : base()
        {
            if (underlying == null)
            {
                throw new ArgumentNullException("underlying");
            }

            if (times < 1)
            {
                throw new ArgumentOutOfRangeException("times", "The number of repeats must be at least 1. ");
            }

            this.underlying = underlying;

            this.times = times;
        }

        public float Evaluate(float t)
        {
            if (t <= 0)
            {
                return underlying.Evaluate(t);
            }
            else if (t >= underlying.Duration * times)
            {
                return underlying.Evaluate(t - underlying.Duration * times);
            }
            else
            {
                return underlying.Evaluate(t % times);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is RepeatMovement))
            {
                return false;
            }
            else
            {
                var other = (RepeatMovement)obj;

                return ((times == other.times) &&
                    (underlying.Equals(other.underlying)));
            }
        }

        public override int GetHashCode()
        {
            return 73 + 19 ^ times.GetHashCode() + 43 ^ underlying.GetHashCode();
        }

        public override string ToString()
        {
            return "RepeatMovement[" + underlying + ", " + times + "]";
        }
    }

    public static class RepeatMovementExtensions
    {
        public static IMovement Repeat(this IMovement movement, int times)
        {
            return new RepeatMovement(movement, times);
        }
    }
}
