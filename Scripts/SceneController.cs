using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SceneController : MonoBehaviour, IUserAction {
	private static SceneController _instance;
	public GameObject player;
	private bool gameOver = false;
	private Factory factory;

	public static SceneController getInstance() {
		return _instance;
	}

	void Awake() {
		_instance = this;
		factory = Factory.getInstance();
		player = factory.getPlayer();
	}
	void Start () {
		for (int i = 0; i < 5; i++) {
			factory.getTank();
		}
		Player.destroyEvent += setGameOver;
	}

	void Update () {
		Camera.main.transform.position = new Vector3(player.transform.position.x, 15, player.transform.position.z);     
	}

	public Vector3 getPlayerPosition() {
		return player.transform.position;
	}

	public void Forward() {
		player.GetComponent<Rigidbody>().velocity = player.transform.forward * 35;
	}
	public void Back() {
		player.GetComponent<Rigidbody> ().velocity = player.transform.forward * -35;
	}
	public void turn(float offsetX) {
		player.transform.localEulerAngles = new Vector3 (player.transform.localEulerAngles.x, player.transform.localEulerAngles.y + offsetX * 2, 0);
	}   

	public void shoot() {
		GameObject bullet = factory.getBullet(tankType.Player);
		bullet.transform.position = new Vector3(player.transform.position.x, 1.5f, player.transform.position.z) + player.transform.forward * 1.5f;
		bullet.transform.forward = player.transform.forward;
		bullet.GetComponent<Rigidbody>().AddForce(player.transform.forward * 20, ForceMode.Impulse);
	}

	public bool isGameOver() {
		return gameOver;
	}

	public void setGameOver() {
		gameOver = true;
	}

}