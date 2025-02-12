# Miscellaneous H3 Functions

These functions include descriptions of the H3 grid system.

## DegsToRads

```c#
double Api.DegsToRads(double degrees)
```

### DegsToRads Summary

Converts degrees to radians.

### DegsToRads Parameters

| Name | Type | Description |
|------|------|-------------|
|degrees|double|Degree to change to radians|

## RadsToDegs

```c#
double Api.RadsToDegs(double radians)
```

### RadsToDegs Summary

Converts radians to degrees.

### Parameters

| Name | Type | Description |
|------|------|-------------|
|radians|double|Radians to change to degrees|

## HexAreaKm2

```c#
double Api.HexAreaKm2(int r)
```

### HexAreaKm2 Summary

Average hexagon area in square kilometers at the given resolution.

### HexAreaKm2 Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution to find average of|

## HexAreaM2

```c#
double Api.HexAreaM2(int r)
```

### HexAreaM2 Summary

Average hexagon area in square meters at the given resolution.

### HexAreaM2 Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution to find average of|

## CellAreaKm2

```c#
double Api.CellAreaKm2(H3Index h)
```

### CellAreaKm2 Summary

Exact area of specific cell in square kilometers.

### CellAreaKm2 Parameters

| Name | Type | Description |
|------|------|-------------|
|h|H3Lib.H3Index|Cell to find area of|

## CellAreaM2

```c#
double Api.CellAreaM2(H3Index h)
```

### CellAreaM2 Summary

Exact area of specific cell in square meters.

### CellAreaM2 Parameters

| Name | Type | Description |
|------|------|-------------|
|h|H3Lib.H3Index|Cell to find area of|

## CellAreaRads2

```c#
double Api.CellAreaRads2(H3Index h)
```

### CellAreaRads2 Summary

Exact area of specific cell in square radians.

### CellAreaRads2 Parameters

| Name | Type | Description |
|------|------|-------------|
|h|H3Lib.H3Index|Cell to find area of|

## EdgeLengthKm

```c#
double Api.EdgeLengthKm(int r)
```

### EdgeLengthKm Summary

Average hexagon edge length in kilometers at the given resolution.

### EdgeLengthKm Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution|

## EdgeLengthM

```c#
double Api.EdgeLengthM(int r)
```

### EdgeLengthM Summary

Average hexagon edge length in meters at the given resolution.

### EdgeLengthM Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution|

## ExactEdgeLengthKm

```c#
double Api.ExactEdgeLengthKm(H3Index edge)
```

### ExactEdgeLengthKm Summary

Exact edge length of specific unidirectional edge in kilometers.

### ExactEdgeLengthKm Parameters

| Name | Type | Description |
|------|------|-------------|
|edge|H3Lib.H3Index|Unidirecitonal edge to measure|

## ExactEdgeLengthM

```c#
double Api.ExactEdgeLengthM(H3Index edge)
```

### ExactEdgeLengthM Summary

Exact edge length of specific unidirectional edge in meters.

### ExactEdgeLengthM Parameters

| Name | Type | Description |
|------|------|-------------|
|edge|H3Lib.H3Index|Unidirecitonal edge to measure|

## ExactEdgeLengthRads

```c#
double Api.ExactEdgeLengthRads(H3Index edge)
```

### ExactEdgeLengthRads Summary

Exact edge length of specific unidirectional edge in radians.

### ExactEdgeLengthRads Parameters

| Name | Type | Description |
|------|------|-------------|
|edge|H3Lib.H3Index|Unidirecitonal edge to measure|

## NumHexagons

```c#
long Api.NumHexagons(int r)
```

### NumHexagons Summary

Number of unique H3 indexes at the given resolution.

### NumHexagons Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution to count cells of|

## GetRes0Indexes

```c#
void Api.GetRes0Indexes(out List<H3Index> outCells)
```

### GetRes0Indexes Summary

All the resolution 0 H3 indexes. out must be an array of at least size res0IndexCount().

### GetRes0Indexes Parameters

| Name | Type | Description |
|------|------|-------------|
|outCells|**out** List&lt;H3Lib.H3Index&gt;|Cells of resolution 0|

## Res0IndexCount

```c#
int Api.Res0IndexCount()
```

### Res0IndexCount Summary

Number of resolution 0 H3 indexes.

## GetPentagonIndexes

```c#
void Api.GetPentagonIndexes(int r, out List<H3Index> outCells)
```

### GetPentagonIndexes Summary

All the pentagon H3 indexes at the specified resolution.

### GetPentagonIndexes Parameters

| Name | Type | Description |
|------|------|-------------|
|r|int|Resolution of pentagons|
|outCells|**out** List&lt;H3Lib.H3Index&gt;|List of pentagons|

## PentagonIndexCount

```c#
int Api.PentagonIndexCount()
```

### PentagonIndexCount Summary

Number of pentagon H3 indexes per resolution. This is always 12, but provided as a convenience.

## PointDistKm

```c#
double Api.PointDistKm(GeoCoord a, GeoCoord b)
```

### PointDistKm Summary

Gives the "great circle" or "haversine" distance between pairs of GeoCoord points (lat/lng pairs) in kilometers.

### PointDistKm Parameters

| Name | Type | Description |
|------|------|-------------|
|a|H3Lib.GeoCoord|Point A|
|b|H3Lib.GeoCoord|Point B|

## PointDistM

```c#
double Api.PointDistM(GeoCoord a, GeoCoord b)
```

### PointDistM Summary

Gives the "great circle" or "haversine" distance between pairs of GeoCoord points (lat/lng pairs) in meters.

### PointDistM Parameters

| Name | Type | Description |
|------|------|-------------|
|a|H3Lib.GeoCoord|Point A|
|b|H3Lib.GeoCoord|Point B|

## PointDistRads

```c#
double Api.PointDistRads(GeoCoord a, GeoCoord b)
```

### PointDistRads Summary

Gives the "great circle" or "haversine" distance between pairs of GeoCoord points (lat/lng pairs) in radians.

### PointDistRads Parameters

| Name | Type | Description |
|------|------|-------------|
|a|H3Lib.GeoCoord|Point A|
|b|H3Lib.GeoCoord|Point B|

<hr>

[Return to Uber API Table of Contents](Uber-Api.md)
