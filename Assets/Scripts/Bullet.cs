using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

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
		StartCoroutine(TimeToLive());
	}

	void OnCollisionEnter (Collision collision) {
		this.Recycle();
	}

	IEnumerator TimeToLive() {
		for (float timer=0; timer<=15; timer+=Time.deltaTime) {
			yield return 0;
		}
		this.Recycle();
	}
}
