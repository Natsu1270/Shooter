using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour {

	// Use this for initialization
	public float upAmount=0.2f;
	public float speed=5f;
	private Vector3 dnPos;
	private Vector3 upPos;
	private Vector3 curPos;	
	void Start () {
		dnPos=transform.position;
		upPos=transform.position+Vector3.up*upAmount;
		curPos=dnPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, curPos, speed * Time.deltaTime);
	}
	private void OnMouseOver() {
		curPos = upPos;
	}
	private void OnMouseExit() {
		curPos=dnPos;
	}
}
