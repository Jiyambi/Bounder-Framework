﻿// ************************************************************************ 
// File Name:   Database.cs 
// Purpose:    	Database base class to be used to hold definition files
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2016 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
#region Imports
// ************************************************************************
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using BounderFramework;
using AssetBundles;
#endregion
// ************************************************************************


// ************************************************************************
namespace BounderFramework { 


// ************************************************************************ 
#region Class: ClearDatabaseEvent
// ************************************************************************
public class ClearDatabaseForSceneChangeEvent : GameEvent { }
#endregion
// ************************************************************************


// ************************************************************************
// Class: Database 
// ************************************************************************
public class Database<T> : Singleton<Database<T>> where T : UnityEngine.Object 
{
	// ********************************************************************
	#region Exposed Data Members
	// ********************************************************************
	[SerializeField]
	protected string m_assetBundleName;
	[SerializeField]
	protected bool m_unloadOnSceneChange;
	[SerializeField]
	protected List<T> m_preloadedAssets;
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Private Data Members
	// ********************************************************************
	protected Dictionary<string, T> m_data = new Dictionary<string, T>();
	protected Dictionary<string, AssetBundleLoadAssetOperation> m_loadRequests = new Dictionary<string, AssetBundleLoadAssetOperation>();
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Properties
	// ********************************************************************
	public bool loading { get { return m_loadRequests.Count != 0; } }
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Monobehavior Methods
	// ********************************************************************
	void Start()
	{
		SetupPreloadedAssets();
	}
	// ********************************************************************
	void OnEnable()
	{
		if (instance == this)
		{
			Events.AddListener<ClearDatabaseForSceneChangeEvent>(ClearDatabase);
		}
	}
	// ********************************************************************
	void OnDisable()
	{
		if (instance == this)
		{
			Events.RemoveListener<ClearDatabaseForSceneChangeEvent>(ClearDatabase);
		}
	}
	// ********************************************************************
	#endregion
	// ********************************************************************



	// ********************************************************************
	#region Public Methods
	// ********************************************************************
	public static bool HasData(string _id)
	{
		return instance.m_data.ContainsKey(_id);
	}
	// ********************************************************************
	public static T GetData(string _id)
	{
		if (instance.m_data.ContainsKey(_id))
		{
			return instance.m_data[_id];
		}
		else
		{
			Debug.LogError("Database.GetData("+_id+"): Database does not contain key.");
			return default (T);
		}
	}
	// ********************************************************************
	public static Coroutine RequestAsset(string _asset, string _assetBundleName = "")
	{
		List<string> assets = new List<string>();
		assets.Add(_asset);
		return RequestAssets(assets, _assetBundleName);
	}
	// ********************************************************************
	public static Coroutine RequestAssets(List<string> _assets, string _assetBundleName = "")
	{
		if (_assets.Count == 0)
			return null;

		Dictionary<string, AssetBundleLoadAssetOperation> requests = new Dictionary<string, AssetBundleLoadAssetOperation>();
		for (int i = 0; i < _assets.Count; ++i)
		{
			if (_assets[i].NullOrEmpty())
				continue;
			if (instance.m_data.ContainsKey(_assets[i]))
				continue;
			if (instance.m_loadRequests.ContainsKey(_assets[i]))
				continue;
			AssetBundleLoadAssetOperation request = AssetBundleManager.LoadAssetAsync(_assetBundleName.NullOrEmpty() ? instance.m_assetBundleName : _assetBundleName, _assets[i], typeof(T));
			instance.StartCoroutine(request);
			requests[_assets[i]] = request;
			instance.m_loadRequests[_assets[i]] = request;	
		}
		if (requests.Count > 0)
			return instance.StartCoroutine(instance.WaitForAssets(requests));
		else
			return null;
	}
	// ********************************************************************
	public static void MakeAvailable(T _asset)
	{
		instance.m_data[_asset.name] = _asset;
	}
	// ********************************************************************
	public static void MakeAvailable(List<T> _assets)
	{
		for (int i = 0; i < _assets.Count; ++i)
		{
			if (_assets[i] != null)
				MakeAvailable(_assets[i]);
		}
	}
	// ********************************************************************
	public static void UnloadAssets()
	{
		instance.m_data.Clear();
		instance.SetupPreloadedAssets();
	}
	// ********************************************************************
	public static List<T> GetDatabaseContents()
	{
		List<T> data =	new List<T>();
		foreach (var entry in instance.m_data)
		{
			data.Add(entry.Value);
		}
		return data;
	}
	// ********************************************************************
	#endregion
	// ********************************************************************


	// ********************************************************************
	#region Private Methods
	// ********************************************************************
	private void SetupPreloadedAssets()
	{
		for (int i = 0; i < m_preloadedAssets.Count; ++i)
		{
			m_data[m_preloadedAssets[i].name] = m_preloadedAssets[i];
		}
	}
	// ********************************************************************
	private IEnumerator WaitForAssets(Dictionary<string, AssetBundleLoadAssetOperation> _requests)
	{
		while (_requests.Count > 0)
		{
			List<string> toRemove = new List<string>();
			foreach (KeyValuePair<string, AssetBundleLoadAssetOperation> request in _requests)
			{
				if (request.Value.IsDone())
				{
					T asset = request.Value.GetAsset<T>();
					if (asset != null)
					{
						m_data[asset.name] = asset;
//						Debug.Log("Database: Asset request complete: "+asset.name);
					}
					else
					{
						Debug.LogError("Database: Asset request failed: "+request.Key);
					}
					toRemove.Add(request.Key);
				}
			}
			for (int i = 0; i < toRemove.Count; ++i)
			{
				m_loadRequests.Remove(toRemove[i]);
				_requests.Remove(toRemove[i]);
			}
			yield return null;
		}
	}
	// ********************************************************************
	private void ClearDatabase(ClearDatabaseForSceneChangeEvent _gameEvent)
	{
		if (m_unloadOnSceneChange)
			UnloadAssets();
	}
	// ********************************************************************
	#endregion
	// ********************************************************************

}
// ************************************************************************

}
// ************************************************************************