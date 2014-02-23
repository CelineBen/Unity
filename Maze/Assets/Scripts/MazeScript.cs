/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeScript : MonoBehaviour {

	//Variables
	private int[,] maze;
	private string[] shuffled;
	private List<string[]> randomDirections;
	private int visitedCells;

	// Use this for initialization
	void Start () {

		//Initialize variables
		visitedCells = 0;
		shuffled = new string[]{"r", "l", "u", "d"};
		randomDirections = new List<string[]> ();

		//Initialize the 25 random paths for the 25 cells
		for (int i = 0; i < 25; i++) {
			randomDirections.Add (shuffle());
		}

		int rows = 5;
		int columns = 5;
		maze = new int[rows, columns];

		//Initialize all cells as unvisited (value 0)
		for(int i=0; i < rows; i++){
			for(int j=0; j < columns; j++){
				maze[i, j] = 0;
			}
		}

		//Create the maze
		visit(0, 0);
	
		//Set breakability on some walls
		initializeGrid ();
	}

	//Depth-first search to create the maze
	void visit(int x, int y){
		maze [x, y] = 1;
		print ("VISITING: " + x + " " + y); 
		visitedCells ++;
		print1D (randomDirections [visitedCells - 1]);
		foreach(string dir in randomDirections[visitedCells-1]){
		//for(int i = 0; i < 4; i++){
			print ("CHECK : " + dir + " for " + x + " " + y);
			int[] next = new int[2];
			next = getNext(x, y, dir);
			int tempX = next[0];
			int tempY = next[1];
			if(isInside(tempX, tempY)){
				if(notVisited (tempX, tempY)){
					print("PATH from " + x + " " + y + " to " + tempX + " " + tempY);
					generateMaze(x, y, dir);
					x = tempX;
					y = tempY;
					visit(x, y);
				}	
			}
		}
	}

	//Delete the corresponding wall of the grid 
	void generateMaze(int x, int y, string direction){
		if (direction == "r") {
			Destroy(GameObject.Find("HMeshWall"+y+x));
		}else if(direction == "l"){
			y = y - 1;
			Destroy(GameObject.Find ("HMeshWall"+y+x));
		}else if(direction == "u"){
			x = x - 1;
			Destroy(GameObject.Find ("VMeshWall"+x+y));
		}else if(direction == "d"){
			Destroy(GameObject.Find ("VMeshWall"+x+y));
		}
	}

	//Randomize the directions 
	string[] shuffle(){ 
		int n = 4;  
		string[] randomized = new string[4];
		while (n > 1) {  
			n--;  
			int k = Random.Range(0, n+1);  
			string value = shuffled[k];  
			shuffled[k] = shuffled[n];  
			shuffled[n] = value;  
		}  
		System.Array.Copy(shuffled, randomized, 4);
		return randomized;
	}

	//Get the coordinates of the next cell given the direction
	int[] getNext(int x, int y, string direction){
		if (direction == "r") {
			y = y + 1;
		}else if(direction == "l"){
			y = y - 1;
		}else if(direction == "u"){
			x = x - 1;
		}else if(direction == "d"){
			x = x + 1;
		}
		int[] next = new int[2];
		next [0] = x;
		next [1] = y;

		return next;
	}

	//Check if cell at position (x,y) is inside grid 
	bool isInside(int x, int y){
		if (x < 0 || x > 4 || y < 0 || y > 4) {
			print ("OUTSIDE");
			return false;		
		} else {
			return true;
		}
	}

	//Check if cell at position (x,y) had been visited
	bool notVisited(int x, int y){
		if(maze[x, y] == 1){
			print ("VISITED");
			return false;
		}else{
			return true;
		}
	}

	//Set the breakable script to 5-10 random walls
	void initializeGrid(){
		int k = Random.Range(5, 10); 
		List<int> done = new List<int>();

		//Contains the walls destroyed when building the maze...
		GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");

		for (int i = 0; i <= k; i++) {
			int index;

			//If wall already picked, pick another one
			do{
				index= Random.Range(0, walls.Length);
			}while(done.Contains(index));

			//Add the Wall collider script so it can be demolished
			walls[index].AddComponent("WallCollider");

			//Keep track
			done.Add(index);
		}
	}

	void print1D(string[] list){
		string dir = "";
		foreach(string d in list){
			dir += d + " ";
		}
		print (dir);
	}
}
