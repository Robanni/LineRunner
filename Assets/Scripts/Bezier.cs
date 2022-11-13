using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier 
{
    public  Vector3 GetPointOnBezierCurve(List<Transform> points, float t)
    {
        Vector3 result = new Vector3();

        for(int i = 0; i < points.Count; i++)
        {
            result += BinomialCoefficient(points.Count-1, i) * Mathf.Pow((1 - t), (points.Count -1 - i))
                                        * Mathf.Pow(t, i) * points[i].position;
        }
        //Debug.Log(result);
        
        return result;
    }

    public Vector3 GetPointOnDerivativeBezierCurve(List<Transform> points, float t) 
    {
        Vector3 result = new Vector3();

        for (int i = 0; i < (points.Count - 1); i++)
        {
            result += BinomialCoefficient(points.Count - 2, i) * Mathf.Pow((1 - t), (points.Count - 2 - i))
                                        * Mathf.Pow(t, i) * (points[i+1].position-points[i].position);
        }

        result*=points.Count;

        return result;
    }

    private int Factorial(int number)
    {
        if(number < 1) return 1;

        return number * Factorial(number - 1);
    }

    private int BinomialCoefficient(int n, int k)
    {
        try
        {
            if (n < k) throw new Exception("n must be greater than k");
            
        }
        catch(Exception e)
        {
            Debug.Log($"Error: {e.Message}");
        }

        if (k == 0) {Debug.Log("k == 0"); return 1; }

        int resoult = Factorial(n) / (Factorial(k) * Factorial(n - k));

        Debug.Log(resoult);

        return resoult;
    }
}
