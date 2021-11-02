using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public List<Sprite> listaImagenes = new List<Sprite>();
    public List<GameObject> listaTexto = new List<GameObject>();
    public Image imagenAMostrar;
    public GameObject mainMenu;
    public GameObject tutorial;
    
    public int actualImage = 0;

    private void Start()
    {
        imagenAMostrar.sprite = listaImagenes[actualImage];
        listaTexto[actualImage].SetActive(true);
    }

    public void ImageLoader()
    {
        listaTexto[actualImage].SetActive(false);
        actualImage += 1;
        if(actualImage>=listaTexto.Count)
        {
            VolverAtras();
            actualImage = 0;
        }
        imagenAMostrar.sprite = listaImagenes[actualImage];
        
        listaTexto[actualImage].SetActive(true);

    }

    public void PreviousImage()
    {
        if(actualImage>=0)
        {
            listaTexto[actualImage].SetActive(false);
            actualImage -= 1;
            listaTexto[actualImage].SetActive(true);
            imagenAMostrar.sprite = listaImagenes[actualImage];
        }

        else
        {
            VolverAtras();
            actualImage = 0;
        }

        
    }



    public void VolverAtras()
    {
        mainMenu.SetActive(true);
        tutorial.SetActive(false);
    }
}
