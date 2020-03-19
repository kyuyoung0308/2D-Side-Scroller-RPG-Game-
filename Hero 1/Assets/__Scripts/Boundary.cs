using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public Transform target;

    //zero out velocity
    Vector3 velocity = Vector3.zero;

    //enable/set max x
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //enable/set min x
    public bool XMinEnabled = false;
    public float XMinValue = 0;

    private void FixedUpdate()
    {
        //target position
        Vector3 targetPos = target.position;
        //horizontal
        if (XMinEnabled && XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        }
        else if (XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
        }







        //align the camera and the target z position
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0f);
    }
}
