using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelUnlocked = 1;
    [SerializeField] Button[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
}
