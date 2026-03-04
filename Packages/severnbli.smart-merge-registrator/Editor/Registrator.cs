using System;
using UnityEditor;
using UnityEngine;

namespace SmartMergeRegistrator.Editor
{
    [InitializeOnLoad]
    internal class Registrator
    {
        private const string SmartMergeRegistratorEditorPrefsKey = "smart_merge_installed";
        private const int Version = 1;
        private static readonly string VersionKey = $"{Version.ToString()}_{Application.unityVersion}";

        [MenuItem("Tools/Git/SmartMerge registration")]
        private static void SmartMergeRegister()
        {
            try
            {
                var unityYamlMergePath = EditorApplication.applicationContentsPath + "/Tools" + "/UnityYAMLMerge.exe";
                Utils.ExecuteGitWithParams("config merge.unityyamlmerge.name \"Unity SmartMerge (UnityYamlMerge)\"");
                Utils.ExecuteGitWithParams($"config merge.unityyamlmerge.driver \"\\\"{unityYamlMergePath}\\\" " +
                                     $"merge -h -p --force --fallback none %O %B %A %A\"");
                Utils.ExecuteGitWithParams("config merge.unityyamlmerge.recursive binary");
                EditorPrefs.SetString(SmartMergeRegistratorEditorPrefsKey, VersionKey);
                Debug.Log($"Successfully registered UnityYAMLMerge with path {unityYamlMergePath}");
            }
            catch (Exception e)
            {
                Debug.Log($"Fail to register UnityYAMLMerge with error: {e}");
            }
        }

        [MenuItem("Tools/Git/SmartMerge unregistration")]
        private static void SmartMergeUnRegister()
        {
            Utils.ExecuteGitWithParams("config --remove-section merge.unityyamlmerge");
            Debug.Log($"Successfully unregistered UnityYAMLMerge");
        }

        static Registrator()
        {
            var installedVersionKey = EditorPrefs.GetString(SmartMergeRegistratorEditorPrefsKey);
            if (installedVersionKey != VersionKey)
            {
                SmartMergeRegister();
            }
        }
    }
}