using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
        RefreshUI();
    }

    public void IncrementScore(int value)
    {
        score += value;
        RefreshUI();
    }
    void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
}
