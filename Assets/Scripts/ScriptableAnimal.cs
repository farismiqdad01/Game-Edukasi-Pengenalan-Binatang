using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [TextArea] public string animalDescription;

}
