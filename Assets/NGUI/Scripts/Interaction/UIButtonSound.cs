//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Sound")]
public class UIButtonSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
	}

	public AudioClip _hover;
	public AudioClip _press;
	public AudioClip audioClip;
	public Trigger trigger;
	public float volume = 1f;
	public float pitch = 1f;

	public void OnHover (bool isOver)
	{
		if (enabled && isOver)
		{
			NGUITools.PlaySound(_hover, volume, pitch);
		}
	}

	public void OnPress (bool isPressed)
	{
		if (enabled && isPressed )
		{
			NGUITools.PlaySound(_press, volume, pitch);
		}
	}

   public	void OnClick ()
	{
		if (enabled && trigger == Trigger.OnClick)
		{
			NGUITools.PlaySound(audioClip, volume, pitch);
		}
	}
}