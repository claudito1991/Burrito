using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public int diceTopRange;
    public int diceResult;
    public GameManaging gameManager;
    public GameObject player;
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
        diceResult = Random.Range(1, diceTopRange);
        gameManager.GetDiceResult(diceResult,player);
        //print(diceResult);
        return diceResult;
    }
}
