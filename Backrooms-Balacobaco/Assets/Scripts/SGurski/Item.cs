using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool canGrab;
    public AudioClip audio;
    public Vector3 offset;
}
