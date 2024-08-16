// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MareMare">
// Copyright © 2024 MareMare.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

// 実行例：
// dotnet run -- "**" "!bin/**" "!obj/**"
var matcher = new Matcher();

// コマンドライン引数を検索パターンと除外パターンに分ける
foreach (var arg in args)
{
    if (arg.StartsWith('!'))
    {
        // "!"で始まる引数は除外パターン
        if (arg.Length >= 1)
        {
            matcher.AddExclude(arg[1..]); // "!"を除いた部分を除外パターンとして追加
        }
    }
    else
    {
        // それ以外の引数は検索パターン
        matcher.AddInclude(arg);
    }
}

var directory = new DirectoryInfoWrapper(new DirectoryInfo(Directory.GetCurrentDirectory()));
var result = matcher.Execute(directory);
Console.WriteLine($"{string.Join(" ", args)} Matched Files:");
foreach (var file in result.Files)
{
    Console.WriteLine(file.Path);
}
