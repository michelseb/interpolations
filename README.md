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
* 4.0.0
    * Introducing interpolation easings
    * Defined for each interpolation
        - Linear
        - EaseIn
        - EaseOut
        - EaseInOut
        - SmoothStep
* 3.3.1
    * Fixing deferred init
* 3.3.0
    * Introducing deferred executions
* 3.2.0
    * You can now set an OnStart event for each interpolation in your list
* 3.1.0
    * You can now set an OnEnd event for each interpolation in your list
* 3.0.0
    * Introducing interpolation queue - can queue to sequential executions
* 2.1.3
    * Added interpolation initialize in InterpolateList methods
* 2.1.2
    * Fixed InterpolateListSimultaneous method
* 2.1.1
    * Adding onEnd event to interpolationController
* 2.1.0
    * Adding an onEnd event on interpolation executions
* 2.0.0
	* Major package reorganization (namespaces, interface definitions)
	* You have more freedom in the way you manipulate your interpolations (access to Init/Process/Apply/Complete methods)
	* You can now execute multiple interpolations sequentially or simultaneously using RunListSequential and RunListSimultaneous
* 1.0.0
    * Initial Release

## License

This project is licensed under the MIT License - see the LICENSE.md file for details
