using UnityEngine;
using UnityEngine.Events;
namespace Eloi.ThreePoints
{
    [System.Serializable]
        public class ThreePoints_TargetPinchEvents : ThreePoints_PinchEvents
{



        public Transform m_targetToPush;
        public UnityEvent<Vector3> m_onEnterPinchPushTarget;
        public UnityEvent<Vector3> m_onExitPinchPushTarget;


        public void OnEnable()
        {
            m_onEnterPinch.AddListener(OnEnterPinchPushTarget);
            m_onExitPinch.AddListener(OnExitPinchPushTarget);
        }
        public void OnDisable()
        {
            m_onEnterPinch.RemoveListener(OnEnterPinchPushTarget);
            m_onExitPinch.RemoveListener(OnExitPinchPushTarget);
        }
        private void OnExitPinchPushTarget()
        {
            m_onExitPinchPushTarget?.Invoke(GetTargetPoint());
        }

        private Vector3 GetTargetPoint()
        {
            if (m_targetToPush == null)
                return GetPoint();
            return m_targetToPush.position;
        }

        private void OnEnterPinchPushTarget()
        {
            m_onEnterPinchPushTarget?.Invoke(GetTargetPoint());
        }
    }

}