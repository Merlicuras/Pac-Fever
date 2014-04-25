using UnityEngine;
using System.Collections;

public class Cheese : PointObject {

	Cheese(){
		//Cheese = 5 points.
		this.point = 5;
	}


	// Use this for initialization
	void Start () {
		base.Initialize();
	}
	
	// Update is called once per frame
	void Update () {}

}
