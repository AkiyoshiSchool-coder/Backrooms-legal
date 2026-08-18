using UnityEngine;

public class RandomGlass : MonoBehaviour
{
    [SerializeField] private GameObject vidroBom;
    [SerializeField] private GameObject vidroMal;
    private int num;
    private float vidroX, vidroBomZ, vidroMalZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = 6.2f;
            vidroBomZ = -9.75f;
            vidroMalZ = -12.45f;
        }
        else
        {
            vidroX = 6.2f;
            vidroBomZ = -12.45f;
            vidroMalZ = -9.75f;
        }
        Vidro();

        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = 2f;
            vidroBomZ = -9.75f;
            vidroMalZ = -12.45f;
        }
        else
        {
            vidroX = 2f;
            vidroBomZ = -12.45f;
            vidroMalZ = -9.75f;
        }
        Vidro();

        num = Random.Range(0,2);
        print(num);
        if(num == 1)
        {
            vidroX = -2.3f;
            vidroBomZ = -9.75f;
            vidroMalZ = -12.45f;
        }
        else
        {
            vidroX = -2.3f;
            vidroBomZ = -12.45f;
            vidroMalZ = -9.75f;
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
