using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI point;
    private void OnDisable()
    {
        point = GameObject.Find("Pointtxt").GetComponent<TextMeshProUGUI>();
        point.text = GameManager.instance.points.ToString();
    }
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
