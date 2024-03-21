using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Hiding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerhid;
    private bool _isInTrigger = false;
    [SerializeField] private string hiddenLayer;
    private bool _isHiding = false;
    [SerializeField] private int _newOrderOutLayer;
    [SerializeField] private int _newOrderInLayer;


    private void Update()
    {
        PlayerHiding();
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerhid.gameObject.layer == playerhid.gameObject.layer)
        {
            Debug.Log("Player entered the trigger!");
            _isInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D playerl)
    {
        if (playerhid.gameObject.layer == playerhid.gameObject.layer)
        {
            Debug.Log("Player exit the trigger!");
            _isInTrigger = false;
        }
    }

    private void PlayerHiding()
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown(KeyCode.E)&& _isInTrigger)
        {
             if (!_isHiding)
                    {
                        player.transform.position = playerhid.position;
                        player.gameObject.layer = LayerMask.NameToLayer(hiddenLayer);                     
                        _isHiding = true;
                        playerSpriteRenderer.sortingOrder = _newOrderInLayer;
                Debug.Log("Player hid!");
                    }
            else
            {
                
                
                    player.transform.position = playerhid.position;
                    player.gameObject.layer = LayerMask.NameToLayer("Player");
                    _isInTrigger = true;
                    Debug.Log("Player exit!");
                    _isHiding = false;
                    playerSpriteRenderer.sortingOrder = _newOrderOutLayer;


            }
        }
        
       

           
    }
}
        
       



