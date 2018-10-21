using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public float width=10f; // width of spawning enemyship area
	public float height=5f; // height of spawning enemyshio area
	public GameObject enemyPrefab; // enemyEntity
	public float padding=1f;  // use for resolving crop size-effect when use mathf.clamp
	public float speed=2f; //ship moving speed.
	public float delay=0.5f;

	private float leftBound,rightBound; // Moving boundary
	private bool moveRight=true;
	
	private List<GameObject> listEnemy=new List<GameObject>();
	private LevelManager level;

	void Start () {
		level=GameObject.FindObjectOfType<LevelManager>();
		/* Use of find exact boundary for moving */
		float dis=transform.position.z-Camera.main.transform.position.z;
		Vector3 lefmost=Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,dis));
		Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1f,0f,dis));
		leftBound=lefmost.x+padding;
		rightBound=rightmost.x-padding;
		leftBound=lefmost.x;
		rightBound=rightmost.x;
		SpawnUntilFull();
		
	}
	//Draw the ship area.
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}

	//if one postion have ship being destroy return that point
	Transform NextFreepos(){
		foreach(Transform c in this.transform){
			if(c.childCount==0){
				return c;
			}
		}
		return null;
	}

	//Spawn one by on enemyship
	void SpawnUntilFull(){
		Transform freePos=NextFreepos();
		if(freePos){
			GameObject enemy= Instantiate(enemyPrefab,freePos.transform.position,Quaternion.identity) as GameObject; 
			enemy.transform.parent=freePos;
		}
		if(NextFreepos()){
			Invoke("SpawnUntilFull",delay);
		}

	}

	//Spawn all ship at one
	void SpawnShip(){
		foreach(Transform child in transform){
			GameObject enemy= Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject; 
			enemy.transform.parent=child;
		}
	}
	private bool allShipDead(){
		foreach(Transform childPosGobj in this.transform){
			if(childPosGobj.childCount>0){
				return false;
			}
		}
		return true;
	}
	// Update is called once per frame
	void Update () {
		// foreach(GameObject gameObject in listEnemy){
		// 	EnemyMove(gameObject);
		// }
		if(moveRight){
			transform.position+=Vector3.right*speed*Time.deltaTime;
		}else{
			transform.position+=Vector3.left*speed*Time.deltaTime;
		}
		float r=transform.position.x+0.5f*width;
		float l=transform.position.x-0.5f*width;
		if(l<=leftBound){
			moveRight=true;
		}
		if(r>=rightBound){
			moveRight=false;
		}
		if(allShipDead()){
			//level.LoadLevel("Lose Screen");
			SpawnUntilFull();
		}

	}
}
