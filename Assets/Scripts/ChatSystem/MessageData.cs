using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewMessageData", menuName = "Message Data", order = 1)]
public class MessageData : ScriptableObject
{
    public List<string> messageContentList = new List<string>();
}
