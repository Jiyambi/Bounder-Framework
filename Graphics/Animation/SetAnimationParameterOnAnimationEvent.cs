﻿// ************************************************************************ 
// File Name:   SetAnimationParameterOnAnimationEvent.cs 
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
#region Class: SetAnimationParameterOnAnimationEvent
// ************************************************************************
public class SetAnimationParameterOnAnimationEvent : MonoBehaviour 
{

	// ********************************************************************
	#region Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	[Tooltip("Parameters you want to change.")]
	private List<AnimatorControllerParameterData> m_parameters = new List<AnimatorControllerParameterData>();
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Private Data Members 
	// ********************************************************************
	private Dictionary<string,AnimatorControllerParameterData> m_paramMap = new Dictionary<string, AnimatorControllerParameterData>();
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region MonoBehaviour Methods
	// ********************************************************************
	void Awake()
	{
		for (int i = 0; i < m_parameters.Count; ++i)
		{
			AnimatorControllerParameterData param = m_parameters[i];
			if (m_paramMap.ContainsKey(param.id))
				Debug.LogError("Duplicate ID found: "+param.id);
			else
				m_paramMap[param.id] = param;
		}
	}
	// ********************************************************************
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Private Data Members 
	// ********************************************************************
	void SetParameter(string _id)
	{
		if (!m_paramMap.ContainsKey(_id))
		{
			Debug.LogError("No data found for ID: "+_id);
			return;
		}

		AnimatorControllerParameterData param = m_paramMap[_id];
		param.Apply();
	}
	#endregion
	// ********************************************************************

}
#endregion
// ************************************************************************
