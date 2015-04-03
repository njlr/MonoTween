using System;

namespace MonoTween
{
    sealed class BlendMovement : IMovement
    {
        private readonly IMovement a;
        private readonly IMovement b;

        private readonly Func<float, float, float> blendFunction;

        public float Start
        {
            get { return blendFunction(a.Start, b.Start); }
        }

        public float End
        {
            get { return blendFunction(a.End, b.End); }
        }

        public float Duration
        {
            get { return a.Duration; }
        }

        public BlendMovement(IMovement a, IMovement b, Func<float, float, float> blendFunction)
            : base()
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            if (b == null)
            {
                throw new ArgumentNullException("b");
            }

            if (blendFunction == null)
            {
                throw new ArgumentNullException("blendFunction");
            }

            if (a.Duration != b.Duration)
            {
                throw new ArgumentException("Only movements of the same duration can be blended. ");
            }

            this.a = a;
            this.b = b;

            this.blendFunction = blendFunction;
        }

        public float Evaluate(float t)
        {
            return blendFunction(a.Evaluate(t), b.Evaluate(t));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BlendMovement))
            {
                return false;
            }
            else
            {
                var other = (BlendMovement)obj;

                return ((blendFunction == other.blendFunction) &&
                    (a.Equals(other.a)) &&
                    (b.Equals(other.b)));
            }
        }

        public override int GetHashCode()
        {
            return 29 + 11 ^ a.GetHashCode() + 7 ^ b.GetHashCode() + 13 ^ blendFunction.GetHashCode();
        }

        public override string ToString()
        {
            return "BlendMovement[" + a + ", " + b + ", " + blendFunction + "]";
        }
    }

    public static class BlendMovementExtensions
    {
        public static IMovement Blend(this IMovement movement, IMovement other, Func<float, float, float> blendFunction)
        {
            return new BlendMovement(movement, other, blendFunction);
        }

        public static IMovement Add(this IMovement movement, IMovement other)
        {
            return new BlendMovement(movement, other, (x, y) => x + y);
        }

        public static IMovement Subtract(this IMovement movement, IMovement other)
        {
            return new BlendMovement(movement, other, (x, y) => x - y);
        }

        public static IMovement Average(this IMovement movement, IMovement other)
        {
            return new BlendMovement(movement, other, (x, y) => (x + y) * 0.5f);
        }

        public static IMovement Min(this IMovement movement, IMovement other)
        {
            Func<float, float, float> blendFunction = (x, y) =>
            {
                if (x < y)
                {
                    return x;
                }
                else
                {
                    return y;
                }
            };

            return new BlendMovement(movement, other, blendFunction);
        }

        public static IMovement Max(this IMovement movement, IMovement other)
        {
            Func<float, float, float> blendFunction = (x, y) =>
            {
                if (x > y)
                {
                    return x;
                }
                else
                {
                    return y;
                }
            };

            return new BlendMovement(movement, other, blendFunction);
        }
    }
}
