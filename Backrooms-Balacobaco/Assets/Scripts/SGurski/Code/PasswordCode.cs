using UnityEngine;
using System.Collections;

public class PasswordCode : MonoBehaviour
{
    [SerializeField] private string password;
    [SerializeField] private string passInput;
    public SafeDoorAnimation safeDoor;
    private bool canType = true;

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
}
