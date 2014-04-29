using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {
	

	public float speed = 0.1f;
	public Vector3 direction;
	public bool isMoving;
	MapManager m;

	public void right ()
	{
		direction = Vector3.right;
	}
	public void left ()
	{
		direction = Vector3.left;
	}
	public void down (){
		direction = Vector3.back;
	}
	public void up()
	{
		//tror det er her
		direction = Vector3.forward;
	}
	
	// Use this for initialization
	public virtual void Start () {
		
		isMoving = true;	//Should be false, when GameManager can 
						// handle activation of Pacman & Control
		
		
		GameObject mm = GameObject.FindGameObjectWithTag ("MapCreate") as GameObject;
		m = mm.GetComponent ("MapManager") as MapManager;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
		//transform.position = transform.position + new Vector3(0,  0,  speed) * Time.deltaTime;
		

		if(isMoving)
			transform.Translate (direction * speed);

		Vector3 newLoc = transform.position;

		if (m.map [Mathf.FloorToInt (transform.position.x), Mathf.FloorToInt (transform.position.z)] == 7)
		{
			if (transform.position.x < 3)
				newLoc.x = m.map.GetLength (0) - 3;
			else
				newLoc.x = 2;
		}
		transform.position = newLoc;
	}


}