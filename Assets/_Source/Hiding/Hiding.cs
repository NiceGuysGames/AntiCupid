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
    private bool isHiding = false;
    [SerializeField] private string hiddenLayer;
    private bool HidScore = false;


    private void Update()
    {
        PlayerHiding();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerhid.gameObject.layer == playerhid.gameObject.layer)
        {
            Debug.Log("Player entered the trigger!");
            isHiding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D playerl)
    {
        if (playerhid.gameObject.layer == playerhid.gameObject.layer)
        {
            Debug.Log("Player exit the trigger!");
            isHiding = false;
        }
    }

    private void PlayerHiding()
    {            
        if (Input.GetKeyDown(KeyCode.E)&& isHiding)
        {
             if (!HidScore)
                    {
                        player.transform.position = playerhid.position;
                        player.gameObject.layer = LayerMask.NameToLayer(hiddenLayer);
                        
                        HidScore = true;
                Debug.Log("Player hid!");
                    }
            else
            {
                
                
                    player.transform.position = playerhid.position;
                    player.gameObject.layer = LayerMask.NameToLayer("Player");
                    isHiding = false;
                    Debug.Log("Player exit!");
                    HidScore = false;

                
            }
        }
        
       

           
    }
}
        
       



