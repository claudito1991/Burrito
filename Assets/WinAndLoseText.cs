using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinAndLoseText : MonoBehaviour
{
    private TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TMP_Text>();
        texto.text = $"Ganaste {4}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
