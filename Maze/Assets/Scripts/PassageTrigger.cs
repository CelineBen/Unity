/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class PassageTrigger : MonoBehaviour {

	//Variables
	public GameObject displayMessage;
	public GameObject player;
	private TextMesh tm;
	private bool isReady; //Used to keep track of where the player is

	// Use this for initialization
	void Start () {
		tm = displayMessage.GetComponent<TextMesh> ();
		isReady = false;
	}
	
	// Update is called once per frame
	void Update () {

		//If X is pressed, character will be moved to underground plane
		if ( isReady && Input.GetKeyDown(KeyCode.X)){
			player.transform.localPosition = new Vector3(1203, -4, 947);
		}	
	}

	//Show message on enter 
	IEnumerator OnTriggerEnter(){
		isReady = true;
		tm.text = "Press X";
		yield return new WaitForSeconds (1);
		tm.text = "";

	}

	void OnTriggerExit(){
		isReady = false;
	}
}
