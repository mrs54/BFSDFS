using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

	public Transform brick;

	static int width = 10;
	static int height = 10;
	static Transform[,] _tiles = new Transform[width,height];

	// Use this for initialization
	void Start () {
		Debug.Log ("Generating Grid");
		for(int x = 0; x < width; x++){
			for(int z = 0; z < height; z++){
				Transform tile = Instantiate (brick, new Vector3(x,0,z), Quaternion.identity);
				tile.name = "Tile_" + x + "_" + z;

				Node n = tile.GetComponent ("Node") as Node;
				n.xIndex = x;
				n.zIndex = z;

				//public List<LinkedListNode> adjacent = null;

				_tiles [x, z] = tile;
			}
		}
		SetNodeRelationships ();
        //DebugNodeRelationships();
		BFSController myBFSBot = new BFSController ();
		myBFSBot.find (_tiles [0, 0]);
	}
		
	// Update is called once per frame
	void Update () {
		
	}
	//#region
	public void SetNodeRelationships()
	{
		for(int x = 0; x < width; x++) {
			for(int z = 0; z < height; z++) {  

				Node n = _tiles[x,z].GetComponent("Node") as Node;
				if( (x - 1) >= 0 && (z + 1) < height )
				{
					n.adjacent.Add( _tiles[x-1,z+1].GetComponent("Node") as Node);  //1
				}
				if( (z + 1) < height )
				{
					n.adjacent.Add( _tiles[x,z+1].GetComponent("Node") as Node);                        //2

				}

				if( (x + 1) < width && (z + 1) < height )
				{
					n.adjacent.Add( _tiles[x+1,z+1].GetComponent("Node") as Node);  //3

				}
				if( (x - 1) >= 0 )
				{
					n.adjacent.Add( _tiles[x-1,z].GetComponent("Node") as Node);                        //4

				}
				if( (x + 1) < width)
				{
					n.adjacent.Add( _tiles[x+1,z].GetComponent("Node") as Node);                        //5

				}
				if( (x - 1) >= 0 && (z - 1) >= 0 )
				{
					n.adjacent.Add( _tiles[x-1,z-1].GetComponent("Node") as Node);  //6

				}
				if( (z - 1) >= 0 )
				{
					n.adjacent.Add( _tiles[x,z-1].GetComponent("Node") as Node);                        //7

				}
				if( (x + 1) < width && (z - 1) >= 0 )
				{
					n.adjacent.Add( _tiles[x+1,z-1].GetComponent("Node") as Node);  //8

				}
			}                  
		}
	}
    public void DebugNodeRelationships()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Node n = _tiles[x, z].GetComponent("Node") as Node;

                string adjacentList = "Tile (" + x + ", " + z + "): ";
                foreach (Node neigh in n.adjacent)
                {
                    adjacentList += "Tile (" + neigh.xIndex + ", " + neigh.zIndex + "), ";
                }

                Debug.Log(adjacentList);
            }
        }
    }
}
	

