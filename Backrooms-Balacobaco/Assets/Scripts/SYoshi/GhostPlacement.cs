using System;
using UnityEngine;

public class GhostPlacement : MonoBehaviour
{

    public bool IsGhostChest = true;
    public bool playerInRange;
    [SerializeField] private Animator animator;
    public bool onPillar;
    public bool open;

    void Update()
    {
        if(onPillar)
        {
            StartAnim();
        }
    }

     public void StartAnim()
    {
       open = true;
       Animator();
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
}
