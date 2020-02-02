using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager SM;

    private static Dictionary<string, Sprite[]> _spriteDict;

    public Sprite[] Sprites(string spritesheetPath)
    {
        if (!_spriteDict.ContainsKey(spritesheetPath))
        {
            _spriteDict.Add(spritesheetPath, Resources.LoadAll<Sprite>(spritesheetPath));
        }
        return _spriteDict[spritesheetPath];
    }

    void Awake()
    {
        _spriteDict = new Dictionary<string, Sprite[]>();
        if (SM != null)
            Destroy(SM);
        else
            SM = this;

        DontDestroyOnLoad(this);
    }
}
