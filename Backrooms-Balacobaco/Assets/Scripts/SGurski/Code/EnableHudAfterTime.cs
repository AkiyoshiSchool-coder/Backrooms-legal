using UnityEngine;

public class EnableHudAfterTime : MonoBehaviour
{
    public float timer = 0f;
    public GameObject hud;
    public RectTransform cursor;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 19.11667f)
        {
            hud.SetActive(true);
            cursor.localScale = new Vector3(1, 1, 1);
            Destroy(gameObject);
        }
    }
}
