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
        public UnityEvent<I_ThreePointsGet> m_onSubmitTriangle = new UnityEvent<I_ThreePointsGet>();
        public bool m_pushToStaticListener = true;


        [ContextMenu("Export Meshes")]
        public void PushRequestToExportWhatIsPossible() {

            StaticCursorThreePoints.RequestExportWhatIsExportable();
        }
        [ContextMenu("Invoke From Current Triangle")]
        public void PushRequestToInvokeFromCurrentTriangle() { 
        
            StaticCursorThreePoints.RequestInvokation(m_currentTriangle);
        }

        [ContextMenu("Submit Triangle")]
        public void SubmitCurrentTriangle() {
            I_ThreePointsGet copy = m_currentTriangle.Copy();
            m_onSubmitTriangle.Invoke(copy);
            if (m_pushToStaticListener)
            {
                StaticCursorThreePoints.PushSubmitTriangle(copy);
            }
        }
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
        public void AddPointFromVector3(Vector3 point)
        {
            AddPoint(point);
        }
        public void AddPointFromTransform(Transform point)
        {
            AddPoint(point.position);
        }
        public void AddPointsFromTransform(Transform[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                AddPoint(points[i].position);
            }
        }
        public void AddPointsFromTransformAndSubmit(params Transform[] transforms) {

            for (int i = 0; i < transforms.Length; i++)
            {
                AddPoint(transforms[i].position);
            }
            SubmitCurrentTriangle();
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