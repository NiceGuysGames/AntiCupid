using UnityEngine;

[System.Serializable]
public class DialogueObject
{
    [Header("Message")]
    public string PersonName;
    public string[] Content;

    [Header("Visual")]
    public Sprite[] PersonAvatarSequence;
    public Sprite LastFrame;
    public DialogueEmotions Emotion;
}
