// Draw the curve using a bezier curve tool like: https://www.desmos.com/calculator/d1ofwre0fr
// Get p0, p1, p2 and p3 from that tool

using UnityEngine;
using System;

public class BeizerCalculator
{
    Vector3 p0;
    Vector3 p1;
    Vector3 p2;
    Vector3 p3;

    public BeizerCalculator(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        this.p0 = p0;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
    }

    // Code from here: https://youtu.be/11ofnLOE8pw?t=228
    // Original formula: https://en.wikipedia.org/wiki/B%C3%A9zier_curve#Cubic_B%C3%A9zier_curves
    public Vector3 calculate(float t)
    {
        if(t > 1 || t < 0)
        {
            throw new ArgumentException("Parameter t has to be between 0 and 1, actual value: " + t);
        }

        return 
            Mathf.Pow(1 - t, 3) * p0 + 
            3 * Mathf.Pow(1 - t, 2) * t * p1 + 
            3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
            Mathf.Pow(t, 3) * p3;
    }
}
