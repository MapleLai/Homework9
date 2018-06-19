using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Tank {
	public delegate void recycle(GameObject Tank);

	private Vector3 target;

	private bool gameover;

	void Start() {
		setHp(100f); 
		StartCoroutine(shoot());
	}

	void Update () {
		gameover = SceneController.getInstance().isGameOver();
		if (!gameover) {     
			if (getHp() <= 0 ) {
				this.gameObject.SetActive(false);
			} else {
				NavMeshAgent agent = GetComponent<NavMeshAgent>();
				target = SceneController.getInstance().getPlayerPosition(); 
				agent.SetDestination(target);
			}
		} else {
			NavMeshAgent agent = GetComponent<NavMeshAgent>();
			agent.velocity = Vector3.zero;
			agent.ResetPath();
		}

	}

	IEnumerator shoot() {
		while(!gameover) {
			for (float i = 2; i > 0; i -= Time.deltaTime) {
				yield return 0; 
			}
			if (Vector3.Distance(transform.position, target) < 20) {
				GameObject bullet = Factory.getInstance().getBullet(tankType.Enemy);
				bullet.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z) + transform.forward * 1.5f;
				bullet.transform.forward = transform.forward;
				bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
			}
		}
	}
}