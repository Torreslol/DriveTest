using UnityEngine;
using System.Collections;


public class UIController : MonoBehaviour {
	protected Vector3 _forwardPosition;
	protected Vector3 _backgroundPosition;
	protected PanelType _panel=PanelType.selectMode;



	// Use this for initialization
	void Start () {
		_forwardPosition=new Vector3(0,transform.localPosition.y,transform.localPosition.z);
		_backgroundPosition=new Vector3(2000,transform.localPosition.y,transform.localPosition.z);
		_panel=PanelType.selectMode;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GoForward()
	{
		transform.localPosition=_forwardPosition;
	}
	public void GoBackground()
	{
	transform.localPosition=_backgroundPosition;
	}

}
