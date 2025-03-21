using System;

namespace Eloi.ThreePoints
{
    public class StaticCursorThreePoints {

        static Action<I_ThreePointsGet> m_onNewTriangleDetected;
        static Action<I_ThreePointsGet> m_onSubmitTriangleDetected;
        static Action<I_ThreePointsGet> m_onInvokationRequested;
        static Action m_onExportDataRequsted;
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

        public static void PushSubmitTriangle(I_ThreePointsGet copy)
        {
            if (copy != null)
                m_onSubmitTriangleDetected?.Invoke(copy);
        }
        public static void AddSubmitTriangleListener(Action<I_ThreePointsGet> listener)
        {
            m_onSubmitTriangleDetected += listener;
        }
        public static void RemoveSubmitTriangleListener(Action<I_ThreePointsGet> listener)
        {
            m_onSubmitTriangleDetected -= listener;
        }

        public static void RequestExportWhatIsExportable()
        {
            m_onExportDataRequsted?.Invoke();
        }

        public static void RequestInvokation(I_ThreePointsGet m_currentTriangle)
        {
            if (m_currentTriangle != null)
                m_onInvokationRequested?.Invoke(m_currentTriangle);
        }

        public static void AddInvokationRequestedListener(Action<I_ThreePointsGet> listener)
        {
            m_onInvokationRequested += listener;
        }

        public static void RemoveInvokationRequestedListener(Action<I_ThreePointsGet> listener)
        {
            m_onInvokationRequested -= listener;
        }

        public static void AddExportDataRequstedListener(Action listener)
        {
            m_onExportDataRequsted += listener;
        }

        public static void RemoveExportDataRequstedListener(Action listener)
        {
            m_onExportDataRequsted -= listener;

        }
    }
}