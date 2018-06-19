using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tankType:int{Player, Enemy}

public class Factory : MonoBehaviour {
	private static Factory _instance;
	public GameObject player;
	public GameObject tank;
	public GameObject bullet;
	public ParticleSystem pS;

	private Dictionary<int, GameObject> Tanks;
	private Dictionary<int, GameObject> usingBullets;
	private Dictionary<int, GameObject> freeBullets;

	private List<ParticleSystem> psContainer;

	public static Factory getInstance() {
		return _instance;
	}

	void Awake() {
		_instance = this;
	}

	void Start() {
		Tanks = new Dictionary<int, GameObject>();
		usingBullets = new Dictionary<int, GameObject>();
		freeBullets = new Dictionary<int, GameObject>();
		psContainer = new List<ParticleSystem>();
	}

	public GameObject getPlayer() {
		return player;
	}

	public GameObject getTank() {
		GameObject newTank = Instantiate<GameObject>(tank);
		Tanks.Add(newTank.GetInstanceID(), newTank);
		newTank.transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
		return newTank;
	}   

	public GameObject getBullet(tankType type) {
		if (freeBullets.Count == 0) {
			GameObject newBullet = Instantiate(bullet);
			newBullet.GetComponent<Bullet>().setTankType(type);
			usingBullets.Add(newBullet.GetInstanceID(), newBullet);
			return newBullet;
		}
		foreach (KeyValuePair<int, GameObject> pair in freeBullets) {
			pair.Value.SetActive(true);
			pair.Value.GetComponent<Bullet>().setTankType(type);
			freeBullets.Remove(pair.Key);
			usingBullets.Add(pair.Key, pair.Value);
			return pair.Value;
		}
		return null;
	}

	public void recycleBullet(GameObject bullet) {
		usingBullets.Remove(bullet.GetInstanceID());
		freeBullets.Add(bullet.GetInstanceID(), bullet);
		bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		bullet.SetActive(false);
	}

	public ParticleSystem getPs() {
		for (int i = 0; i < psContainer.Count; i++) {
			if (!psContainer[i].isPlaying) {
				return psContainer[i];
			}
		}
		ParticleSystem newPs = Instantiate<ParticleSystem>(pS);
		psContainer.Add(newPs);
		return newPs;
	}

}