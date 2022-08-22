using UnityEngine;

namespace DefaultNamespace
{ 
    /// <summary>
    /// Stores the <see cref="_previousColor"/> before the color change and the <see cref="_newColor"/> after the change is Executed.
    /// When <see cref="Execute"/> is called changes the <see cref="_selectedObject"/> color to the <see cref="_newColor"/>
    /// When <see cref="Undo"/> is called returns the <see cref="_selectedObject"/> to the <see cref="_previousColor"/>
    /// </summary>
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