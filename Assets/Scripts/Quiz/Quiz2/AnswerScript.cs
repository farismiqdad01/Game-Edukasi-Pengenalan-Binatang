using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public QuestionManager questionManager;
    public bool isCorrect = false;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Benar");
            questionManager.Correct();
        }
        else
        {
            Debug.Log("Salah");
            questionManager.Correct();
        }
    }
}
