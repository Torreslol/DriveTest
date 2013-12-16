using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Drivetrain))]

public class LogiControl: MonoBehaviour {
    public Transform _centerOfMass;//汽车重心
    public Wheel[] _wheels;//车轮数组


    float _brake;//刹车
    float _throttle;//油门
    float _throttleInput;//油门输入
    float _steering;//转向（-1到1）
    float _clutch;//离合器 
    Drivetrain _drivetrain;//驱动管理器实例 
    bool _init=false;
    
    public float _inertiaFactor = 1.5f;
    LogitechGSDK.LogiControllerPropertiesData _properties;//初始化数据

    public float slipVelo
    {
        get
        {
            float val = 0.0f;
            foreach (Wheel w in _wheels)
                val += w.slipVelo / _wheels.Length;
            return val;
        }
    }
	// Use this for initialization
    void Start()
    {
        //重心初始化
        if (_centerOfMass != null)
        {
            rigidbody.centerOfMass = _centerOfMass.localPosition;
            rigidbody.inertiaTensor *= _inertiaFactor;
        }
        _drivetrain = GetComponent(typeof(Drivetrain)) as Drivetrain;
        LogitechGSDK.LogiSteeringInitialize(false);//初始化控制器窗口
        if (LogitechGSDK.LogiIsConnected(0))
        {
            _properties.wheelRange = 900;
            _properties.forceEnable = true;
            _properties.overallGain = 80;
            _properties.springGain = 80;
            _properties.damperGain = 80;
            _properties.allowGameSettings = false;
            _properties.combinePedals = false;
            _properties.defaultSpringEnabled = true;
            _properties.defaultSpringGain = 80;
            LogitechGSDK.LogiSetPreferredControllerProperties(_properties);
        }
        _init = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))//检测是否连接
        {
            if (!_init)
            {
 
                if (!LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SPRING))
                {
                    if (LogitechGSDK.LogiPlaySpringForce(0, 0, 40, 100))
                    {
                        _init = true;
                        Debug.Log("success");
                    }
                }
                else
                {
                    LogitechGSDK.LogiStopSpringForce(0);
                    Debug.Log("stop");
                }
                
                
            }
            else
            {
                Debug.Log("init=true");
            }
    

            //更新 
            Debug.Log("Index 0 Current Device Name==" + LogitechGSDK.LogiSteeringGetFriendlyProductName(0));
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);//控制器状态
            float f = rec.lX;
            _steering= Mathf.Clamp(f/32767,-1,1);//x轴
            float f1 = rec.lY;
            _throttle = Mathf.Clamp(Mathf.Abs((f1 / 32767-1)/2), 0, 1);
            _drivetrain.throttle = _throttle;//手动档油门
            _drivetrain.throttleInput = _throttleInput;//自动挡油门

            float f2 = rec.lRz;
            _brake = Mathf.Clamp(Mathf.Abs((f2 / 32767 - 1) / 2), 0, 1);//刹车

            _clutch = rec.rglSlider[1];//离合器数值
            if (_clutch <= -32000)
            {
                if (Input.GetButton("Gear1"))
                {
                    _drivetrain.gear = 2;
                    Debug.Log("gear1");
                }
                else if (Input.GetButton("Gear2"))
                {
                    _drivetrain.gear = 3;
                    Debug.Log("gear2");
                }
                else if (Input.GetButton("Gear3"))
                {
                    _drivetrain.gear = 4;
                }
                else if (Input.GetButton("Gear4"))
                {
                    _drivetrain.gear = 5;
                }
                else if (Input.GetButton("Gear5"))
                {
                    _drivetrain.gear = 6;
                }
                else if (Input.GetButton("Gear6"))
                {
                    _drivetrain.gear = 0;
                }
            
            }

            //播放侧面碰撞力    LogitechGSDK.LogiPlaySideCollisionForce(0, 10);
            //播放颠簸的路的效果   LogitechGSDK.LogiPlayBumpyRoadEffect(0, 10);
            //检测有无按钮按下 支持128个
    /*       for (int i=0;i<128;i++)
            {
                if (rec.rgbButtons[i] == 128)
                {
                    Debug.Log("button of  index" + i.ToString() + "is pressed");
                }
            }
       */     
            foreach (Wheel w in _wheels)
            {
                w.brake = _brake;
                w.steering = _steering;
            }
          
        }
        else//设备连接不成功
        {
            Debug.LogError("Index 0 No Device Connected");
        }
        
	
	
	}

    void OnGUI()
    {
         LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);//控制器状态
      
        GUI.Label(new Rect(0, 100, 400, 200), "steer=: " +_steering.ToString() );
        GUI.Label(new Rect(0, 120, 400, 200), "brake=: " + _brake.ToString());
        GUI.Label(new Rect(0, 140, 400, 200), "throttle=: " + _throttle.ToString());
        GUI.Label(new Rect(0, 160, 400, 200), "km/h: " + rigidbody.velocity.magnitude * 3.6f);
       
    }
}
