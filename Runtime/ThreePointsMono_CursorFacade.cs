using Eloi.ThreePoints;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{

    public class ThreePointsMono_CursorFacade : MonoBehaviour
    {
        public Transform m_trackedPoints;
        public ThreePoints_PointsQueue m_stackPoints;
        public ThreePointsTriangleDefault m_currentTriangle;
        public UnityEvent<I_ThreePointsGet> m_onNewTriangle = new UnityEvent<I_ThreePointsGet>();
        public bool m_pushToStaticListener = true;


        [ContextMenu("Clear Stack")]
        public void ClearPointsStack()
        {
            m_stackPoints.m_newToOldPoints.Clear();
        }
        [ContextMenu("Add Track Point to stack")]
        public void AddPointFromTrackedPoint()
        {
            AddPoint(m_trackedPoints.position);
        }

        public void AddPoint(Vector3 point)
        {
            m_stackPoints.AddPoint(point);
            if (m_stackPoints.HasThreePoint())
            {
                m_stackPoints.GetThreeLastPoint(out Vector3 recent, out Vector3 previous, out Vector3 lastest);
                m_currentTriangle.SetThreePoints(recent, previous, lastest);
                I_ThreePointsGet copy = m_currentTriangle.Copy();
                m_onNewTriangle.Invoke(copy);
                if (m_pushToStaticListener) { 
                    StaticCursorThreePoints.PushNewTriangleDetected(copy);
                }
                
            }
        }

    }
}