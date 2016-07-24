﻿// ************************************************************************ 
// File Name:   AudioInfo.cs 
// Purpose:    	Holds information used for playing audio
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2014 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
using BounderFramework;
#endregion
// ************************************************************************


// ************************************************************************
namespace BounderFramework 
{ 
	// ******************************************************************** 
	#region Class: AudioInfo
	// ********************************************************************
	[System.Serializable]
	public class AudioInfo {
		
		// ****************************************************************
		#region Public Data Members
		// ****************************************************************
		public AudioCategory category = AudioCategory.EFFECTS;
		public float volume = 1.0f;
		public float volumeFuzz = 0.0f;
		public float pitch = 1.0f;
		public float pitchFuzz = 0.0f;
		public bool shouldLoop = false;
		#endregion
		// ****************************************************************

		// ****************************************************************
		#region Public Methods
		// ****************************************************************
		public AudioInfo() { }
		// ****************************************************************
		public AudioInfo(AudioCategory _category) 
		{ 
			category = _category;
		}
		// ****************************************************************
		#endregion
		// ****************************************************************

	}
	#endregion
	// ********************************************************************
}
// ************************************************************************