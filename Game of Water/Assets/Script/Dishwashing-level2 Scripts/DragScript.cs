using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {

    public bool checkClick = false;
    public GameObject pickTheDishes;
    public Vector3 sendBack;
    public Vector3 cleaned;
    public bool cleanOrNot;
    public Sprite cleanDish;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (checkClick == true)
        {
            pickTheDishes = this.gameObject;
            Vector3 vec = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            pickTheDishes.transform.position = vec;
        }
        /*if (checkClick == false)
        {
            if (cleanOrNot == true)
            {
                pickTheDishes.GetComponent<SpriteRenderer>().sprite = cleanDish;
                sendBack = cleaned;
            }

            pickTheDishes.transform.position = sendBack;


        }*/
	}
    public void OnMouseDown()
    {
        sendBack = Input.mousePosition;
        checkClick = true;
                
    }
    public void OnMouseUp()
    {
        checkClick = false;
    }
}
