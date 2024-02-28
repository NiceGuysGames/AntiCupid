using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Use : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private bool isInRange1;


    public GameObject UseItem;
    public GameObject Particle;
    public GameObject Window;



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isInRange1 = true;
            print("Voshel");
        }



    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isInRange1 = false;
            print("Vishel");
        }



    }
    private void Start()
    {
        Particle.SetActive(false);
        Window.SetActive(false);
    }
    private void Update()
    {
        if (isInRange1)
        {
            Particle.SetActive(true);
        }
        else
        {
            Particle.SetActive(false);
        }

        if (isInRange1 && Input.GetKeyDown(KeyCode.E))
        {
            _animator.Play("PickUp");
            Window.SetActive(true);
        }
        if (Window.activeInHierarchy && Input.GetMouseButton(0))
        {
            Window.SetActive(false);

        }

    }
}