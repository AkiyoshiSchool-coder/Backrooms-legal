using UnityEngine;
using UnityEngine.UI;

public class RepositionPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 pos;
    [SerializeField] private Vector2 mobileScale = new Vector2(1, 1);
    public RectTransform objectPos;

    void Start()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            objectPos.anchoredPosition = objectPos.anchoredPosition+pos;
            objectPos.localScale = objectPos.localScale*mobileScale;
        }
    }
}
