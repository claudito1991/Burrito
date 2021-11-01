using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Camera mainCam;
    public GameObject player;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            speed += Time.deltaTime;
            mainCam.transform.RotateAround(player.transform.position, Vector3.up, speed);
        }
    }
}
