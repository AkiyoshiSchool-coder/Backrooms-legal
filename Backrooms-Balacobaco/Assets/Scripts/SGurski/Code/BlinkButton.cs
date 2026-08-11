using UnityEngine;
using System.Collections;

public class BlinkButton : MonoBehaviour
{
    public Light luz;
    [SerializeField] private float lightTime;
    [SerializeField] private float lightIntensity;

    public void Blink()
    {
        StartCoroutine(Pisca());
    }

    IEnumerator Pisca()
    {
        luz.intensity = lightIntensity;
        yield return new WaitForSeconds(lightTime);
        luz.intensity = 0;
        yield break;
    }
}
