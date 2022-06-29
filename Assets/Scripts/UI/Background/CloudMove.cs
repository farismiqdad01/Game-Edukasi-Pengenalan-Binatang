using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    Transform cloudTransform;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        cloudTransform = GetComponent<Transform>();
        Rect rect = GetComponent<RectTransform>().rect;
        rect.width = Random.Range(300, 500);
        rect.height = Random.Range(300, 500);
        speed = Random.Range(0.5f, 1.5f);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        cloudTransform.position += new Vector3(speed, 0, 0);
    }
}
