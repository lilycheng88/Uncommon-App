using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Student", menuName = "Student")]
public class StudentData : ScriptableObject
{

    public string _studentName;
    public string _studentDescription;

    public int _academic;
    public int _finance;


    public Sprite _studentImage;


}
