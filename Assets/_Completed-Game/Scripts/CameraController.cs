using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public GameObject player;
	private Vector3 offset;

	//start of the game
	void Start ()
	{
		//create an offset by subtracting the cameras position from the player's position
		offset = transform.position - player.transform.position;
	}

	//after the standard 'Update()' loop runs and just before each frame is rendered
	void LateUpdate ()
	{
		//set the position of the camera to the player's position, plus the offset amount
		transform.position = player.transform.position + offset;
	}
}