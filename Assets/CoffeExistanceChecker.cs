using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeExistanceChecker : MonoBehaviour
{
    public GameObject[] cafeLista;
    public int cantidadActiva;
    // Start is called before the first frame update
    void Start()
    {
        cafeLista = GameObject.FindGameObjectsWithTag("cafe");

    }

    // Update is called once per frame
    void Update()
    {


    }

    public int CantidadDeCafeEnEscena()
    {
        cafeLista = GameObject.FindGameObjectsWithTag("cafe");
        return cafeLista.Length;
    }
}
