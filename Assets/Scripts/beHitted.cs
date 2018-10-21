using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beHitted : MonoBehaviour {

	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="beam"){
			Destroy(this.gameObject);
		}
	}
}
