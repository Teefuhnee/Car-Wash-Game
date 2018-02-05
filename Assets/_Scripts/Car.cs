using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Car : MonoBehaviour 
{

	private Rigidbody m_rigidbody;
	public float m_speed;
	public int scoreVal;
	private GameController gameController;
	public GameObject waterParticles;

	private void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody> ();
	}


	void Start()
	{
		m_rigidbody.velocity = transform.forward * (-1) 
						* Random.Range(3, 5) * m_speed;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Floor" || other.tag == "Boundary" || other.tag == "Car") 
		{
			return;
		}

		if (other.tag == "Bullet") 
		{
			gameController.AddScore (scoreVal);
			Instantiate(waterParticles, transform.position, Quaternion.identity);

		}

		if (other.tag == "Player") 
		{
			if (gameController.lives > 0) 
			{ 
				gameController.LoseLife ();
				Destroy (gameObject);
			}
			if (gameController.lives <= 0 || gameController.gameOver) 
			{
				gameController.GameOver ();
			}

		} 
		else 
		{
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
