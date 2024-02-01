using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string PersonName = "Name";
    public Sprite PersonAvatar;
    public string[] Content;
}
