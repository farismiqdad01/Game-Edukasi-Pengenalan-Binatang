using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int unlockedLevel = 1;
    [Header("Animals")]
    public ScriptableAnimal animal;
    int animalsOnThisScene = 0;

    //variable player
    [Header("Point")]
    [SerializeField] TextMeshProUGUI pointText;
    public int points;
    [Header("Player")]
    public Vector3 checkpoint;
    public int health;
    [SerializeField] Slider healthSlider;
    [Header("Panel")]
    [SerializeField] GameObject pausePanel, finishPanel, gameOverPanel;
    [SerializeField] TextMeshProUGUI animalsCountText;
    public int animalCatched;
    [Header("Puzzle")]
    [SerializeField] GameObject[] disable;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
    }
    private void Start()
    {
        health = 5;
        points = 0;
        animalCatched = 0;
        Time.timeScale = 1;
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        animalsOnThisScene = animals.Length; ;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = points.ToString();
        healthSlider.value = health;
        if (health <= 0)
        {
            GameOver();
        }
        animalsCountText.text = animalCatched.ToString() + "/" + animalsOnThisScene.ToString();
        if (animalCatched == animalsOnThisScene)
        {
            FinishGame();
        }
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
    public void GotoPuzzle()
    {
        disable[0].SetActive(false);
        disable[1].SetActive(false);
    }
    public void BacktoGame()
    {
        disable[0].SetActive(true);
        disable[1].SetActive(true);
    }
    public void FinishGame()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
        finishPanel.SetActive(true);
        Time.timeScale = 0;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("LevelUnlocked"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", currentLevel + 1);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
