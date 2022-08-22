using UnityEngine;

namespace DefaultNamespace
{
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

        private static void VisualizeSelectionUndo()
        {
            SelectionManager.Instance.SelectedObj.GetComponent<DraggableObjectColor>().TemporaryColor(0.2f);
        }
    }
}