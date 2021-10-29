using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitedNodeList : MonoBehaviour
{
    public List<Collider> listaNodos = new List<Collider>();
    public float actualNodePosition;
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
                inventario.InventarioLocal(other.GetComponent<GeneradorCafe>().CoffeVal);
                
                EraseCoffeList();
                //Debug.Log($"La lista de nodos es: {listaNodos.Count} ");
            }

            actualNodePosition = other.GetComponent<Orden>().branchPosition;
           // Debug.Log($"El numero del nodo actual es: {actualNodePosition}");
            
                
        }
        
    }

    public void EraseCoffeList()
    {
        
        for (int i=0; i < listaCafeLocal.listaCafe.Count; i++)
        {
            Destroy(listaCafeLocal.listaCafe[i]);
        }
        
    }

}
