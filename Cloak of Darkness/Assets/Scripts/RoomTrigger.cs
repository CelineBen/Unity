/** 
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP531 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	//Variables
	public GameObject barLight;
	public GameObject hiddenMessage;
	public GameObject displayMessage;
	public GameObject inventoryMessage;

	public GameObject tableCollider;

	private TableTrigger tableScript;
	private TextMesh tm;
	private TextMesh inventory;
	private TextMesh secretMessage;
	private bool isInside;
	private bool empty;
	private Light light;

	// Use this for initialization
	void Start () {

		//Initialize variables
		tableScript = tableCollider.GetComponent<TableTrigger> ();
		tm = displayMessage.GetComponent<TextMesh>();	
		inventory = inventoryMessage.GetComponent<TextMesh> ();
		secretMessage = hiddenMessage.GetComponent<TextMesh> ();
		isInside = false;
		empty = false;
		light = barLight.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Show/Hide inventory 
		if ( Input.GetKeyDown(KeyCode.I) == true ){
			if(inventory.text == ""){
				if(empty){
					inventory.text = "Inventory: \n empty";
				}else{
					inventory.text = "Inventory: \n wrench";
			}
			}else{
				inventory.text = "";
			}
		}

		//If X pressed and object dropped on table properly, switch to win mode (turn on light and show message)
		if (isInside) {
			if ( Input.GetKeyDown(KeyCode.X) == true ){
				empty = tableScript.dropObject();
				if(empty){
					winMode ();
				}
			}
			if ( Input.GetKeyDown(KeyCode.C) == true ){
				tm.text = "";
			}
		}
	}

	IEnumerator OnTriggerEnter(Collider other){
		isInside = true;
		tm.text = "Drop your tool on the table, \n press X";
		yield return new WaitForSeconds(1);
		tm.text = "";	
	}
	
	void OnTriggerExit(Collider other){
		isInside = false;
	}

	// Show light + message
	void winMode(){
		light.intensity = (float)0.5;
		secretMessage.text = "Congratulations !";
	}

}
