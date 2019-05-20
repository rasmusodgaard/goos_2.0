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
        StartCoroutine(playIntro());
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
    }


    public void NextScene() 
    {
        print("Current scene: " + currentScene);
        if (currentScene.Equals("LogIn"))
        {
            SceneManager.LoadScene("HourGlass");
        } 

        else if (currentScene.Equals("HourGlass"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextScene();
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

    IEnumerator waitForEmptyScreen() 
    {

        yield return new WaitForSeconds(5);
        Application.Quit();
    }

    IEnumerator playIntro()
    {

        yield return new WaitForSeconds(2);
        GetComponent<SoundFX>().playIntro();
    }

}
