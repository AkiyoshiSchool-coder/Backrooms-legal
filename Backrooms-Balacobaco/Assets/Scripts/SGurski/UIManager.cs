using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI interactText;

    void Awake()
    {
        instance = this;
    }

    public void changeColor(Color cor)
    {
        gameObject.GetComponent<RawImage>().color = cor;
    }

    public void InteractText(bool setYorN)
    {
        interactText.gameObject.SetActive(setYorN);
    }
}
