using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "Dialogue System/Dialogue")]
public class DialogueSequence : ScriptableObject
{
    public List<DialogueObject> DialogueObjects;
}
