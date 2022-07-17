using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    [SerializeField] AudioClip buttonClick, backsoundMenu, backsoundGame, jump, point, openPuzzle, walk;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    public void PlayBacksoundMenu()
    {
        audioSource.PlayOneShot(backsoundMenu);
    }
    public void PlayerJump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void PlayerPoint()
    {
        audioSource.PlayOneShot(point);
    }
    public void Walk()
    {
        audioSource.clip = walk;
        audioSource.Play();
        audioSource.loop = true;
    }
}