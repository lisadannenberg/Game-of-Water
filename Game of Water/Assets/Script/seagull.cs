using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{

	//private int xcoord = 0;
	//private int ycoord = 0;
	private Rigidbody2D rb2d;
	public Beach beach;
	private Trash target;

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
			//print(other);
			//print(other.gameObject);
			//print(other.gameObject.GetComponent<Trash>());

			//beach.eatTrash(other.gameObject.GetComponent<Trash>());
			//other.gameObject.SetActive(false);
			//print("test");

		}
	}
}
