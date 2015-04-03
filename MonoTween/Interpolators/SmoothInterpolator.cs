
namespace MonoTween.Interpolators
{
    public sealed class SmoothInterpolator : IInterpolator
    {
        public SmoothInterpolator()
            : base()
        {

        }

        public float Evaluate(float t)
        {
            t = TweenHelpers.Saturate(t);

            return t * t * (3f - 2f * t);
        }

        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is SmoothInterpolator);
        }

        public override int GetHashCode()
        {
            return 41 * 23;
        }

        public override string ToString()
        {
            return "SmoothInterpolator";
        }
    }
}
