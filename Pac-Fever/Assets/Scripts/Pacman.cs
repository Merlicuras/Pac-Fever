using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour {

	// Use this for initialization
	void Start () {

		public float speed = 20.0f;

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3(0,  0,  speed) * Time.deltaTime;
		
		if(Input.GetKeyDown(KeyCode.A))
			transform.position += new Vector3(-2.0f, 0, 0);
		
		if(Input.GetKeyDown(KeyCode.D))
			transform.position += new Vector3(2.0f, 0, 0);
		
		if (Input.GetKeyDown(KeyCode.W))
			transform.position += new Vector3(0, 2.0f, 0);
		if(Input.GetKeyDown(KeyCode.S))
			transform.position += new Vector3(0, -2.0f, 0);

	}
}
