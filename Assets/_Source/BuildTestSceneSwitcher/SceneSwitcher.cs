using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private UnityEngine.UI.Button button;
    [SerializeField] private string sceneName;
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => NextScene());

    }
    
    private void NextScene()
    {
        Debug.Log("Switching to " + sceneName);
        try
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }

        catch (Exception e)
        {
            Debug.Log("Unable to Switch Scene" + e);
        }
    }

}