using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public LineRenderer line;
    public Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = points.Length;
        for (int i=0; i < points.Length; i++)
        {
            line.SetPosition(i, points[i].position);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //line.SetPosition(0, points[0].position);
        //line.SetPosition(1, points[1].position);
       
        //line.SetPosition(2, points[2].position);
 
        //line.SetPosition(3, points[3].position);
    }
}
