using UnityEngine;

public class HideOnPlatform : MonoBehaviour
{
    void Start()
    {
        if(Application.platform != RuntimePlatform.Android)
        {
            gameObject.SetActive(false);
        }
    }
}