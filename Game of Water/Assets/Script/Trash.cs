using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A trash object is a collectable item. A seagull can die from it. A player can win when he collects trash 
 * */
public class Trash : MonoBehaviour
{
	// A reference to the main level
	public Beach beach;
	// The physical representation of the trash object.
	private Rigidbody2D rb2d;
	// The x - coordinate of the object in the world
	float x;
	// The y - coordinate of the object in the world.
	float y;

	// Is executed when the game starts
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//Nothing happens here
	}

	// Is called when the object should disappear 
	public void disappear()
	{
		this.gameObject.SetActive(false);
	}

	// Triggers when the object collides with another object.
	void OnTriggerEnter2D(Collider2D other)
	{
		// Removes the trash when a seagull hits the trash. The seagull looses a life.
		if (other.gameObject.CompareTag("seagull1"))
		{
			beach.eatTrash(this);
			disappear();
		}
		else if (other.gameObject.CompareTag("seagull2"))
		{
			beach.eatTrash(this);
			disappear();
		}
	}

	// Removes the object when  the player clicks on the item.
	void OnMouseDown()
	{
		beach.collectTrash(this);
		disappear();
	}
}
