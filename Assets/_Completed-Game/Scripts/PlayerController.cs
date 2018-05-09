using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// create variables for player speed and for text UI game objects
	public float speed;
	public Text countText;
	public Text winText;

	// create private references to rigidbody component on player, and count of objects picked up
	private Rigidbody rb;
	private int count;

	// start of the game
	void Start ()
	{
		// assign rigidbody to private rb variable
		rb = GetComponent<Rigidbody>();

		// set count to zero 
		count = 0;

		// run SetCountText to update the UI
		SetCountText ();

		// set text property of win text UI to an empty string making the 'You Win' blank
		winText.text = "";
	}


	void FixedUpdate ()
	{
		// set local float variables equal to the value of horizontal and vertical inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// create Vector3 variable assign X and Z to feature horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// add physical force to player rigidbody using 'movement' Vector3 multiply it by speed
		rb.AddForce (movement * speed);
	}

	// when this game object intersects a collider with 'is trigger' checked 
	// store a reference to that collider in a variable named 'other'
	void OnTriggerEnter(Collider other) 
	{
		// if the game object we intersect has the tag 'Pick Up' assigned to it
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object inactive
			other.gameObject.SetActive (false);

			// add one to the score variable 'count'
			count = count + 1;

			// run the 'SetCountText()' function
			SetCountText ();
		}
	}

	// create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// update the text field of our 'countText' 
		countText.text = "Count: " + count.ToString ();

		// check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
}