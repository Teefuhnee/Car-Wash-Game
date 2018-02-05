using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour 
{
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Car") 
		{
			if (gameController.lives > 0) 
			{ 
				gameController.LoseLife ();
			}
			if (gameController.lives <= 0 || gameController.gameOver) 
			{
				gameController.GameOver ();
			}

		}
		Destroy (other.gameObject);
		//Destroy(gameObject);

	}
}
