using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	// Rubbish attributes contains rubbish and different sprites
	public Trash rubbish2;
	// Rubbish attributes contains rubbish and different sprites
	public Trash rubbish3;
	// Rubbish attributes contains rubbish and different sprites
	public Trash rubbish4;
	// Rubbish attributes contains rubbish and different sprites
	public Trash rubbish5;
	// Text field initialization
	public Text seagullLife;
	//Displays how much trash is collected by the player so far
	public Text collectedTrashText;
	// Displays if the player won or lost.
	public Text winOrLoseScreen;
	// Displays the game's goal
	public Text explaination;
	// Restarts the game, when clicked
	public Button restartButton;

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
		// Trash is commented. Can be used for a harder game
		//unusedTrash.Add(rubbish4);
		//unusedTrash.Add(rubbish5);
		// Set target for seagul, which it tries to get
		seagullLeft.setTarget(rubbish1);
		seagullRight.setTarget(rubbish2);
		// Will be activated at the end of the game
		winOrLoseScreen.gameObject.SetActive(false);
		// Add event to a button
		restartButton.onClick.AddListener(TaskOnClick);
		restartButton.gameObject.SetActive(false);
		// Time in the scene runs normal
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update()
	{
		// Setting textfields
		string playerHealth =  "Life : " + life;
		string collectedTrashByPlayer = "Collected Trash: " + collectedTrash;
		// Updates the text fields
		seagullLife.text =  playerHealth;
		collectedTrashText.text = collectedTrashByPlayer;

		if (life <= 0 || collectedTrash >= 15) 
		{
			// Pauses the game
			Time.timeScale = 0;
			winOrLoseScreen.gameObject.SetActive(true);
			// Game is over. Player lost
			if (life <= 0) 
			{
				winOrLoseScreen.text = "Sorry,you have lost";
				seagullLeft.changeSprite();
				seagullRight.changeSprite();
				restartButton.gameObject.SetActive(true);
			}
			// Player won
			if(collectedTrash >= 15)
			{
				winOrLoseScreen.text = "You saved the seagull's life";
			}
		}
		// Spawns new trash on the map
		if ((counter % 20) == 0 && unusedTrash.Count > 0)
		{
			// Calculates a random spot where the next trash object spawns
			float randomX = Random.Range(-13.0f, 13.0f);
			float randomY = Random.Range(-4.5f, -2.0f);
			Trash tmp = getTrash();
			// Inserts the new trash object into the currently displayed trash list and removes it from the unused list.
			trashlist.Add(tmp);
			unusedTrash.Remove(tmp);
			tmp.transform.position = new Vector3(randomX, randomY, 0f);
			tmp.gameObject.SetActive(true);
		}
		// Remove the explaination text from screen after player grabbed some trash
		if (collectedTrash == 2)
		{
			explaination.gameObject.SetActive(false);
		}
		counter++;
	}

	/*
	 * Return a random trash object from the unused trash list.
	 * @return a trash object
	 * */
	public Trash getTrash()
	{
		int randomNr = Random.Range(0, (unusedTrash.Count - 1));
		return unusedTrash[randomNr];
	}

	/*
	 * Is called whenever trash is collected/eaten. 
	 * The collected trash is added to a list of unuesed trash.
	 * */
	public void handleTrash(Trash pTrash)
	{
		trashlist.Remove(pTrash);
		unusedTrash.Add(pTrash);
	}

	/*
	 * Collect a object @pTrash and increase the player's collected trash plus 1. 
	 * */
	public void collectTrash(Trash pTrash)
	{
		handleTrash(pTrash);
		collectedTrash++;
	}

	/*
	 * Eats a object @param pTrash and decreases the seagull's life minus 1.
	 **/
	public void eatTrash(Trash pTrash)
	{
		handleTrash(pTrash);
		life--;
	}

	// The task is activated by clicking the restart button. Restarts the game.
	void TaskOnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
