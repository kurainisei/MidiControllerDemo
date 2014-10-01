using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public ExplosionManager explosion;
	private Transform _bulletBody;
	// Use this for initialization
	void OnEnable () {
		_bulletBody = transform.Find("bullet/Body");
	}

	public void initialize (float scale, float speed, Color bulletColor)
	{
		_bulletBody.renderer.material.color = bulletColor;
		transform.localScale = Vector3.one*scale;
		rigidbody.velocity = transform.forward*speed;
		StartCoroutine(TimeToLive(Random.Range(4.0f*scale, 8.0f*scale)));
	}

	void Update () {
	}

	void OnCollisionEnter (Collision collision) {
		Explode();
	}

	IEnumerator TimeToLive(float time) {
		for (float timer=0; timer<= time; timer+=Time.deltaTime) {
			yield return 0;
		}
		this.Recycle();
	}

	void Explode() {
		explosion.ExplodeBullet(transform.position);
		this.Recycle();
	}
}
