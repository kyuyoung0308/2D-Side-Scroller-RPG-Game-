using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    //zero out velocity
    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    //enable/ set max y
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //enable/set  min y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

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

        //vertical
        if (YMinEnabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        }
        else if (YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        }
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

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
