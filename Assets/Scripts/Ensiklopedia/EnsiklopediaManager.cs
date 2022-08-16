using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnsiklopediaManager : MonoBehaviour
{
    [SerializeField] ScriptableAnimal animal;
    [SerializeField] GameObject binatang;
    [SerializeField] Image animalImage, habitatImage, makananImage, kembangBiakImage, peringataImage;
    [SerializeField] TextMeshProUGUI nama, deskripsiBinatang, habitat, Makanan, Berkembangbiak, Peringatan;
    [SerializeField] Sprite air, aman, amfibi, danger, darat, udara, herbivora, karnivora, omnivora, nektivora, granivora, ovipar, vivipar, ovovivipar;

    void Start()
    {
        animal = EnsiklopediaMenu.instance.animal;
        deskripsiBinatang.text = animal.animalDescription;
        nama.text = animal.animalName;
        animalImage.sprite = animal.animalImage;
        if (animal.animalHabitat == "Air")
        {
            habitatImage.sprite = air;
            habitat.text = "Air";
        }
        else if (animal.animalHabitat == "Darat")
        {
            habitatImage.sprite = darat;
            habitat.text = "Darat";
        }
        else if (animal.animalHabitat == "Amfibi")
        {
            habitatImage.sprite = amfibi;
            habitat.text = "Amfibi";
        }
        else
        {
            habitatImage.sprite = udara;
            habitat.text = "Udara";
        }
        if (animal.animalMakanan == "Karnivora")
        {
            makananImage.sprite = karnivora;
            Makanan.text = "Pemakan Daging (Karnivora)";
        }
        else if (animal.animalMakanan == "Herbivora")
        {
            makananImage.sprite = herbivora;
            Makanan.text = "Pemakan Tumbuhan (Herbivora)";
        }
        else if (animal.animalMakanan == "Omnivora")
        {
            makananImage.sprite = omnivora;
            Makanan.text = "Pemakan Segala (Omnivora)";
        }
        else if (animal.animalMakanan == "Nektivora")
        {
            makananImage.sprite = nektivora;
            Makanan.text = "Pemakan Nektar (Nektivora)";
        }
        else
        {
            makananImage.sprite = granivora;
            Makanan.text = "Pemakan Biji-bijian (Granivora)";
        }
        if (animal.animalBerkembangbiak == "Ovipar")
        {
            kembangBiakImage.sprite = ovipar;
            Berkembangbiak.text = "Bertelur (Ovipar)";
        }
        else if (animal.animalBerkembangbiak == "Vivipar")
        {
            kembangBiakImage.sprite = vivipar;
            Berkembangbiak.text = "Beranak (Vivipar)";
        }
        else
        {
            kembangBiakImage.sprite = ovovivipar;
            Berkembangbiak.text = "Bertelur dan Beranak (Ovovivipar)";
        }
        if (animal.animalPeringatan == "Aman")
        {
            peringataImage.sprite = aman;
            Peringatan.text = "Aman";
        }
        else
        {
            peringataImage.sprite = danger;
            Peringatan.text = "Berbahaya";
        }
    }

    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync("Ensiklopedia");
        AudioManager.instance.PlayButtonClick();
    }
}
