using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.ThreePoints
{

    public class ThreePointsMono_PointsQueue : MonoBehaviour
    {
        public ThreePoints_PointsQueue m_pointsQueue;

        public void AddPoint(Vector3 point)
        {
            m_pointsQueue.AddPoint(point);
        }
    }

    [System.Serializable]
public class ThreePoints_PointsQueue
 {


    public List<Vector3> m_newToOldPoints = new List<Vector3>();
    public int m_maxPoints = 10;
    public UnityEvent<Vector3, Vector3, Vector3> m_onNewThreePoints = new UnityEvent<Vector3, Vector3, Vector3>();
    public UnityEvent<Vector3> m_onNewPointAdded =new UnityEvent<Vector3>();
    
    public void AddPoint(Vector3 point)
    {
        m_newToOldPoints.Insert(0,point);
        if (m_newToOldPoints.Count > 10)
        {
            m_newToOldPoints.RemoveAt(m_newToOldPoints.Count-1);
        }
        if (m_newToOldPoints.Count >= 3)
        {
            m_onNewThreePoints.Invoke(m_newToOldPoints[0], m_newToOldPoints[1], m_newToOldPoints[2]);
        }
        m_onNewPointAdded.Invoke(point);
    }


    public void GetListOfPoints(out IEnumerable<Vector3> points) { 
    
        points = m_newToOldPoints;
    }
    public bool HasThreePoint() { return m_newToOldPoints.Count >=3; }
    public void GetThreeLastPoint(out Vector3[] lastPoint) { 
    
        lastPoint = new Vector3[3];
        lastPoint[0] = m_newToOldPoints[0];
        lastPoint[1] = m_newToOldPoints[1];
        lastPoint[2] = m_newToOldPoints[2];
    }
    public void GetThreeLastPoint(out Vector3 recent, out Vector3 previous, out Vector3 lastest) {

        recent = m_newToOldPoints[0];
        previous = m_newToOldPoints[1];
        lastest = m_newToOldPoints[2];
    }



}

}