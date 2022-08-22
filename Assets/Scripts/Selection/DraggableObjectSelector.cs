using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Used to Select an object that was clicked on with the help of <see cref="ObjectSelectionCommand"/>
    /// The Command gets Executed using the <see cref="CommandManager"/>
    /// </summary>
    public class DraggableObjectSelector : MonoBehaviour
    {
        void OnMouseDown()
        {
            var selectionCommand = new ObjectSelectionCommand(gameObject);
            CommandManager.Instance.ExecuteCommand(selectionCommand);
        }
    }
}