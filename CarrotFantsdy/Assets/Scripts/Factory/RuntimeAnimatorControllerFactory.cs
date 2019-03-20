using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeAnimatorControllerFactory : IBaseResourceFactory<RuntimeAnimatorController> {

	  
	protected Dictionary<string, RuntimeAnimatorController> factoryDict = new Dictionary<string, RuntimeAnimatorController>();

	protected string loadPath;
	public RuntimeAnimatorControllerFactory()
	{
		loadPath = "Animator/"; 
	}
	public RuntimeAnimatorController GetSingleResources(string resourcePath)
	{
		RuntimeAnimatorController itemGo = null;
		string itemLoadPath = loadPath + resourcePath;
		if (factoryDict.ContainsKey(resourcePath))
		{
			itemGo = factoryDict[resourcePath];
		}
		else
		{
			itemGo = Resources.Load<RuntimeAnimatorController>(itemLoadPath);
			factoryDict.Add(resourcePath,itemGo);
		}

		if (itemGo == null)
		{
			Debug.Log(itemLoadPath+"路径问题");
			
		}
		return itemGo;
	}
}
