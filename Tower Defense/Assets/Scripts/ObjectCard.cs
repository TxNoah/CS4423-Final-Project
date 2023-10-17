using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour
{
    /*public GameObject object_Drag;
    public GameObject object_Game;
    private GameObject objectDragInstance;
    private GameManager gameManager;

    private void Start(){
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData){
        objectDragInstance.transform.position = Input.mousePosition;
    }
    void OnMouseDown()
    {
        objectDragInstance = Instantiate(object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<DragFunction>().card = this;
        
        gameManager.draggingObject = objectDragInstance;
    }
    void OnMouseUp()
    {
        gameManager.PlaceObject();
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
    }

    public void OnPointerDown(PointerEventData eventData){
        objectDragInstance = Instantiate(object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<DragFunction>().card = this;
        
        gameManager.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData){
        gameManager.PlaceObject();
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
    }
    */

}
