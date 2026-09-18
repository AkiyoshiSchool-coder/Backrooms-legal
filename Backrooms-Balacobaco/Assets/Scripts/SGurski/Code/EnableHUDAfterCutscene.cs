using UnityEngine;
using UnityEngine.Timeline;

public class EnableHUDAfterCutscene : MonoBehaviour
{
    public GameObject cutsceneCanvas, playerHUD, cursor;
    public TimelineAsset timeline;
    private float timer;

    void Start()
    {
        playerHUD.SetActive(false);
        cursor.transform.localScale = new Vector3(0, 0, 0); // esconde o cursor sem desativar ele
    }

    void Update()
    {
        if(cutsceneCanvas.activeSelf)
        {
            timer += Time.deltaTime;
            if(timer >= timeline.duration)
            {
                EnableHUD();
            }
        }
        else
        {
            EnableHUD();
        }
    }

    void EnableHUD()
    {
        cursor.transform.localScale = new Vector3(1, 1, 1);
        playerHUD.SetActive(true);
        Destroy(this); // REMOVE APENAS O COMPONENTE
    }
}
