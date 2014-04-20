using UnityEngine;
using System.Collections;

public class Pacman : MovingObject {



	private int lives;

	public GUIText winText;
	public GUIText livesText;

	SetLivesText ();
	winText.text = "";

	private bool state;

	public bool ghosts; //maybe this could be put in the ghosts' scripts to make them vulnerable?




	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "ghost"){
			Destroy(this.gameObject);
			Debug.Log ("collision");
			lives=lives-1;
			SetLivesText ();
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "UberCheese"){
			state = true;
			Debug.Log ("collision");
		}
	}
	
	// Use this for initialization
	void Start () {
		lives = 3;
		state = false;

	}
	
	// Update is called once per frame
	public override void Update () {

		void SetLivesText (){
			livesText.text = "Lives: " + lives.ToString();
			if (lives <= 0){
			winText.text = "GAME OVER";
			}
		}

		if (state = true;)
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

	}
}
