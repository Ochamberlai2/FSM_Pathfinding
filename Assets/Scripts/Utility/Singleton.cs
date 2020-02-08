using UnityEngine;
using Sirenix.OdinInspector;

// A script to turn anything into a singleton if it inherits from it
// e.g. public class MyScript : MotherSingleton<MyScript>
public class Singleton<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviour
{
    protected static T _instance; /** Returns the instance of this singleton. */
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return _instance;
        }
    }
}