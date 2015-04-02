# MonoTween
A nifty tween library for MonoGame and XNA. 

## Usage

### Interpolators

Interpolators are generalized smoothing functions from 0 to 1. They are the building blocks for more complex animations. 

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

They can be easily composed: 

```
var i = new LinearInterpolator().Sequence(a, 0.5f).Average(b);
```

They can be built in an ad-hoc manner: 

```
var i = new CustomInterpolator(x => x * x * (3f - 2f * x));
```

### Movements

Movements are predefined transitions between values over time. 

A linear movement from 0 to 100, in 3 seconds: 

```
var m = new Movement(0f, 100f, 3f, new LinearInterpolator());
```

Movements can be sequenced: 

```
var i = j.Then(j);
```

They can be repeated: 

```
var i = j.Repeat(3);
```
