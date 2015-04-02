using System;

namespace MonoTween.Interpolators
{
    sealed class MaxInterpolator : IInterpolator
    {
        private readonly IInterpolator a;
        private readonly IInterpolator b;

        public MaxInterpolator(IInterpolator a, IInterpolator b)
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

            if (i > j)
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
            if (obj == null || !(obj is MaxInterpolator))
            {
                return false;
            }
            else
            {
                var other = (MaxInterpolator)obj;

                return ((a == other.a && b == other.b) || 
                    (a == other.b && b == other.a));
            }
        }

        public override int GetHashCode()
        {
            return 59 + 19 ^ (a.GetHashCode() * b.GetHashCode());
        }

        public override string ToString()
        {
            return "MaxInterpolator[" + a + ", " + b + "]";
        }
    }

    public static class MaxInterpolatorExtensions
    {
        public static IInterpolator Max(this IInterpolator tween, IInterpolator other)
        {
            return new MaxInterpolator(tween, other);
        }
    }
}
