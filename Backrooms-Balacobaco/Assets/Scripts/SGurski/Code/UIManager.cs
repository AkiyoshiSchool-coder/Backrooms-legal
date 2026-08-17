using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI interactText;
    Texture image;
    bool mudanca = false;

    void Awake()
    {
        instance = this;
        image = gameObject.GetComponent<RawImage>().texture;
    }

    public void ChangeColor(Color cor)
    {
        gameObject.GetComponent<RawImage>().color = cor;
    }

    public void ChangeImage(Texture texture)
    {
        mudanca = !mudanca;
        if (mudanca == true)
            gameObject.GetComponent<RawImage>().texture = texture;
        else
            gameObject.GetComponent<RawImage>().texture = image;
    }

    public void InteractText(bool setYorN)
    {
        interactText.gameObject.SetActive(setYorN);
    }
}
