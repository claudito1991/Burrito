using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int InventarioPersonaje;
    public GameManaging gameManager;
    public GameObject parentTag;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventarioLocal(int CantidadAsumar)
    {
        InventarioPersonaje += CantidadAsumar;
        if (parentTag.CompareTag("Player"))
        {
            gameManager.player1alforja = InventarioPersonaje;
        }

        else
        {
            gameManager.player2alforja = InventarioPersonaje;
        }
    }

    public void ResetLocalInventory()
    {
        InventarioPersonaje = 0;
    }
}
