# Light-Novel-Reader
This is a Light Novel Reader&amp;Translator for Chinese readers who knows little about Japanese, or want to learn Japanese through reading Japanese light novels.  May support other languages in later versions.

##Important！
在clone本工程之后，需在nuget中卸载Microsoft.NETCore.UniversalWindowsPlatform 5.4.0，并重新安装。以避免出现无引用情况。
After you cloning this project, you may need to uninstall 
**Microsoft.NETCore.UniversalWindowsPlatform 5.4.0** from your 
**Project** by using the Nuget tools, and then re-install it.
Or the Visual Studio 2017 may not get the correct reference to the
.NetCore UWP Library, and there'll be no references to "System".
