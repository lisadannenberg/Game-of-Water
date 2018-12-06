using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PplSpawn1 : MonoBehaviour {
    public GameObject[] people;
    public GameObject[] pplSpawn;
    public GameObject[] findPerson;
    public float timeLeft;
    public bool timer;
    public int counter;
    // Use this for initialization
    void Start () {
        pplSpawn = GameObject.FindGameObjectsWithTag("pplSpawn");
        GameObject peo = people[Random.Range(0, 4)];
        peo.transform.localScale = new Vector3(.5f, .5f, 1);
        Instantiate(peo, pplSpawn[0].transform.position, peo.transform.rotation);
        timer = false;
    }
	
	// Update is called once per frame
	void Update () {
        findPerson = GameObject.FindGameObjectsWithTag("ppl");
        counter = findPerson.Length;
        if (timer == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timer == false)
        {
            timeLeft = .5f;
        }
        if (timeLeft <= 0)
        {
            timer = false;
            GameObject peo = people[Random.Range(0, 5)];
            peo.transform.localScale = new Vector3(.5f, .5f, 1);
            Instantiate(peo, pplSpawn[0].transform.position, peo.transform.rotation);
            counter = 1;
            timeLeft = .5f;
        }
        if (counter == 0)
        {
            timer = true;
        }
        
    }
    
}
