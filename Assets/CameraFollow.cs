using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;
    public float speed = 20f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }



    private void LateUpdate()
    {
        

        // update position
        Vector3 targetPosition = Target.position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        camTransform.LookAt(Target.position);

        if (Input.GetKey(KeyCode.Q))
        {
            camTransform.RotateAround(Target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        
        // update rotation
        //transform.LookAt(Target);
    }
}