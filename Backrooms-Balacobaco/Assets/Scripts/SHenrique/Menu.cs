using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuObject, creditosObject, controlesObject;
    public StudioEventEmitter audioEmitter;

    public void MudardeCena(int sceneIndex)
    {
        ClickButton();
        SceneManager.LoadScene(sceneIndex);
    }

    public void Creditos(bool open)
    {
        ClickButton();
        creditosObject.SetActive(open);
        mainMenuObject.SetActive(!open);
    }

    public void Controles(bool open)
    {
        ClickButton();
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

    public void ClickButton()
    {
        audioEmitter.Play();
    }
}
