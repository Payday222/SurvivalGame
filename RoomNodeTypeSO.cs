using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RoomNodeType_", menuName = "Scriptable Objects/Dungeon/Room Node Type")]
public class RoomNodeTypeSO : ScriptableObject
{
public string roomNodeTypename;
public bool displayInNodeGraphEditor = true;

public bool Iscorridor;

public bool isCorridorNS;

public bool isCorridorEW;

public bool isEnteracne;

public bool isBossRoom;

public bool isNone;

#region Validation
#if UNITY_EDITOR
private void  OnValidate()
{
    HelperUtilities.ValidateCheckEmptyString(this, nameof(roomNodeTypename), roomNodeTypename);
}
#endif
#endregion Validation
}
