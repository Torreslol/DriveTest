using UnityEngine;
using System.Collections;

public class Reachability : MonoBehaviour {
	public Reachability instance=null;
	public LogitechGSDK.LogiControllerPropertiesData _properties;
	public LogitechGSDK.DIJOYSTATE2ENGINES _rec;
	private bool _init;

	// Use this for initialization
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	void Start () {
		LogitechGSDK.LogiSteeringInitialize(false);//初始化控制器窗口
		if (LogitechGSDK.LogiIsConnected(0))
		{
			_properties.wheelRange = 900;
			_properties.forceEnable = true;
			_properties.overallGain = 80;
			_properties.springGain = 80;
			_properties.damperGain = 80;
			_properties.allowGameSettings = false;
			_properties.combinePedals = false;
			_properties.defaultSpringEnabled = true;
			_properties.defaultSpringGain = 80;
			LogitechGSDK.LogiSetPreferredControllerProperties(_properties);
		}
		_init = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))//检测是否连接
		{
			if (!_init)
			{
				
				if (!LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SPRING))
				{
					if (LogitechGSDK.LogiPlaySpringForce(0, 0, 40, 100))
					{
						_init = true;
						Debug.Log("init spring force success");
					}
				}
				else
				{
					LogitechGSDK.LogiStopSpringForce(0);
					Debug.Log("init spring force failed");

				}
				
				
			}
			else
			{
				Debug.Log("have init");
			}

			_rec = LogitechGSDK.LogiGetStateUnity(0);
	}
}
}
