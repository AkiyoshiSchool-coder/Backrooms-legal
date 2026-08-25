using UnityEngine;

public class HideOnPlatform : MonoBehaviour
{
    void Start()
    {
        if(Application.platform != RuntimePlatform.WindowsEditor)
        {
            gameObject.SetActive(false);
        }
    }
}