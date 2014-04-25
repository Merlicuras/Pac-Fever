using UnityEngine;
using System.Collections;

//Parent class of point giving objects. Contains common fields for point objects.
public abstract class PointObject : MonoBehaviour {

	protected int point {get; set;}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Pacman"){
			Destroy(this.gameObject);
			Debug.Log ("collision");
		}
	}
}
