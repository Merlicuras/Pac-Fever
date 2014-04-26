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
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			Debug.Log ("collision");
			scoreboard.SendMessage("AddPoints", point);
			if(this.gameObject.tag == "Fruit"){
				Debug.Log ("Fruit collision");
				mapCreate = GameObject.FindGameObjectWithTag("MapCreate");
				Vector3 fruit = this.gameObject.transform.position;
				mapCreate.SendMessage("FruitRespawn", fruit);
			}
			Destroy(this.gameObject);
		}
	}
}
