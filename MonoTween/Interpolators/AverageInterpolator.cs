using System;

namespace MonoTween.Interpolators
{
    sealed class AverageInterpolator : IInterpolator
    {
        private readonly IInterpolator a;
        private readonly IInterpolator b;

        public AverageInterpolator(IInterpolator a, IInterpolator b)
            : base()
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            if (b == null)
            {
                throw new ArgumentNullException("b");
            }

            this.a = a;
            this.b = b;
        }

        public float Evaluate(float t)
        {
            t = TweenHelpers.Saturate(t);

            return (a.Evaluate(t) + b.Evaluate(t)) * 0.5f;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AverageInterpolator))
            {
                return false;
            }
            else
            {
                var other = (AverageInterpolator)obj;

                return ((a == other.a && b == other.b) ||
                    (a == other.b && b == other.a));
            }
        }

        public override int GetHashCode()
        {
            return 53 + 29 ^ (a.GetHashCode() * b.GetHashCode());
        }

        public override string ToString()
        {
            return "AverageInterpolator[" + a + ", " + b + "]";
        }
    }

    public static class AverageInterpolatorExtensions
    {
        public static IInterpolator Average(this IInterpolator interpolator, IInterpolator other)
        {
            return new AverageInterpolator(interpolator, other);
        }
    }
}
