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
		public void SelectOverSpeed (Mode gameMode)
		{
				
				
				switch (gameMode) 
		       {
		case Mode.overMan:
			GameRunningData.instance._gameMode=Mode.overMan;

						break;
		case Mode.overTime:
			GameRunningData.instance._gameMode=Mode.overTime;			
						break;
		case Mode.overSpeed:
			GameRunningData.instance._gameMode=Mode.overSpeed;
						break;
		case Mode.overLoading:
			GameRunningData.instance._gameMode=Mode.overLoading;
						break;
				}
				 GoBackground (); 
		         base._panel=PanelType.selectCar;
		        _chooseView.Reload();
		        _chooseView.GoForward ();
		}


}
