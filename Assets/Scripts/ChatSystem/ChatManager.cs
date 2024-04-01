using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{

    //===========References============
    [SerializeField] GameObject messagePrefab;
    [SerializeField] Transform messageParent;
    List<MessageData> messageDatas = new List<MessageData>();

    //=================================


    //==========Variables==============
    private MessageData currentMessageData;
    private int currentMessageIndex;


    //=================================

    void Awake()
    {
        // Load all MessageData assets from the "MessageData" folder within Resources
        MessageData[] loadedMessageDatas = Resources.LoadAll<MessageData>("MessageData");
        
        // Add the loaded MessageData assets to the messageDatas list
        messageDatas.AddRange(loadedMessageDatas);
    }

    void Start()
    {
        Debug.Log("messageDatas[0].ToString()" + messageDatas[0].name);
        SetCurrentChat(messageDatas[0].name,0);
        
    }

    public void ToNextMessage()
    {
        if (currentMessageData.messageContentList.Count > currentMessageIndex + 1)
        {
            SetCurrentChat("none", currentMessageIndex + 1);   

        }else
        {

        }


    }

    public void SetCurrentChat(string messageData, int index)
    {

        if (messageData != "none")
        {
            currentMessageData = FindMessageDataByName(messageData);
           
        }
        if(currentMessageData == null)
        {
            currentMessageData = messageDatas[0];
        }
        
        currentMessageIndex = index;
        InstantiateMessage();
    }

    public void InstantiateMessage()
    {
        
        var message = Instantiate(messagePrefab, new Vector3(0, 0, 0), Quaternion.identity, messageParent);
        string content = currentMessageData.messageContentList[currentMessageIndex];

        if (content != null)
        {
            message.GetComponent<Message>().currentText = content;
        }
    }

        // Function to find a MessageData by its name
    public MessageData FindMessageDataByName(string name)
    {
        // Use the Find method to search for the MessageData with the matching name
        MessageData foundMessageData = messageDatas.Find(messageData => messageData.name == name);
        
        // Return the found MessageData (or null if not found)
        return foundMessageData;
    }



}
