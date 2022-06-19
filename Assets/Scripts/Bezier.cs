using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class Bezier 
{
    // Start is called before the first frame update
    public static Vector3 GetPoint ( Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
         oneMinusT * oneMinusT * oneMinusT * P0 +
         3f * oneMinusT * oneMinusT * t * P1 +
         3f * oneMinusT * t * t * P2 +
         t * t * t * P3;




    }
    public static Vector3 GetFirstFerivative(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (P1 - P0) +
            6f * oneMinusT * t * (P2 - P1) +
            3f * t * t * (P3 - P2);
    }
   
}
