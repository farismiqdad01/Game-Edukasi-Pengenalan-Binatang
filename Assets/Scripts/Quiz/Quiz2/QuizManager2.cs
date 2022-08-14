using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    public static QuizManager2 instance;
    public int switchCount;
    [SerializeField] GameObject hasilPanel;
    [SerializeField] GameObject QuizPanel;
    int onCount = 0;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI hasilConfirmation;
    private void Awake()
    {
        instance = this;
    }

    public void SwitcCharge(int point)
    {
        onCount = onCount + point;
        if (onCount == switchCount)
        {
            hasilPanel.SetActive(true);
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
}
