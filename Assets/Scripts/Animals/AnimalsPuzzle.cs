using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPuzzle : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] GameObject confirmPuzzlePanel;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            confirmPuzzlePanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            confirmPuzzlePanel.SetActive(false);
        }
    }
    public void EnterPuzzle()
    {

    }
}
