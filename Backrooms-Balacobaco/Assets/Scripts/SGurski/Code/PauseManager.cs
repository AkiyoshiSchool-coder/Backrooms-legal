using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class PauseManager : MonoBehaviour
{
    public GameObject controlesMenu, pauseMenu;
    public PlayerInteraction playerCode;

    public void Controles()
    {
        pauseMenu.SetActive(false);
        controlesMenu.SetActive(true);
    }

    public void Voltar()
    {
        pauseMenu.SetActive(true);
        controlesMenu.SetActive(false);
    }

    public void Continuar()
    {
        playerCode.Pausar();
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuInicial");
    }
}
