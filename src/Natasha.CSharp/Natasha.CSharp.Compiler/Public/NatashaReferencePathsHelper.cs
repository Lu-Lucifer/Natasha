﻿
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

public static class NatashaReferencePathsHelper
{
    public static IEnumerable<string>? GetReferenceFiles(Func<AssemblyName, string?, bool> excludeReferencesFunc)
    {


        IEnumerable<string>? paths = null;
        try
        {
            paths = DependencyContext.Default?
            .CompileLibraries.SelectMany(cl => cl.ResolveReferencePaths()).ToList();
        }
        catch
        {

        }

        if (paths == null || !paths.Any())
        {
            var refsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "refs");
            if (Directory.Exists(refsFolder))
            {
                paths = Directory.GetFiles(refsFolder);
            }

            refsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            if (Directory.Exists(refsFolder))
            {
                if (paths != null)
                {

                    var tempPaths = Directory.GetFiles(refsFolder);
                    if (tempPaths != null && tempPaths!.Length > 0)
                    {
                        paths = paths.Concat(tempPaths);
                    }

                }
                else
                {

                    paths = Directory.GetFiles(refsFolder);

                }
            }
        }
        return paths;

    }
}

