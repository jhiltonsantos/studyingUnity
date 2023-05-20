using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool isBeingDragged { get; private set; }
    private Vector3 initialPosition;
    private float dragDistance;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        dragDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        if (isBeingDragged)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f);
                    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                    rb.MovePosition(objectPosition);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isBeingDragged = false;
                    rb.isKinematic = false;

                    if (!ObjectCorrectPositon())
                    {
                        rb.MovePosition(initialPosition);
                    }
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isBeingDragged)
        {
            isBeingDragged = true;
            initialPosition = transform.position;
        }
    }

    private bool ObjectCorrectPositon()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.CompareTag("Destiny"))
            {
                return true;
            }
        }

        return false;
    }

}
