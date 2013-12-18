using UnityEngine;
using System.Collections;

public class ChooseCarController : UIController {
	public LogoViewController _logoView;
	public Vector3 forwardPosition;
	public Vector3 backgroundPosition;
	public CheckBoxState _car;
	public CheckBoxState _schoolbus;
	public CheckBoxState _passengerbus;
	public CheckBoxState _truck;
	public Transform _panelDraggable;
	// Use this for initialization
	void Start ()
	{
		_forwardPosition=forwardPosition;
		_backgroundPosition=backgroundPosition;
		transform.localPosition=backgroundPosition;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButton("Car"))
		{
			_car._checkBox.isChecked=true;
		}
		if(Input.GetButton("PassengerBus"))
		{
			_passengerbus._checkBox.isChecked=true;
		}
		if(Input.GetButton("Truck"))
		{

			_truck._checkBox.isChecked=true;
		}
		if(Input.GetButton("SchoolBus"))
		{
			_schoolbus._checkBox.isChecked=true;
		}
	
	}
	public void Back()
	{
		GoBackground();
		_logoView.GoForward();
		
	}
	public void StartGame()
	{
		if(!Application.isLoadingLevel)
		{
		Application.LoadLevel("MainScene");
		}
	}
	public void Reload()
	{
		_panelDraggable.localPosition=Vector3.zero;

		_car.Reload(GameRunningData.instance._gameMode);
		_schoolbus.Reload(GameRunningData.instance._gameMode);
		_passengerbus.Reload(GameRunningData.instance._gameMode);
		_truck.Reload(GameRunningData.instance._gameMode);
		

	}


}
