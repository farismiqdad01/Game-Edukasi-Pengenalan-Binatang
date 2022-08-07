using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalProfile : MonoBehaviour
{
    public ScriptableAnimal animal;

    //referensi component
    [SerializeField] Image animalImage;
    public SpriteRenderer animalSprite;
    [SerializeField] TMPro.TextMeshProUGUI animalName;
    private void Start()
    {
        animalSprite = GetComponent<SpriteRenderer>();
        if (animalSprite != null)
        {
            animalSprite.sprite = animal.animalSiluet;
        }
        else if (animal.caught == true)
        {
            animalName.text = animal.animalName;
            animalImage.sprite = animal.animalImage;
        }
    }
}
