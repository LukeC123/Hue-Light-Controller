#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

^!]::
Run cmd.exe /c "C:\Users\Luke\source\repos\Hue Light Controller\Hue Light Controller\bin\Release\netcoreapp3.1\Hue Light Controller.exe" on,,hide
return

^![::
Run cmd.exe /c "C:\Users\Luke\source\repos\Hue Light Controller\Hue Light Controller\bin\Release\netcoreapp3.1\Hue Light Controller.exe" off,,hide
return

^!=::
Run cmd.exe /c "C:\Users\Luke\source\repos\Hue Light Controller\Hue Light Controller\bin\Release\netcoreapp3.1\Hue Light Controller.exe" increase 20,,hide
return

^!-::
Run cmd.exe /c "C:\Users\Luke\source\repos\Hue Light Controller\Hue Light Controller\bin\Release\netcoreapp3.1\Hue Light Controller.exe" decrease 20,,hide
return
