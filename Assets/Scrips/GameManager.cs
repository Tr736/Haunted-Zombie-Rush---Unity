using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject mainMenu;

	public static GameManager instance = null;
	private bool _playerActive = false;
	private bool _gameOver = false;
	private bool _gameStarted = false;
	public bool playerActive { 
		get {		
			return _playerActive;
			 }
	}

	public bool gameOver {  
		get { 
			return _gameOver;
		}
	}


	public bool gameStarted {
		get{ 
			return _gameStarted;
		}
	}


	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);

		}

		DontDestroyOnLoad (gameObject);


		Assert.IsNotNull (mainMenu);


	}

	public void PlayerCollided(){

		_gameOver = true;


	}

	public void PlayerStartedGame(){

		_playerActive = true;


	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterGame(){

		_gameStarted = true;
		mainMenu.SetActive ( false);
	}
}
