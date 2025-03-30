using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsCursorMono_PushToStaticListener : MonoBehaviour {
    
        public void PushAsNewTriangleDetected(I_ThreePointsGet triangle)
        {
            StaticCursorThreePoints.PushNewTriangleDetected(triangle);
        }
        public void PushAsSubmitTriangleDetected(I_ThreePointsGet triangle)
        {
            StaticCursorThreePoints.PushSubmitTriangle(triangle);
        }
        public void PushAsInvokationRequested(I_ThreePointsGet triangle)
        {
            StaticCursorThreePoints.RequestInvokation(triangle);
        }
        [ContextMenu("Push Export Request")]
        public void PushAsExportDataRequested()
        {
            StaticCursorThreePoints.RequestExportWhatIsExportable();
        }
    }
}