using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivaction : MonoBehaviour
{
    [SerializeField] private LayerMask _activationLayer;
    [SerializeField] private DialogueSystem _dialogueSystem;
    [SerializeField] private DialogueSequence _dialogueSequence;
    private bool _isInArea;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_activationLayer & 1 << other.gameObject.layer) != 0)
        {
            _isInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((_activationLayer & 1 << other.gameObject.layer) != 0)
        {
            _isInArea = false;
        }
    }

    private void Update()
    {
        if (_isInArea && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Work");
            StartCoroutine(_dialogueSystem.StartSequence(_dialogueSequence));
        }
    }
}
