using UnityEngine;

public class RandomGlass : MonoBehaviour
{
    [SerializeField] private GameObject vidroBom;
    [SerializeField] private GameObject vidroMal;
    private int num;
    [SerializeField] private float vidroX;
    [SerializeField] private float vidroBomZ;
    [SerializeField] private float vidroMalZ;
    [SerializeField] private float vidroX1 = 6.2f;
    [SerializeField] private float vidroX2 = 2f;
    [SerializeField] private float vidroX3 = -2.3f;

    [SerializeField] private float vidroZ1 = -9.75f;

    [SerializeField] private float vidroZ2 = -12.45f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = vidroX1; // 6.2f;
            vidroBomZ = vidroZ1; // -9.75f;
            vidroMalZ = vidroZ2; // -12.45f;
        }
        else
        {
            vidroX = vidroX1; // 6.2f;
            vidroBomZ = vidroZ2; // -12.45f;
            vidroMalZ = vidroZ1; // -9.75f;
        }
        Vidro();

        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = vidroX2; // 2f;
            vidroBomZ = vidroZ1; // -9.75f;
            vidroMalZ = vidroZ2; // -12.45f;
        }
        else
        {
            vidroX = vidroX2; // 2f;
            vidroBomZ = vidroZ2; // -12.45f;
            vidroMalZ = vidroZ1; // -9.75f;
        }
        Vidro();

        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = vidroX3; // -2.3f;
            vidroBomZ = vidroZ1; // -9.75f;
            vidroMalZ = vidroZ2; // -12.45f;
        }
        else
        {
            vidroX = vidroX3; // -2.3f;
            vidroBomZ = vidroZ2; // -12.45f;
            vidroMalZ = vidroZ1; // -9.75f;
        }
        Vidro();
        

    }

    // Update is called once per frame
    void Vidro()
    {
        Instantiate(vidroBom, new Vector3(vidroX, -0.15f,  vidroBomZ), Quaternion.identity);
        Instantiate(vidroMal, new Vector3(vidroX, -0.15f,  vidroMalZ), Quaternion.identity);
    }
}
