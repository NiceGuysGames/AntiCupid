using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport
{
    private GameObject _player { get; set; }
    private Transform _teleportDestination { get; set; }
    private float _teleportCooldown = 1.0f;
    public bool Triggered { get; set; }
    private LayerMask _layer;
    private float _lastTeleportTime = 0.0f;
    public Teleport(GameObject player, Transform teleportDestination, float teleportCooldown, bool triggered, LayerMask layer)
    {
        _player = player;
        _teleportDestination = teleportDestination;
        _teleportCooldown = teleportCooldown;
        Triggered = triggered;
        _layer = layer;
    }


    public void TeleportPlayer(Transform transform)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanTeleport() && Triggered)
            {
                if (IsPlayerInTrigger(transform))
                {
                    _player.transform.position = _teleportDestination.position;
                    _lastTeleportTime = Time.time;
                }
            }
        }
    }
    private bool CanTeleport()
    {
        return Time.time - _lastTeleportTime >= _teleportCooldown;
    }

    private bool IsPlayerInTrigger(Transform transform)
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale / 2, 0, _player.layer);
    }
}
