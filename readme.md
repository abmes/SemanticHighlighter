Semantic Highlighter
=========================
[![Build status](https://ci.appveyor.com/api/projects/status/ga0hpujttna3ot73?svg=true)](https://ci.appveyor.com/project/abmes/semantichighlighter)

This is a Visual Studio extension which adds the following Classification Types

| Classification Type |       Elements       |     Default Color     |
|:--------------------|:--------------------:|:---------------------:|
| Abmes Namespace     | C# Namespace         | R: 120, G: 10, B: 170 |
| Abmes Brace         | '**{**' and '**}**'  | Blue                  |
| Abmes Bracket       | '**[**' and '**]**'  | Red                   |
| Abmes Parenthesis   | '**(**' and '**)**'  | Red                   |
| Abmes Colon         | '**:**'              | Red                   |

The colors can be changed by going to Tools -> Options -> Fonts and Colors


Installation
------------
You can get the latest release from the Visual Studio Gallery. Go to Tools -> Extensions and Updates -> Online -> Visual Studio Gallery and search for Abmes SemanticHighlighter


Compatible Visual Studio Versions
---------------------------------
* Visual Studio 2017


Recommended Colors
------------------
- Operator = Red
- User Types - Interfaces = R: 0, G: 128, B: 255
- String = Green
- String - Verbatim = Green
- Comment = Gray
- XML Doc Comment = Silver
- Number = Navy
- Preprocessor Keyword = Olive
- HTML Razor Code Background = Automatic
- HTML Server-Side Script - Background = Automatic
- HTML Server-Side Script - Foreground = Purple


Other recommended colors
------------------------
The following colors are recommended for **"Breakpoint"**, **"Breakpoint - Mapped"** and **"Breakpoint - Advanced"**

Breakpoint (Disabled) - Foreground = R: 231, G: 190, B: 196

Breakpoint (Enabled) - Foreground = Automatic  
Breakpoint (Enabled) - Background = R: 231, G: 190, B: 196

Breakpoint (Error) - Foreground = Red  
Breakpoint (Error) - Background = R: 231, G: 190, B: 196

Breakpoint (Scroll Bar) - Background = R: 231, G: 190, B: 196

Breakpoint (Warning) - Foreground = Automatic  
Breakpoint (Warning) - Background = R: 231, G: 190, B: 196
