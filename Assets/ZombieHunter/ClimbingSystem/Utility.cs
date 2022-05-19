using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static GameObject GetNearest(Vector3 origin, List<GameObject> collection)
    {
        GameObject nearest = null;
        var minDistance = float.MaxValue;
        var distance = 0f;

        foreach (var entity in collection)
        {
            distance = (entity.gameObject.transform.position - origin).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = entity;
            }
        }

        return nearest;
    }
}
