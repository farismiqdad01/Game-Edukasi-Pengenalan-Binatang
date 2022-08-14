using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    [SerializeField] bool isReachEndPos = false;
    [SerializeField] float speedMove = 1;

    private void Update()
    {
        if (isReachEndPos == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speedMove * Time.deltaTime);
            if (transform.position == endPos.position)
            {
                isReachEndPos = true;
            }
        }
        if (isReachEndPos == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, speedMove * Time.deltaTime);
            if (transform.position == startPos.position)
            {
                isReachEndPos = false;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPos.position, endPos.position);
    }
}
