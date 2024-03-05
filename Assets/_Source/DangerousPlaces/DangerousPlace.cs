using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousPlace : MonoBehaviour, IInteractable
{
    [field: SerializeField] public GameObject Player { get; set; }
    [SerializeField] private PlayerMover playerMover;
    private bool isTriggered = false;
    private void Start()
    {
        if (playerMover == null)
        {
            Debug.Log("Player Mover == null in " + gameObject.name);
        }

    }

    private void OnTriggerEnter2D(Collider2D playerl)
    {
        if (Player.gameObject.layer == playerl.gameObject.layer && !playerMover.IsCrouching && playerMover.IsMoving && !isTriggered)
        {
            isTriggered = true;
            Debug.Log("Noise!\n Animation of DangerousPlace");

        }
    }

    private void OnTriggerExit2D(Collider2D playerl)
    {
        if (Player.gameObject.layer == playerl.gameObject.layer && !playerMover.IsCrouching && playerMover.IsMoving && !isTriggered)
        {
            isTriggered = true;
            Debug.Log("Noise!\n Animation of DangerousPlace");

        }
    }
}
