using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField, Tooltip("Перетащите сюда поле с картинкой персонажа")]
    private Image PersonAvatar;
    [SerializeField, Tooltip("Перетащите сюда поле текста с именем")]
    private Text _name;
    [SerializeField, Tooltip("Перетащите сюда поле текста, где находится повествование")]
    private Text _content;
    [SerializeField, Tooltip("Перетащите сюда объект, который объединяет все объекты диалогового окна")]
    private GameObject _dialogueBody;
    [SerializeField, Tooltip("Задержка между появлением каждой новой буквы")]
    private float _textSpeed;
    
    private int _index;
    private DialogueObject _dialogue;

    private void Update()
    {
        CheckActivate();
    }

    private void CheckActivate()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        if (!_dialogue)
        {
            return;
        }
        
        if (_content.text == _dialogue.Content[_index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            _content.text = _dialogue.Content[_index];
        }
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        _dialogue = dialogue;
        _index = 0;
        _content.text = string.Empty;
        PersonAvatar.sprite = _dialogue.PersonAvatarAnimation[0];
        _name.text = _dialogue.PersonName;
        _dialogueBody.SetActive(true);
        StartCoroutine(TypeLine());
    }
    
    private IEnumerator TypeLine()
    {
        foreach (char c in _dialogue.Content[_index].ToCharArray())
        {
            _content.text += c;
            PersonAvatar.sprite = GetRandomSprite(_dialogue.PersonAvatarAnimation);
            yield return new WaitForSeconds(_textSpeed);
        }
    }
    
    private Sprite GetRandomSprite(List<Sprite> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
    
    private void NextLine()
    {
        if (_index < _dialogue.Content.Length - 1)
        {
            _index++;
            _content.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _dialogue = null;
            _dialogueBody.SetActive(false);
        }
    }
}
