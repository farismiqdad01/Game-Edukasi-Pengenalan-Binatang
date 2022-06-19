using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAnimal", menuName = "GameEdukasi/ScriptableAnimal")]
public class ScriptableAnimal : ScriptableObject
{
    public string animalName;
    public Sprite animalImage;
    public AudioClip animalSound;
    public string animalDescription;

}
