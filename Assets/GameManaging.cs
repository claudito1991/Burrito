using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
   
    public GameObject player1;
    public GameObject player2;
    public Transform player1SpawnLoc;
    public Transform player2SpawnLoc;
    public bool player1Turn = true;

    public int player1alforja;
    public int player2alforja;

    public int player1TotalScore;
    public int player2TotalScore;

    public int diceResultP1;
    public int diceResultP2;

    public int diceResult;


    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<Movement>().enabled = false;
        player1alforja = player1.GetComponent<Inventory>().InventarioPersonaje;
        player2alforja = player2.GetComponent<Inventory>().InventarioPersonaje;

        //diceResultP1 = player1.GetComponent<DiceThrow>().diceResult;
        //diceResultP2 = player2.GetComponent<DiceThrow>().diceResult;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTurn()
    {
        

        if (player1Turn)
        {
            player2.transform.position = player2SpawnLoc.position;
            player2.GetComponent<Movement>().enabled = false;
            player1.GetComponent<Movement>().enabled = true;
            GetInventarioP2(player2);
            player2TotalScore += player2alforja;
            player2alforja = 0;
            player2.GetComponent<Inventory>().ResetLocalInventory();


        }
        else
        {
            player1.transform.position = player1SpawnLoc.position;
            player1.GetComponent<Movement>().enabled = false;
            player2.GetComponent<Movement>().enabled = true;
            GetInventarioP1(player1);
            player1TotalScore += player1alforja;
            player1alforja = 0;
            player1.GetComponent<Inventory>().ResetLocalInventory();
        }
        player1Turn = !player1Turn;
    }

    public void TotalScore(int CantidadAsumar, int playerTotalScore)
    {
        playerTotalScore += CantidadAsumar;
        return;
    }

    public void GetInventarioP1(GameObject Player)
    {
        player1alforja = Player.GetComponent<Inventory>().InventarioPersonaje;
        return;
    }

    public void GetInventarioP2(GameObject Player)
    {
        player2alforja = Player.GetComponent<Inventory>().InventarioPersonaje;
        return;
    }

    public void GetDiceResult(int Dice)
    {
        diceResult = Dice;
        Debug.Log($"the dice says: {diceResult}");
    }





}
