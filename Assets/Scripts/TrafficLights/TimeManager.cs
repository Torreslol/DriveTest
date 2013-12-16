using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
	public float _baseTime;
	public TrafficLights[] _trafficLights1;
	public TrafficLights[] _trafficLights2;
	public float _timer;
	public float _greenTime;
	public float _blinkTime;
	public float _yellowTime;
	private float _redTime;

	// Use this for initialization
	void Start () {
		_redTime=_greenTime+_blinkTime+_yellowTime;
		_timer=-_baseTime;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate ()
	{
		_timer+=Time.fixedDeltaTime;
		if(_timer<_greenTime)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.ShowGreen();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.ShowRed();
			}

		}
		else if(_timer<_greenTime+_blinkTime)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.GreenBlink();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.ShowRed();
			}

		}
		else if(_timer<_greenTime+_blinkTime+_yellowTime)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.ShowYellow();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.ShowRed();
			}

		}
		else if(_timer<(_greenTime+_yellowTime)*2)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.ShowRed();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.ShowGreen();
			}

		}
		else if(_timer<(_greenTime+_yellowTime)*2+_blinkTime)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.ShowRed();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.GreenBlink();
			}

		}
		else if(_timer<(_greenTime+_yellowTime)*2+_blinkTime+_yellowTime)
		{
			foreach(TrafficLights t1 in _trafficLights1)
			{
				t1.ShowRed();
			}
			foreach(TrafficLights t2 in _trafficLights2)
			{
				t2.ShowYellow();
			}
			
		}
		else 
		{
			_timer=0;
		}

	}
}
