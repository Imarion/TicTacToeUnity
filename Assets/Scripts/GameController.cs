using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerColor {
	public Color panelColor;
	public Color textColor;
}

[System.Serializable]
public class Player {
	public Image panel;
	public Text text;
	public Button button;
}

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;

	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public GameObject startInfo;

	private string playerSide;
	private int moveCount;

	void Awake ()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons();
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

	public void SetStartingSide (string startingSide)
	{
		playerSide = startingSide;
		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		} 
		else
		{
			SetPlayerColors(playerO, playerX);
		}

		StartGame ();
	}

	public void EndTurn ()
	{
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (moveCount >= 9) {
			GameOver ("draw");
		} else {
			ChangeSides ();
		}
	}

	void ChangeSides ()
	{
		playerSide = (playerSide == "X") ? "O" : "X";    // Note: Capital Letters for "X" and "O"

		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		} 
		else
		{
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	void GameOver (string winningPlayer)
	{
		if (winningPlayer == "draw") {
			SetPlayerColorsInactive();
			SetGameOverText ("It's a draw!");
		} else {
			SetGameOverText(playerSide + " Wins!"); // Note the space after the first " and Wins!"
		}

		SetBoardInteractable(false);
		restartButton.SetActive(true);
	}

	void StartGame() {
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		startInfo.SetActive(false);
	}

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);

		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].text = "";
		}
		restartButton.SetActive(false);
		SetPlayerButtons (true);
		SetPlayerColorsInactive ();
		startInfo.SetActive(true);
	}

	void SetBoardInteractable(bool toggle) {
		Button btn;
		for (int i = 0; i < buttonList.Length; i++)
		{
			btn = buttonList [i].GetComponentInParent (typeof(Button)) as Button;
			btn.interactable = toggle;
		}
	}

	void SetPlayerColors (Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void SetPlayerButtons (bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;  
	}

	void SetPlayerColorsInactive ()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}
}
