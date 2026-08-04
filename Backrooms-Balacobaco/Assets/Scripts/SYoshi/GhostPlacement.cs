using System;
using UnityEngine;

public class GhostPlacement : MonoBehaviour
{

    public bool playerInRange;
    [SerializeField] private Animator animator;


    private void OnTriggerEnter( Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void Animator()
    {
        
    }
}
