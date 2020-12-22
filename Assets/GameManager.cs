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
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance.gameObject);
    }

    private void Start()
    {
        username = "";
        if (currentScene == "Desktop")
        {
            StartCoroutine(playIntro());
        }
        lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        print("Current: " + SceneManager.GetActiveScene().buildIndex + ". Last: " + lastSceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
    }


    public void NextScene()
    {
        print("Now changing scene...");
        print("Current: " + SceneManager.GetActiveScene().buildIndex + ". Last: " + lastSceneIndex);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= lastSceneIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(++currentSceneIndex);
        }

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    NextScene();
        //}
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

    public string GetUserName() { return username; }

}
