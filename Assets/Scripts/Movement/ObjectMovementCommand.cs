using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Stores the <see cref="_previousPosition"/> before movement and the <see cref="_currentPosition"/> after movement is Executed.
    /// When <see cref="Execute"/> is called moves the <see cref="_objectToMove"/> to the <see cref="_currentPosition"/>
    /// When <see cref="Undo"/> is called returns the <see cref="_objectToMove"/> to the <see cref="_previousPosition"/>
    /// </summary>
    public class ObjectMovementCommand : ICommand
    {
        private Vector3 _previousPosition;
        private Vector3 _currentPosition;
        private GameObject _objectToMove;

        public ObjectMovementCommand(Vector3 previousPosition, Vector3 currentPosition, GameObject objectToMove)
        {
            _previousPosition = previousPosition;
            _currentPosition = currentPosition;
            _objectToMove = objectToMove;
        }

        public void Execute()
        {
            _objectToMove.transform.position = _currentPosition;
        }

        public void Undo()
        {
            _objectToMove.transform.position = _previousPosition;
        }
        
    }
}