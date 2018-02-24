using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void find(Transform _startNode)
	{
		//BFS (G, s)
		//Let Q be queue
		Queue<Node> Q = new Queue<Node>();
		Node startNode = _startNode.GetComponent ("Node") as Node;
		Q.Enqueue (startNode);
		startNode.Visited = true;


		while ( Q.Count > 0)
		{
			//Removing that vertex from queue,whose neighbour will be visited now
			Node parent  =  Q.Dequeue( );
            Debug.Log("Parent" + parent.xIndex + ", " + parent.zIndex);
				//turn this into a Node somehow

				//processing all the neighbours of v  
				for (int i = 0; i < parent.adjacent.Count; i++)
				{
				Node child = parent.adjacent [i];
				if(!child.Visited)
				{
					Q.Enqueue (child);
					child.Visited = true;
				}
				Debug.Log("Child: " + child.xIndex + ", " + child.zIndex);
				}
					
					//if w is not visited 
					//	Q.enqueue( w )             //Stores w in Q to further visit its neighbour
					//	mark w as visited.
				
		}
	}
		//Q.enqueue(s)

}
