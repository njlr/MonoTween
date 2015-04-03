
namespace MonoTween
{
    /// <summary>
    /// A movement between two points across some duration. 
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// The starting point of the movement
        /// </summary>
        float Start { get; }

        /// <summary>
        /// The end point of the movement
        /// </summary>
        float End { get; }

        /// <summary>
        /// The duration of the movement
        /// </summary>
        float Duration { get; }

        /// <summary>
        /// The interpolated position of the movement at the given time-step. 
        /// </summary>
        /// <param name="t">The time-step to resolve</param>
        /// <returns>The position at the given time-step</returns>
        float Evaluate(float t);
    }
}
