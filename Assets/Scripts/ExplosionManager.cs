using UnityEngine;
using System.Collections;

public class ExplosionManager : MonoBehaviour {
	public ParticleSystem bulletExplosion;
	// Use this for initialization
	void Start () {
		bulletExplosion.CreatePool(10);
	}
	
	public void ExplodeBullet (Vector3 position) {
		ParticleSystem instance = bulletExplosion.Spawn(position, Quaternion.identity);
		instance.Play();
	}
}
