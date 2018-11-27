using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Seagull : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public Beach beach;
	private Trash target;
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
		moveToTarget(1.5f);
	}

	public void setTarget(Trash pTarget)
	{
		target = pTarget;
	}

	public void moveToTarget(float pSpeed)
	{
		float speed = pSpeed;
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("trash"))
		{

		}
	}

	public void changeSprite()
	{
		this.GetComponent<SpriteRenderer>().sprite = deadSeagull;

	}
}
