using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimations : MonoBehaviour
{
    //Referensi komponen
    [SerializeField] Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenEnsiklopedia()
    {
        animator.Play("OpenEnsiklopedia");
    }
}
