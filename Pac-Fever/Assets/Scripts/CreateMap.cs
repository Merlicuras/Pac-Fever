using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	Object roadObject;
	Object wallObject;
	Object fruitObject;
	Object cheeseObject;
	Object uberCheeseObject;
	Object pacmanObject;
	Object ghostObject;

	// Use this for initialization
	void Start () {
		/*
		 * //Map lies sideways when used.
		int[,] map = {
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,4,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,4,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
			{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,5,5,5,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,5,5,5,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,1,1,5,5,1,1,5,5,1,1,0,1,1,1,1,1,1},
			{0,0,0,0,0,0,0,5,5,5,5,1,2,2,2,2,1,5,5,5,5,0,0,0,0,0,0,0},
			{1,1,1,1,1,1,0,1,1,5,5,1,1,1,1,1,1,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,5,5,5,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,6,5,5,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,4,0,0,1,1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,1,1,0,0,4,1},
			{1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
			{1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
			{1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
			{1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
		};
		*/

		//Sideways array for standard map.
		int[,] map = {
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, 
			{1,0,0,0,0,1,1,4,0,0,0,1,1,1,1,1,7,1,1,1,1,1,0,0,0,0,0,4,0,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1}, 
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,1,1,0,5,5,5,5,5,5,5,5,5,1,1,0,0,0,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,5,5,5,5,5,5,5,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,5,5,1,1,1,5,5,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,0,0,0,1,1,0,0,0,0,1,1,5,5,1,2,1,5,5,0,0,0,1,1,0,0,0,0,0,1}, 
			{1,0,1,1,1,1,1,3,1,1,1,1,1,5,5,1,2,5,5,5,1,1,1,1,1,0,1,1,1,1,1},
			{1,0,1,1,1,1,1,0,1,1,1,1,1,6,5,1,2,5,5,5,1,1,1,1,1,0,1,1,1,1,1},
			{1,0,0,0,0,1,1,0,0,0,0,1,1,5,5,1,2,1,5,5,0,0,0,1,1,0,0,0,0,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,5,5,1,1,1,5,5,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,5,5,5,5,5,5,5,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,1,1,0,5,5,5,5,5,5,5,5,5,1,1,0,0,0,0,1,1,1,0,1}, 
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1}, 
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,0,1}, 
			{1,0,0,0,0,1,1,4,0,0,0,1,1,1,1,1,7,1,1,1,1,1,0,0,0,0,0,4,0,0,1}, 
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
		};
		
		roadObject = Resources.Load("Prefabs/Road");
		GameObject roadGameObject = roadObject as GameObject;

		wallObject = Resources.Load("Prefabs/Wall");
		GameObject wallGameObject = wallObject as GameObject;

		fruitObject = Resources.Load("Prefabs/Fruit");
		GameObject fruitGameObject = fruitObject as GameObject;

		cheeseObject = Resources.Load("Prefabs/Cheese");
		GameObject cheeseGameObject = cheeseObject as GameObject;

		uberCheeseObject = Resources.Load("Prefabs/UberCheese");
		GameObject uberCheeseGameObject = uberCheeseObject as GameObject;

		pacmanObject = Resources.Load("Prefabs/Pacman");
		GameObject pacmanGameObject = pacmanObject as GameObject;

		ghostObject = Resources.Load("Prefabs/Ghost");
		GameObject ghostGameObject = ghostObject as GameObject;

		for (int x = 0; x < map.GetLength(0); x++){
			for (int y = 0; y < map.GetLength(1); y++){
				if (map[x,y] == 0){
					//road with cheese
					//Debug.Log ("y: " + y + ". x: " + x + ". Type: " + map[y,x]); //-Only used for testing the instantiate overload problem
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject cheeseSpawned = Instantiate(cheeseGameObject, new Vector3(x,0.75f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 1){
					//wall
					GameObject wallSpawned = Instantiate(wallGameObject, new Vector3(x,0.75f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 2)	{
					//road with ghost spawn
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					//ghost
					//GameObject ghostSpawned = Instantiate(ghostGameObject, new Vector3(x,0.5f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 3){
					//road with pacman spawn
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject pacmanSpawned = Instantiate(pacmanGameObject, new Vector3(x,0.75f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 4)	{
					//road with UberCheese
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject uberCheeseSpawned = Instantiate(uberCheeseGameObject, new Vector3(x,0.75f,y),Quaternion.identity) as GameObject;											
				}
				else if (map[x,y] == 5)	{
					//road without cheese
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 6)	{
					//road with Fruit
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject fruitSpawned = Instantiate(fruitGameObject, new Vector3(x,0.75f,y),fruitGameObject.transform.rotation) as GameObject;
				}
				else if (map[x,y] == 7)	{
					//road without secret passage
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {	}

	public IEnumerator FruitRespawn(Vector3 fruit){
		fruitObject = Resources.Load("Prefabs/Fruit");
		GameObject fruitGameObject = fruitObject as GameObject;

		yield return new WaitForSeconds(20);
		Debug.Log ("Fruit spawn");
		GameObject fruitRespawn = Instantiate(fruitGameObject,fruit ,fruitGameObject.transform.rotation) as GameObject;
		
	}

}
