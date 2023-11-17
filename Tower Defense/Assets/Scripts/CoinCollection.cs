using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public Text scoreText;

    private int score = 300;

    private void Start(){

        UpdateScoreDisplay();
    }

    public int GetScore() {
        return score;
    }

    public void IncreaseScore(int amount){

        score += amount;
        UpdateScoreDisplay();
    }

    public void DecreaseScore(int amount){

        score -= amount;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay(){
        scoreText.text = "Coins: " + score.ToString();
    }

}
