﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UnityPaths 
{


    private static string GoUpInPath(string currentPath)
    {
        int lastIndex = currentPath.LastIndexOf('/');
        if (lastIndex < 0)
            lastIndex = currentPath.LastIndexOf('\\');
        if (lastIndex < 0)
            return "";
        return currentPath.Substring(0, lastIndex);
    }
    internal static string[] GetAllParents(string path, bool addGivenPath)
    {
        List<string> result = new List<string>();
        if (addGivenPath)
            result.Add(path);
        bool hasFinish=false;
        do {
            path = GoUpInPath(path);
            hasFinish = path.Length <= 0;
            if (!hasFinish)
                result.Add(path);
        }
        while (!hasFinish);
        return result.ToArray();
    }

    internal static string[] Filter(string[] files, string[] notAuthorizedExtentsion)
    {
        List<string> authorizedPath = new List<string>();
        for (int i = 0; i < files.Length; i++)
        {
            for (int j = 0; j < notAuthorizedExtentsion.Length; j++)
            {
                if(files[i].EndsWith(notAuthorizedExtentsion[j]))
                   authorizedPath.Add(files[i]);
            }
        }
        return authorizedPath.ToArray();
    }

    public static string GetUnityAssetsPath()
    {
        return Directory.GetCurrentDirectory()+"/Assets";
    }
    public static string GetUnityRootPath()
    {
        return Directory.GetCurrentDirectory();
    }

    public static string ReplaceByBackslash(string path)
    {
        return path.Replace("\\", "/");
    }
    public static string ReplaceBySlash(string path)
    {
        return path.Replace("/","\\");
    }

    
}
