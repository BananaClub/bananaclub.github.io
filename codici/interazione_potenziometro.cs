using UnityEngine;
using System.Collections;
using Uniduino;

public class Servo2 : MonoBehaviour {

	public Arduino arduino;

	public int pin = 0;
	public int pinValue;
	public float spinSpeed = 0.2f;

	private GameObject cube;

	void Start( )
	{
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);

		cube = GameObject.Find("Cube");
	}

	void ConfigurePins( )
	{
		arduino.pinMode(pin, PinMode.ANALOG);
		arduino.reportAnalog(pin, 1);
	}

	void Update () 
	{       
		pinValue = arduino.analogRead(pin);     
		cube.transform.rotation = Quaternion.Euler(0,pinValue*spinSpeed,0);     
	}
}
