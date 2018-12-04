using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 *  The seagull is moving around eats trash. If a seagull dies the player has lost.
 **/
public class Seagull : MonoBehaviour
{	
	// The physical body of the seagull
	private Rigidbody2D rb2d;
	// A reference to the level
	public Beach beach;
	// The target which the seagull wants to eat next.
	private Trash target;
	// The sprite of a dead seagull.
	public Sprite deadSeagull;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		// beach = GameObject.Find("ELU").GetComponent("Beach");
	}

	// Update is called once per frame
	void Update()
	{
		//transform.Translate(-0.1f, 0, 0)
		moveToTarget(1.1f);
	}

	/*
	 * Set the target of the seagull, to which she heads next.
	 * */
	public void setTarget(Trash pTarget)
	{
		target = pTarget;
	}

	/*
	 * Move the object to the target with a given speed (@param pSpeed).
	 * */
	public void moveToTarget(float pSpeed)
	{
		float speed = pSpeed;
		// Speed is influenced by time
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}

	/*
	 * Is activated when an objects collides with another object( @param other)
	 * */
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("trash"))
		{
			// Nothing happens. Look at the trash class for the reaction from the trash in case of collision.
		}
	}

	/*
	 * Change the sprite of the seagull into a deadgull
	 * */
	public void changeSprite()
	{
		this.GetComponent<SpriteRenderer>().sprite = deadSeagull;

	}
}
