//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps sprites.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button")]
public class UIImageButton : MonoBehaviour
{
	public UISprite target;
	public string normalSprite;
	public string hoverSprite;
	public string pressedSprite;
	public UIButtonScale _buttonScle;
	public UIButtonSound _buttonSound;

	void OnEnable ()
	{
		if (target != null)
		{
			target.spriteName = UICamera.IsHighlighted(gameObject) ? hoverSprite : normalSprite;
		}
	}

	void Start ()
	{
		if (target == null) target = GetComponentInChildren<UISprite>();
		_buttonScle=gameObject.GetComponentInChildren<UIButtonScale>();
		_buttonSound=gameObject.GetComponentInChildren<UIButtonSound>();
	}

	public void OnHover (bool isOver)
	{
		if (enabled && target != null)
		{
			target.spriteName = isOver ? hoverSprite : normalSprite;
			target.MakePixelPerfect();
			_buttonScle.OnHover(true);
			_buttonSound.OnPress(true);
		}
	}

	public void OnPress (bool pressed)
	{
		if (enabled && target != null)
		{
			target.spriteName = pressed ? pressedSprite : normalSprite;
			target.MakePixelPerfect();
			_buttonScle.OnPress(true);
			_buttonSound.OnPress(true);
		}
	}
}