using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public int diceTopRange;
    public int diceTopRandeDiffucult;
    public int diceResult;
    public GameManaging gameManager;
    public GameObject player;
    public Inventory inventario;
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

        if(inventario.InventarioPersonaje<=5)
        {
            Debug.Log("easy");
            diceResult = Random.Range(1, diceTopRange);
        }

        if (inventario.InventarioPersonaje > 5)
        {
            Debug.Log("Difficult");
            diceResult = Random.Range(1, diceTopRandeDiffucult);
        }


        //gameManager.GetDiceResult(diceResult,player);

        return diceResult;
    }
}
