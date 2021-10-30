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

    public TotalScore scoreUI;
    public TotalScore scoreUIP2;
    public int setMaxScore = 30;


    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<Movement>().enabled = false;
        player1alforja = player1.GetComponent<Inventory>().InventarioPersonaje;
        player2alforja = player2.GetComponent<Inventory>().InventarioPersonaje;
        scoreUI.MaxScoreUI(setMaxScore);
        scoreUIP2.MaxScoreUI(setMaxScore);

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
            scoreUIP2.SetScore(player2TotalScore);
            WinningConditionCheck(player2TotalScore, player2);
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
            scoreUI.SetScore(player1TotalScore);
            WinningConditionCheck(player1TotalScore, player1);
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
        
    }
  
    public void GetInventarioP2(GameObject Player)
    {
        player2alforja = Player.GetComponent<Inventory>().InventarioPersonaje;
        
    }

    public void GetDiceResult(int Dice)
    {
        diceResult = Dice;
        Debug.Log($"the dice says: {diceResult}");
    }

    public void WinningConditionCheck(int playerScore, GameObject player)
    {
        if (playerScore >= setMaxScore)
        {
            Debug.Log($"Ganó el player: {player}");
        }
        

        
    }





}
