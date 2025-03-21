using UnityEngine;
using UnityEngine.Events;
namespace Eloi.ThreePoints
{


    public class ThreePointsMono_TargetPinchEvents : MonoBehaviour
    {
        public ThreePoints_TargetPinchEvents m_data;
        public void OnEnable()
        {
            m_data.OnEnable();
        }
        public void OnDisable()
        {
            m_data.OnDisable();
        }
        public void Update()
        {
            m_data.Update();
        }
    }

}