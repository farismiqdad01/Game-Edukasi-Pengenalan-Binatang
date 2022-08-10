using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsPuzzle : MonoBehaviour
{
    private Collider2D col;
    ScriptableAnimal animal;
    AnimalProfile animalProfile;
    AudioSource audioSource;
    [SerializeField] GameObject confirmPuzzlePanel;

    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<AnimalProfile>().animal;
        audioSource = GetComponent<AudioSource>();
        animalProfile = GetComponent<AnimalProfile>();
        col = GetComponent<Collider2D>();
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(animal.animalSound);
        }
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
        this.gameObject.SetActive(false);
    }
}
