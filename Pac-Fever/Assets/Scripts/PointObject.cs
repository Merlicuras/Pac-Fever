using UnityEngine;
using System.Collections;

//Parent class of point giving objects. Contains common fields for point objects.
public abstract class PointObject : MonoBehaviour {

	protected int point {get; set;}
	private GameObject scoreboard;
	private GameObject mapCreate;

	void Start()
	{
	}

	protected void Initialize()
	{
		//Debug.Log("Debug Checkpoint: PointObject.Start"); //see if the child inherits
		scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");
		mapCreate = GameObject.FindGameObjectWithTag("MapCreate");
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			scoreboard.SendMessage("AddPoints", point);

			GameManager gm = mapCreate.GetComponent("GameManager") as GameManager;
			gm.cheeses++;

			if(this.gameObject.tag == "Fruit"){
				Debug.Log ("Fruit collision");
				Vector3 fruit = this.gameObject.transform.position;
				mapCreate.SendMessage("FruitRespawn", fruit);
			}

			Pacman p = other.GetComponent("Pacman") as Pacman;

			if(this.gameObject.tag == "UberCheese")
			{
				p.setUber();
			}

			Destroy(this.gameObject);
		}
	}
}
