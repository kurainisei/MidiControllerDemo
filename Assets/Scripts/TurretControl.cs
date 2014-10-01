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
	private int _baseButton1 = 32;
	private int _baseButton2 = 48;
	private int _baseButton3 = 64;

	private MeshRenderer _turretMesh;

	void Start()
	{
		_turretMesh = GetComponentInChildren<MeshRenderer>();
		_turretMesh.renderer.material.color = turretColor;
		ButtonsOn();
	}

	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.AngleAxis (rotationKnobValue*360-180, Vector3.up);
		float scale = dimensionSliderValue.Remap(0,1,0.5f,1);
		transform.localScale = Vector3.one*scale;

	}

	public void ButtonsOff() {
		foreach (int button in energyButtonsId) {
			MidiOut.SendControlChange(MidiChannel.Ch1, button, 0);
		}
	}

	public void ButtonsOn() {
		foreach (int button in energyButtonsId) {
			MidiOut.SendControlChange(MidiChannel.Ch1, button, 1);
		}
	}
}
