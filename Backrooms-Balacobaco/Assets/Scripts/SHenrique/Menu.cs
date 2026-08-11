using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuObject, creditosObject, controlesObject;

    public void MudardeCena(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Creditos(bool open)
    {
        creditosObject.SetActive(open);
        mainMenuObject.SetActive(!open);
    }

    public void Controles(bool open)
    {
        controlesObject.SetActive(open);
        mainMenuObject.SetActive(!open);
    }

    public void Sair()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    } 
}
