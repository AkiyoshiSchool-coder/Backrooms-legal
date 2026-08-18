using TMPro;
using UnityEngine;
using FMODUnity;

public class Keys : MonoBehaviour
{
    public float keys = 0;
    [SerializeField] TextMeshProUGUI textochave; //Está no canvas dentro do object Chaves
    public StudioEventEmitter keySound;

    public void KeyChange() //Chamado pelo modelos de chave na hierarquia
    {
        keySound.Play();
        keys = keys + 1;
        UIManager.instance.ChangeText(textochave, keys.ToString());
    }
}
