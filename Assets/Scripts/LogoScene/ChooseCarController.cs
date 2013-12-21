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
	public GameObject _animation;
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
		if(base._panel==PanelType.selectCar)
		{
			_animation.SetActive(true);
			if(Reachability.instance._rec.lY<0)
			{
				StartGame();
			}
			if(Reachability.instance._rec.lRz<-20000)
			{
				Back();
			}
		}
		else
		{
			_animation.SetActive(false);
		}
	}
	public void Back()
	{
		GoBackground();
		base._panel=PanelType.selectMode;
		_logoView.GoForward();
		
	}
	public void StartGame()
	{
		if(!Application.isLoadingLevel)
		{
		base._panel=PanelType.none;
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
