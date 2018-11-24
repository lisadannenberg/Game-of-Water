using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {
	float x;
	float y;

	public Trash(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public void disappear(){
		this.gameObject.SetActive(false);
	}
}
