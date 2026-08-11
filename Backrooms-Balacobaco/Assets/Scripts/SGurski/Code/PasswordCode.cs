using UnityEngine;
using System.Collections;

public class PasswordCode : MonoBehaviour
{
    [SerializeField] private string password;
    [SerializeField] private string passInput;
    public SafeDoorAnimation safeDoor;
    private bool canType = true;

    void Start()
    {
        password = Random.Range(0, 10000).ToString("D4"); // https://stackoverflow.com/questions/5418324
    }

    public void InsertCharacter(string number)
    {
        if(canType)
        {
            if(passInput.Length < 4)
            {
                passInput += number;
                Debug.Log(passInput);
            }
            if(passInput.Length >= 4)
            {
                StartCoroutine(PasswordEnter());
            }
        }
    }

    IEnumerator PasswordEnter()
    {
        canType = false;
        if(passInput == password)
        {
            Debug.Log("SENHA CORRETA");
            safeDoor.PlayAnim();
            yield break;
        }
        else
        {
            Debug.Log("SENHA INCORRETA");
            passInput = "";
        }
        canType = true;
    }

    public string sendSenha()
    {
        return password;
    }
}
