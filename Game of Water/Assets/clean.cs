using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clean : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "dirtydish")
        {
            collision.gameObject.GetComponent<DragScript>().cleanOrNot = true;

        }
    }
}
