using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{
    public class ThreePointsCursorMono_ListenToStaticPush : MonoBehaviour {

        public ThreePointsTriangleDefault m_lastReceived =new ThreePointsTriangleDefault();
        public UnityEvent<I_ThreePointsGet> m_onNewDetectedTriangle = new UnityEvent<I_ThreePointsGet>();
        public UnityEvent<I_ThreePointsGet> m_onSubmitTriangle = new UnityEvent<I_ThreePointsGet>();
        public UnityEvent<I_ThreePointsGet> m_onInvokeRequest= new UnityEvent<I_ThreePointsGet>();
        public UnityEvent m_onExportDataRequested = new UnityEvent();
        void OnNewTriangleDetected(I_ThreePointsGet triangle)
        {
            m_lastReceived.SetThreePoints(triangle);
            m_onNewDetectedTriangle.Invoke(triangle);
        }
        void OnNewSubmitTriangleDetected(I_ThreePointsGet triangle)
        {
            m_lastReceived.SetThreePoints(triangle);
            m_onSubmitTriangle.Invoke(triangle);
        }
        void OnNewInvokeRequest(I_ThreePointsGet triangle)
        {
            m_lastReceived.SetThreePoints(triangle);
            m_onInvokeRequest.Invoke(triangle);
        }
        public void OnRequestExportData() {

            m_onExportDataRequested.Invoke();
        }
        void OnEnable()
        {
            StaticCursorThreePoints.AddThreePointsDetectedListener(OnNewTriangleDetected);
            StaticCursorThreePoints.AddSubmitTriangleListener(OnNewSubmitTriangleDetected);
            StaticCursorThreePoints.AddInvokationRequestedListener(OnNewInvokeRequest);
            StaticCursorThreePoints.AddExportDataRequstedListener(OnRequestExportData);

        }
        void OnDisable()
        {
            StaticCursorThreePoints.RemoveThreePointsDetectedListener(OnNewTriangleDetected);
            StaticCursorThreePoints.RemoveSubmitTriangleListener(OnNewSubmitTriangleDetected);
            StaticCursorThreePoints.RemoveInvokationRequestedListener(OnNewInvokeRequest);
            StaticCursorThreePoints.RemoveExportDataRequstedListener(OnRequestExportData);
        }
    }
}