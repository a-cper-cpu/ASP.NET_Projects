IF NOT EXIST bin mkdir bin
%CORPATH%csc /t:library /out:bin\student1.dll /r:System.dll /r:System.Web.dll /r:System.Xml.dll /r:System.Data.dll /recurse:*.cs >readme.txt