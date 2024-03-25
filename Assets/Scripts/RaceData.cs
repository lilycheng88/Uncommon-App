using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStudentRace", menuName = "Character Customization/Student Race", order = 0)]
public class RaceData : ScriptableObject
{
    public List<Sprite> ASpriteList;
    public List<Sprite> BSpriteList;
    public List<Sprite> CSpriteList;
    public List<Sprite> DSpriteList;
    public List<Sprite> ESpriteList;
    public List<Sprite> FSpriteList;
    public List<Sprite> GSpriteList;
    public List<Sprite> HSpriteList;
    public List<Sprite> ISpriteList;
    public List<Sprite> JSpriteList;
    public List<Sprite> KSpriteList;
    public List<Sprite> LSpriteList;
    // Add more as needed, such as hair, mouth, etc.

    // You can also add fields for race-specific attributes if needed.
    public string raceName;
    public string raceDescription; // Description or other characteristics.
}
