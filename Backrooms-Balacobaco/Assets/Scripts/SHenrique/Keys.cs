using TMPro;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public float keys = 0;
    [SerializeField] TextMeshProUGUI textochave;

    public void KeyChange()
    {
        keys = keys + 1;
        UIManager.instance.ChangeText(textochave, keys.ToString());
    }
}
