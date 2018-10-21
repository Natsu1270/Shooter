using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public static int score;

	private Text scoreText;
	void Start () {
		scoreText=GetComponent<Text>();
	}
	public void Score(int Point){
		score+=Point;
		scoreText.text=score.ToString();	
	}
	public static void Reset(){
		score=0;
	}
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
