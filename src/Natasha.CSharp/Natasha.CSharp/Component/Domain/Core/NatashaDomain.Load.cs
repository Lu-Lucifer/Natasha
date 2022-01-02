﻿using Natasha.CSharp.Component.Domain;
using Natasha.Domain.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

/// <summary>
/// Natasha域实现
/// C# 的引用代码是通过 Using 来完成的,该域实现增加了 Using 记录
/// </summary>
public partial class NatashaDomain : AssemblyLoadContext, IDisposable
{

    internal LoadBehaviorEnum _loadPluginBehavior;

    /// <summary>
    /// 依赖解析库
    /// </summary>
    private AssemblyDependencyResolver _dependencyResolver;
    /// <summary>
    /// Using 记录
    /// </summary>
    private readonly UsingRecoder _usingRecoder;


    /// <summary>
    /// 将文件转换为程序集，并加载到域
    /// </summary>
    /// <param name="path">外部文件</param>
    /// <returns></returns>
    public virtual Assembly LoadAssemblyFromFile(string path)
    {

#if DEBUG
        Debug.WriteLine($"[加载]路径:{path}.");
#endif
        Assembly assembly;
        if (Name == "Default")
        {
            assembly = Default.LoadFromAssemblyPath(path);
        }
        else
        {
            assembly = LoadFromAssemblyPath(path);
        }
        _referenceCache.AddReference(assembly.GetName(),path);
        _usingRecoder.Using(assembly);
        return assembly;

    }


    /// <summary>
    /// 将流转换为程序集，并加载到域
    /// [手动释放]
    /// </summary>
    /// <param name="stream">外部流</param>
    /// <returns></returns>
    public virtual Assembly LoadAssemblyFromStream(Stream stream)
    {
        using (stream)
        {

            Assembly assembly;
            if (Name == "Default")
            {
                assembly = Default.LoadFromStream(stream);
            }
            else
            {
                assembly = LoadFromStream(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            _referenceCache.AddReference(assembly.GetName(), stream);
            _usingRecoder.Using(assembly);
            return assembly;

        }
    }

    /// <summary>
    /// 对程序集上下文的重载函数，注：系统规定需要重载
    /// </summary>
    /// <param name="assemblyName">程序集名</param>
    /// <returns></returns>
    protected override Assembly? Load(AssemblyName assemblyName)
    {
#if DEBUG
        Debug.WriteLine($"[解析]程序集:{assemblyName.Name},全名:{assemblyName.FullName}");
#endif
        if (_loadPluginBehavior != LoadBehaviorEnum.None)
        {
            var name = assemblyName.GetUniqueName();
            if (!_defaultAssembliesCache.TryGetValue(name!, out var defaultCacheName))
            {
                if (DefaultDomain._pluginAssemblies.TryGetValue(name!, out var defaultCacheAssembly))
                {
                    defaultCacheName = defaultCacheAssembly!.GetName();
                }
            }
            if (defaultCacheName != default)
            {
                if (defaultCacheName.CompareWith(assemblyName, _loadPluginBehavior) == LoadVersionResultEnum.UseBefore)
                {
                    return null;
                }
            }
            //var asm = this.LoadFromAssemblyName(assemblyName);//死循环代码
        }
        var result = _excludeAssembliesFunc != null && _excludeAssembliesFunc(assemblyName);
        if (!result)
        {
            string? assemblyPath = _dependencyResolver!.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadAssemblyFromFile(assemblyPath);
            }
        }
        return null;

    }


    /// <summary>
    /// 对程序集上下文非托管插件的函数重载，注：系统规定需要重载
    /// </summary>
    /// <param name="unmanagedDllName">路径</param>
    /// <returns></returns>
    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        //var result = _excludeAssembliesFunc == null ? false : _excludeAssembliesFunc(unmanagedDllName);
        //if (!result)
        //{
            string? libraryPath = _dependencyResolver!.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }
       //}
        return IntPtr.Zero;

    }

}