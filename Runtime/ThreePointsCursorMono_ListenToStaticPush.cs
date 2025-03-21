using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{
    public class ThreePointsCursorMono_ListenToStaticPush : MonoBehaviour {

        public ThreePointsTriangleDefault m_lastReceived =new ThreePointsTriangleDefault();
        public UnityEvent<I_ThreePointsGet> m_onPushedTriangle = new UnityEvent<I_ThreePointsGet>();
        void OnNewTriangleDetected(I_ThreePointsGet triangle)
        {
            m_lastReceived.SetThreePoints(triangle);
            m_onPushedTriangle.Invoke(triangle);
        }
        void OnEnable()
        {
            StaticCursorThreePoints.AddThreePointsDetectedListener(OnNewTriangleDetected);
        }
        void OnDisable()
        {
            StaticCursorThreePoints.RemoveThreePointsDetectedListener(OnNewTriangleDetected);
        }
    }
}