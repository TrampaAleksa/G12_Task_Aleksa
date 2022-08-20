using UnityEngine;

namespace DefaultNamespace
{
    public class DraggableObjectSelector : MonoBehaviour
    {
        void OnMouseDown()
        {
            var selectionCommand = new ObjectSelectionCommand(gameObject);
            CommandManager.Instance.ExecuteCommand(selectionCommand);
        }
    }
}