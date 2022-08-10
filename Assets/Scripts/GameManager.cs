using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] GameObject playerPrefab;
    [Header("Panel")]
    [SerializeField] GameObject pausePanel, FinishPanel;
    [SerializeField] GameObject animalPrefab;
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
        animalsCountText.text = animalCatched.ToString() + "/" + animalsOnThisScene.ToString();
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
        FinishPanel.SetActive(true);
        PlayerPrefs.SetInt("LevelUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 0;
    }
}
