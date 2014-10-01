using UnityEngine;
using System.Collections;

public class OctagonController : MonoBehaviour {
	private AutoRotate _rotator;
	private float _currentRotSpeed;
	private float _newRotSpeed;
	private int[] _rotationSpeeds = new int[] {30, 20, 10, -10, -20, -30};

	// Use this for initialization
	void Start () {
		_rotator = GetComponent<AutoRotate>();
		StartCoroutine (TimedRotation(5));	
	}

	void changeRotSpeed (float speed) {
		_rotator.rotation = new Vector3 (0,speed,0);
	}

	IEnumerator TimedRotation (float rotationTime) {
		for (float i=0; i<=rotationTime; i+=Time.deltaTime)
		{
			yield return 0;
		}

		changeRotSpeed (_rotationSpeeds[Random.Range(0, _rotationSpeeds.Length-1)]);
		StartCoroutine (TimedRotation(Random.Range(2,5)));
	}
}
