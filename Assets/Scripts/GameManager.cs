using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public
    public static GameManager instance = null;
    public string username;

    // Private
    private string currentScene;
    private int lastSceneIndex;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance.gameObject);
    }

    private void Start()
    {
        username = "";

        lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("OnSceneLoaded: " + scene.name);
        currentScene = scene.name;
        if(currentScene == "Desktop")
        {
            StartCoroutine(playIntro());
        }
    }


    public void NextScene()
    {
        print("Now changing scene...");
        print("Current: " + SceneManager.GetActiveScene().buildIndex + ". Last: " + lastSceneIndex);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex >= lastSceneIndex)
        {
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            SceneManager.LoadSceneAsync(++currentSceneIndex);
        }

    }

    public void Quit()
    {
        GameObject.FindWithTag("ScreenCol").SetActive(false);
        StartCoroutine(waitForEmptyScreen());
    }

    public void addUsername(string input)
    {
        username = input;
    }

    public void TimedQuit(float duration)
    {
        StartCoroutine(TimedQuitCoroutine(duration));
    }

    IEnumerator TimedQuitCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        NextScene();
    }

    IEnumerator waitForEmptyScreen()
    {

        yield return new WaitForSeconds(5);
        //Application.Quit();
        NextScene();
    }

    IEnumerator playIntro()
    {

        yield return new WaitForSeconds(1.2f);
        GetComponent<SoundFX>().playIntro();
    }

    public string GetUserName()
    {
        return username;
    }

}
