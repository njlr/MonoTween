using System;

namespace MonoTween.Interpolators
{
    sealed class MinInterpolator : IInterpolator
    {
        private readonly IInterpolator a;
        private readonly IInterpolator b;

        public MinInterpolator(IInterpolator a, IInterpolator b)
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

            float i = a.Evaluate(t);
            float j = b.Evaluate(t);

            if (i < j)
            {
                return i;
            }
            else
            {
                return j;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MinInterpolator))
            {
                return false;
            }
            else
            {
                var other = (MinInterpolator)obj;

                return ((a == other.a && b == other.b) ||
                    (a == other.b && b == other.a));
            }
        }

        public override int GetHashCode()
        {
            return 73 + 19 ^ (a.GetHashCode() * b.GetHashCode());
        }

        public override string ToString()
        {
            return "MinInterpolator[" + a + ", " + b + "]";
        }
    }

    public static class MinInterpolatorExtensions
    {
        public static IInterpolator Min(this IInterpolator interpolator, IInterpolator other)
        {
            return new MinInterpolator(interpolator, other);
        }
    }
}
