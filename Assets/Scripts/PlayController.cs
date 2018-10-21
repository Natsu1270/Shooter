using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {
	public float firingRate=0.2f;
	public float projectSpeed=10f;
	public float speed=15.0f;
	public float padding=1f;
	public GameObject projecttile;
	public float Health=500f;
	private float leftbound;
	private float rightbound;
	private float topbound;
	private float botbound;
	//private AudioSource fireSound;
	public AudioClip fireSound;
	private LevelManager level;
	// Use this for initialization
	void Start () {
		//fireSound=gameObject.GetComponent<AudioSource>();
		float screenToCamDis=transform.position.z-Camera.main.transform.position.z;
		Vector3 lefmost=Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,screenToCamDis));
		Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1f,0f,screenToCamDis));
		Vector3 topmost=Camera.main.ViewportToWorldPoint(new Vector3(0f,1f,screenToCamDis));
		leftbound=lefmost.x+padding;
		rightbound=rightmost.x-padding;
		topbound=topmost.y-padding;
		botbound=lefmost.y+padding;
		level=GameObject.FindObjectOfType<LevelManager>();

	}
	void Fire(){
		//fireSound.Play(); -> create normal sound effect;
		Vector3 startPos=transform.position+new Vector3(0,1,0);
		GameObject beam=Instantiate(projecttile,startPos,Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity=new Vector3(0f,projectSpeed,0f);
		AudioSource.PlayClipAtPoint(fireSound,transform.position); //-> tao am thanh vong tai vi tri ban.
	}
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire",0.00001f,firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			//transform.position+=new Vector3(speed*Time.deltaTime,0f,0f);
			transform.position+=Vector3.right*speed*Time.deltaTime;
		}else if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.position-=new Vector3(speed*Time.deltaTime,0f,0f);
			transform.position+=Vector3.left*speed*Time.deltaTime;
		}else if(Input.GetKey(KeyCode.UpArrow)){
			transform.position+=Vector3.up*speed*Time.deltaTime;
		}else if(Input.GetKey(KeyCode.DownArrow)){
			transform.position+=Vector3.down*speed*Time.deltaTime;
		}
		float newX=Mathf.Clamp(transform.position.x,leftbound,rightbound);
		float newY=Mathf.Clamp(transform.position.y,botbound,topbound);
		transform.position=new Vector3(newX,newY,transform.position.z);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		//sound.Play();
		projectile tile= other.gameObject.GetComponent<projectile>();
		if(tile){
			Health-=tile.GetDamage();
			if(Health<=0){
				Destroy(gameObject);
				level.LoadLevel("Lose Screen");
				
			}
		}
	}
}
