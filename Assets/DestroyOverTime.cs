using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float destroyTime;
    public Vector3 offset = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime/Time.deltaTime);
        transform.localPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
