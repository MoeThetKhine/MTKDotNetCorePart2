﻿using MTKDotNetCorePart2.HttpClientConsoleApp;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();
