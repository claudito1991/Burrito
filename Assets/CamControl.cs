using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform player;
    public Transform camTransform;
    private Vector3 velocity = Vector3.zero;
    public float SmoothTime = 0.1f;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(player.position, Vector3.up, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(player.position, Vector3.up, -speed * Time.deltaTime);
        }
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, SmoothTime);
        camTransform.LookAt(player.position);

    }
}
