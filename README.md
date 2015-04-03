# MonoTween
A nifty tween library for MonoGame and XNA. 

## Usage

### Interpolators

Interpolators are generalized smoothing functions from 0 to 1 across a time-step from 0 to 1. They are the building blocks for more complex animations. 

Interpolators are easy to define: 

```
class MyInterpolator : IInterpolator
{
    public float Evaluate(float t)
    {
        if (t < 0.5f)
        {
            return 0f;
        }
        else
        {
            return 1f;
        }
    }
}
```

Interpolators can be easily composed: 

```
var i = new LinearInterpolator().Sequence(a, 0.5f).Average(b);
```

Interpolators can be built in an ad-hoc manner: 

```
var i = new CustomInterpolator(x => x * x * (3f - 2f * x));
```

### Movements

Movements are predefined transitions between values over time. 

A linear movement from 0 to 100, in 3 time-steps: 

```
var m = MovementFactory.CreateMovement(0f, 100f, 3f, new LinearInterpolator());
```

Movements can be sequenced: 

```
var i = j.Then(j);
```

Movements can be repeated: 

```
var i = j.Repeat(3);
```

Movements can be delayed: 

```
var i = j.Wait(3f).Then(k);
```

Movements can be reversed: 

```
var i = j.Reverse();
```

Movements can be rewound: 

```
var i = j.ThenReverse();
```

Movements can be stretched: 

```
var i = j.Stretch(2f); // Takes 2x as long; moves at 1/2 speed
```

Movements can be blended: 

```
var i = j.Min(k); // Take the minimum of j and k
i = j.Max(k); // Take the maximum of j and k
i = j.Average(k); // Take the mean of j and k
i = j.Add(k); // Take the sum of j and k
i = j.Subtract(k); // Take j minus k
i = j.Blend(k, (x, y) => x * 0.1f + y * 0.9f); // Whatever you like!
```