using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue components")]
    [SerializeField] private Image _personAvatarField;
    [SerializeField] private Text _nameField;
    [SerializeField] private Text _contentField;

    [Header("Dialogue settings")]
    [SerializeField] private GameObject _dialogueBody;
    [SerializeField] private float _textSpeed;
    
    private int _index;
    private DialogueObject _dialogue;
    private bool _isComplete;

    private void Update()
    {
        CheckActivate();
    }

    public void StartOnce(DialogueObject dialogue)
    {
        _isComplete = false;
        _dialogue = dialogue;
        _index = 0;
        _contentField.text = string.Empty;
        _personAvatarField.sprite = _dialogue.PersonAvatarSequence[0];
        _nameField.text = _dialogue.PersonName;
        _dialogueBody.SetActive(true);
        StartCoroutine(TypeLine());
    }

    public void StartDualogue(DialogueSequence sequence)
    {
        StartCoroutine(StartSequence(sequence));
    }

    public IEnumerator StartSequence(DialogueSequence sequence)
    {
        foreach (DialogueObject dialogue in sequence.DialogueObjects)
        {
            StartOnce(dialogue);
            yield return new WaitUntil(() => _isComplete);
        }
    }

    private void CheckActivate()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (_dialogue == null)
        {
            return;
        }
        
        if (_contentField.text == _dialogue.Content[_index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            _contentField.text = _dialogue.Content[_index];
            _personAvatarField.sprite = _dialogue.LastFrame;
        }
    }
    
    private IEnumerator TypeLine()
    {
        var i = 0;

        foreach (char c in _dialogue.Content[_index].ToCharArray())
        {
            _contentField.text += c;

            if (i > _dialogue.PersonAvatarSequence.Length - 1)
            {
                i = 0;
            }

            if (c == ' ')
            {
                _personAvatarField.sprite = _dialogue.PersonAvatarSequence[i++];
            }

            yield return new WaitForSeconds(_textSpeed);
        }
    }
    
    private void NextLine()
    {
        if (_index < _dialogue.Content.Length - 1)
        {
            _index++;
            _contentField.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _dialogue = null;
            _dialogueBody.SetActive(false);
            _isComplete = true;
        }
    }
}
