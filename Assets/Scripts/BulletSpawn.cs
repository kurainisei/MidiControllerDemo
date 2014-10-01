using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {
	public Bullet bullet;
	public float bulletRate;
	private TurretControl _turretControl;
	// Use this for initialization
	void OnEnable () {
		bullet.CreatePool(10);
		InvokeRepeating("LaunchProjectile", 3, bulletRate);
		_turretControl = GetComponentInParent<TurretControl>();
	}
	

	void LaunchProjectile () {
		Bullet instance = bullet.Spawn(transform.position,transform.rotation);
		instance.initialize(transform.parent.localScale.x, _turretControl.dimensionSliderValue.Remap (0,1,5,3), _turretControl.turretColor);
		Physics.IgnoreCollision(instance.collider, transform.parent.collider);
	}

	void OnDisable() {
		CancelInvoke("LaunchProjectile");
	}
			
}
