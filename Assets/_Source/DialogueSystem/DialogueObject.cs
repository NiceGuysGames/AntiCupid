using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue")]
public class DialogueObject : ScriptableObject
{
    public string PersonName = "Name";
    public List<Sprite> PersonAvatarAnimation;
    public string[] Content;
}
