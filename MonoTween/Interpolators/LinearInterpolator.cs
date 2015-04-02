
namespace MonoTween.Interpolators
{
    public sealed class LinearInterpolator : IInterpolator
    {
        public LinearInterpolator()
            : base()
        {

        }

        public float Evaluate(float t)
        {
            return TweenHelpers.Saturate(t);
        }

        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is LinearInterpolator);
        }

        public override int GetHashCode()
        {
            return 41 * 89;
        }

        public override string ToString()
        {
            return "LinearInterpolator";
        }
    }
}
