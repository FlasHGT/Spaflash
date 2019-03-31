﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public float realTimeSpeed;

	public bool gamePaused = false;
	public bool retryButtonPressed = false;

	public Slider afxSlider = null;
	public Slider musicSlider = null;
	public Slider uiSlider = null;

	public void ResetGame()
	{
		gamePaused = true;
		UIManager.Instance.loseScreen.SetActive(true);

		if (retryButtonPressed)
		{
			UIManager.Instance.loseScreen.SetActive(false);
			int i = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(i);
			retryButtonPressed = false;
			gamePaused = false;
		}
	}

	private void Awake()
	{
		if(!Instance)
		{
			Instance = this;
		}
	}

	private void FixedUpdate()
	{
		if (gamePaused)
		{
			ResetGame();
		}

		if (Player.Instance)
		{
			float playerSpeed = Player.Instance.speed;
			if (Player.Instance.transform.position.y > 1000f)
			{
				playerSpeed += 4f;
			}
			else if (Player.Instance.transform.position.y > 750f)
			{
				playerSpeed += 3f;
			}
			else if (Player.Instance.transform.position.y > 500f)
			{
				playerSpeed += 2f;
			}
			else if (Player.Instance.transform.position.y > 250f)
			{
				playerSpeed += 1f;
			}

			realTimeSpeed = playerSpeed * Time.fixedDeltaTime;
		}
		else
		{
			realTimeSpeed = 2f * Time.fixedDeltaTime;
		}
	}
}
