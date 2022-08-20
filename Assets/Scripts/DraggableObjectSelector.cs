using UnityEngine;

namespace DefaultNamespace
{
    public class DraggableObjectSelector : MonoBehaviour
    {
        void OnMouseDown()
        {
            var selectionCommand = new DraggableObjectCommand(gameObject);
            CommandManager.Instance.ExecuteCommand(selectionCommand);
        }
    }
}