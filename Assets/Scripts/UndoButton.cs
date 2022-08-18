using UnityEngine;

namespace DefaultNamespace
{
    public class UndoButton : MonoBehaviour
    {
        public void UndoCommand()
        {
            CommandManager.Instance.UndoCommand();
        }
    }
}