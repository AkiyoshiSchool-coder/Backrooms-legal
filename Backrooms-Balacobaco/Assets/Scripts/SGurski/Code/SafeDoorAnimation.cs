using UnityEngine;
using System.Collections;

public class SafeDoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AnimationClip doorOpening;

    public void PlayAnim()
    {
        StartCoroutine(doorAnimation());
    }

    IEnumerator doorAnimation()
    {
        doorAnimator.SetBool("playAnim", true);
        yield return new WaitForSeconds(doorOpening.length);
        doorAnimator.SetBool("animDone", true);
    }
}
