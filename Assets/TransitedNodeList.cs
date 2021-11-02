using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitedNodeList : MonoBehaviour
{
    public List<Collider> listaNodos = new List<Collider>();
    public float actualNodePosition = 0;
    public Inventory inventario;
    public cafeSpawneadoLocal listaCafeLocal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("nodo"))
        {
            if (!listaNodos.Contains(other.GetComponent<Collider>()))
            {
                listaNodos.Add(other.GetComponent<Collider>());
                listaCafeLocal = other.GetComponentInChildren<cafeSpawneadoLocal>();
                //En lugar de tomar CoffeVal para el inventario tengo que tomar la cantidad de elementos actual en la lista de café
                //Sino al borrar el cafe con un player previo este también tiene acceso.
                inventario.InventarioLocal(other.GetComponentInChildren<cafeSpawneadoLocal>().listaCafe.Count);
               
                
                EraseCoffeList();
                //Debug.Log($"La lista de nodos es: {listaNodos.Count} ");
            }

            actualNodePosition = other.GetComponent<Orden>().branchPosition;
            //Debug.Log($"El numero del nodo actual es: {actualNodePosition}");
            
                
        }
        
    }

    public void EraseCoffeList()
    {
        
        for (int i=0; i < listaCafeLocal.listaCafe.Count; i++)
        {
            Destroy(listaCafeLocal.listaCafe[i]);

        }
        listaCafeLocal.listaCafe.Clear();
    }


    public void EraseTransitedNodeList()
    {
        if (listaNodos.Count > 0)
        {
            listaNodos = new List<Collider>();
        }
        
    }

}
