using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionViewHolder : MonoBehaviour
{
    private Vector3 _startPos;
        
    void Start()
    {
        _startPos= transform.position;
    }
    void Update() 
    { 
        transform.position= new Vector3(transform.position.x, _startPos.y, transform.position.z);
        
        
    }
}
