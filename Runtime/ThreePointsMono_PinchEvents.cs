using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.ThreePoints
{
    public class ThreePointsMono_PinchEvents : MonoBehaviour
    {
        public ThreePoints_PinchEvents m_data;

        public void Update()
        {
            m_data.Update();
        }
    }

    [System.Serializable]
        public class ThreePoints_PinchEvents  {

        
    public Transform m_fingerTipA;
    public Transform m_fingerTipB;

    public bool m_isPinching = false;
    public float m_pinchDistance = 0.02f;

    [Header("Debug")]
    public float m_currentDistance = 0.0f;

    public UnityEvent m_onEnterPinch;
    public UnityEvent m_onExitPinch;

    public UnityEvent<Vector3> m_onEnterPinchPushCenter
            ;
    public UnityEvent<Vector3> m_onExitPinchPushCenter;



    public void Update()
    {
        if (m_fingerTipA == null || m_fingerTipB == null)
            return;

        m_currentDistance = Vector3.Distance(m_fingerTipA.position, m_fingerTipB.position);
        if (m_currentDistance < 0.0001f)
                return;

        bool isPinching = Mathf.Abs(m_currentDistance ) < m_pinchDistance;
        if (isPinching != m_isPinching ) {
            m_isPinching = isPinching;
            if (isPinching)
            {
                m_onEnterPinch.Invoke();
                m_onEnterPinchPushCenter.Invoke(GetPoint());
            }
            else { 
                m_onExitPinch.Invoke();
                m_onExitPinchPushCenter.Invoke(GetPoint());
            }
        }
    }

    public Vector3 GetPoint() { 
        return (m_fingerTipA.position + m_fingerTipB.position) / 2;
    }

}

}