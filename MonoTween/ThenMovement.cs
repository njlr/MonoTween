using System;

namespace MonoTween
{
    sealed class ThenMovement : IMovement
    {
        private readonly IMovement first;
        private readonly IMovement second;

        public float Start
        {
            get { return first.Start; }
        }

        public float End
        {
            get { return second.End; }
        }

        public float Duration
        {
            get { return first.Duration + second.Duration; }
        }

        public ThenMovement(IMovement first, IMovement second)
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

            this.first = first;
            this.second = second;
        }

        public float Evaluate(float t)
        {
            if (t <= first.Duration)
            {
                return first.Evaluate(t);
            }
            else
            {
                return second.Evaluate(t - first.Duration);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ThenMovement))
            {
                return false;
            }
            else
            {
                var other = (ThenMovement)obj;

                return first.Equals(other.first) && second.Equals(other.second);
            }
        }

        public override int GetHashCode()
        {
            return 11 + 7 ^ first.GetHashCode() + 3 ^ second.GetHashCode();
        }

        public override string ToString()
        {
            return "ThenMovement[" + first + ", " + second + "]";
        }
    }

    public static class ThenMovementExtensions
    {
        public static IMovement Then(this IMovement movement, IMovement nextMovement)
        {
            return new ThenMovement(movement, nextMovement);
        }
    }
}
