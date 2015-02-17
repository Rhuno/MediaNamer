# MediaNamer
A command line program to rename video files (tv episodes, specifically) to match xbmc naming conventions.

-----------
| SUMMARY |
-----------
MediaNamer is a command line based tool to assist in renaming video files to match the xbmc naming conventions.
It is specifically targeted at TV shows as those tend to be the most tedious to rename.
MediaNamer was built with C# .Net 4.5

--------------
| HOW TO USE |
--------------

-Open a command prompt in the directory containing the MediaNamer program (shift+right click > open command window here)
-Type: MediaNamer
-Add the required arguments as described below

MediaNamer expects the following 3 arguments:

1) Path to the directory containing the videos to rename (use quotes if the path contains spaces)
2) The show name (use quotes if the title includes spaces)
3) The show season (a number: 1, 2, etc)

EXAMPLE: MediaNamer "C:\My Shows\Home Improvement" "Home Improvement" 1

By default the program will rename files with the following extensions:

-.avi
-.mp4
-.mkv
-.wmv
-.mpeg
-.mpg
-.qt
-.mov

The program accepts a 4th, optional argument which is a comma-separated list of additional file types to rename

EXAMPLE: MediaNamer "C:\My Shows\Home Improvement" "Home Improvement" 1 ".ogg, .mp2"
