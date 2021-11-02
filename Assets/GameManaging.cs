using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{

    public List<int> listaSkippedTurns = new List<int>();
    public Camera mainCamera;
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
    public WinAndLoseText TMPText;
    public int setMaxScore;

    public bool playerOneWins = false;
    public bool playerTwiWins = false;
    public bool bothTurnsSkipped = false;

    public CamControl followingCamera;
    public bool noSuma;
    public int maxAlforja;

    public GameObject diceText;
    public GameObject _currentObjectText;

    public Volcador volcador;
    public Collider baseColliderP1;
    public Collider baseColliderP2;


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
       // Debug.Log($"player 1 alfoja value: {player1alforja}");
        //Debug.Log($"player 1 alfoja value: {player2alforja}");

    }

    public void ChangeTurn()
    {
        

        if (player1Turn)
        {
            followingCamera.player = player1.transform;
            player2.transform.position = player2SpawnLoc.position;
            player2.GetComponent<Movement>().enabled = false;
            player1.GetComponent<Movement>().enabled = true;
            //player1.GetComponent<Movement>().waypointIndex = -1;
            GetInventarioP2(player2);
            if(!noSuma)
            {
                player2TotalScore += player2alforja;
                volcador.GenerateCoffeInBase(player2, player2alforja, baseColliderP2);
            }
            

            scoreUIP2.SetScore(player2TotalScore);
            player1.GetComponent<TransitedNodeList>().EraseTransitedNodeList();
            player2alforja = 0;
            player2.GetComponent<Inventory>().ResetLocalInventory();
            noSuma = false;
            EndGame();


        }
        else
        {
            followingCamera.player = player2.transform;
            player1.transform.position = player1SpawnLoc.position;
            player1.GetComponent<Movement>().enabled = false;
            player2.GetComponent<Movement>().enabled = true;
            //player2.GetComponent<Movement>().waypointIndex = -1;
            GetInventarioP1(player1);
            if(!noSuma)
            {
                player1TotalScore += player1alforja;
                volcador.GenerateCoffeInBase(player1, player1alforja, baseColliderP1);
            }

          

            
            
            scoreUI.SetScore(player1TotalScore);
            player2.GetComponent<TransitedNodeList>().EraseTransitedNodeList();
            player1alforja = 0;
            player1.GetComponent<Inventory>().ResetLocalInventory();
            EndGame();
            noSuma = false;
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

    public void  GetDiceResult(int Dice, GameObject player)
    {
        diceResult = Dice;



        if (player == player1 && diceResult == player1alforja)
        {
            noSuma = true;
            var Perdiste = player1.GetComponent<Inventory>().ShowPerdiste();
            Perdiste.transform.position = new Vector3(0, 2, 0)+ player1.transform.position;
            player1alforja = 0;
           
        }
        if (player == player2 && diceResult == player2alforja)
        {
            noSuma = true;
            var Perdiste = player2.GetComponent<Inventory>().ShowPerdiste();
            Perdiste.transform.position = new Vector3(0, 2, 0) + player2.transform.position;
            player2alforja = 0;
            //player1.GetComponent<Inventory>().ShowPerdiste();
            

        }


        //Debug.Log($"the dice says: {diceResult}");
    }

    //public void WinningConditionCheck(int playerScore, GameObject player, bool playerWon)
    //{
    //    if (playerScore >= setMaxScore )
    //    {
            
    //        playerWon = true;
    //    }
    //}

    public void WinOrLose()
    {
        //Esto chequea primero si el score alcanzado es superior al score necesario para ganar y dispara un booleano en consecuencia.

       if( player1TotalScore>=setMaxScore)
        {
            playerOneWins = true;
        }
        if (setMaxScore <= player2TotalScore)
        {
            playerTwiWins= true;
        }

        //Si ambos jugadores pasan el turno de manera continuada. Se termina el juego. En este caso se chequea el puntaje mayor para determinar el victorioso.
        if (bothTurnsSkipped)
        {
            if(player1TotalScore>player2TotalScore)
            {
                playerOneWins = true;
            }
            if(player1TotalScore<player2TotalScore)
            {
                playerTwiWins = true;
            }
        }
    }

    public void DiceChecker(int diceResult, int playerAlforja)
    {
        if(diceResult == playerAlforja)
        {
            playerAlforja = 0;
        }
    }






    public void CheckPassedTurns()
    {
        //Este codigo comienza a contar cuando la cantidad de turnos pasados es de 2 o mayor. Si es así chequea cada vez que es llamado y hay dos 
        //turnos consecutivos con el mismo valor.
        if (listaSkippedTurns.Count>=2)
        {
            for (int i = 0; i < listaSkippedTurns.Count-1; i++)
            {
                if (listaSkippedTurns[i] == listaSkippedTurns[i + 1] && listaSkippedTurns[i]==1)
                {
                    Debug.Log("Ambos pasaron el turno");
                    bothTurnsSkipped = true;
                    EndGame();
                }
            }
        }

    }

    public void EndGame()
    {
        WinOrLose();
        if (playerOneWins)
        {
            Debug.Log("Se acabó el juego ganó Player1");
            player1.SetActive(false);
            player2.SetActive(false);
            TMPText.TMPText(player1);
            Debug.Log("Trigerea endgame");

        }

        if(playerTwiWins)
        {
            Debug.Log("Se acabó el juego ganó el Player2");
            player1.SetActive(false);
            player2.SetActive(false);
            TMPText.TMPText(player2);
            Debug.Log("Trigerea endgame");
        }

    }





}
