using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumn : MonoBehaviour {
	private Slider sf;
	// Use this for initialization
	void Start () {
		sf=GameObject.FindObjectOfType<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		AudioListener.volume=sf.value;
	}
}
