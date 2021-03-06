﻿// ************************************************************************ 
// File Name:   ButtonOpenURL.cs 
// Purpose:    	Open a URL in the default browser on button press
// Project:		Bounder Framework
// Author:      Sarah Herzog  
// Copyright: 	2018 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: ButtonOpenURL
// ************************************************************************
public class ButtonOpenURL : MonoBehaviour 
{
	// ********************************************************************
	#region Public Methods 
	// ********************************************************************
	public void OpenURL (string _url) 
	{
		Application.OpenURL(_url);
	}
	// ********************************************************************
	#endregion
	// ********************************************************************

}
#endregion
// ************************************************************************
