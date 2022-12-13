родитель - Mvc.Core_New_Proj

if not add TS nuget package - you don't have way to control TS version to be used inside Visual Studio

to achive real-time typescript compilation - go to tsconfig.json folder and run tsc -watch

in future it sould be done via task runner explorer + cmd support (currently those are not supported by Visual Studio 2022)