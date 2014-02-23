/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour {

	//When canon thrown on breakable wall, destroy projectile and wall. 
	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "projectile") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
