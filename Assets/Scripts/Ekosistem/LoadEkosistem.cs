using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEkosistem : MonoBehaviour
{
    [SerializeField] ScriptableEkosistem ekosistem;
    [SerializeField] Image spriteRenderer;
    [SerializeField] TMPro.TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = ekosistem.spriteEkosistem;
        textMeshPro.text = ekosistem.namaEkosistem;
    }
}
