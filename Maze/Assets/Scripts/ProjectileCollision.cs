/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	//Destroy projectile when it hits other object (usually a non-breakable wall)
	void OnCollisionEnter(Collision other){
		Destroy (gameObject);
	}
}
