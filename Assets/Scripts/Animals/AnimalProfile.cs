using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalProfile : MonoBehaviour
{
    [SerializeField] ScriptableAnimal animal;

    //referensi component
    [SerializeField] Image animalImage;
    [SerializeField] TMPro.TextMeshProUGUI animalName;
    private void Start()
    {

    }
}
