using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text scDisplay=GetComponent<Text>();
		scDisplay.text=ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
