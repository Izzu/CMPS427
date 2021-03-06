﻿using UnityEngine;
using System.Collections;

public class MenuUI : UIState {
    private const float WINDOW_WIDTH = 200;
    private const float WINDOW_HEIGHT = 400;

    private Rect windowDimensions;

    public MenuUI(int id, UIController controller)
        : base(id, controller) 
    {
        windowDimensions = new Rect(Screen.width / 2 - WINDOW_WIDTH / 2, Screen.height / 2 - WINDOW_HEIGHT / 2, WINDOW_WIDTH, WINDOW_HEIGHT);
    }

    public override void Enter()
    {
        Debug.Log("Entering Menu state.");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Menu state.");
    }

    public override void Update()
    {
        
    }

    public override void OnGui()
    {
        GUI.Window(0, windowDimensions, OnWindow, "Main Menu");
    }

    void OnWindow(int windowId)
    {
        if (GUI.Button(new Rect(WINDOW_WIDTH / 2 - 40, 40, 80, 45), "Resume")) 
        {
            Controller.GuiState = UIController.States.INGAME;
        }

        if (GUI.Button(new Rect(WINDOW_WIDTH / 2 - 40, 115, 75, 45), "Quit"))
        {
            // Ignored in Editor and Web player.
            Application.Quit();
        }
    }
}
