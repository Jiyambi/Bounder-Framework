﻿// ************************************************************************ 
// File Name:   RandomSprite.cs 
// Purpose:    	Select a random sprite from a list
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2017 Bounder Games
// ************************************************************************
namespace BounderFramework { 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BounderFramework;
#endregion
// ************************************************************************


// ************************************************************************ 
#region Class: RandomSprite
// ************************************************************************ 
[RequireComponent(typeof(SpriteRenderer))]
public class RandomSprite : MonoBehaviour 
{
	// ********************************************************************
	#region Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	private Sprite[] m_sprites;
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Monobehavior Methods 
	// ********************************************************************
	void Start () 
	{
		if (m_sprites == null || m_sprites.Length == 0)
		{
			Debug.LogError("RandomSprite.Start() - no sprites provided");
			return;
		}

		int index = Random.Range(0,m_sprites.Length);
		Sprite sprite = m_sprites[index];
		if (sprite == null)
		{
			Debug.LogError("RandomSprite.Start() - sprite "+index+" null");
			return;
		}

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		if (sprite == null)
		{
			Debug.LogError("RandomSprite.Start() - no SpriteRenderer attached");
			return;
		}

		renderer.sprite = sprite;
	}
	// ********************************************************************
	#endregion
	// ********************************************************************
}
// ************************************************************************
#endregion
// ************************************************************************

}
