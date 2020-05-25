﻿using System;
using System.IO;
using UnityEditor;

public class UnityPathSelectionInfo
{
    public static void Get(out bool found, out UnityPathSelectionInfo info)
    {
        var obj = Selection.activeObject;
        found = obj != null;
        info = new UnityPathSelectionInfo();
        if (found)
        {
            info.Set(AssetDatabase.GetAssetPath(obj.GetInstanceID()));
        }
    }
     string m_absolutePath;
     string m_relativePath;

    public string GetFullPath() { return m_absolutePath; }
    public string GetFolderPath() { return Path.GetDirectoryName(m_absolutePath); }

    public void Set(string relativePath)
    {

        m_relativePath = relativePath;
        m_absolutePath = Directory.GetCurrentDirectory();
        m_absolutePath += "/" + relativePath;
    }
    public bool IsFile() { return File.Exists(m_absolutePath); }
    public bool IsFolder() { return Directory.Exists(m_absolutePath); }
    public UnityPathSelectionInfo()
    {
        Set("Assets");
    }
    public UnityPathSelectionInfo(string relativePath)
    {
        Set(relativePath);
    }

    public string GetRelativePath(bool getFolderOnly)
    {
        if (getFolderOnly && IsFile())
            return Path.GetDirectoryName(m_relativePath);
        return m_relativePath;
    }

    public string GetAbsolutePath(bool getFolderOnly)
    {
        if (getFolderOnly && IsFile())
           return  Path.GetDirectoryName(m_absolutePath);
        return m_absolutePath;
    }
}