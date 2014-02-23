/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class UpTrigger : MonoBehaviour {

	//Variables
	public GameObject displayMessage;
	public GameObject player;

	private bool isReady;
	private TextMesh tm;

	// Use this for initialization
	void Start () {
		tm = displayMessage.GetComponent<TextMesh> ();
		isReady = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			if ( isReady && Input.GetKeyDown(KeyCode.X)){
				player.transform.localPosition = new Vector3(1200, 5, 948);
			}	
		}
	}

	//On entering, show message and wait for player to press X to go back to main terrain
	IEnumerator OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MainCamera") {
			isReady = true;
			tm.text = "Press X to continue";
			yield return new WaitForSeconds (1);
			tm.text = "";			
		}
	}

	//On exit, prevent the player from pressing X and exiting the underground plane
	void OnTriggerExit(){
		isReady = false;
	}
}
