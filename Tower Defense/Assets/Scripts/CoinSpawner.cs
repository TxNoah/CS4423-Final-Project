using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinz;

    void Start() {
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn() {
        Instantiate(coinz, transform.position, Quaternion.identity);
    }

    
}
