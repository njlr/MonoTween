
namespace MonoTween
{
    static class TweenHelpers
    {
        /// <summary>
        /// Clamps a given value between 0 and 1. 
        /// </summary>
        /// <param name="x">The value to clamp</param>
        /// <returns>The value clamped between 0 and 1</returns>
        public static float Saturate(float x)
        {
            if (x < 0f)
            {
                return 0f;
            }
            else if (x > 1f)
            {
                return 1f;
            }
            else
            {
                return x;
            }
        }
    }
}
