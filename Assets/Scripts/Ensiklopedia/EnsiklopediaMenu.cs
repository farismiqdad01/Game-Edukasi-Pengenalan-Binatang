using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsiklopediaMenu : MonoBehaviour
{
    public static EnsiklopediaMenu instance;
    public ScriptableAnimal animal;
    public bool air, darat, amfibi, udara;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    public void SelectEnsiklopedia(string habitat)
    {
        if (habitat == "Air")
        {
            air = true;
            darat = false;
            amfibi = false;
            udara = false;
        }
        else if (habitat == "Darat")
        {
            air = false;
            darat = true;
            amfibi = false;
            udara = false;
        }
        else if (habitat == "Amfibi")
        {
            air = false;
            darat = false;
            amfibi = true;
            udara = false;
        }
        else
        {
            air = false;
            darat = false;
            amfibi = false;
            udara = true;
        }
    }
}
