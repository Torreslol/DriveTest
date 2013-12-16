using UnityEngine;
using System.Collections;

public class ChooseCarController : UIController {
	public LogoViewController _logoView;
	public Vector3 forwardPosition;
	public Vector3 backgroundPosition;
	public CheckBoxState[] _checkBoxList;
	public Transform _panelDraggable;
	// Use this for initialization
	void Start ()//
	{
		_forwardPosition=forwardPosition;
		_backgroundPosition=backgroundPosition;
		transform.localPosition=backgroundPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
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
		 foreach(CheckBoxState c in _checkBoxList)
		{
			c.Reload(GameRunningData.instance._gameMode);
		}

	}


}
