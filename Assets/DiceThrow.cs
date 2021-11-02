using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public int maxDiceRange;
   
    public int diceResult;
    public GameManaging gameManager;
    public GameObject player;
    public Inventory inventario;
    public TransitedNodeList nodesCount;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManaging>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int DiceThrowing()


    {
        Random.InitState((int)System.DateTime.Now.Ticks);

            var topRange = maxDiceRange - inventario.InventarioPersonaje - (2 * nodesCount.listaNodos.Count);
            //Debug.Log($"Valor de inventario: {inventario.InventarioPersonaje}");
            //Debug.Log($"lista de nodos cantidad:{nodesCount.listaNodos.Count}");
            //Debug.Log($"Resultado top range del dado:{topRange}");
            diceResult = Random.Range(1, topRange);
            
         
     


        //gameManager.GetDiceResult(diceResult,player);

        return diceResult;
    }
}
