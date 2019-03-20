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
}
