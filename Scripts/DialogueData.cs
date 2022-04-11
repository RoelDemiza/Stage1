using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    //Encapsulation
    [SerializeField] private string _npcname;
    [SerializeField][TextArea] private string[] _lines; 
    public string[] lines => _lines;
    public string npcname => _npcname;
}