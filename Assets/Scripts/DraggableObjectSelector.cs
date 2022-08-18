using UnityEngine;

namespace DefaultNamespace
{
    public class DraggableObjectSelector : MonoBehaviour
    {
        void OnMouseDown() 
        {
            SelectionManager.Instance.SelectedObj = gameObject;
        }
    }
}