using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour {

	public float speed = 0.1f;
	public Vector3 direction;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3(0,  0,  speed) * Time.deltaTime;
		
		if (Input.GetKeyDown (KeyCode.A))
			direction = Vector3.right * -1;
		
		if(Input.GetKeyDown(KeyCode.D))
			direction = Vector3.left * -1;
		
		if (Input.GetKeyDown(KeyCode.W))
			direction = Vector3.down * -1;

		if (Input.GetKeyDown (KeyCode.S))
						direction = Vector3.up * -1;

		transform.Translate (direction * speed);

	}
}
