using UnityEngine;
using System.Collections;

public class GameUIController : MonoBehaviour {
	public UISprite _modeSprite;
	public UISprite _numberSprite;
	public UISprite _indicatorRPM;
	public UISprite _indicatorVelo;

	// Use this for initialization
	void Start () {
		Mode gameMode=GameRunningData.instance._gameMode;
		switch (gameMode)
		{
		case Mode.overLoading:
			_modeSprite.spriteName="2-overloading";
			break;
		case Mode.overMan:
			_modeSprite.spriteName="2-overman";
			break;
		case Mode.overSpeed:
			_modeSprite.spriteName="2-overspeed";
			break;
		case Mode.overTime:
			_modeSprite.spriteName="2-overtime";
			break;
		
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
