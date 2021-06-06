using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
	public static DoNotDestroy Created { get; private set; }

	public static float previousBackgroundVolume = 1f;
	public static float previousSoundEffectsVolume = 1f;

	void Awake()
    {
		if (Created == null)
		{
			DontDestroyOnLoad(gameObject);
		//	Created = this;
		}
		//else
		//{
		//	Destroy(gameObject);
		//}
    }
}
