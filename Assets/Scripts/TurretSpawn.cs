using UnityEngine;
using System.Collections;

public class TurretSpawn : MonoBehaviour {
	private TurretControl _turret;
	// Use this for initialization
	void Awake () {
		_turret = GetComponentInChildren<TurretControl>();
	}
	
	public void EnableTurret() {
		_turret.gameObject.SetActive(true);
	}
}
