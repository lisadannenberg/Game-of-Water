using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach : MonoBehaviour
{
	// Attributes
	public int counter = 0;
	public int collectedTrash = 0;
	public int life = 5;
	public List<Trash> trashlist;
	public List<Trash> unusedTrash;
	public Seagull seagullRight;
	public Seagull seagullLeft;
	// Rubbish attributes
	public Trash rubbish1;
	public Trash rubbish2;
	public Trash rubbish3;
	public Trash rubbish4;
	public Trash rubbish5;

	// Use this for initialization
	void Start()
	{
		trashlist = new List<Trash>();
		//seagullLeft = 
		rubbish3.gameObject.SetActive(false);
		rubbish4.gameObject.SetActive(false);
		rubbish5.gameObject.SetActive(false);
		// Initialize Position
		rubbish1.transform.position = new Vector3(4f, -2.9f, 0f);
		rubbish2.transform.position = new Vector3(-4f, -2.7f, 0f);
		//Putting the currently displayed trash into a list
		trashlist.Add(rubbish1);
		trashlist.Add(rubbish2);
		// Putting the other trash into a seperate list
	//	unusedTrash.Add(rubbish3);
	//	unusedTrash.Add(rubbish4);
	//	unusedTrash.Add(rubbish5);
		// Set target for seagul
		seagullLeft.setTarget(rubbish1);
		seagullRight.setTarget(rubbish2);
	}

	// Update is called once per frame
	void Update()
	{
		if (life == 0 || collectedTrash == 15)
		{
			// Pauses the game
			Time.timeScale = 0;
		}

		if ((counter % 20) == 0 && unusedTrash.Count > 0)
		{
			float randomX = Random.Range(-13.0f, 13.0f);
			float randomY = Random.Range(-4.5f, -2.0f);
			Trash tmp = getTrash();
			trashlist.Add(tmp);
			unusedTrash.Remove(tmp);
			tmp.transform.position = new Vector3(randomX, randomY, 0f);
			tmp.gameObject.SetActive(true);
		}
		counter++;
	}

	public Trash getTrash()
	{
		int randomNr = Random.Range(0, (unusedTrash.Count - 1));
		return unusedTrash[randomNr];
	}

	public void handleTrash(Trash pTrash)
	{
		trashlist.Remove(pTrash);
		unusedTrash.Add(pTrash);
	}

	public void collectTrash(Trash pTrash)
	{
		handleTrash(pTrash);
		collectedTrash++;
	}

	public void eatTrash(Trash pTrash)
	{
		handleTrash(pTrash);
		life--;
		print(life);
	}
}
