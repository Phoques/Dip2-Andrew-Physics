using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    public float forceAmount = 500;

    Rigidbody dragObject;
    Vector3 offset;

    Vector3 originalPosition;
    private float selectionDistance;

    public GameObject marker;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                selectionDistance = Vector3.Distance(ray.origin, hit.point);

                dragObject = hit.rigidbody;
                offset = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                originalPosition = hit.collider.transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

        if(dragObject != null)
        {
            selectionDistance += Input.mouseScrollDelta.y * 0.2f;
        }

        

    }

    private void FixedUpdate()
    {
        if (dragObject)
        {
            marker.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, selectionDistance));

            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalPosition;

            dragObject.velocity = (originalPosition + mousePositionOffset - dragObject.transform.position) * forceAmount * Time.deltaTime;


        }
    }

}
