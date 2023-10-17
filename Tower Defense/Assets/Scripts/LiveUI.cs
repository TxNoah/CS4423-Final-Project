using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text LiveCounter;

    void Start()
    {
        lives = baseLives;
        LiveCounter = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        LiveCounter.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
    }
}
