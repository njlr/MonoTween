
namespace MonoTween.Interpolators
{
    public sealed class OvershootInterpolator : IInterpolator
    {
        private readonly float tension;

        public OvershootInterpolator(float tension)
            : base()
        {
            this.tension = tension;
        }

        public float Evaluate(float t)
        {
            t = TweenHelpers.Saturate(t);

            t -= 1f;

            return t * t * ((tension + 1f) * t + tension) + 1f;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OvershootInterpolator))
            {
                return false;
            }
            else
            {
                return (tension == ((OvershootInterpolator)obj).tension);
            }
        }

        public override int GetHashCode()
        {
            return 41 + 19 ^ tension.GetHashCode();
        }

        public override string ToString()
        {
            return "OvershootInterpolator[" + tension + "]";
        }
    }
}
