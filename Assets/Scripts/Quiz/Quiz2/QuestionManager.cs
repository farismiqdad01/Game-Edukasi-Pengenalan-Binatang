using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    #region listpertanyaan
    [Header("List Pertanyaan")]
    public List<QuestionNAnswer> QnA;
    #endregion
    [Space(100)]
    [Header("List Opsi")]
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI questionText;

    private void Start()
    {
        GenerateQuestion();
    }
    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];
            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        questionText.text = QnA[currentQuestion].question;
        SetAnswer();

    }
}
