using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
	public Beach beach;
	private Rigidbody2D rb2d;
	float x;
	float y;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		// beach = GameObject.Find("ELU").GetComponent("Beach");
	}

	// Update is called once per frame
	void Update()
	{
		//Nothing happens here
	}

	public void disappear()
	{
		this.gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
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

	void OnMouseDown()
	{
		beach.collectTrash(this);
		disappear();
	}
}
