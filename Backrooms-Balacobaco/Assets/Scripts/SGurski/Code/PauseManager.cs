using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class PauseManager : MonoBehaviour
{
    public GameObject controlesMenu, pauseMenu;
    public PlayerInteraction playerCode;
    public StudioEventEmitter audioEmitter;

    public void Controles()
    {
        ClickButton();
        pauseMenu.SetActive(false);
        controlesMenu.SetActive(true);
    }

    public void Voltar()
    {
        ClickButton();
        pauseMenu.SetActive(true);
        controlesMenu.SetActive(false);
    }

    public void Continuar()
    {
        ClickButton();
        playerCode.Pausar();
    }

    public void Menu()
    {
        ClickButton();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuInicial");
    }
    
    public void ClickButton()
    {
        audioEmitter.Play();
    }
}
