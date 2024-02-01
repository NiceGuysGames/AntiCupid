using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private string _personName;
    [SerializeField] private Text _textContent;
    [SerializeField] private Text _nameText;
    [SerializeField] private string[] _lines;
    [SerializeField] private float _textSpeed;
    [SerializeField] private GameObject _body;
    private int index;
    
    private void Start()
    {
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textContent.text == _lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textContent.text = _lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        _textContent.text = string.Empty;
        _nameText.text = _personName;
        _body.SetActive(true);
        StartCoroutine(TypeLine());
    }
    
    private IEnumerator TypeLine()
    {
        foreach (char c in _lines[index].ToCharArray())
        {
            _textContent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }
    
    private void NextLine()
    {
        if (index < _lines.Length - 1)
        {
            index++;
            _textContent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
