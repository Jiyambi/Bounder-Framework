﻿// ************************************************************************ 
// File Name:   CanvasCameraAttach.cs 
// Purpose:    	Causes the canvas to attach to a camera when one is available
// Project:		Armoured Engines
// Author:      Sarah Herzog  
// Copyright: 	2019 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: CanvasCameraAttach
// ************************************************************************
[RequireComponent(typeof(Canvas))]
public class CanvasCameraAttach : MonoBehaviour
{
    // ********************************************************************
    #region Private Data Members 
    // ********************************************************************
    private Canvas m_canvas;
    // ********************************************************************
    #endregion
    // ********************************************************************


    // ********************************************************************
    #region Unity Functions 
    // ********************************************************************
    void Start()
    {
        m_canvas = GetComponent<Canvas>();
    }
    // ********************************************************************
    void Update()
    {
        if (Camera.main != null)
        {
            m_canvas.worldCamera = Camera.main;
            enabled = false;
        }
    }
    // ********************************************************************
    #endregion
    // ********************************************************************
}
#endregion
// ************************************************************************