using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoTween
{
    static class TweenHelpers
    {
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
