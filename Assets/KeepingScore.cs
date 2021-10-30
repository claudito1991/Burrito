using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepingScore : MonoBehaviour
{
    public GameManaging gameManager;
    public Text player1Score;
    public GameObject playerTag;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManaging>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerTag.CompareTag("Player"))
        {
            player1Score.text = gameManager.player1alforja.ToString();
        }

        else
        {
            player1Score.text = gameManager.player2alforja.ToString();
        }
        
    }
}
