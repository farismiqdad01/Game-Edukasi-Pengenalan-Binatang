using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject[] questions;
    [SerializeField] GameObject panelHasil;
    [Header("Hasil")]
    [SerializeField] TextMeshProUGUI hasil;
    int answered = 0;
    int correct = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        questions[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Answer(bool isCorrect)
    {
        answered++;
        if (isCorrect)
        {
            correct++;
        }
        if (answered == questions.Length)
        {
            Debug.Log("You got " + correct + " out of " + questions.Length);
            Done();
        }
        else
        {
            questions[answered].SetActive(true);
        }
        questions[answered - 1].SetActive(false);
    }
    public void Done()
    {
        GetComponent<AudioSource>().Stop();
        int point = correct * 100 / questions.Length;
        score.text = point.ToString();
        panelHasil.SetActive(true);
        if (correct >= 4)
        {
            hasil.text = "Lanjutkan";
            AudioManager.instance.Win();
        }
        else
        {
            hasil.text = "Ulangi";
            AudioManager.instance.Lose();
        }
    }
    public void Confirmation()
    {
        if (correct < 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
