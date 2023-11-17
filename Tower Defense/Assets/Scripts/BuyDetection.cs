using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDetection : MonoBehaviour
{
    public int coinValue = 0;
    private CoinCollection CoinCollection;

    private void Start(){
        CoinCollection = FindObjectOfType<CoinCollection>();
    }

    void OnMouseDown() {
        
        CoinCollection.DecreaseScore(coinValue);
    }
}
