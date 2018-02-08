# sl.xamarin.multilingual

[![NuGet](https://img.shields.io/nuget/v/sl.xamarin.multlingual.svg?label=NuGet)](https://www.nuget.org/packages/sl.xamarin.multlingual/)

Xamarin plugin to handle localization of language for cross platform applications.

## Supported platforms

- Android
- iOS
- UWP

## Setup

- Available on NuGet: [sl.xamarin.multilingual](https://www.nuget.org/packages/sl.xamarin.multlingual/)
- Dependency by dll: Download project and build by your own, or extract dll from NuGet package with [NuGetPackageExplorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer)

## Features

- Change of the language your application use which resx files
- Show default language of the device
- Show available languages

Based on the default libraries, provided by Xamarin for cross plattform applications.

## Getting started

1. Add "resx" files for the specific languages

	![](https://github.com/ThunderSL/sl.xamarin.multilingual/resources/images/ResxFiles.png)

	To provide different languages for your application, you will need different ressource files "resx". a default ressource file without language code and one each lananguage. The name for this files follows a specific naming convention, which using the file name and the specific language code.

2. Integrate "TranslateExtension.cs"

	To use this multilingual plugin also in your xaml code, you will need a extension, which load the text from your ressource file dynamicly

3. Set the culture of your application

4. Xamarin Forms Controls

	If you use native controls from the Xamarin Forms library you need to reimplemented them native with the specific renderer classes. Because they always take the language for this controls from the current cultur of the device.

	You can find a example for a custom renderer in the example application. This shows a picker.

## Demo

<div style="margin: 50" align="center">
	<img style="text-align:center" src="https://github.com/ThunderSL/sl.xamarin.multilingual/blob/master/resources/gifs/android.gif?raw=true" width="264" height="536"/>
</div>
