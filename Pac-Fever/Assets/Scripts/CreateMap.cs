using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
			{1,1,1,1,1,1,0,1,1,5,5,1,1,0,0,1,1,5,5,1,1,0,1,1,1,1,1,1},
			{0,0,0,0,0,0,0,5,5,5,5,1,2,2,2,2,1,5,5,5,5,0,0,0,0,0,0,0},
			{1,1,1,1,1,1,0,1,1,5,5,1,1,1,1,1,1,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,6,5,5,5,5,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,5,5,5,5,5,5,5,5,5,5,1,1,0,1,1,1,1,1,1},
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
		
		Object roadObject = Resources.Load("Prefabs/Road");
		GameObject roadGameObject = roadObject as GameObject;

		Object wallObject = Resources.Load("Prefabs/Wall");
		GameObject wallGameObject = wallObject as GameObject;

		Object fruitObject = Resources.Load("Prefabs/Fruit");
		GameObject fruitGameObject = fruitObject as GameObject;

		Object cheeseObject = Resources.Load("Prefabs/Cheese");
		GameObject cheeseGameObject = cheeseObject as GameObject;

		Object uberCheeseObject = Resources.Load("Prefabs/UberCheese");
		GameObject uberCheeseGameObject = uberCheeseObject as GameObject;

		Object pacmanObject = Resources.Load("Prefabs/Pacman");
		GameObject pacmanGameObject = pacmanObject as GameObject;

		Object ghostObject = Resources.Load("Prefabs/Ghost");
		GameObject ghostGameObject = ghostObject as GameObject;

		for (int x = 0; x < 31; x++){
			for (int y = 0; y < 28; y++){
				if (map[x,y] == 0){
					//road with cheese
					//Debug.Log ("y: " + y + ". x: " + x + ". Type: " + map[x,y]); //-Only used for testing the instantiate overload problem
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject cheeseSpawned = Instantiate(cheeseGameObject, new Vector3(x,0.5f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 1){
					//wall
					GameObject wallSpawned = Instantiate(wallGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
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
					GameObject pacmanSpawned = Instantiate(pacmanGameObject, new Vector3(x,0.5f,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 4)	{
					//road with UberCheese
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject uberCheeseSpawned = Instantiate(uberCheeseGameObject, new Vector3(x,0.5f,y),Quaternion.identity) as GameObject;											
				}
				else if (map[x,y] == 5)	{
					//road without cheese
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
				}
				else if (map[x,y] == 6)	{
					//road with Fruit
					GameObject roadSpawned = Instantiate(roadGameObject, new Vector3(x,0,y),Quaternion.identity) as GameObject;
					GameObject fruitSpawned = Instantiate(fruitGameObject, new Vector3(x,0.5f,y),Quaternion.identity) as GameObject;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {	}

}
