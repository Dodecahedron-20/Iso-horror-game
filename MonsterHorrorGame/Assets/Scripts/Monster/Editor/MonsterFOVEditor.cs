using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Monster))]
public class MonsterFOVEditor : Editor
{
    void OnSceneGUI()
    {
        Monster fov = (Monster)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
        Vector3 viewAngleA = fov.DirFromAngle (-fov.currentFOVAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.currentFOVAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.radius);

        Handles.color = Color.red;
        foreach(Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
