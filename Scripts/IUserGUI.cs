using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUserGUI : MonoBehaviour {
	IUserAction action;
	void Start () {
		action = SceneController.getInstance() as IUserAction;  
	}
		
	void Update () {
		if (!action.isGameOver()) {
			if (Input.GetKey(KeyCode.W)) {
				action.Forward();
			}

			if (Input.GetKey(KeyCode.S)) {
				action.Back();
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				action.shoot(); 
			}

			float offsetX = Input.GetAxis ("Horizontal1");
			action.turn(offsetX);
		}
	}
}