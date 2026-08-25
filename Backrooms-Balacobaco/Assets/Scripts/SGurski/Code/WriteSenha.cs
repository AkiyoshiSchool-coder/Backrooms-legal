using UnityEngine;
using TMPro;

public class WriteSenha : MonoBehaviour
{
    [SerializeField] private TextMeshPro textoSenha;
    private PasswordCode passcode;

    public void Init(PasswordCode pass)
    {
        passcode = pass;
        textoSenha.text = passcode.sendSenha(); // manda a senha pro papel
    }
}
