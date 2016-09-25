using EnumLibrary;
using System.Collections.Generic;

public class Toolbox : Singleton<Toolbox>
{
    protected Toolbox() { }
    //private static Dictionary<DirectorID, object> _directors = new Dictionary<DirectorID, object>();

    public static Toolbox getInstance()
    {
        if (_instance == null)
        {
            _instance = new Toolbox();
        }

        return _instance;
    }
    
    /******************  COMMENTED OUT FOR NOW *************************
    public static void SetDirector(DirectorID aDirector, object aObject)
    {
        if (!_directors.ContainsKey(aDirector))
        {
            _directors.Add(aDirector, aObject);
        }
    }

    public static object GetDirector(DirectorID aDirector)
    {
        if (_directors.ContainsKey(aDirector))
        {
            return _directors[aDirector];
        }

        return null;
    }

    public static void RemoveDirector(DirectorID aDirector)
    {
        if (_directors.ContainsKey(aDirector))
        {
            _directors.Remove(aDirector);
        }
    }
    ******************************************************************/
}