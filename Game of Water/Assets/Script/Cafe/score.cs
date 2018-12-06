using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public int count;
	// Use this for initialization
	void Start ()
    {
        count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.GetComponent<Text>().text = count.ToString();
	}
}
