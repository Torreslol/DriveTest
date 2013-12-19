using UnityEngine;
using System.Collections;

public class WheelAnimation : MonoBehaviour {
	public bool ActivateWait = false;
	
	float fireRate = 0.2f;
	int i = 0;
	float nextFire;
	public string[] ActivatorTexture = new string[] {};    

	void Awake()
	{
		this.GetComponent<UISprite>().enabled = false;
	}
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (ActivateWait)
		{
			this.GetComponent<UISprite>().enabled = true;
			if (i < ActivatorTexture.Length)
			{
				if (Time.time > nextFire)
				{
					nextFire = Time.time + fireRate;
					this.GetComponent<UISprite>().spriteName= ActivatorTexture[i];
					i++;
				}
			}
			else
			{
				i = 0;
			}
		}
		else
		{
			this.GetComponent<UISprite>().enabled = false;
		}
	}
}
