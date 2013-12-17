using UnityEngine;
using System.Collections;

public class LogoViewController : UIController
{
		/// <summary>
		/// The _choose view.
		/// </summary>
		public ChooseCarController _chooseView;
		public Vector3 forwardPosition;
		public Vector3 backgroundPosition;
	public UIImageButton _chaosu;


		// Use this for initialization
		void Start ()
		{
				_forwardPosition = forwardPosition;
				_backgroundPosition = backgroundPosition;
		        transform.localPosition=forwardPosition;
		_chaosu.OnHover(true);
		 

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		/// <summary>
		/// Selects the over speed.
		/// </summary>
		/// <returns>The over speed.</returns>
		/// <param name="go">Go.</param>
		public void SelectOverSpeed (GameObject go)
		{
				
				
				switch (go.name) 
		       {
				case "Image Button-chaoyuan":
			GameRunningData.instance._gameMode=Mode.overMan;
						break;
				case "Image Button-pilao":
			GameRunningData.instance._gameMode=Mode.overTime;			
						break;
				case "Image Button-chaosu":
			GameRunningData.instance._gameMode=Mode.overSpeed;
						break;
				case "Image Button-chaozai":
			GameRunningData.instance._gameMode=Mode.overLoading;
						break;
				}
				GoBackground (); 
		        _chooseView.Reload();
		        _chooseView.GoForward ();
		}


}
