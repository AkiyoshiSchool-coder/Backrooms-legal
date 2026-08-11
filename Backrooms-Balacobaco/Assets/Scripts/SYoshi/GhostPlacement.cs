using System;
using UnityEngine;

public class GhostPlacement : MonoBehaviour
{

    public bool playerInRange;
    [SerializeField] private Animator animator;
    private bool onPillar;
    public bool open;


    private void OnTriggerEnter( Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            playerInRange = true;
        }
        if(colisao.CompareTag("Pilar"))
        {
            onPillar = true;
        }
    }

    public void CheckPillar()
    {
       // if()
    }

    private void Animator()
    {
        animator.SetBool("aberto", open);
    }
}
