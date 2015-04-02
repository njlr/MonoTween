using System;

namespace MonoTween.Interpolators
{
    public sealed class CustomInterpolator : IInterpolator
    {
        private readonly Func<float, float> function;

        public CustomInterpolator(Func<float, float> function)
            : base()
        {
            this.function = function;
        }

        public float Evaluate(float t)
        {
            return function(TweenHelpers.Saturate(t));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CustomInterpolator))
            {
                return false;
            }
            else
            {
                return function == ((CustomInterpolator)obj).function;
            }
        }

        public override int GetHashCode()
        {
            return 59 + 17 ^ function.GetHashCode();
        }

        public override string ToString()
        {
            return "CustomInterpolator[" + function + "]";
        }
    }
}
