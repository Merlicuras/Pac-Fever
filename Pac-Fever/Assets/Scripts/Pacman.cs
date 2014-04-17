using UnityEngine;
using System.Collections;

public class Pacman : MovingObject {



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	public override void Update () {


		
		if (Input.GetKeyDown (KeyCode.A))
			base.left();
		
		if(Input.GetKeyDown(KeyCode.D))
			base.right();

		if (Input.GetKeyDown(KeyCode.W))
			base.up();

		if (Input.GetKeyDown (KeyCode.S))
			base.down ();

		base.Update ();

	}
}
