using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tank : MonoBehaviour {
	private float Hp;

	public float getHp() {
		return Hp;
	}

	public void setHp(float hp) {
		this.Hp = hp; 
	}

}