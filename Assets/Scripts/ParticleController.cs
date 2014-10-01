using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	// Update is called once per frame
	void LateUpdate () {
		if (!particleSystem.IsAlive()){
			gameObject.Recycle();
		}
	}
}
