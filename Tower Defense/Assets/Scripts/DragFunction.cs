using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragFunction : MonoBehaviour
{
    public GameObject GameItem;
    private GameObject currentPrefab;
    private CoinCollection CoinCollection;
    private Vector3 mouseOffset;
    private bool isDragging = false;
    
    public int coinValue = 0;
    public TMP_Text popupText;

    private void Start(){
        CoinCollection = FindObjectOfType<CoinCollection>();
        popupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (CoinCollection.GetScore() >= coinValue) {

                if (hitCollider != null && hitCollider.gameObject == gameObject) {
                    CoinCollection.DecreaseScore(coinValue);
                    isDragging = true;
                    mouseOffset = transform.position - mousePosition;
                    currentPrefab = Instantiate(GameItem, mousePosition, Quaternion.identity);
                }

                else {
                    // Show popup text when not enough coins
                    ShowPopupText("Not enough coins!");
                }
            }

        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPrefab.transform.position = new Vector3(mousePosition.x + mouseOffset.x, mousePosition.y + mouseOffset.y, transform.position.z);
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            currentPrefab.GetComponent<BoxCollider2D>().enabled = true;
            currentPrefab = null;
            isDragging = false;
        }

    }

    private void ShowPopupText(string message) {
        popupText.text = message;
        popupText.gameObject.SetActive(true);

        // Hide the popup text after 2 seconds (adjust the time as needed)
        Invoke("HidePopupText", 2f);
    }

    private void HidePopupText() {
        popupText.gameObject.SetActive(false);
    }
}