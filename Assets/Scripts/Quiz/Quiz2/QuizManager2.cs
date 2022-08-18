using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    public static QuizManager2 instance;
    public int switchCount;
    [SerializeField] GameObject puzzleRope;
    [SerializeField] GameObject QuizPanel;
    int onCount = 0;
    private void Awake()
    {
        instance = this;
    }

    public void SwitcCharge(int point)
    {
        onCount = onCount + point;
        if (onCount == switchCount)
        {
            puzzleRope.SetActive(false);
            Done();
        }
    }
    public void Done()
    {
        // if (onCount == switchCount)
        // {
        //     hasilConfirmation.text = "Lanjutkan";
        //     AudioManager.instance.Win();
        // }
        // else
        // {
        //     hasilConfirmation.text = "Ulangi";
        //     AudioManager.instance.Lose();
        // }
        // onCount = onCount * 100 / switchCount;
        // score.text = onCount.ToString();
        QuizPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
