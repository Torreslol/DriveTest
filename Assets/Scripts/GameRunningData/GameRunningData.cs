using UnityEngine;
using System.Collections;
public enum Mode
{
	overSpeed,
	overMan,
	overLoading,
	overTime
	
};
public enum CarType
{
	none=0,
	car,
	truck,
	bus,
	schoolBus
	
};
public enum PanelType
{
	selectMode=0,
	selectCar

};

public class GameRunningData : MonoBehaviour {
	public static GameRunningData instance = null; //单键

	public Mode _gameMode;
	public CarType _carType;

	// Use this for initialization
	void Start () {
	
	}
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
