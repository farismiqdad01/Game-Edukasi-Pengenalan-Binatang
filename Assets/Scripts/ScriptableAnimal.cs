using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAnimal", menuName = "GameEdukasi/ScriptableAnimal")]
public class ScriptableAnimal : ScriptableObject
{
    public bool caught;
    public string animalName;
    public Sprite animalImage;
    public Sprite animalSiluet;
    public AudioClip animalSound;
    [TextArea] public string animalDescription;

}
