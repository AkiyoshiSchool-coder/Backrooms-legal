using UnityEngine;

public class HideOnPlatform : MonoBehaviour
{
    public bool showOnMobile;
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            gameObject.SetActive(showOnMobile);
        }
        else
        {
            gameObject.SetActive(!showOnMobile);
        }
    }
}