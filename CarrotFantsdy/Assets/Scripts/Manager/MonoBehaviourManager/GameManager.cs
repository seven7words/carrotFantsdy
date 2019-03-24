using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏总管理，负责所有的管理者
/// </summary>
public class GameManager : MonoBehaviour
{

	public PlayerManager playerManager;
	public FactoryManager factoryManager;
	public AudioSourceManager audioSourceManager;
	public UIManger uiManger;


	private static GameManager _instance;

	public static GameManager Instance
	{
		get { return _instance; }
	}

	private void Awake()
	{
		
		DontDestroyOnLoad(gameObject);
		_instance = this;
		playerManager = new PlayerManager();
		factoryManager = new FactoryManager();
		audioSourceManager = new AudioSourceManager();
		uiManger = new UIManger();
			   
	}

	public GameObject CreateItem(GameObject itemGo)
	{
		GameObject go = Instantiate(itemGo);
		return go;
	}
	/// <summary>
	/// 获取精灵资源
	/// </summary>
	/// <param name="resourcePath"></param>
	/// <returns></returns>
	public Sprite GetSprite(string resourcePath)
	{
		return factoryManager.spriteFactory.GetSingleResources(resourcePath);
	}
	/// <summary>
	/// 获取音频资源
	/// </summary>
	/// <param name="resourcePath"></param>
	/// <returns></returns>
	public AudioClip GetAudioClip(string resourcePath)
	{
		return factoryManager.audioClipFactory.GetSingleResources(resourcePath);
	}
	public RuntimeAnimatorController GetRuntimeAnimatorController(string resourcePath)
	{
		return factoryManager.runtimeAnimatorControllerFactory.GetSingleResources(resourcePath);
	}
	/// <summary>
	/// 获取游戏物体
	/// </summary>
	/// <param name="factoryType"></param>
	/// <param name="resourcePath"></param>
	/// <returns></returns>
	public GameObject GetGameObjectResource(FactoryType factoryType,string resourcePath)
	{
		return factoryManager.factoryDict[factoryType].GetItem(resourcePath);
	}

	public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
	{
		factoryManager.factoryDict[factoryType].PushItem(resourcePath, itemGo);
	}
}
