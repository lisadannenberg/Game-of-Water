using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach : MonoBehaviour {
	public int counter = 0;
	public List<Trash> trashlist;
	private int winningCondition = 0;

	// Use this for initialization
	void Start () {
		trashlist = new List<Trash> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
