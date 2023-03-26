using UnityEngine;

[CreateAssetMenu (fileName = "New Level", menuName = "Scriptable Level")]

public class Level : ScriptableObject
{
    public string levelName;
    public string levelScene;
    
    public Color levelColor;
    public Sprite levelImage;
    public bool available;
}
