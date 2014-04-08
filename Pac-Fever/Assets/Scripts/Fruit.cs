using UnityEngine;
using System.Collections;

public class Fruit : PointObject {


	Fruit(){
		//Fruit = 100 points.
		this.point = 100;
	}

	// Use this for initialization
	void Start () {
		Debug.Log (point);
	}
	
	// Update is called once per frame
	void Update () {}
}
