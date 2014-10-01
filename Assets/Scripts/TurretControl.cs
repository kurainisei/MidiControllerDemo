using UnityEngine;
using System.Collections;



public class TurretControl : MonoBehaviour {

	public int turretID;
	public Color turretColor;
	
	public float rotationKnobValue {
		get {
			return MidiInput.GetKnob (_baseKnob+turretID);
		}
	}
	
	public float dimensionSliderValue {
		get {
			return MidiInput.GetKnob (_baseSlider+turretID);
		}
	} 

	public int[] energyButtonsId {
		get {
			return new int[] {_baseButton1+turretID, _baseButton2+turretID, _baseButton3+turretID};
		}
	}

	private int _baseKnob=16;
	private int _baseSlider=0;
	private int _baseButton1 = 64;
	private int _baseButton2 = 48;
	private int _baseButton3 = 32;

	private int _lives = 2;

	private MeshRenderer _turretMesh;

	private int[] _buttonValues = new int[] {1,1,1};


	void OnEnable()
	{
		_turretMesh = GetComponentInChildren<MeshRenderer>();
		_turretMesh.renderer.material.color = turretColor;
		_lives = 2;
	}

	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.AngleAxis (rotationKnobValue*360-180, Vector3.up);
		float scale = dimensionSliderValue.Remap(0,1,0.5f,1);
		transform.localScale = Vector3.one*scale;

		//set lives button if they have changed last frame
		//NOTE: for some reason Midi control change doesn't work in a one-time method it needs to be constantly updated.

		for (int i=0; i<energyButtonsId.Length; i++) {
			MidiOut.SendControlChange(MidiChannel.Ch1, energyButtonsId[i], _buttonValues[i]);
		}
	}


	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag=="Bullet")
		{
			_buttonValues[_lives] = 0;
			_lives --;
			if (_lives<0) {
				StartCoroutine(Death());
			}
		}
	}

	public void ButtonsOff() {
		for (int i=0; i<energyButtonsId.Length; i++) {
			_buttonValues[i]=0;
		}
	}

	public void ButtonsOn() {
		for (int i=0; i<energyButtonsId.Length; i++) {
			_buttonValues[i]=1;
		}
	}

	IEnumerator Death () {
		yield return 0;
		this.gameObject.SetActive(false);
	}
}
