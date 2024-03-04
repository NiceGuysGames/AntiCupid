using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransitionOnLevel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [field: SerializeField] public GameObject player { get; set; }
    [field: SerializeField] public Transform teleportDestination { get; set; }
    [field: SerializeField] public float teleportCooldown = 1.0f;
    [field: SerializeField] private bool Triggered = false;
    [SerializeField] private LayerMask layer;
    private float _lastTeleportTime = 0.0f;

    private void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D playerl)
    {  
        if (player.gameObject.layer == playerl.gameObject.layer)
        {
            Debug.Log("Player entered the trigger!");
            Triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D playerl)
    {       
        if (player.gameObject.layer == playerl.gameObject.layer)
        {
            Debug.Log("Player exit the trigger!");
            Triggered = false;
        }
    }
    private void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanTeleport() && Triggered)
            {
                if (IsPlayerInTrigger())
                {
                    AnimationController.ChangeAnimation("Jump", _animator);
                    player.transform.position = teleportDestination.position;
                    _lastTeleportTime = Time.time;
                }
            }
        }
    }
    private bool CanTeleport()
    {
        return Time.time - _lastTeleportTime >= teleportCooldown;
    }

    private bool IsPlayerInTrigger()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale / 2, 0, player.layer);
    }
}
