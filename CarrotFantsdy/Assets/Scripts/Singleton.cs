using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{

//	private static Singleton _instance = new Singleton();
//	
//	
//	//饿汉式单例
//	public static Singleton Instance
//	{
//		get { return _instance; }
//	}
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//
//
//	private void Awake()
//	{
//		_instance = this;
//	}
	


	//懒汉式单例
	private static Singleton _instance;

	public static Singleton instance
	{
		get {
			if (_instance == null)
			{
				_instance = new Singleton();
			}

			return _instance;
		}
	}

	
}

public abstract class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance
	{
		get { return _instance; }
	}

	private void Awake()
	{
		_instance = this as T;
	}
}
