using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    int score = 0;

    public void AddScore()
    {
        score = score + 1;
        text.text = "Score: " + score;
    }
}
