using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Penghubung : MonoBehaviour
{
    [SerializeField] SpriteRenderer wireEnd;
    [SerializeField] GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    private void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    public void OnMouseDrag()
    {
        //mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //checkfor nearby connections points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            //make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                //update wire to the connection point position
                UpdateWire(collider.transform.position);
                //check if the wires are same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    //count connection
                    QuizManager2.instance.SwitcCharge(1);
                    collider.GetComponent<Penghubung>()?.Done();
                    Done();
                }
                return;
            }
        }

        //update wire
        UpdateWire(newPosition);
    }
    void Done()
    {
        lightOn.SetActive(true);
        Destroy(this);
    }
    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }
    private void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;

        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        //update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
