using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Vector3 camOffset;
    public Transform Target;

    public float SmoothOffset = 0.145f;

    public void FixedUpdate()
    {
        Vector3 desirePose = Target.position + camOffset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePose, SmoothOffset);
        transform.position = smoothPosition;

        transform.LookAt(Target);
    }
}
