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
		Debug.Log("game mode"+gameMode);
		switch (gameMode)
		{
		case Mode.overLoading:
			_modeSprite.spriteName="2-overloading";
			_numberSprite.spriteName="2-mass";
			break;
		case Mode.overMan:
			_modeSprite.spriteName="2-overman";
			_numberSprite.spriteName="2-number";
			break;
		case Mode.overSpeed:
			_modeSprite.spriteName="2-overspeed";
			_numberSprite.spriteName="2-limitvelo";
			break;
		case Mode.overTime:
			_modeSprite.spriteName="2-overtime";
			_numberSprite.spriteName="2-h";
			break;
		
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
