using UnityEngine;
using System.Collections;

public class TrafficLights : MonoBehaviour {
//	public GameObject _redLight;
//	public GameObject _yellowLight;
//	public GameObject _greenLight;
	public Material _red;
	public Material _yellow;
	public Material _green;

	private bool _blink; 
	private Material _blinkMaterial;
	private float _blinkTime=0.5f;
	private bool _show=true;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}
	void FixedUpdate ()
	{

		if (_blink)
		{
			_blinkTime-=Time.fixedDeltaTime;

			if(_blinkTime<=0)
			{
				_blinkTime=0.5f;
			  if(_show)
			  {
			    _show=false;
				_blinkMaterial.color=Color.gray;
			  }
			  else
			  {
				_show=true;
				_blinkMaterial.color=Color.green;

			  }
			}
		
		}



	}
	public void ShowRed()
	{
		_blink=false;
		_red.color=Color.red;
		_green.color=Color.gray;
		_yellow.color=Color.gray;

	}
	public void ShowGreen()
	{
		_blink=false;
		_green.color=Color.green;
		_red.color=Color.gray;
		_yellow.color=Color.gray;

	}
	public void ShowYellow()
	{
		_blink=false;
		_yellow.color=Color.yellow;
		_red.color=Color.gray;
		_green.color=Color.gray;

	}

	public void GreenBlink()
	{
		_blink=true;
		_blinkMaterial=_green;
	
	}
}
