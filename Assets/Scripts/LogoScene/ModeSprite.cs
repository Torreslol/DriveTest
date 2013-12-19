using UnityEngine;
using System.Collections;

public class ModeSprite : MonoBehaviour {
	public string _normal;
	public string _highlighted;
	private UIButtonSound _buttonSound;
	private UIButtonScale  _buttonScale;
	private UISprite _sprite;

	// Use this for initialization
	void Start () {
		_buttonScale=gameObject.GetComponentInChildren<UIButtonScale>();
		_buttonSound=gameObject.GetComponentInChildren<UIButtonSound>();
		_sprite=gameObject.GetComponentInChildren<UISprite>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnHover(bool over)
	{
		if(over)
		{
		_sprite.spriteName=_highlighted;
		_buttonSound.OnHover(true);
		_buttonScale.OnHover(true);
		}
		else
		{
			_sprite.spriteName=_normal;
			_buttonSound.OnHover(false);
			_buttonScale.OnHover(false);
		}


	}
	public void OnPress(bool over)
	{
		if(over)
		{
		_sprite.spriteName=_highlighted;
		_buttonScale.OnPress(true);
		_buttonSound.OnPress(true);
		}
		else
		{
			_buttonScale.OnPress(false);
			_buttonSound.OnPress(false);
		}

	}
	public void Normal(bool over)
	{
		_sprite.spriteName=_normal;
		_buttonScale.OnHover(false);

	}
}
