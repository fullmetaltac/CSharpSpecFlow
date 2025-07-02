using System;
using DotNetEnv;


class EnviromentData
{
    static EnviromentData() => Env.Load();
    public static string EnvVar(string name) => Environment.GetEnvironmentVariable(name);
}