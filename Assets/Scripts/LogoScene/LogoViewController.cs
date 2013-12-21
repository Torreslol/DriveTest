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
	    private int i=0; 
	    public  CheckModeUI _checkModeUI;
	    public  GameObject _animation;



		// Use this for initialization
		void Start ()
		{
				_forwardPosition = forwardPosition;
				_backgroundPosition = backgroundPosition;
		        transform.localPosition=forwardPosition;
		       
		 

		}
	
		// Update is called once per frame
		void Update ()
		{
		if(base._panel==PanelType.selectMode)
		{
		    _animation.SetActive(true);
		 
			i=CheckWhichButtonShown(Reachability.instance._rec.lX);
			if(Reachability.instance._rec.lY<0)
			{
				switch(i)
				{
				case 0:
					break;
				case 1:
					SelectOverSpeed(Mode.overSpeed);
					break;
				case 2:
					SelectOverSpeed(Mode.overMan);
					break;
				case 3:
					SelectOverSpeed(Mode.overTime);
					break;
				case 4:
					SelectOverSpeed(Mode.overLoading);
					break;

				}
			}
		}
		else
		{
			_animation.SetActive(false);
		}
	
		}
			public int CheckWhichButtonShown(int lx){
				float max = 32767.0f;
				float piece = max / 10.0f;
				
				if(lx > -max && lx <= -max + piece)
					return 1;
				else if(lx > -max + piece && lx <= -max+3*piece)
					return 2;
				else if(lx > -max + 3*piece && lx <= -max+5*piece)
					return 3;
				else if(lx > -max + 5*piece && lx <= -max+7*piece)
					return 4;
				else if(lx > -max + 7*piece && lx <= -max+9*piece)
					return 1;
				else if(lx > -max + 9*piece && lx <= -max+11*piece)
					return 2;
				else if(lx > -max + 11*piece && lx <= -max+13*piece)
					return 3;
				else if(lx > -max + 13*piece && lx <= -max+15*piece)
					return 4;
				else if(lx > -max + 15*piece && lx <= -max+17*piece)
					return 1;
				else if(lx > -max + 17*piece && lx <= -max+19*piece)
					return 2;
				else if(lx > -max + 19*piece && lx <= -max+20*piece)
					return 3;
		        else
			return 1;
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
		default:
				break;
				
				}
				 GoBackground (); 
		         base._panel=PanelType.selectCar;
		        _chooseView.Reload();
		        _chooseView.GoForward ();
		}


}
