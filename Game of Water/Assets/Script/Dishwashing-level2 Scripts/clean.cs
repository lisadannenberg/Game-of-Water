using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clean : MonoBehaviour {

    public GameObject[] dishes;
    public int counter;
    public GameObject completeLevelUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter = 0;
        for (int x = 0; x < dishes.Length + 1; x++)
        {
            if(dishes[x].GetComponent<DragScript>().cleanOrNot == true)
            {
                counter++;
            }
        }
        if (counter == dishes.Length)
        {
            CompleteLevel();
        }
	}

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
       // SceneManager.LoadScene("Level3");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
