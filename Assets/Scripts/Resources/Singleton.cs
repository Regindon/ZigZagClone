using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	
    #region Fields


    // The instance.
    private static T instance;

    #endregion

    #region Properties


    // Gets the instance.
    public static T Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<T> ();
                if ( instance == null )
                {
                    GameObject obj = new GameObject ();
                    obj.name = typeof ( T ).Name;
                    instance = obj.AddComponent<T> ();
                }
            }
            return instance;
        }
    }

    #endregion

    #region Methods


    // Use this for initialization.
    protected virtual void Awake ()
    {
        if ( instance == null )
        {
            instance = this as T;
            DontDestroyOnLoad ( gameObject );
        }
        else
        {
            Destroy ( gameObject );
        }
    }

    #endregion
	
}