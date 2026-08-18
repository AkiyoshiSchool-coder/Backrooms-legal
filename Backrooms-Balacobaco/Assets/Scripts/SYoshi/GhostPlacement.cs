using System;
using UnityEngine;
using FMODUnity;

public class GhostPlacement : MonoBehaviour
{
    public bool playerInRange;
    [SerializeField] private Animator animator;
    public bool onPillar;
    public bool open;
    [SerializeField] private bool Tocado = false;
    [SerializeField] private StudioEventEmitter GhostSound;

    void Update()
    {
        if(onPillar && Tocado != true)
        {
            StartAnim();
        }
    }

     public void StartAnim()
    {
        open = true;
        Animator();
        GhostSound.Play();
        Tocado = true;
    }

    private void Animator()
    {
        animator.SetBool("aberto", open);
    }

    private void OnTriggerEnter(Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
