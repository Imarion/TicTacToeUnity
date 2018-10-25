using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;

	private string playerSide;
	private int moveCount;

	void Awake ()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons();
		playerSide = "X";
		restartButton.SetActive(false);
	}

	void SetGameControllerReferenceOnButtons ()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent< GridSpace>().SetGameControllerReference(this);
		}
	}

	public string GetPlayerSide ()
	{
		return playerSide;
	}

	public void EndTurn ()
	{
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		}

		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		}

		moveCount++;
		if (moveCount >= 9)
		{
			GameOver("draw");
		}
		ChangeSides();
	}

	void ChangeSides ()
	{
		playerSide = (playerSide == "X") ? "O" : "X";    // Note: Capital Letters for "X" and "O"
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	void GameOver (string winningPlayer)
	{
		if (winningPlayer == "draw") {
			SetGameOverText ("It's a draw!");
		} else {
			SetGameOverText(playerSide + " Wins!"); // Note the space after the first " and Wins!"
		}

		SetBoardInteractable(false);
		restartButton.SetActive(true);
	}

	public void RestartGame()
	{
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive(false);

		SetBoardInteractable (true);
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].text = "";
		}
		restartButton.SetActive(false);
	}

	void SetBoardInteractable(bool toggle) {
		Button btn;
		for (int i = 0; i < buttonList.Length; i++)
		{
			btn = buttonList [i].GetComponentInParent (typeof(Button)) as Button;
			btn.interactable = toggle;
		}
	}
}
