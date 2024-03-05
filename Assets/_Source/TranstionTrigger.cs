using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TranstionTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [field: SerializeField] public GameObject Player { get; set; }
    [field: SerializeField] private Transform teleportDestination;
    [field: SerializeField] private float teleportCooldown = 1.0f;
    [field: SerializeField] private bool triggered = false;
    [SerializeField] private LayerMask layer;

    private Teleport _teleport;
    private void Update()
    {
        _teleport.TeleportPlayer(transform);
    }

    private void Start()
    {
        _teleport = new Teleport(Player, teleportDestination, teleportCooldown, triggered, layer, animator);
    }

    private void OnTriggerEnter2D(Collider2D playerl)
    {
        if (Player.gameObject.layer == playerl.gameObject.layer)
        {
            Debug.Log("Player entered the trigger!");
            _teleport.Triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D playerl)
    {
        if (Player.gameObject.layer == playerl.gameObject.layer)
        {
            Debug.Log("Player exit the trigger!");
            _teleport.Triggered = false;
        }
    }


}