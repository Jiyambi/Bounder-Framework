﻿// ************************************************************************ 
// File Name:   AnimatorControllerParameterData.cs 
// Purpose:    	Information for applying a paramter to an animation
// Project:		Armoured Engines
// Author:      Sarah Herzog  
// Copyright: 	2017 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: AnimatorControllerParameterData
// ************************************************************************ 
[System.Serializable]
public class AnimatorControllerParameterData : GameEvent
{
	// ********************************************************************
	#region Public Data Members 
	// ********************************************************************
	public string id;
	[Tooltip("Animator for the animation you want to activate.")]
	public Animator animator;
	[Tooltip("Parameter you want to change.")]
	public string parameter;
	[Tooltip("Parameter type.")]
	public AnimatorControllerParameterType parameterType;
	[Tooltip("Parameter value if bool")]
	public bool parameterValueBool;
	[Tooltip("Parameter value if int")]
	public int parameterValueInt;
	[Tooltip("Parameter value if float")]
	public float parameterValueFloat;
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Public Methods 
	// ********************************************************************
	public void Apply(Animator _animator = null)
	{
		Animator animatorToApply = _animator;
		if (_animator == null)
			animatorToApply = animator;
		switch(parameterType)
		{
		case AnimatorControllerParameterType.Trigger:
			animatorToApply.SetTrigger(parameter);
			break;
		case AnimatorControllerParameterType.Bool:
			animatorToApply.SetBool(parameter, parameterValueBool);
			break;
		case AnimatorControllerParameterType.Int:
			animatorToApply.SetInteger(parameter, parameterValueInt);
			break;
		case AnimatorControllerParameterType.Float:
			animatorToApply.SetFloat(parameter, parameterValueFloat);
			break;
		}
	}
	// ********************************************************************
	#endregion
	// ********************************************************************

}
#endregion
// ************************************************************************
