using MonoTween.Interpolators;

namespace MonoTween
{
    public static class MovementFactory
    {
        /// <summary>
        /// Creates a new movement between the given points for the given duration and interpolator. 
        /// </summary>
        /// <param name="start">The starting point of the movement</param>
        /// <param name="end">The finishing point of the movement</param>
        /// <param name="duration">The length of the movement</param>
        /// <param name="interpolator">The interpolator to use</param>
        /// <returns>The movement</returns>
        public static IMovement CreateMovement(float start, float end, float duration, IInterpolator interpolator)
        {
            return new InterpolatedMovement(start, end, duration, interpolator);
        }

        /// <summary>
        /// Creates a new movement that waits at a given point for a given duration. 
        /// </summary>
        /// <param name="position">The position to wait at</param>
        /// <param name="duration">The duration of the wait</param>
        /// <returns>The movement</returns>
        public static IMovement CreateMovement(float position, float duration)
        {
            return new WaitMovement(position, duration);
        }
    }
}
