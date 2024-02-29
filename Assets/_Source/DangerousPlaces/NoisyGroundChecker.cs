using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyGroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private LayerMask noisyGroundLayer;

    private void Start()
    {

        if (playerMover == null)
        {
            Debug.Log("Player Mover == null in " + gameObject.name);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if ((noisyGroundLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            // Debug.Log("NoisyGround!");
            if (playerMover.IsMoving && !playerMover.IsCrouching)
            {
                Debug.Log("Noise!");
            }
        }

    }
}
