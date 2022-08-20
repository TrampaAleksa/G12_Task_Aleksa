using UnityEngine;

namespace DefaultNamespace
{
    public class ColorChangerCommand : ICommand
    {
        private readonly Material _previousColor;
        private readonly Material _newColor;
        private readonly GameObject _selectedObject;

        public ColorChangerCommand(Material previousColor, Material newColor, GameObject selectedObject)
        {
            _previousColor = previousColor;
            _newColor = newColor;
            _selectedObject = selectedObject;
        }
        public void Execute()
        {
            ChangeColor(_newColor);
        }
        public void Undo()
        {
            ChangeColor(_previousColor);
        }
        
        private void ChangeColor(Material toChangeTo)
        {
            Debug.Log("Undo: Changed Material of Object: " + _selectedObject.name);
            
            var objectColor =
                _selectedObject.GetComponent<DraggableObjectColor>();
            objectColor.CurrentMaterial = toChangeTo;
            objectColor.ChangeMaterial(toChangeTo);
        }
    }
}