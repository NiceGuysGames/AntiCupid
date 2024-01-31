using UnityEngine;

public class DemoControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") *
            _speed * Time.deltaTime, 0f);
    }
}
