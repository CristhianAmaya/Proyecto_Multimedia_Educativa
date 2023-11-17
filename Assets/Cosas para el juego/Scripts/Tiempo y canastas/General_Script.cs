using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class General_Script : MonoBehaviour
{
    public int score_total = 0;
    public TextMeshPro score_text;

    public void AddScore(int score)
    {
        score_total += score;
        score_text.text = "Score: " + score_total;
        Debug.Log("Score: " + score_total);
    }
}
