using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject car;
	public Vector3 spawnVal;
	private int numCars;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int	 highScore;

	private int score;
	public int lives;
	public TextBox textBox;

	public bool gameOver;
	private bool restart;
	private bool winGame;

	void Start()
	{	
		score = 0;
		lives = 3;
		numCars = 3;
		gameOver = false;
		textBox.gameOverText.text = "";
		restart = false;
		textBox.restartText.text = "";
		winGame = false;
		textBox.winText.text = "";
		textBox.shootText.text = "Use 'Spacebar' to shoot water \n" +
								 "and arrow keys to move";

		UpdateScore ();
		UpdateLives ();
		StartCoroutine (SpawnCars ());

	}

	IEnumerator SpawnCars()
	{
		yield return new WaitForSeconds (startWait);
		textBox.shootText.text = "";

		while (true) 
		{
			for (int count = 0; count < numCars; ++count) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnVal.x, spawnVal.x), spawnVal.y, spawnVal.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (car, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			++numCars;
			if (gameOver || winGame) 
			{
				textBox.restartText.text = "Press 'Spacebar' to restart";
				restart = true;
				break;
			}
		}
	}

	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void UpdateScore()
	{
		textBox.scoreText.text = "Score: " + score;
		if (score >= highScore) 
		{
			winGame = true;
			textBox.winText.text = "You won! :)";
		}

	}

	void UpdateLives()
	{
		textBox.livesText.text = "Lives: " + lives;
	}

	public void AddScore (int newScore)
	{
		score += newScore;
		UpdateScore ();
	}

	public void LoseLife ()
	{
		--lives;
		UpdateLives();
	}

	public void GameOver ()
	{
		textBox.gameOverText.text = "Game Over!";
		gameOver = true;
	}
}

[System.Serializable]
public class TextBox
{
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public Text winText;
	public Text livesText;
	public Text shootText;
}