using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinz;

    void Start() {
        InvokeRepeating("Spawn", 3, 3);
    }

    void Spawn() {
        Instantiate(coinz, transform.position, Quaternion.identity);
    }

    
}
