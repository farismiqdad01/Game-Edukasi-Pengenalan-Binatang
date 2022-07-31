using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int animalsOnThisScene = 0;

    //variable player
    public int points;
    [Header("Player")]
    [SerializeField] GameObject playerPrefab;
    [Header("Panel")]
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject animalPrefab;
    [SerializeField] TextMeshProUGUI animalsCountText;
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
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        animalsOnThisScene = animals.Length;
        animalsCountText.text = animalsOnThisScene.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // public void GameReset()
    // {

    //     Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    // }
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
