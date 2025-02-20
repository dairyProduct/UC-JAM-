#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/*******************************************************************************
The content of this file includes portions of the proprietary AUDIOKINETIC Wwise
Technology released in source code form as part of the game integration package.
The content of this file may not be used without valid licenses to the
AUDIOKINETIC Wwise Technology.
Note that the use of the game engine is subject to the Unity(R) Terms of
Service at https://unity3d.com/legal/terms-of-service
 
License Usage
 
Licensees holding valid licenses to the AUDIOKINETIC Wwise Technology may use
this file in accordance with the end user license agreement provided with the
software or, alternatively, in accordance with the terms contained
in a written agreement between you and Audiokinetic Inc.
Copyright (c) 2025 Audiokinetic Inc.
*******************************************************************************/

public class AkObjectInfoArray : AkBaseArray<AkObjectInfo>
{
	public AkObjectInfoArray(int count) : base(count)
	{
	}

	protected override int StructureSize
	{
		get { return AkUnitySoundEnginePINVOKE.CSharp_AkObjectInfo_GetSizeOf(); }
	}

	protected override void DefaultConstructAtIntPtr(System.IntPtr address)
	{
		AkUnitySoundEnginePINVOKE.CSharp_AkObjectInfo_Clear(address);
	}

	protected override AkObjectInfo CreateNewReferenceFromIntPtr(System.IntPtr address)
	{
		return new AkObjectInfo(address, false);
	}

	protected override void CloneIntoReferenceFromIntPtr(System.IntPtr address, AkObjectInfo other)
	{
		AkUnitySoundEnginePINVOKE.CSharp_AkObjectInfo_Clone(address, AkObjectInfo.getCPtr(other));
	}
}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.