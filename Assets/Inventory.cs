﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int InventarioPersonaje;
   
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
       
        return;
    }

    public void ResetLocalInventory()
    {
        InventarioPersonaje = 0;
    }
}
