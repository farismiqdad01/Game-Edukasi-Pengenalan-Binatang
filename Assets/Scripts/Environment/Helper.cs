using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [SerializeField] GameObject objectHelper;
    [SerializeField] Image imageHelper;
    [SerializeField] GameObject panelHelper;
    // Start is called before the first frame update
    void Start()
    {
        imageHelper.sprite = objectHelper.GetComponent<SpriteRenderer>().sprite;
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
