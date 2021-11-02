using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcador : MonoBehaviour
{
    public GameObject cafe;
    public Transform spawnPlace;
    

    public float waitingTime;
    private bool yes;
    private bool called;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GenerateCoffeInBase(GameObject player, int alforja, Collider collider)
    {

        for (int i=0; i<alforja; i++)
        {

                var cafeInst = Instantiate(cafe, RandomPointPicker(collider.bounds), Quaternion.identity);
                cafeInst.transform.localScale = new Vector3(80, 80, 80);
                cafeInst.GetComponent<Rigidbody>().mass = 10;
                cafeInst.tag = "Untagged";
                waitingTime = 0.2f;
             
             

         }


    }

    



    public void Generation()
    { 
    }



    public Vector3 RandomPointPicker(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
