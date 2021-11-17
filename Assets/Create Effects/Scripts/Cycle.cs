using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cycle : MonoBehaviour
{
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private Text SceneName;
     private string CurrentSceneName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        ChangeSceneName();
    }

    private void ChangeSceneName()
    {
        string start = "Assets/";
        string end = ".unity";
        CurrentSceneName = SceneManager.GetActiveScene().path;
        
        // Test if the path contains 'start' data, if so, remove it
        if(CurrentSceneName.StartsWith(start))
            CurrentSceneName = CurrentSceneName.Substring(start.Length);
        
        // Test if the path contains 'end' data, if so, remove it
        if(CurrentSceneName.EndsWith(end))
            // ReSharper disable once StringLastIndexOfIsCultureSpecific.1
            CurrentSceneName = CurrentSceneName.Substring(0, CurrentSceneName.LastIndexOf(end));

        CurrentSceneName = CurrentSceneName.Substring((CurrentSceneName.LastIndexOf("/", StringComparison.Ordinal) + 1));
        SceneName.text = (CurrentSceneName);
    }

    void Update()
    {
        ChangeSceneName();
        if(Input.GetKeyDown(leftKey))
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if(Input.GetKeyDown(rightKey))
        {
            if(SceneManager.GetActiveScene().buildIndex - 1 == -1)
            {
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}