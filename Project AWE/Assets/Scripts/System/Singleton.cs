using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected Singleton() { }

    protected static T _instance;

    protected static bool _quitting = false;
    protected static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_quitting)
            {
                Debug.Log("[Singleton] Instance '" + typeof(T) + " destroyed on application quit.");
                return null;
            }

            lock(_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    //  Check that there's only a single Instance of me
                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] More than one singleton " + typeof(T) + " exist!");
                        return _instance;
                    }

                    //  Instantiate myself if I do not already exist
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(Singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] A singleton instance of " + typeof(T) + "was created.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] " + typeof(T) + " singleton already exist.");
                    }
                }

                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            //  If I am the first Instance then assign myself
            _instance = this as T;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            //  If I am not, then remove me
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void OnDestroy()
    {
        //  Ensures there are no artifacts left over once the application closes
        _quitting = true;
    }
}