using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public Rigidbody2D Rb { get; set; }
}
