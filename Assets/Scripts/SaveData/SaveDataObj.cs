using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class SaveDataObj
{
    [XmlElement("caught")]
    public bool caught;
    [XmlElement("animalName")]
    public string animalName;
}
