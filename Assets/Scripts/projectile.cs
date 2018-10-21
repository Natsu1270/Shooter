using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
	public float damage=100f;
	public float GetDamage(){
		return damage;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		Destroy(gameObject);
	}
	void hit(){
		Destroy(gameObject);
	}
}
