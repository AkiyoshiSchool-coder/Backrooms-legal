using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class CacoVidro : MonoBehaviour
{
    private float speed = 7f;
    bool parar = false;
    [SerializeField] private float timer = 1.77f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
        yield break;
    }
   // void OnTriggerEnter(Collider other)
   // {
  //      print("coco");
 //       Destroy(this.gameObject);
   /// }
}
