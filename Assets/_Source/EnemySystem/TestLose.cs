using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLose : MonoBehaviour
{
  private static GameObject panel;

  private void Start()
  {
      panel = GameObject.Find("OverPanel");
      panel.SetActive(false);
  }

  public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ActivatePanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
