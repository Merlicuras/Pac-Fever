using UnityEngine;
using System.Collections;

public class UberCheese : PointObject {

	UberCheese(){
		//UberCheese = 50 points.
		this.point = 50;
	}
	
	// Use this for initialization
	void Start () {
		Debug.Log (point);
	}

	// Update is called once per frame
	void Update () {}
}
