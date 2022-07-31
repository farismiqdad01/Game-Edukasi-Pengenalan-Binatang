using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] GameObject objectHelper;
    [SerializeField] GameObject panelHelper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && objectHelper.activeSelf == false)
        {
            panelHelper.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelHelper.SetActive(false);
        }
    }
    public void UnlockHelper()
    {
        if (GameManager.instance.points >= 10)
        {
            objectHelper.SetActive(true);
            GameManager.instance.points -= 10;
            AudioManager.instance.Unlock();
            panelHelper.SetActive(false);
        }
        else
        {
            AudioManager.instance.Reject();
        }
    }
}
