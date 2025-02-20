#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.3.0
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public enum AkCallbackType {
  AK_EndOfEvent = 1,
  AK_EndOfDynamicSequenceItem = 2,
  AK_Marker = 4,
  AK_Duration = 8,
  AK_SpeakerVolumeMatrix = 16,
  AK_Starvation = 32,
  AK_MusicPlaylistSelect = 64,
  AK_MusicPlayStarted = 128,
  AK_MusicSyncBeat = 256,
  AK_MusicSyncBar = 512,
  AK_MusicSyncEntry = 1024,
  AK_MusicSyncExit = 2048,
  AK_MusicSyncGrid = 4096,
  AK_MusicSyncUserCue = 8192,
  AK_MusicSyncPoint = 16384,
  AK_MIDIEvent = 32768,
  AK_Callback_Last = 65536,
  AK_MusicSyncAll = 32512,
  AK_CallbackBits = 65535,
  AK_EnableGetSourcePlayPosition = 1048576,
  AK_EnableGetMusicPlayPosition = 2097152,
  AK_EnableGetSourceStreamBuffering = 4194304,
  AK_SourceInfo_Last = 8388608,
  AK_Monitoring = 536870912,
  AK_Bank = 1073741824,
  AK_AudioInterruption = 570425344,
  AK_AudioSourceChange = 587202560
}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.