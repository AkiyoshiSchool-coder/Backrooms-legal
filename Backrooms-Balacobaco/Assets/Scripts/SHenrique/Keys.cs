using TMPro;
using UnityEngine;
using FMODUnity;

public class Keys : MonoBehaviour
{
    public float keys = 0;
    [SerializeField] TextMeshProUGUI textochave;
    public StudioEventEmitter keySound;

    public void KeyChange()
    {
        keySound.Play();
        keys = keys + 1;
        UIManager.instance.ChangeText(textochave, keys.ToString());
    }
}
