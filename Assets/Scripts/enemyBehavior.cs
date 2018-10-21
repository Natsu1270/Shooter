using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {
	public AudioClip enemyFireSound;
	public AudioClip explode;
	public int ScoreValue=150;
	public GameObject projecttile;
	public float fireSpeed=10f;
	public float shotPerSec=1f;
	public float Health=200f;
	private AudioSource sound;
	private GameObject player;
	private ScoreKeeper scoreKeeper;
	private projectile tile;
	// Use this for initialization
	private void Start() {
		scoreKeeper=GameObject.Find("Score").GetComponent<ScoreKeeper>();
		player=GameObject.FindGameObjectWithTag("Player");
		sound=gameObject.GetComponent<AudioSource>();		
	}
	private void Update() {
		float prob=Time.deltaTime*shotPerSec;
		if(Random.value<prob){
			Fire();
		}
	}
	void Fire(){
		//Vector2 playerSpot=new Vector2(player.transform.position.x,player.transform.position.y);
		Vector3 startPos=transform.position+new Vector3(0,-1,0);
		GameObject fire=Instantiate(projecttile,startPos,Quaternion.identity) as GameObject;
		fire.GetComponent<Rigidbody2D>().velocity=new Vector2(0,-fireSpeed);
		AudioSource.PlayClipAtPoint(enemyFireSound,transform.position);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		//sound.Play();
		tile= other.gameObject.GetComponent<projectile>();
		if(tile){
			Health-=tile.GetDamage();
			if(Health<=0){
				Died();
			}
		}
	}
	private void Died(){
		AudioSource.PlayClipAtPoint(explode,tile.transform.position);
		scoreKeeper.Score(ScoreValue);
		Destroy(gameObject);
	}
}
