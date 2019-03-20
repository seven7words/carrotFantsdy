using UnityEngine;


public class DPFactory : MonoBehaviour
{
    
}

public class BulletOne : MonoBehaviour
{
    private AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioClip = Resources.Load<AudioClip>("ddd");
        audioSource.clip = audioClip;
        Destroy(gameObject,4);
        
    }
    //其他
}

public class BulletTwo : MonoBehaviour
{
    private AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioClip = Resources.Load<AudioClip>("ddd");
        audioSource.clip = audioClip;
        Destroy(gameObject,4);
        
    }
    //其他
}