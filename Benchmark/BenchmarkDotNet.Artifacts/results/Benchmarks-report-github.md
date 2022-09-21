``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2006/21H2/November2021Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2


```
|           Method |  Value |         Mean |       Error |    StdDev |       Median |
|----------------- |------- |-------------:|------------:|----------:|-------------:|
| **OffsetPagination** |     **20** |     **993.2 μs** |    **18.92 μs** |  **44.97 μs** |     **978.7 μs** |
| KeysetPagination |     20 |   1,013.3 μs |    20.04 μs |  49.53 μs |   1,005.2 μs |
| **OffsetPagination** | **900000** | **127,089.7 μs** | **1,127.25 μs** | **941.30 μs** | **127,174.7 μs** |
| KeysetPagination | 900000 |   1,006.2 μs |    19.24 μs |  55.51 μs |     986.4 μs |
