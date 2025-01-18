using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {
        Vector3 launchVector = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition) - transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(launchVector * 5000);
    }


}
