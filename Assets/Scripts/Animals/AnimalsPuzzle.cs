using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPuzzle : MonoBehaviour
{
    private Collider2D col;
    private bool isPuzzleSolved = false;
    private bool isPuzzleStarted = false;
    private bool isPuzzleFinished = false;
    private bool isPuzzleFailed = false;
    private bool isPuzzlePaused = false;
    private bool isPuzzleResumed = false;
    private bool isPuzzleRestarted = false;
    private bool isPuzzleReset = false;
    private bool isPuzzleSuspended = false;
    private bool isPuzzleUnsuspended = false;
    private bool isPuzzleDisabled = false;
    private bool isPuzzleEnabled = false;
    private bool isPuzzleDestroyed = false;
    private bool isPuzzleCreated = false;
    private bool isPuzzleLoaded = false;
    private bool isPuzzleUnloaded = false;
    private bool isPuzzleSaved = false;
    private bool isPuzzleLoadedFromSave = false;
    private bool isPuzzleSavedToSave = false;
    private bool isPuzzleLoadedFromSaveWithKey = false;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player is near the puzzle");
        }
    }
}
