using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Start(){

        UpdateScoreDisplay();
    }

    public void IncreaseScore(int amount){

        score += amount;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay(){
        scoreText.text = "Coins: " + score.ToString();
    }
}
