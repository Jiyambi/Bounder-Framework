﻿// ************************************************************************ 
// File Name:   InputManager.cs 
// Purpose:    	
// Project:		
// Author:      Sarah Herzog  
// Copyright: 	2017 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BounderFramework;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Enum: ControlScheme
// ************************************************************************
[Flags] 
public enum ControlScheme
{
	NONE 			= 0,
	TOUCH			= 1 << 0,
	MOUSE_KEYBOARD	= 1 << 1,
	CONTROLLER		= 1 << 2,
	ALL				= TOUCH | MOUSE_KEYBOARD | CONTROLLER
}
// ************************************************************************
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: InputManager
// ************************************************************************
public class InputManager : Singleton<InputManager> 
{

	// ********************************************************************
	#region Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	private ControlScheme m_controlScheme;
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Properties 
	// ********************************************************************
	public static ControlScheme controlScheme 
	{ 
		get { return instance.m_controlScheme; } 
		set { instance.m_controlScheme = value; } 
	}
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region MonoBehaviour Methods 
	// ********************************************************************
	void Start () 
	{
		
	}
	// ********************************************************************
	void Update () 
	{
		
	}
	// ********************************************************************
	#endregion
	// ********************************************************************

}
#endregion
// ************************************************************************
