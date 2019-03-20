using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFactory : IBaseResourceFactory<Sprite> {

	protected Dictionary<string, Sprite> factoryDict = new Dictionary<string, Sprite>();

	protected string loadPath;
	public SpriteFactory()
	{
		loadPath = "Pictures/";
	}

	public Sprite GetSingleResources(string resourcePath)
	{
		Sprite itemGo = null;
		string itemLoadPath = loadPath + resourcePath;
		if (factoryDict.ContainsKey(resourcePath))
		{
			itemGo = factoryDict[resourcePath];
		}
		else
		{
			itemGo = Resources.Load<Sprite>(itemLoadPath);
			factoryDict.Add(resourcePath,itemGo);
		}

		if (itemGo == null)
		{
			Debug.Log(itemLoadPath+"路径问题");
			
		}
		return itemGo;
	}
}
