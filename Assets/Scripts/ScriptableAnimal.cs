using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "ScriptableAnimal", menuName = "GameEdukasi/ScriptableAnimal")]
public class ScriptableAnimal : ScriptableObject
{
    public bool caught;
    public Sprite animalImage;
    public Sprite animalSiluet;
    public AudioClip animalSound;
    [Header("Sifat Binatang")]
    public string animalName;
    public string animalHabitat, animalMakanan, animalBerkembangbiak, animalPeringatan;
    [ResizableTextArea] public string animalDescription;

}
