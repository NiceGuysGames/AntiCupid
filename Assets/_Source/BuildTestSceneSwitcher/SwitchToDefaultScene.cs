using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToDefaultScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("BuildScene");
        }
    }
}
