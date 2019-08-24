﻿using System;
using System.Collections.Concurrent;
using static System.Runtime.Loader.AssemblyLoadContext;

namespace Natasha
{

    public class AssemblyManagment
    {

        public static ConcurrentDictionary<string, WeakReference> Cache;
        static AssemblyManagment()
        {

            Cache = new ConcurrentDictionary<string, WeakReference>();

        }





        public static AssemblyDomain Create(string key)
        {

            return new AssemblyDomain(key);

        }



#if NETCOREAPP3_0
        public static ContextualReflectionScope Lock(string key)
        {

            if (Cache.ContainsKey(key))
            {
                return ((AssemblyDomain)(Cache[key].Target)).EnterContextualReflection();
            }
            return Default.EnterContextualReflection();

        }
        public static ContextualReflectionScope Lock(AssemblyDomain domain)
        {

            return domain.EnterContextualReflection();

        }
        public static ContextualReflectionScope CreateAndLock(string key)
        {

            return Lock(Create(key));

        }
#endif





        public static void Add(string key, AssemblyDomain domain)
        {

            if (Cache.ContainsKey(key))
            {

                ((AssemblyDomain)(Cache[key].Target)).Dispose();
                if (!Cache[key].IsAlive)
                {
                    Cache[key] = new WeakReference(domain);
                }

            }
            else
            {

                Cache[key] = new WeakReference(domain, trackResurrection: true);

            }

        }




        public static WeakReference Remove(string key)
        {

            if (Cache.ContainsKey(key))
            {
                Cache.TryRemove(key, out var result);
                return result;

            }

            throw new Exception($"Can't find key : {key}!");

        }




        public static bool IsDelete(string key)
        {

            if (Cache.ContainsKey(key))
            {
                return !Cache[key].IsAlive;
            }
            return true;

        }




        public static AssemblyDomain Get(string key)
        {

            if (Cache.ContainsKey(key))
            {
                return (AssemblyDomain)Cache[key].Target;
            }
            return null;

        }




        public static int Count(string key)
        {
            return ((AssemblyDomain)(Cache[key].Target)).Count;
        }

    }

}
