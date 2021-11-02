using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurnos : MonoBehaviour
{
    public Text texto;

    public void MostrarTurnos(int cantidadTurnos)
    {
        texto.text = cantidadTurnos.ToString();
    }
}


