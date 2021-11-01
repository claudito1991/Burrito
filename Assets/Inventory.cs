using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int InventarioPersonaje;
    public GameManaging gameManager;
    public GameObject parentTag;
    public GameObject textMesh;
    public Camera mainCamera;
    public GameObject textoPerdiste;
    public bool perdiste;
    public GameObject cafeMolido;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(InventarioPersonaje>0)
        {
            cafeMolido.SetActive(true);
        }

        if (InventarioPersonaje == 0)
        {
            cafeMolido.SetActive(false);
        }

    }

    public void InventarioLocal(int CantidadAsumar)
    {
        perdiste = false;
        InventarioPersonaje += CantidadAsumar;

        if (InventarioPersonaje > gameManager.maxAlforja)
        {
            perdiste = true;
            ShowPerdiste(textoPerdiste);
            InventarioPersonaje = 0;
        }

        if (CantidadAsumar >0 && !perdiste)
        {
            ShowText(textMesh, CantidadAsumar);
            
        }
        


        if (parentTag.CompareTag("Player"))
        {
            gameManager.player1alforja = InventarioPersonaje;
        }

        else
        {
            gameManager.player2alforja = InventarioPersonaje;
        }
    }

    public void ResetLocalInventory()
    {
        InventarioPersonaje = 0;
    }

    public void ShowText(GameObject texto, int CantidadASumar)
    {

            var textoInstanciado = Instantiate(texto, parentTag.transform.position, Quaternion.identity);
            textoInstanciado.transform.LookAt(mainCamera.transform.position);
            textoInstanciado.transform.Rotate(Vector3.up, 180);

            textoInstanciado.GetComponent<TMP_Text>().text = "+ " + CantidadASumar.ToString();
        

    }

    public void ShowPerdiste(GameObject texto)
    {

        var textoInstanciado = Instantiate(texto, parentTag.transform.position, Quaternion.identity);
        textoInstanciado.transform.LookAt(mainCamera.transform.position);
        textoInstanciado.transform.Rotate(Vector3.up, 180);
        textoInstanciado.GetComponent<TMP_Text>().color = Color.red;
        textoInstanciado.GetComponent<TMP_Text>().text = "¡Perdiste el café!";


    }
}
