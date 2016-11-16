using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    Vector2 m_screenPos = new Vector2();
    public Text touch;
    public Text move;
    public Text pichup;
    public Text twoFinger;
    private int _touchTime = 0;
    private int _moveTime = 0;
    private int _pickupTime = 0;
    private int _twoFingerTime = 0;
    // Use this for initialization
    void Start () {
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //判斷平台
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
        MobileInput ();
#else
        DeskopInput();
#endif
    }

    public void DeskopInput()
    {
        //紀錄滑鼠左鍵的移動距離
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        float speed = 6.0f;
        if (mx != 0 || my != 0)
        {
            //滑鼠左鍵
            if (Input.GetMouseButton(0))
            {
                _moveTime++;
                move.text = _moveTime.ToString();
            }
        }

        if (Input.GetMouseButton(0))
        {
            _touchTime++;
            touch.text = _touchTime.ToString();
        }
    }

    public void MobileInput()
    {
        if (Input.touchCount <= 0)
            return;

        //1個手指觸碰螢幕
        if (Input.touchCount == 1)
        {
            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _touchTime++;
                touch.text = _touchTime.ToString();
                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                _moveTime++;
                move.text = _moveTime.ToString();
            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _pickupTime++;
                pichup.text = _pickupTime.ToString();
            }
            //攝影機縮放，如果1個手指以上觸碰螢幕
        }
        else if (Input.touchCount > 1)
        {
            _twoFingerTime++;
            twoFinger.text = _twoFingerTime.ToString();
        }//end else if 
    }//end void
}
