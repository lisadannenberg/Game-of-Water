using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * Contains the world/level that controlls the game flow and contains the game elements.
 */
public class Beach : MonoBehaviour
{
	// Attributes
	// Is the clock to create new trash in the playfield.
	public int counter = 0;
	// Is the trash collected by the player.
	public int collectedTrash = 0;
	// The life of the seagulls, if 0 the game ends.
	public int life = 10;
	// Contains the active  trash in the game
	public List<Trash> trashlist;
	// Contains the inactive trash in the game
	public List<Trash> unusedTrash;
	// The first seagull that looks to the left and which eats trash
	public Seagull seagullRight;
	// The second seagull that looks to the right and which eats trash
	public Seagull seagullLeft;
	// Rubbish attributes contains rubbish and different sprites
	public Trash rubbish1;
	public Trash rubbish2;
	public Trash rubbish3;
	public Trash rubbish4;
	public Trash rubbish5;
	// Text field initialization
	public Text seagullLife;
	public Text collectedTrashText;
	public Text winOrLoseScreen;

	// Use this for initialization
	void Start()
	{
		trashlist = new List<Trash>();
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
		unusedTrash.Add(rubbish3);
		//unusedTrash.Add(rubbish4);
		//unusedTrash.Add(rubbish5);
		// Set target for seagul
		seagullLeft.setTarget(rubbish1);
		seagullRight.setTarget(rubbish2);
		winOrLoseScreen.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		// Setting textfields
		string playerHealth =  "Life : " + life;
		string collectedTrashByPlayer = "Collected Trash: " + collectedTrash;
		seagullLife.text =  playerHealth;
		collectedTrashText.text = collectedTrashByPlayer;

		if (life == 0 || collectedTrash == 15) 
		{
			// Pauses the game
			Time.timeScale = 0;
			winOrLoseScreen.gameObject.SetActive(true);
			// Game is over. Player lost
			if (life == 0) 
			{
				winOrLoseScreen.text = "Sorry,you have lost";
				seagullLeft.changeSprite();
				seagullRight.changeSprite();
			}
			// Player won
			if(collectedTrash == 15)
			{
				winOrLoseScreen.text = "You saved the seagull's life";
			}
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
	}
}
