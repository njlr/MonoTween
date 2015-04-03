using System;

namespace MonoTween
{
    sealed class ReverseMovement : IMovement
    {
        private readonly IMovement underlying;

        public float Start
        {
            get { return underlying.End; }
        }

        public float End
        {
            get { return underlying.Start; }
        }

        public float Duration
        {
            get { return underlying.Duration; }
        }

        public ReverseMovement(IMovement underlying)
            : base()
        {
            if (underlying == null)
            {
                throw new ArgumentNullException("underlying");
            }

            this.underlying = underlying;
        }

        public float Evaluate(float t)
        {
            if (t < 0f)
            {
                return underlying.End;
            }
            else if (t > underlying.Duration)
            {
                return underlying.Start;
            }
            else
            {
                return underlying.Evaluate(underlying.Duration - t);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ReverseMovement))
            {
                return false;
            }
            else
            {
                return underlying.Equals(((ReverseMovement)obj).underlying);
            }
        }

        public override int GetHashCode()
        {
            return 2 + 19 ^ underlying.GetHashCode();
        }

        public override string ToString()
        {
            return "ReverseMovement[" + underlying + "]";
        }
    }

    public static class ReverseMovementExtensions
    {
        public static IMovement Reverse(this IMovement movement)
        {
            return new ReverseMovement(movement);
        }

        public static IMovement ThenReverse(this IMovement movement)
        {
            return movement.Then(new ReverseMovement(movement));
        }
    }
}
