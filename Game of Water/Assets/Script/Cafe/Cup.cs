using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cup : MonoBehaviour {

    public Image cupFill;
    public bool fill;
    public bool full;    
    public GameObject[] bottles;
    public GameObject[] bottleSpawn;
    public GameObject[] findPerson;
    public GameObject[] txt;
    // Use this for initialization
    void Start () {
        full = false;
        bottleSpawn = GameObject.FindGameObjectsWithTag("Spawn");
        cupFill.fillAmount = 0;
        
        fill = false;
    }
    private void Awake()
    {
        this.gameObject.GetComponent<Cup>().enabled = true;
        this.gameObject.GetComponent<DragScript>().enabled = true;
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        cupFill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        
        findPerson = GameObject.FindGameObjectsWithTag("ppl");
        txt = GameObject.FindGameObjectsWithTag("score");
        if (fill == true)
        {
            cupFill.fillAmount = cupFill.fillAmount + 0.01f;
        }
        if (cupFill.fillAmount >= 0.95f)
        {
            full = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ppl" && full == true)
        {
            txt[0].gameObject.GetComponent<score>().count++;
            Destroy(this.gameObject);
            Destroy(findPerson[0]);
            //GameObject bot = bottles[Random.Range(0, 5)];     
            int y = Random.Range(0, 5);            
            Instantiate(bottles[y], bottleSpawn[0].transform.position, bottles[y].transform.rotation);
            bottles[y].gameObject.GetComponent<Cup>().enabled = true;
            bottles[y].gameObject.GetComponent<DragScript>().enabled = true;
            bottles[y].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            GameObject[] person = GameObject.FindGameObjectsWithTag("ppl");
            

        }
        if (collision.gameObject.tag == "Water")
        {
            fill = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            fill = false;
        }
    }
    private void OnDestroy()
    {
        
    }
}
