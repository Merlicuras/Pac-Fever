using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {
	

	public float speed = 0.1f;
	public Vector3 direction;

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
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
		//transform.position = transform.position + new Vector3(0,  0,  speed) * Time.deltaTime;
		

		
		transform.Translate (direction * speed);

	}


}