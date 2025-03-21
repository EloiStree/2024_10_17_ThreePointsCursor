using System;

namespace Eloi.ThreePoints
{
    public class StaticCursorThreePoints {

        static Action<I_ThreePointsGet> m_onNewTriangleDetected; 
        public static void PushNewTriangleDetected(I_ThreePointsGet triangle)
        {
            if (triangle != null)
                m_onNewTriangleDetected?.Invoke(triangle);
        }

        public static void AddThreePointsDetectedListener(Action<I_ThreePointsGet> listener)
        {
            m_onNewTriangleDetected += listener;
        }
        public static void RemoveThreePointsDetectedListener(Action<I_ThreePointsGet> listener)
        {
            m_onNewTriangleDetected -= listener;
        }
    }
}