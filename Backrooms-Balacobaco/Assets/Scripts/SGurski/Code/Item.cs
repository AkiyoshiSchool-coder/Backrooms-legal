using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool canGrab;
    public AudioClip audio;
    public string texto;
    public bool canRotate;
    public bool inHand;
    public bool hasExtraAction;

}
