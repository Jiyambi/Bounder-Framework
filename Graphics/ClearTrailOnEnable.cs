﻿// ************************************************************************ 
// File Name:   ClearTrailOnEnable.cs 
// Purpose:     Clears a trail renderer on enable
// Project:		Bounder Framework
// Author:      Sarah Herzog  
// Copyright: 	2017 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
using System.Collections.Generic;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: ClearTrailOnEnable
// ************************************************************************ 
[RequireComponent(typeof(TrailRenderer))]
public class ClearTrailOnEnable : MonoBehaviour
{
	// ********************************************************************
	#region MonoBehaviour Methods 
	// ********************************************************************
	void OnEnable()
	{
		GetComponent<TrailRenderer>().Clear();
	}
	// ********************************************************************
	#endregion
	// ********************************************************************
}
#endregion
// ************************************************************************