using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach : MonoBehaviour {
	public int counter = 0;
	public List<Trash> trashlist;
	private int winningCondition = 0;
	private Seagull seagullRight;
	private Seagull seagullLeft;

	// Use this for initialization
	void Start () {
		trashlist = new List<Trash> ();
		//seagullLeft = 
	}
	
	// Update is called once per frame
	void Update () {
		if(winningCondition == 3){
			// Pauses the game
			Time.timeScale = 0;
		}

		if ((counter % 5) == 0){
			float randomX = Random.Range(-13.0f, 13.0f);
			float randomY = Random.Range(-4.5f, -2.0f);
			trashlist.Add(new Trash(randomX, randomY));
		}
		counter++;
	}

	public Trash getTrash(){
		int randomNr = Random.Range(0, (trashlist.Count -1));
		// Smart solution is written here. TODO
		return null;
	}
	
	public Beach getBeach()
	{
		return this;
	}

}
