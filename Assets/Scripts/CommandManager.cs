using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CommandManager : MonoBehaviour
    {
        private Stack<ICommand> _commands;

        private void Awake()
        {
            _commands = new Stack<ICommand>();
        }

        public void UndoCommand()
        {
            _commands.Pop().Undo();
        }

        public void ExecuteCommand(ICommand commandToExecute)
        {
            commandToExecute.SaveState();
            _commands.Push(commandToExecute);
            commandToExecute.Execute();
        }
    }
}