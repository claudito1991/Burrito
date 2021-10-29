using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorCafe : MonoBehaviour
{
    public GameObject cafe;
    public Transform spawnPlace;
    public int  CoffeVal;
    private Collider placeCollider;
    private GameObject objetoInstanciado;
    public cafeSpawneadoLocal listaDeCafes;
   
   
   
    // Start is called before the first frame update
    private void Awake()
    {
        CoffeVal = Random.Range(1, 5);
        placeCollider = spawnPlace.GetComponentInParent<Collider>();

        for (int i = 0; i < CoffeVal; i++)
        {
            //Debug.Log($"Numero de iteracion: {i}");
            var objetoInstanciado = Instantiate(cafe, RandomPointInBounds(placeCollider.bounds), spawnPlace.transform.rotation);
            objetoInstanciado.GetComponent<trackCoffeParent>().parent = spawnPlace;
            listaDeCafes.listaCafe.Add(objetoInstanciado);
        }



    }
    void Start()
    {
 
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Cafe perteneciente a este spawn place: {listaDeCafes.listaCafe.Count}");
    }



    public  Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
