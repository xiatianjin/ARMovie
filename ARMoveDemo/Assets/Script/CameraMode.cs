using UnityEngine;
using System.Collections;

/*
 最近有人一直在问高通实现相机对焦问题，我把项目中用到的脚本放在这里，仅供大家参考，互相学习！
代码如下，附件中有脚本（Unity下实现）
本脚本直接拖放到场景中一直处于激活状态对象上即可，当在移动端触屏即可实现相机对焦，Unity Editor下点击鼠标左键实现对焦*/
public class CameraMode : MonoBehaviour
{
    public static bool m_bIsFocus;

    // Use this for initialization
    void Start()
    {
        
        m_bIsFocus = false;
      Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_bIsFocus)
#if UNITY_EDITOR
        if(Input.GetMouseButtonUp(0))
#elif UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#endif
        {
           Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}