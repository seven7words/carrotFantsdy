using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏物体类型的工厂基类
/// </summary>
public class BaseFactory : IBaseFactory {
	/// <summary>
	/// 所有的gameObject类型的资源（UI，UIPanel，Game）存取的类型资源
	/// </summary>
	protected Dictionary<string, GameObject> factoryDict = new Dictionary<string, GameObject>();
	//对象池（就是我们具体存储的游戏物体类型的对象）对应的物体
	
	//对象池字典
	protected Dictionary<string,Stack<GameObject>> objectPoolDict = new Dictionary<string, Stack<GameObject>>();
	
	//加载路径
	protected string loadPath;

	public BaseFactory()
	{
		loadPath = "Prefabs/"; 
	}
	
	/// <summary>
	/// 取实例
	/// </summary>
	/// <param name="itemName"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public GameObject GetItem(string itemName)
	{
		GameObject itemGo = null;
		if (objectPoolDict.ContainsKey(itemName))
		{
			if (objectPoolDict[itemName].Count == 0)
			{
				GameObject go = GetResource(itemName);
				itemGo = GameManager.Instance.CreateItem(go);
				
			}
			else
			{
				itemGo = objectPoolDict[itemName].Pop();
				itemGo.SetActive(true);
			}
		}
		else
		{
			objectPoolDict.Add(itemName, new Stack<GameObject>());
			GameObject go = GetResource(itemName);
			itemGo = GameManager.Instance.CreateItem(go);
		}

		if (itemGo == null)
		{
			Debug.LogError(itemName + "的实例获取失败");
		}
		return itemGo;
	}
	/// <summary>
	/// 取资源
	/// </summary>
	/// <param name="itemName"></param>
	/// <returns></returns>
	private GameObject GetResource(string itemName)
	{
		GameObject itemGo = null;
		string itemLoadPath = loadPath + itemName;
		if (factoryDict.ContainsKey(itemName))
		{
			itemGo = factoryDict[itemName];
			
		}
		else
		{
			itemGo = Resources.Load<GameObject>(itemLoadPath);
			factoryDict.Add(itemName, itemGo);
			
		}

		if (itemGo == null)
		{
			Debug.Log(itemName+"的资源加载失败");
			Debug.Log("失败路径"+itemLoadPath);
		}

		return itemGo; 
	}
	/// <summary>
	/// 放入池子
	/// </summary>
	/// <param name="itemName"></param>
	/// <param name="item"></param>
	public void PushItem(string itemName, GameObject item)
	{
		item.SetActive(false);
		item.transform.SetParent(GameManager.Instance.transform);
		if (objectPoolDict.ContainsKey(itemName))
		{
			objectPoolDict[itemName].Push(item);
		}
		else
		{
			Debug.LogError("当前字典没有"+itemName+"的栈");
		}
	}
}
