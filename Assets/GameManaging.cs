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
    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<Movement>().enabled = false;
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
        }
        else
        {
            player1.transform.position = player1SpawnLoc.position;
            player1.GetComponent<Movement>().enabled = false;
            player2.GetComponent<Movement>().enabled = true;
        }
        player1Turn = !player1Turn;
    }




    
}
