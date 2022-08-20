using UnityEngine;

namespace DefaultNamespace
{
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