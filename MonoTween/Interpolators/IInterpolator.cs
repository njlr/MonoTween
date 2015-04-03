
namespace MonoTween.Interpolators
{
    /// <summary>
    /// An interpolation function from 0 to 1 for timesteps 0 to 1. 
    /// Used to build more complex tweens. 
    /// </summary>
    public interface IInterpolator
    {
        /// <summary>
        /// Evaluates the interpolator function at a given point. 
        /// </summary>
        /// <param name="t">The distance along the interpolator</param>
        /// <returns>The interpolated point</returns>
        float Evaluate(float t);
    }
}
