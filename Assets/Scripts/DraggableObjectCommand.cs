using UnityEngine;

namespace DefaultNamespace
{
    public class DraggableObjectCommand : ICommand
    {
        private GameObject _previouslySelectedObj;
        private GameObject _currentlySelectedObj;

        public DraggableObjectCommand(GameObject currentlySelectedObj)
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
            
            Debug.Log("Undo: Selected Object is now: " + SelectionManager.Instance.SelectedObj.name);

        }
    }
}