using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Executes Commands and stores them into a Stack - allowing it to go Back and Undo the Commands if needed.
    /// See the Command Pattern : https://learn.unity.com/tutorial/command-pattern#
    /// </summary>
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
            _commands.Push(commandToExecute);
            commandToExecute.Execute();
        }
    }
}