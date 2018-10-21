using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOption : MonoBehaviour {
	// private int opIndex;
	// // Use this for initialization
	// void Start () {
	// 	opIndex=0;
	// }

	
	// // Update is called once per frame
	// void Update () {
	// 	// if(Input.GetAxisRaw("Vertical")!=0 && !buttonSelected){
	// 	// 	eventSystem.SetSelectedGameObject(selectedObj);
	// 	// 	buttonSelected=true;
	// 	// }
	// 	ChangeIndex();
	// 	eventSystem.SetSelectedGameObject(this.transform.GetChild(opIndex).gameObject);
		
	// }
	// public void ChangeIndex(){
	// 	if(Input.GetKeyDown(KeyCode.DownArrow)){
	// 		opIndex++;
	// 	}else if (Input.GetKeyDown(KeyCode.UpArrow)){
	// 		opIndex--;
	// 	}
	// 	if(opIndex<=0) opIndex=0;
	// 	else if (opIndex>=this.transform.childCount) opIndex=this.transform.childCount-1;
	// }
	// private void OnDisable() {
	// 	buttonSelected=false;	
	// }
	public EventSystem eventSystem;
	public GameObject selectedOption;
	private bool optionSelected;
	// Use this for initialization
	void Start () {
		eventSystem.SetSelectedGameObject(this.transform.GetChild(0).gameObject); //selectedOption
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical")!=0 && !optionSelected){
			eventSystem.SetSelectedGameObject(selectedOption);
			optionSelected=true;
		}
	}
	private void OnDisable() {
		optionSelected=false;	
	}
}
