using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI interactText, extraText;

    void Awake()
    {
        instance = this;
    }

    public void ChangeColor(Color cor)
    {
        gameObject.GetComponent<RawImage>().color = cor;
    }

    public void ChangeImage(Texture texture)
    {
        gameObject.GetComponent<RawImage>().texture = texture;
    }

    public void ChangeScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void ChangeText(TextMeshProUGUI textMeshProUGUI, string texto)
    {
        textMeshProUGUI.text = texto;
    }

    public void InteractText(bool setYorN)
    {
        interactText.gameObject.SetActive(setYorN);
    }

    public void ExtraText(string textoExtra)
    {
        if(extraText != null) // remover if quando o jogo estiver pronto
        {
            extraText.text = textoExtra;
        }
    }
}
