using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //variable player
    [HideInInspector] public int points;

    [Header("GameObjects")]
    [SerializeField] GameObject pausePanel;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        points = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
