﻿// ************************************************************************ 
// File Name:   ButtonOpenPanel.cs 
// Purpose:    	
// Project:		
// Author:      Sarah Herzog  
// Copyright: 	2017 Bounder Games
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
#region Class: ButtonOpenPanel
// ************************************************************************
public class ButtonOpenPanel : MonoBehaviour 
{
	// ********************************************************************
	#region Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	private PanelData m_panelData = null;
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Properties 
	// ********************************************************************
	public PanelData panelData {
		get { return m_panelData; }
		set { m_panelData = value; }
	}
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Public Methods 
	// ********************************************************************
	public void OpenPanel (Panel _panel) 
	{
		PanelManager.OpenPanel(_panel, m_panelData);
	}
	// ********************************************************************
	#endregion
	// ********************************************************************

}
#endregion
// ************************************************************************
