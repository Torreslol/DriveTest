using UnityEngine;
using System.Collections;

public class CheckModeUI : MonoBehaviour {
	public ModeSprite _chaosu;
	public ModeSprite _chaoyuan;
	public ModeSprite _chaozai;
	public ModeSprite _pilao;



	// Use this for initialization
	void Start () {

	
	}
	public void SelectChaoyuan()
	{
		_chaoyuan.OnHover(true);
		_chaosu.OnHover(false);
		_chaozai.OnHover(false);
		_pilao.OnHover(false);

	}
	public void Selectpilao()
	{
		_chaoyuan.OnHover(false);
		_chaosu.OnHover(false);
		_chaozai.OnHover(false);
		_pilao.OnHover(true);
		
	}
	public void SelectChaozai()
	{
		_chaoyuan.OnHover(false);
		_chaosu.OnHover(false);
		_chaozai.OnHover(true);
		_pilao.OnHover(false);
		
	}
	public void SelectChaosu()
	{
		_chaoyuan.OnHover(false);
		_chaosu.OnHover(true);
		_chaozai.OnHover(false);
		_pilao.OnHover(false);
		
	}
	public void Go()
	{
		switch(GameRunningData.instance._gameMode)
		{
		case Mode.overLoading:
			_chaozai.OnPress(true);
			break;
		case Mode.overMan:
			_chaoyuan.OnPress(true);
		break;	
		case Mode.overSpeed:
			_chaosu.OnPress(true);
		break;
		case Mode.overTime:
			_pilao.OnPress(true);
			break;




		}

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
