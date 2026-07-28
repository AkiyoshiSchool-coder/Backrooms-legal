using UnityEngine;
using System.Collections;
using TMPro;

public class PasswordCode : MonoBehaviour
{
    [SerializeField] private string password;
    private TextMeshPro passText;
    private bool canType = true;
    void Start()
    {
        passText = gameObject.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        Debug.Log(canType);
    }

    public void InsertCharacter(string number)
    {
        if(canType)
        {
            if(passText.text.Length < 4)
            {
                passText.text += number;
            }
            if(passText.text.Length >= 4)
            {
                StartCoroutine(PasswordEnter());
            }
        }
    }

    IEnumerator PasswordEnter()
    {
        canType = false;
        if(passText.text == password)
        {
            passText.color = Color.green;
            yield return new WaitForSeconds(0.8f);
            passText.text = "";
            yield return new WaitForSeconds(0.3f);
            passText.text = "CORRETO";
            yield break;
        }
        else
        {
            passText.color = Color.red;
            yield return new WaitForSeconds(0.8f);
            passText.text = "";
            yield return new WaitForSeconds(0.3f);
            passText.text = "ERRADO";
            yield return new WaitForSeconds(0.8f);
            passText.text = "";
            passText.color = Color.white;
        }
        canType = true;
    }
}
