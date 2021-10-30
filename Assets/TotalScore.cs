using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    private void Start()
    {
        slider.value = 0;
    }
    public void SetScore(int score)
    {
        slider.value = score;
    }

    public void MaxScoreUI(int maxScore)
    {
        slider.maxValue = maxScore;
        slider.value = 0;
    }
}
