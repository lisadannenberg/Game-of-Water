using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour {

	//private int xcoord = 0;
	//private int ycoord = 0;
	private Rigidbody2D rb2d;
	private GameObject myWorld;
	private Trash target;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		myWorld = GameObject.Find("ELU");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f, 0, 0);		
	}

	public Seagull getSeagull()
	{
		return this;
	}
}
