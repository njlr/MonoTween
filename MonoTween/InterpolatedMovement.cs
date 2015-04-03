using MonoTween.Interpolators;
using System;

namespace MonoTween
{
    sealed class InterpolatedMovement : IMovement
    {
        private readonly float start;
        private readonly float end;

        private readonly float duration;

        private readonly IInterpolator interpolator;

        public float Start
        {
            get { return start; }
        }

        public float End
        {
            get { return end; }
        }

        public float Duration
        {
            get { return duration; }
        }

        public IInterpolator Interpolator
        {
            get { return interpolator; }
        }

        public InterpolatedMovement(float start, float end, float duration, IInterpolator interpolator)
            : base()
        {
            if (duration < 0f)
            {
                throw new ArgumentOutOfRangeException("duration", "The duration of a movement must be at least 0. ");
            }

            if (interpolator == null)
            {
                throw new ArgumentNullException("interpolator");
            }

            this.start = start;
            this.end = end;

            this.duration = duration;

            this.interpolator = interpolator;
        }

        public float Evaluate(float t)
        {
            if (t <= 0f)
            {
                return start;
            }
            else if (t >= duration)
            {
                return end;
            }
            else
            {
                return start + (end - start) * interpolator.Evaluate(t / duration);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is InterpolatedMovement))
            {
                return false;
            }
            else
            {
                var other = (InterpolatedMovement)obj;

                return ((start == other.start) && (end == other.end) && 
                    (duration == other.duration) && (interpolator.Equals(other.interpolator)));
            }
        }

        public override int GetHashCode()
        {
            return 61 + 
                3 ^ start.GetHashCode() +
                23 ^ end.GetHashCode() + 
                7 ^ duration.GetHashCode() + 
                11 ^ interpolator.GetHashCode();
        }

        public override string ToString()
        {
            return "InterpolatedMovement[" + start + ", " + end + ", " + duration + ", " + interpolator + "]";
        }
    }
}
