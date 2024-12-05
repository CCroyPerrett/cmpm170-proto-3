using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject parent;

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(parent.transform.position);

        offset = parent.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        parent.transform.position = curPosition;
   
    }
}
