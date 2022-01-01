﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Runtime.Loader.AssemblyLoadContext;

public static class NatashaDomainExtension
{

    /// <summary>
    /// 锁定域的上下文
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public static ContextualReflectionScope CreateScope(this NatashaDomain domain)
    {
        return domain.EnterContextualReflection();
    }


    /// <summary>
    /// 创建一个以该字符串命名的域并锁定
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public static ContextualReflectionScope NatashaDomainScope(this string domain)
    {
        return DomainManagement.Create(domain).EnterContextualReflection();
    }


    /// <summary>
    /// 如果该插件某个依赖已经在主域中,则使用版本较高的那个.
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="path">插件路径</param>
    /// <param name="excludeAssembliesFunc">排除对应程序集名的依赖项</param>
    /// <returns></returns>
    public static Assembly LoadPluginWithHighDependency(this NatashaDomain domain,string path, Func<AssemblyName, bool>? excludeAssembliesFunc = null)
    {
        domain.LoadPluginBehavior = LoadBehaviorEnum.UseHighVersion;
        return domain.LoadPlugin(path, excludeAssembliesFunc);
    }


    /// <summary>
    /// 如果该插件某个依赖已经在主域中,则使用版本较低的那个.
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="path">插件路径</param>
    /// <param name="excludeAssembliesFunc">排除对应程序集名的依赖项</param>
    /// <returns></returns>
    public static Assembly LoadPluginWithLowDependency(this NatashaDomain domain, string path, Func<AssemblyName, bool>? excludeAssembliesFunc = null)
    {
        domain.LoadPluginBehavior = LoadBehaviorEnum.UseLowVersion;
        return domain.LoadPlugin(path, excludeAssembliesFunc);
    }


    /// <summary>
    /// 如果该插件某个依赖已经在主域中,则跳过该依赖项的加载.
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="path">插件路径</param>
    /// <param name="excludeAssembliesFunc">排除对应程序集名的依赖项</param>
    /// <returns></returns>
    public static Assembly LoadPluginSkipDefaultDependency(this NatashaDomain domain, string path, Func<AssemblyName, bool>? excludeAssembliesFunc = null)
    {
        domain.LoadPluginBehavior = LoadBehaviorEnum.UseBeforeIfExist;
        return domain.LoadPlugin(path, excludeAssembliesFunc);
    }


    /// <summary>
    /// 加载插件和其所有插件
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="path">插件路径</param>
    /// <param name="excludeAssembliesFunc">排除对应程序集名的依赖项</param>
    /// <returns></returns>
    public static Assembly LoadPluginWithNewDependency(this NatashaDomain domain, string path, Func<AssemblyName, bool>? excludeAssembliesFunc = null)
    {
        domain.LoadPluginBehavior = LoadBehaviorEnum.None;
        return domain.LoadPlugin(path, excludeAssembliesFunc);
    }
}

