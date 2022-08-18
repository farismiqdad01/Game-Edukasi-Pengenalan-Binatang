using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FilterEnsiklopedia : MonoBehaviour
{
    [SerializeField] ScriptableAnimal animal;
    private void Awake()
    {
        animal = GetComponent<AnimalProfile>().animal;
        if (PlayerPrefs.GetString(animal.name) == "true")
        {
            gameObject.SetActive(true);
            animal.caught = true;
        }
    }
    private void Start()
    {

    }
    private void OnDisable()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (EnsiklopediaMenu.instance.udara && animal.animalHabitat == "Udara")
        {
            gameObject.SetActive(true);
        }
        else if (EnsiklopediaMenu.instance.darat && animal.animalHabitat == "Darat")
        {
            gameObject.SetActive(true);
        }
        else if (EnsiklopediaMenu.instance.amfibi && animal.animalHabitat == "Amfibi")
        {
            gameObject.SetActive(true);
        }
        else if (EnsiklopediaMenu.instance.air && animal.animalHabitat == "Air")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void EnterEnsiklopedia()
    {
        EnsiklopediaMenu.instance.animal = animal;
        if (animal.caught)
        {
            SceneManager.LoadScene("Ensiklopedia", LoadSceneMode.Additive);
        }
    }

}
