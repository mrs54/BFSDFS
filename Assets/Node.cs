using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	// Use this for initialization
	public int xIndex = 0;
	public int zIndex = 0;

	public bool Visited = false;

	public List <Node> adjacent = new List<Node> ();

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
