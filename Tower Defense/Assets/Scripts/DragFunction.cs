using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFunction : MonoBehaviour
{
    public GameObject GameItem;
    private GameObject currentPrefab;
    private Vector3 mouseOffset;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                isDragging = true;
                mouseOffset = transform.position - mousePosition;
                currentPrefab = Instantiate(GameItem, mousePosition, Quaternion.identity);
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPrefab.transform.position = new Vector3(mousePosition.x + mouseOffset.x, mousePosition.y + mouseOffset.y, transform.position.z);
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
    
