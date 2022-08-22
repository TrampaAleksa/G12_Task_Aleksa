using UnityEngine;

namespace DefaultNamespace
{
    
    /// <summary>
    /// A Command that saves the <see cref="_previouslySelectedObj"/> and the new <see cref="_currentlySelectedObj"/>.
    /// When <see cref="Execute"/> is called the <see cref="_currentlySelectedObj"/> is the Selected object.
    /// Once we <see cref="Undo"/> the command the Selected  object becomes the <see cref="_previouslySelectedObj"/>.
    /// </summary>
    public class ObjectSelectionCommand : ICommand
    {
        private GameObject _previouslySelectedObj;
        private GameObject _currentlySelectedObj;

        public ObjectSelectionCommand(GameObject currentlySelectedObj)
        {
            _currentlySelectedObj = currentlySelectedObj;
        }

        public void Execute()
        {
            _previouslySelectedObj = SelectionManager.Instance.SelectedObj;
            SelectionManager.Instance.SelectedObj = _currentlySelectedObj;
            
            Debug.Log("Undo: Previous Object was: " + _previouslySelectedObj.name);
            Debug.Log("Undo: Selected Object is: " + _currentlySelectedObj.name);
        }

        public void Undo()
        {
            SelectionManager.Instance.SelectedObj = _previouslySelectedObj;
            VisualizeSelectionUndo();
            Debug.Log("Undo: Selected Object is now: " + SelectionManager.Instance.SelectedObj.name);

        }

        /// <summary>
        /// Used to Visualize the Undo so that the user doesn't think that the Undo failed.
        /// </summary>
        private static void VisualizeSelectionUndo()
        {
            SelectionManager.Instance.SelectedObj.GetComponent<DraggableObjectColor>().TemporaryColor(0.2f);
        }
    }
}