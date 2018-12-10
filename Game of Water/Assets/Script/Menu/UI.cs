using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
    public GameObject menu;
    int currentScene;
	// Use this for initialization
	void Start ()
    {
       
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
    public void level4()
    {
        SceneManager.LoadScene(4);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        menu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackToGame()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
