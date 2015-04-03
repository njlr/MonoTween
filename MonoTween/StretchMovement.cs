using System;

namespace MonoTween
{
    sealed class StretchMovement : IMovement
    {
        private readonly IMovement underlying;

        private readonly float factor;

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
            get { return underlying.Duration * factor; }
        }

        public StretchMovement(IMovement underlying, float factor)
            : base()
        {
            if (underlying == null)
            {
                throw new ArgumentNullException("underlying");
            }

            if (factor <= 0f)
            {
                throw new ArgumentOutOfRangeException("factor", "The stretch factor must be greater than 0. ");
            }

            this.underlying = underlying;

            this.factor = factor;
        }

        public float Evaluate(float t)
        {
            return underlying.Evaluate(t / factor);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StretchMovement))
            {
                return false;
            }
            else
            {
                var other = (StretchMovement)obj;

                return ((factor == other.factor) &&
                    (underlying.Equals(other.underlying)));
            }
        }

        public override int GetHashCode()
        {
            return 29 + 11 ^ factor.GetHashCode() + 7 ^ underlying.GetHashCode();
        }

        public override string ToString()
        {
            return "StretchMovement[" + underlying + ", " + factor + "]";
        }
    }

    public static class StretchMovementExtensions
    {
        public static IMovement Stretch(this IMovement movement, float factor)
        {
            return new StretchMovement(movement, factor);
        }
    }
}
