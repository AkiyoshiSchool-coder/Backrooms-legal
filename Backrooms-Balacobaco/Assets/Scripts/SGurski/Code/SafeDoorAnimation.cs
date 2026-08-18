using UnityEngine;
using System.Collections;
using FMODUnity;

public class SafeDoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AnimationClip doorOpening;
    [SerializeField] private StudioEventEmitter openSound;

    public void PlayAnim()
    {
        StartCoroutine(doorAnimation());
        openSound.Play();
    }

    IEnumerator doorAnimation()
    {
        doorAnimator.SetBool("playAnim", true);
        yield return new WaitForSeconds(doorOpening.length);
        doorAnimator.SetBool("animDone", true);
    }
}
