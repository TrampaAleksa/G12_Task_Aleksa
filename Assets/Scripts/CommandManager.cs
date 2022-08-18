using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CommandManager : MonoBehaviour
    {
        private Stack<ICommand> _commands;
        public static CommandManager Instance;

        private void Awake()
        {
            _commands = new Stack<ICommand>();
            
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        public void UndoCommand()
        {
            if (_commands.Count <= 0)
                return;
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