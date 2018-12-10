using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour {
    public GameObject[] people;
    public GameObject[] pplSpawn;
    public GameObject[] bottles;
    public GameObject[] bottleSpawn;
    public GameObject[] txt;
    public GameObject[] life;
    public int lifeCounter;

    // Use this for initialization
    void Start () {
        bottleSpawn = GameObject.FindGameObjectsWithTag("Spawn");
        pplSpawn = GameObject.FindGameObjectsWithTag("pplSpawn");
        txt = GameObject.FindGameObjectsWithTag("score");
        life = GameObject.FindGameObjectsWithTag("Life1");        
        
    }



    // Update is called once per frame
    void Update ()
    {
        for (int x = 0; x <= life.Length; x++)
        {
            if (lifeCounter < life.Length)
            {
                lifeCounter++;
            }            
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Destroy(this.gameObject);
            Destroy(life[lifeCounter - 1]);
            int y = Random.Range(0, 5);
            bottles[y].gameObject.GetComponent<Cup>().enabled = true;
            bottles[y].gameObject.GetComponent<DragScript>().enabled = true;
            bottles[y].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            Instantiate(bottles[y], bottleSpawn[0].transform.position, bottles[y].transform.rotation);
        }
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(this.gameObject);            
            //GameObject bot = bottles[Random.Range(0, 5)];     
            int y = Random.Range(0, 5);
            bottles[y].gameObject.GetComponent<Cup>().enabled = true;
            bottles[y].gameObject.GetComponent<DragScript>().enabled = true;
            bottles[y].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            Instantiate(bottles[y], bottleSpawn[0].transform.position, bottles[y].transform.rotation);
            txt[0].gameObject.GetComponent<score>().count++;
        }

    }
}
