# Package

A simple way to deal with interpolations

## Description

This package provides you with a handy helper class that will make it easier to handle interpolations through code.

## Getting Started

### Dependencies

* URP (Universal Render Pipeline) v17.3.0

### Using the helper

* You can use it directly by adding a InterpolationController component to your gameObject

```
private void Awake()
{ 
	InterpolationController = AddComponent<InterpolationController>();
}
```

* and then call the Run method

```
InterpolationController.Run(new TransformScaleInterpolation(transform, transform.position, transform.position + Vector3.one, 1f);
```

## Help

May you have any questions, email me at sebastien.michel60@gmail.com

## Authors

Sebastien MICHEL

## Version History

* 1.0.0
    * Initial Release

## License

This project is licensed under the MIT License - see the LICENSE.md file for details