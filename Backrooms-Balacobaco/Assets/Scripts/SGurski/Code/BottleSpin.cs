using UnityEngine;
using System.Collections;

public class BottleSpin : MonoBehaviour
{
    Coroutine corrotina;
    private float timer = 0f;

    public void OpenBottle()
    {
        if(corrotina==null)
        {
            corrotina = StartCoroutine(BottleAnimation());
        }
    }

    IEnumerator BottleAnimation()
    {
        timer+=Time.deltaTime;
        if(timer<=1)
        {
            transform.Rotate(0, 720*Time.deltaTime, 0, Space.World);
            transform.Translate(0, 0.1f*Time.deltaTime, 0);
            yield return null; 
        } 
        else
        {
            yield break;
        }
    }
}
