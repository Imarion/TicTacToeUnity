﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameController gameController;

	public void SetGameControllerReference (GameController controller)
	{
		gameController = controller;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSpace ()
	{
		buttonText.text = gameController.GetPlayerSide();
		button.interactable = false;
		gameController.EndTurn();
	}
}
