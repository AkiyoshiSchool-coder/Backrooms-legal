using UnityEngine;
using TMPro;

public class PasswordCode : MonoBehaviour
{
    [SerializeField] private string password;
    private TextMeshPro passText;
    void Start()
    {
        passText = gameObject.GetComponent<TextMeshPro>();
    }

    public void InsertCharacter(string number)
    {
        if(passText.text.Length < 4)
        {
            passText.text += number;
        }
        else if(passText.text.Length >= 4)
        {
            EnterText();
        }
    }

    public void EnterText()
    {
        if(passText.text == password)
        {
            Debug.Log("moranget abacatudo 67 42");
        }
        else
        {
            Debug.Log("errou");
        }
        passText.text = "";
    }
}
