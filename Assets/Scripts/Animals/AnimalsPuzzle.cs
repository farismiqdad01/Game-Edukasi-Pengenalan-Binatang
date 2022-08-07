using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsPuzzle : MonoBehaviour
{
    private Collider2D col;
    AnimalProfile animalProfile;
    [SerializeField] GameObject confirmPuzzlePanel;

    // Start is called before the first frame update
    void Start()
    {
        animalProfile = GetComponent<AnimalProfile>();
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
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Additive);
        GameManager.instance.animal = animalProfile.animal;
        GameManager.instance.GotoPuzzle();
    }
}
