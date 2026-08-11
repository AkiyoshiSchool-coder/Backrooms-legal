using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MudardeCena(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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
