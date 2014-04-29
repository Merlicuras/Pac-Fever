using UnityEngine;
using System.Collections;

public class Ghost : MovingObject {

	//Making stuff prettier
	public enum Mode {Standby,Chase, Scatter, Frightened, Dead};
	
	
	//Target and scatter location for pathfinding
	public Vector3 scatter;
	public Vector3 target;
	
	//Ghost current mode
	Mode mode;
	
	protected Vector3 prevPos;
	protected Vector3 turnDir;
	protected bool haveTurnDir;
	
	//Will reverse on next tile if true
	protected bool overwriteReversal;
	
	//For release sequence
	protected bool isReleased;

	// Use this for initialization
	public virtual void Start () {
		
		//Ghost begin by going up
		base.up();
		
		//Stand still
		changeMode(Mode.Standby);
		
		overwriteReversal = false;
		
		isReleased = false;
		
		prevPos = transform.position;
		haveTurnDir = false;
	}
	
	public override void Update () {
		//Standby does nothing
		if(mode == Mode.Standby)
			return;
			
		//Move and such
		base.Update();
		
			
		//Not out of prison yet?
		if(!isReleased)
		{
			transform.position = new Vector3(14,0,18);
			base.left();
			base.isMoving = true;
			
			isReleased = true;
/* 			GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
			MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
			
			//We're moving out
			if(!base.isMoving)
			{
				//Move to middle of prison first
				if(transform.position.x < m.map.GetLength(0)/2)
					base.right();
				else
					base.left();
					
				base.isMoving = true;
			}
			else
			{
				//Already moving. Up yet?
				if(base.direction != Vector3.forward) //up
				{
					//Else if we're near center, go up
					if(Mathf.FloorToInt(transform.position.x) == m.map.GetLength(0)/2)
						base.up();
				}
				else
				{
					//We ARE moving up. Are we out yet, then?
					if(getTileType(transform.position) != 8)
					{
						isReleased = true;
					}
				}
			}
			return; */
		}
		
		
		
		//Check if we are entering a new tile
		if(Mathf.FloorToInt(prevPos.x) != Mathf.FloorToInt(transform.position.x)
			|| Mathf.FloorToInt(prevPos.z) != Mathf.FloorToInt(transform.position.z))
		{
			//If yes, check if this tile has other pathways
			int numPaths = 0;
			Vector3 pos = transform.position;
			
			if(getTileType(pos+Vector3.right) != 1)
				numPaths++;
			if(getTileType(pos+Vector3.back) != 1)
				numPaths++;
			if(getTileType(pos+Vector3.left) != 1)
				numPaths++;
			if(getTileType(pos+Vector3.forward) != 1)
				numPaths++;
			
			if(numPaths > 2)
			{
				//Update target based on possible turn decision
				// note: reversal not allowed (unless overruled later)
				haveTurnDir = true;
				
				//Measure is minimum euclidean distance
				float minDist = 999999f;
				
				//Tile to check
				Vector3 tile = pos+Vector3.right;
				
				//We can't reverse, so check if tile in question is position
				if(getTileType(tile) != 1)
				{
					//Vector from tile to target
					Vector3 tVec = target - tile;
					
					//First to be checked is minimum so far
					minDist = tVec.magnitude;
					turnDir = Vector3.right;
				}
				
				
				tile = pos+Vector3.back;
				
				if(getTileType(tile) != 1)
				{
					Vector3 tVec = target - tile;
					
					//if less than current min, replace
					if(tVec.magnitude < minDist)
					{
						minDist = tVec.magnitude;
						turnDir = Vector3.back;
					}
				}
				
				
				tile = pos+Vector3.left;
				
				if(getTileType(tile) != 1)
				{
					Vector3 tVec = target - tile;
					
					//if less than current min, replace
					if(tVec.magnitude < minDist)
					{
						minDist = tVec.magnitude;
						turnDir = Vector3.left;
					}
				}
				
				
				tile = pos+Vector3.forward;
				
				if( getTileType(tile) != 1)
				{
					Vector3 tVec = target - tile;
					
					//if less than current min, replace
					if(tVec.magnitude < minDist)
					{
						minDist = tVec.magnitude;
						turnDir  = Vector3.forward;
					}
				}
					
			}
			else
			{
				//We have 1 other direction. Check for corners
				if(getTileType(transform.position + base.direction) == 1)
				{
					//Find the direction to turn
					Vector3 p = transform.position;
					Vector3 next = p+base.direction;
					
					if(next+Vector3.right!= p && getTileType(next+Vector3.right) != 1)
						turnDir = Vector3.right;
					else if(next+Vector3.back != p && getTileType(next+Vector3.back) != 1)
						turnDir = Vector3.back;
					else if(next+Vector3.left != p && getTileType(next+Vector3.left) != 1)
						turnDir = Vector3.left;
					else if(next+Vector3.forward != p && getTileType(next+Vector3.forward) != 1)
						turnDir = Vector3.forward;
					
					haveTurnDir = true;
				}
				else
				{
					haveTurnDir = false;
				}
			}
		}
		
		//Check if we have a turn direction to go for
		if(haveTurnDir)
		{
			//Check if we are approximately in the middle of the pathway
			float distFromX,distFromZ;
			distFromX = transform.position.x - Mathf.Floor(transform.position.x);
			distFromZ = transform.position.z - Mathf.Floor(transform.position.z);
			
			if(distFromX > 0.45 && distFromX < 0.55
				&& distFromZ > 0.45 && distFromZ < 0.55)
			{
				//Turn!
				base.direction = turnDir;
				haveTurnDir = false;
			}
		}
		
		//Check if reverse overwrite
		if(overwriteReversal)
		{
			base.direction = base.direction * -1;
			overwriteReversal = false;
		}
		
		prevPos = transform.position;
		
	}
	
	int getTileType(Vector3 pos)
	{
		//int[x,y(z)] map
		GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
		MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
		
		return m.map[Mathf.FloorToInt(pos.x),Mathf.FloorToInt(pos.z)];
	}
	
	void Respawn()
	{
		
	}
	
	public void changeMode(Mode m)
	{	
		Debug.Log ("Ghost " + gameObject.tag + " changing to mode " + m.ToString());
		switch(m)
		{
			case Mode.Standby:
				//Stand still, no action.
				base.isMoving = false;
				break;
			
			case Mode.Dead:
				//Become eyes, run back & respawn
				break;
			
			case Mode.Frightened:
				//Become blue, force reversal, random turns
				break;
			
			case Mode.Chase:
				updateTarget();		//Specific for colors
				break;
			
			case Mode.Scatter:
				target = scatter;
				break;
				
		}
		
		// Remember reversal if switching from
		if(mode == Mode.Chase || mode == Mode.Scatter)
		{
			//Force reversal on next tile
			overwriteReversal = true;
		}
		
		mode = m;
		
	}
	
	virtual public void updateTarget()
	{
		// Target tile for pathfinding. Specific for each Ghost.
	}
	
}

