using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip scoreSound;

    int score = 0;

    public void changeScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score :" + score.ToString();

        if (scoreToAdd > 0)
        {
            source.clip = scoreSound;
            source.Play();
        }
    }
    
}
