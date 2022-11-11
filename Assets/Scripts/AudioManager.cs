using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    [SerializeField] AudioClip buttonClick, point, jump, win, lose, reject, unlock, jumpWater;
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
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    public void PlayerJump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void PlayerJumpWater()
    {
        audioSource.PlayOneShot(jumpWater);
    }
    public void PlayerPoint()
    {
        audioSource.PlayOneShot(point);
    }
    public void Win()
    {
        audioSource.PlayOneShot(win);
    }
    public void Lose()
    {
        audioSource.PlayOneShot(lose);
    }
    public void Reject()
    {
        audioSource.PlayOneShot(reject);
    }
    public void Unlock()
    {
        audioSource.PlayOneShot(unlock);
    }
}
