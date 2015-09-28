using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static int lives = 3;
	public static int score = 0;
	public static GameState currentGameState = GameState.Start;
	public static int blockCount = 28;
	private GameObject[] blocks;

	public static BallScript ball;

	Text statusText;
	// Use this for initialization
	void Start () {
		blocks = GameObject.FindGameObjectsWithTag("Block");
		ball = GameObject.Find ("Ball").GetComponent<BallScript>();
		statusText = GameObject.Find ("Status").GetComponent<Text>();
	}

	private bool InputTake()
	{
		return Input.touchCount > 0 || Input.GetMouseButtonUp(0);
	}

	
	// Update is called once per frame
	void Update () 
	{
		switch (currentGameState) 
		{
			case GameState.Start:
				if(InputTake())
				{
					statusText.text = string.Format("Lives:{0}Score:{1}",lives,score);
					currentGameState = GameState.Playing;
					ball.StartBall();
				}
				break;
			case GameState.Playing:
				statusText.text = string.Format("Lives:{0}Score:{1}",lives,score);
				break;
			case GameState.Won:
				if(InputTake())
				{
					Restart();
					ball.StartBall();
					statusText.text = string.Format("Lives:{0}Score:{1}",lives,score);
					currentGameState = GameState.Playing;
				}
				break;
			case GameState.LostALife:
				if(InputTake())
				{
					ball.StartBall();
					statusText.text = string.Format("Lives:{0}Score:{1}",lives,score);
					currentGameState = GameState.Playing;
				}
				break;
			case GameState.LostAllLives:
				if(InputTake())
				{
					Restart();
					ball.StartBall();
					statusText.text = string.Format("Lives:{0}Score:{1}",lives,score);
					currentGameState = GameState.Playing;
				}
				break;
			default:
				break;
		}
	}

	private void Restart()
	{
		foreach (var item in blocks) 
		{
			item.SetActive(true);
		}
		lives = 3;
		score = 0;
	}

	public void DecreaseLives()
	{
		if (lives > 0) 
		{
			lives--;
		}
		if (lives == 0) 
		{
			statusText.text = "Lost all lives.Tap to play again";
			currentGameState = GameState.LostAllLives;
		}
		else 
		{
			statusText.text = "Lost a life.Tap to continue";
			currentGameState = GameState.LostALife;
		}
		ball.StopBall();
	}

	public enum GameState
	{
		Start,
		Playing,
		Won,
		LostALife,
		LostAllLives
	}
}
