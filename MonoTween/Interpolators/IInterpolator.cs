
namespace MonoTween.Interpolators
{
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
