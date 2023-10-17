using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 25; // Set the score value for the item.
    private CoinCollection CoinCollection;
    public Vector2 velocity;

    private void Start(){
        CoinCollection = FindObjectOfType<CoinCollection>();
    }

    void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
    
    void OnMouseDown() {

        CoinCollection.IncreaseScore(coinValue);
        Destroy(gameObject);
    }

}