using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float explosionRadius = 3f;
	private tankType type;

	public void setTankType(tankType _type) {
		type = _type;
	}

	void OnCollisionEnter(Collision other) {
		ParticleSystem explosion = Factory.getInstance().getPs();
		explosion.transform.position = transform.position;
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].tag == "Player" && this.type == tankType.Enemy || colliders[i].tag == "Enemy" && this.type == tankType.Player) {
				float Hp = colliders[i].GetComponent<Tank>().getHp();
				float damage = 100f / (Vector3.Distance(colliders[i].transform.position, transform.position));
				colliders[i].GetComponent<Tank>().setHp(Hp - damage);
			}
		}
		explosion.Play();
		if (this.gameObject.activeSelf) {
			Factory.getInstance().recycleBullet(this.gameObject);
		}
	}

}