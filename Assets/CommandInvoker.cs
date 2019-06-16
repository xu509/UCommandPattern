﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    private void Awake()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command) {
        while (commandHistory.Count > counter) {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }

    private void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
        }
        else {
            if (Input.GetKeyDown(KeyCode.Z)) {
                if (counter > 0) {
                    counter--;
                    commandHistory[counter].Undo();
                }
            } else if (Input.GetKeyDown(KeyCode.R)){
                if (counter < commandHistory.Count) {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
    }

}
