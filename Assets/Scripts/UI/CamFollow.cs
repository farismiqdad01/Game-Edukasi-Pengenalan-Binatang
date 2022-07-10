using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script ini ditempelkan di objek kamera dan ditargetkan ke player.
/// default kamera berada di posisi (0,0,-10) dan menghadap ke player.
/// </summary>

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2f, -10);

    [Range(0, 10)] public float smoothSpeed = 1.8f;
    private void Start()
    {
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
