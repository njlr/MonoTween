using System;

namespace MonoTween.Interpolators
{
    sealed class ReverseInterpolator : IInterpolator
    {
        private readonly IInterpolator underlying;

        public ReverseInterpolator(IInterpolator underlying)
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
            return underlying.Evaluate(1f - TweenHelpers.Saturate(t));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ReverseInterpolator))
            {
                return false;
            }
            else
            {
                return underlying == ((ReverseInterpolator)obj).underlying;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 11 ^ underlying.GetHashCode();
        }

        public override string ToString()
        {
            return "ReverseInterpolator[" + underlying + "]";
        }
    }

    public static class ReverseInterpolatorExtensions
    {
        public static IInterpolator Reverse(this IInterpolator interpolator)
        {
            return new ReverseInterpolator(interpolator);
        }
    }
}
