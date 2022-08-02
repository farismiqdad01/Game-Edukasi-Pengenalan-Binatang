using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.points++;
            AudioManager.instance.PlayerPoint();
            gameObject.SetActive(false);
        }
    }
}
