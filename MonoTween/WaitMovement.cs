using MonoTween.Interpolators;
using System;

namespace MonoTween
{
    sealed class WaitMovement : IMovement
    {
        private readonly float position;

        private readonly float duration;

        public float Start
        {
            get { return position; }
        }

        public float End
        {
            get { return position; }
        }

        public float Duration
        {
            get { return duration; }
        }

        public WaitMovement(float position, float duration)
            : base()
        {
            if (duration < 0f)
            {
                throw new ArgumentOutOfRangeException("duration", "The duration of a movement must be at least 0. ");
            }

            this.position = position;

            this.duration = duration;
        }

        public float Evaluate(float t)
        {
            return position;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is WaitMovement))
            {
                return false;
            }
            else
            {
                var other = (WaitMovement)obj;

                return ((position == other.position) &&  
                    (duration == other.duration));
            }
        }

        public override int GetHashCode()
        {
            return 13 +
                23 ^ position.GetHashCode() +
                7 ^ duration.GetHashCode();
        }

        public override string ToString()
        {
            return "WaitMovement[" + position + ", " + duration + "]";
        }
    }

    public static class WaitMovementExtensions
    {
        /// <summary>
        /// Adds a waiting period to the end of a movement. 
        /// </summary>
        /// <param name="movement">The movement</param>
        /// <param name="duration">The number of time-steps to wait for</param>
        /// <returns>A new movement with a wait appended</returns>
        public static IMovement Wait(this IMovement movement, float duration)
        {
            return movement.Then(new WaitMovement(movement.End, duration));
        }
    }
}
