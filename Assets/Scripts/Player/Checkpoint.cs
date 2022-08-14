using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = GetComponent<Transform>().position;
        checkpoint.z = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.checkpoint = checkpoint;
        }
    }
}
