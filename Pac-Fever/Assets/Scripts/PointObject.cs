using UnityEngine;
using System.Collections;

//Parent class of point giving objects. Contains common fields for point objects.
public abstract class PointObject : MonoBehaviour {

	protected int point {get; set;}
	private GameObject scoreboard;

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
			Destroy(this.gameObject);
			Debug.Log ("collision");
			scoreboard.SendMessage("AddPoints", point);
		}
	}
}
