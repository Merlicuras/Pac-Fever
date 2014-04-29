using UnityEngine;
using System.Collections;

public class Pacman : MovingObject {


	private Vector3 oriPos;
	public int lives;
	public bool state;
	public bool ghosts;
	public GUIText winText;
	public GUIText livesText;
	public IEnumerator StateChange()
	{
		state = true;
		yield return new WaitForSeconds(5);
		state = false;
	}





	public void killed()
	{
		GameManager gm = GameObject.FindGameObjectWithTag ("MapCreate").GetComponent ("GameManager") as GameManager;
		lives=lives-1;
		if (lives == 0)
			gm.gameOver ();
		else
			gm.pacmanKilled ();

		GameObject scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");
		scoreboard.SendMessage("setLives", lives);

		Reset ();
	}

	public void setUber()
	{
		StartCoroutine(StateChange());
	}
	

	// Use this for initialization
	public override void Start () {
		base.Start();
		lives = 3;
		state = false;
		oriPos = transform.position;
	}

	public void Reset()
	{
		transform.position = oriPos;
		base.direction = Vector3.left;
		base.isMoving = false;
		rigidbody.velocity = Vector3.zero;

		//Need to wait for Start() function
	}
	
	// Update is called once per frame
	public override void Update () {


		if (state == true)
			ghosts = true; //true = vulnerable


		if (Input.GetKeyDown (KeyCode.A))
			base.left();
		
		if(Input.GetKeyDown(KeyCode.D))
			base.right();

		if (Input.GetKeyDown(KeyCode.W))
			base.up();

		if (Input.GetKeyDown (KeyCode.S))
			base.down ();

		base.Update ();
		//Denne her skal lige ned under base.Update. Jeg kan ikke cut-paste. :)
		Vector3 fixedHeight = new Vector3 (transform.position.x, 1, transform.position.z);
		transform.position = fixedHeight;

	}
}
