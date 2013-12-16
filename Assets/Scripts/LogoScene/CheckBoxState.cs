using UnityEngine;
using System.Collections;

public class CheckBoxState : MonoBehaviour {
	public UISprite _lockSprite;
	private UICheckbox _checkBox;
	// Use this for initialization
	void Start () {

		_checkBox=gameObject.GetComponentInChildren<UICheckbox>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnActivate()
	{
		string name=gameObject.name;
		if(_checkBox.isChecked)
		{
			switch(name)
			{
			case"Checkbox-bus":
					GameRunningData.instance._carType=CarType.bus;
					break;
			case"Checkbox-minibus":
					GameRunningData.instance._carType=CarType.miniBus;
				break;
			case"Checkbox-schoolbus":
					GameRunningData.instance._carType=CarType.schoolBus;
				break;
			case"Checkbox-truck":
					GameRunningData.instance._carType=CarType.truck;
				break;
			case"Checkbox-car":
					GameRunningData.instance._carType=CarType.car;
				break;
				
				
			}
		}
	}
	public void Reload(Mode gameMode)
	{
		switch(gameMode)
		{

		case Mode.overSpeed:
		{
			if(gameObject.name=="Checkbox-car"||gameObject.name=="Checkbox-bus"||gameObject.name=="Checkbox-truck")
			{
				_lockSprite.enabled=false;
				_checkBox.enabled=true;

			}
			else
			{
				_lockSprite.enabled=true;
				_checkBox.enabled=false;
			}
		}
			break;
		case Mode.overMan:
		{
			if(gameObject.name=="Checkbox-car"||gameObject.name=="Checkbox-bus"||gameObject.name=="Checkbox-minibus"||gameObject.name=="Checkbox-schoolbus")
			{
				_lockSprite.enabled=false;
				_checkBox.enabled=true;
				
			}
			else
			{
				_lockSprite.enabled=true;
				_checkBox.enabled=false;
			}
		}
			break;
		case Mode.overLoading:
		{
			if(gameObject.name=="Checkbox-truck")
			{
				_lockSprite.enabled=false;
				_checkBox.enabled=true;
				
			}
			else
			{
				_lockSprite.enabled=true;
				_checkBox.enabled=false;
			}

		}
			break;
		case Mode.overTime:
		{
		
				_lockSprite.enabled=false;
				_checkBox.enabled=true;
				
	
			break;
		}
    
		}


	}
}
