using UnityEngine;
using System.Collections;

public class Pacman : MovingObject {

	
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






	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "ghost"){
			Destroy(this.gameObject);
			Debug.Log ("collision");
			lives=lives-1;
			SetLivesText ();
		}
		if(other.gameObject.name == "UberCheese"){
			StartCoroutine(StateChange());

			Debug.Log ("collision");
		}
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
		winText.text = " ";
		SetLivesText ();

	}

	public void SetLivesText (){
		livesText.text = "Lives: " + lives.ToString();
		if (lives <= 0){
			winText.text = "GAME OVER";
		}
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
