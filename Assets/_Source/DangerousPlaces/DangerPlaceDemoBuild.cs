using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerPlaceDemoBuild : MonoBehaviour
{
    [field: SerializeField] public GameObject Player { get; set; }
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private GameObject _noiseText;
    
    private bool isTriggered = false;
    private void Start()
    {
        _noiseText.SetActive(false);
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
            _noiseText.SetActive(true);
            

        }
    }

    private void OnTriggerExit2D(Collider2D playerl)
    {
        if (Player.gameObject.layer == playerl.gameObject.layer && !playerMover.IsCrouching && playerMover.IsMoving && isTriggered)
        {
            isTriggered = false;
            Debug.Log("Noise!ext\n Animation of DangerousPlace");
            _noiseText.SetActive(false);
        }
    } 
   
}
