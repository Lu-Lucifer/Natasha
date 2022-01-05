﻿using Xunit;

namespace NatashaFunctionUT.Domain.Plugin
{
    [Trait("基础功能测试", "插件")]
    public class DNDVTest: PluginPrepare
    {
        [Fact(DisplayName = "[不同插件][同名不同版本依赖]测试")]
        public void Test()
        {
            var path1 = PathCombine1("DNDV1.dll");
            var path2 = PathCombine2("DNDV2.dll");

            var result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.None,false);
            Assert.Equal("InvalidCastException", result.r1);
            Assert.Equal("InvalidCastException", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.None);
            Assert.Equal("Json:12.0.0.0;Dapper:1.60.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("FileLoadException", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseHighVersion);
            Assert.Equal("Json:12.0.0.0;Dapper:1.60.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("FileLoadException", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseLowVersion);
            Assert.Equal("Json:9.0.0.0;Dapper:1.60.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("FileLoadException", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseDefault);
            Assert.Equal("Json:9.0.0.0;Dapper:1.60.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("FileLoadException", result.r2);
        }
    }
}
