using UnityEngine;
using System.Collections;
using FMODUnity;

public class PasswordCode : MonoBehaviour
{
    [SerializeField] private string password;
    [SerializeField] private string passInput;
    public StudioEventEmitter audioEmitter; // https://fmod.com/docs/2.03/unity/api-studioeventemitter.html
    public SafeDoorAnimation safeDoor;
    private bool canType = true;

    void Start()
    {
        password = Random.Range(0, 10000).ToString("D4"); // https://stackoverflow.com/questions/5418324
    }

    public void InsertCharacter(string number)
    {
        audioEmitter.Play();
        if(canType)
        {
            if(passInput.Length < 4)
            {
                passInput += number;
                Debug.Log(passInput);
            }
            if(passInput.Length >= 4)
            {
                PasswordEnter();
            }
        }
    }

    void PasswordEnter()
    {
        canType = false;
        if(passInput == password)
        {
            Debug.Log("SENHA CORRETA");
            safeDoor.PlayAnim();
        }
        else
        {
            Debug.Log("SENHA INCORRETA");
            passInput = "";
            canType = true;
        }
    }

    public string sendSenha()
    {
        return password;
    }
}
